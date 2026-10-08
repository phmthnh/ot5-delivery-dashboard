using System.Globalization;

namespace DeliveryDashboard
{
    public partial class MainForm : Form
    {
        private bool _isUpdating;
        private Control? _editingControl;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            if (dgvItems.Rows.Count <= 1) SetupGrid();
            UpdateClock();
            _clockTimer.Start();
        }

        private void SetupGrid()
        {
            _isUpdating = true;
            try
            {
                // Giá và trọng lượng lưu bằng số, không dùng chuỗi đã định dạng.
                dgvItems.Rows.Add("Laptop Dell", 2, 4.5m, 18_000_000m);
                dgvItems.Rows.Add("Chuột không dây", 5, 0.3m, 350_000m);
            }
            finally { _isUpdating = false; }
            RecalcAll();
        }

        private void UpdateClock() => lblTime.Text = DateTime.Now.ToString("HH:mm:ss  dd/MM/yyyy");
        private void clockTimer_Tick(object? sender, EventArgs e) => UpdateClock();

        private static string CellText(DataGridViewCell cell)
        {
            return Convert.ToString(cell.Value, CultureInfo.CurrentCulture)?.Trim() ?? "";
        }

        private static bool ReadQuantity(string text, out int value)
        {
            return int.TryParse(text, NumberStyles.Integer, CultureInfo.CurrentCulture, out value) && value > 0;
        }

        private static bool ReadDecimal(string text, out decimal value)
        {
            return decimal.TryParse(text, NumberStyles.Number, CultureInfo.CurrentCulture, out value);
        }

        private void dgvItems_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !_isUpdating) RecalcAll();
        }

        private void dgvItems_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (_editingControl != null) _errorProvider.SetError(_editingControl, "");
            RecalcAll();
        }

        private void dgvItems_RowsAdded(object? sender, DataGridViewRowsAddedEventArgs e) => RecalcAll();
        private void dgvItems_RowsRemoved(object? sender, DataGridViewRowsRemovedEventArgs e) => RecalcAll();

        private void RecalcAll()
        {
            if (_isUpdating || dgvItems.Columns.Count < 5) return;
            _isUpdating = true;
            try
            {
                decimal totalQty = 0, totalWeight = 0, totalMoney = 0;
                var errors = new List<string>();
                foreach (DataGridViewRow row in dgvItems.Rows)
                {
                    if (row.IsNewRow) continue;
                    var quantityCell = row.Cells["colQty"];
                    var weightCell = row.Cells["colWeight"];
                    var priceCell = row.Cells["colPrice"];
                    bool validQty = ReadQuantity(CellText(quantityCell), out int qty);
                    bool validWeight = ReadDecimal(CellText(weightCell), out decimal weight) && weight > 0;
                    bool validPrice = ReadDecimal(CellText(priceCell), out decimal price) && price >= 0;
                    quantityCell.ErrorText = validQty ? "" : "Số lượng phải là số nguyên > 0.";
                    weightCell.ErrorText = validWeight ? "" : "Trọng lượng mỗi món phải là số > 0.";
                    priceCell.ErrorText = validPrice ? "" : "Đơn giá phải là số >= 0.";
                    row.Cells["colTotal"].ErrorText = "";
                    var rowErrors = new[] { quantityCell.ErrorText, weightCell.ErrorText, priceCell.ErrorText }
                        .Where(error => error.Length > 0).ToList();
                    if (rowErrors.Count == 0)
                    {
                        try
                        {
                            decimal lineMoney = qty * price;
                            decimal lineWeight = qty * weight;
                            // Tính tất cả trước khi cộng để tránh chỉ cộng một phần của dòng lỗi.
                            decimal nextQty = totalQty + qty;
                            decimal nextWeight = totalWeight + lineWeight;
                            decimal nextMoney = totalMoney + lineMoney;
                            row.Cells["colTotal"].Value = lineMoney;
                            totalQty = nextQty; totalWeight = nextWeight; totalMoney = nextMoney;
                        }
                        catch (OverflowException)
                        {
                            rowErrors.Add("Giá trị quá lớn để tính tổng.");
                            row.Cells["colTotal"].ErrorText = rowErrors[0];
                            row.Cells["colTotal"].Value = null;
                        }
                    }
                    else row.Cells["colTotal"].Value = null;
                    row.ErrorText = string.Join(" ", rowErrors);
                    if (rowErrors.Count > 0) errors.Add($"Dòng {row.Index + 1}: {row.ErrorText}");
                }
                // Cảnh báo vẫn tồn tại cho đến khi TẤT CẢ dòng sai được sửa hoặc xóa.
                _errorProvider.SetError(dgvItems, string.Join(Environment.NewLine, errors));
                lblTotalQty.Text = $"Tổng SL: {totalQty:N0}";
                lblTotalWeight.Text = $"Tổng KL: {totalWeight:N2} kg";
                lblTotalMoney.Text = $"Tổng tiền: {totalMoney:N0} VNĐ";
                lblValidation.Text = errors.Count == 0 ? "Dữ liệu hợp lệ." : $"Có {errors.Count} dòng lỗi; tổng chỉ gồm các dòng hợp lệ.";
                lblValidation.ForeColor = errors.Count == 0 ? Color.DarkGreen : Color.Firebrick;
            }
            finally { _isUpdating = false; }
        }

        private void dgvItems_EditingControlShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (_editingControl != null)
            {
                _editingControl.TextChanged -= EditingControl_TextChanged;
                _errorProvider.SetError(_editingControl, "");
            }
            _editingControl = e.Control;
            _editingControl.TextChanged += EditingControl_TextChanged;
            EditingControl_TextChanged(_editingControl, EventArgs.Empty);
        }

        private void EditingControl_TextChanged(object? sender, EventArgs e)
        {
            if (_editingControl == null || dgvItems.CurrentCell == null) return;
            string text = _editingControl.Text.Trim();
            string error = dgvItems.CurrentCell.OwningColumn?.Name switch
            {
                "colQty" => ReadQuantity(text, out _) ? "" : "Số lượng phải là số nguyên > 0.",
                "colWeight" => ReadDecimal(text, out var weight) && weight > 0 ? "" : "Trọng lượng mỗi món phải là số > 0.",
                "colPrice" => ReadDecimal(text, out var price) && price >= 0 ? "" : "Đơn giá phải là số >= 0.",
                _ => ""
            };
            _errorProvider.SetError(_editingControl, error);
        }

        private void dgvItems_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                dgvItems.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Dữ liệu không hợp lệ.";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F2)
            {
                tabDetails.SelectedTab = tabItems;
                dgvItems.EndEdit();
                int index = dgvItems.Rows.Add("", 1, 0.1m, 0m);
                dgvItems.CurrentCell = dgvItems.Rows[index].Cells["colItem"];
                dgvItems.Focus();
                dgvItems.BeginEdit(true);
                return true;
            }
            // Chỉ xóa dòng khi đang ở bảng; Delete trong ô khách hàng vẫn xóa ký tự.
            if (keyData == Keys.Delete && dgvItems.ContainsFocus && !dgvItems.IsCurrentCellInEditMode)
            {
                if (dgvItems.CurrentRow is { IsNewRow: false } row) dgvItems.Rows.Remove(row);
                RecalcAll();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
