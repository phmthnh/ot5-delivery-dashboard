namespace DeliveryDashboard
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.Timer _clockTimer = new();
        private readonly System.Windows.Forms.ErrorProvider _errorProvider = new();

        public MainForm()
        {
            InitializeComponent();
            SetupGrid();
            SetupTimer();
            _errorProvider.ContainerControl = this;
        }

        // Cài đặt DataGridView với dữ liệu mẫu
        private void SetupGrid()
        {
            dgvItems.Columns.Clear();
            dgvItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "colItem",   HeaderText = "Tên hàng",           Width = 180 });
            dgvItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "colQty",    HeaderText = "Số lượng",           Width = 90  });
            dgvItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "colWeight", HeaderText = "Trọng lượng (kg)",   Width = 120 });
            dgvItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPrice",  HeaderText = "Đơn giá (VNĐ)",     Width = 130 });
            dgvItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTotal",  HeaderText = "Thành tiền (VNĐ)",  Width = 140, ReadOnly = true });

            // Dữ liệu mẫu
            dgvItems.Rows.Add("Laptop Dell", "2", "4.5", "18000000");
            dgvItems.Rows.Add("Chuột không dây", "5", "0.3", "350000");
            RecalcAll();
        }

        // Timer đồng hồ hệ thống
        private void SetupTimer()
        {
            _clockTimer.Interval = 1000;
            _clockTimer.Tick += (s, e) => lblTime.Text = $"🕐 {DateTime.Now:HH:mm:ss  dd/MM/yyyy}";
            _clockTimer.Start();
        }

        // Tính lại toàn bộ khi cell thay đổi
        private void dgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            RecalcRow(e.RowIndex);
            RecalcAll();
        }

        private void dgvItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvItems.Rows[e.RowIndex];

            // Validate số lượng
            if (int.TryParse(row.Cells["colQty"].Value?.ToString(), out int qty) && qty <= 0)
                _errorProvider.SetError(dgvItems, $"Dòng {e.RowIndex + 1}: Số lượng phải > 0");
            else if (double.TryParse(row.Cells["colWeight"].Value?.ToString(), out double wt) && wt <= 0)
                _errorProvider.SetError(dgvItems, $"Dòng {e.RowIndex + 1}: Trọng lượng phải > 0");
            else
                _errorProvider.Clear();

            RecalcRow(e.RowIndex);
            RecalcAll();
        }

        private void RecalcRow(int rowIdx)
        {
            var row = dgvItems.Rows[rowIdx];
            if (row.IsNewRow) return;

            decimal.TryParse(row.Cells["colQty"].Value?.ToString(), out decimal qty);
            decimal.TryParse(row.Cells["colPrice"].Value?.ToString(), out decimal price);
            row.Cells["colTotal"].Value = (qty * price).ToString("N0");
        }

        private void RecalcAll()
        {
            decimal totalQty = 0, totalWeight = 0, totalMoney = 0;
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.IsNewRow) continue;
                decimal.TryParse(row.Cells["colQty"].Value?.ToString(), out decimal q);
                double.TryParse(row.Cells["colWeight"].Value?.ToString(), out double w);
                decimal.TryParse(row.Cells["colTotal"].Value?.ToString().Replace(",", ""), out decimal t);
                totalQty    += q;
                totalWeight += (decimal)w;
                totalMoney  += t;
            }
            lblTotalQty.Text    = $"Tổng SL: {totalQty}";
            lblTotalWeight.Text = $"Tổng KL: {totalWeight:N2} kg";
            lblTotalMoney.Text  = $"Tổng tiền: {totalMoney:N0} VNĐ";
        }

        // F2 = thêm dòng mới, Delete = xóa dòng đang chọn
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F2)
            {
                dgvItems.Rows.Add();
                dgvItems.CurrentCell = dgvItems.Rows[dgvItems.Rows.Count - 2].Cells[0];
                return true;
            }
            if (keyData == Keys.Delete && dgvItems.CurrentRow != null && !dgvItems.CurrentRow.IsNewRow)
            {
                dgvItems.Rows.Remove(dgvItems.CurrentRow);
                RecalcAll();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
