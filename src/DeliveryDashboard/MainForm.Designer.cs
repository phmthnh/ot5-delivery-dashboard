namespace DeliveryDashboard
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.splitMain       = new System.Windows.Forms.SplitContainer();
            this.grpCustomer     = new System.Windows.Forms.GroupBox();
            this.lblSender       = new System.Windows.Forms.Label();
            this.txtSender       = new System.Windows.Forms.TextBox();
            this.lblReceiver     = new System.Windows.Forms.Label();
            this.txtReceiver     = new System.Windows.Forms.TextBox();
            this.lblAddress      = new System.Windows.Forms.Label();
            this.txtAddress      = new System.Windows.Forms.TextBox();
            this.lblShipType     = new System.Windows.Forms.Label();
            this.cboShipType     = new System.Windows.Forms.ComboBox();
            this.lblHotkey       = new System.Windows.Forms.Label();
            this.grpItems        = new System.Windows.Forms.GroupBox();
            this.dgvItems        = new System.Windows.Forms.DataGridView();
            this.statusStrip     = new System.Windows.Forms.StatusStrip();
            this.lblTime         = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSep1         = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalQty     = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSep2         = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalWeight  = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSep3         = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalMoney   = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.grpCustomer.SuspendLayout();
            this.grpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            // splitMain
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            this.splitMain.SplitterDistance = 310;
            this.splitMain.TabIndex = 0;

            // Panel1 (trái) — thông tin khách hàng
            this.splitMain.Panel1.Controls.Add(this.grpCustomer);

            // Panel2 (phải) — bảng hàng hóa
            this.splitMain.Panel2.Controls.Add(this.grpItems);

            // grpCustomer
            this.grpCustomer.Controls.Add(this.lblSender);
            this.grpCustomer.Controls.Add(this.txtSender);
            this.grpCustomer.Controls.Add(this.lblReceiver);
            this.grpCustomer.Controls.Add(this.txtReceiver);
            this.grpCustomer.Controls.Add(this.lblAddress);
            this.grpCustomer.Controls.Add(this.txtAddress);
            this.grpCustomer.Controls.Add(this.lblShipType);
            this.grpCustomer.Controls.Add(this.cboShipType);
            this.grpCustomer.Controls.Add(this.lblHotkey);
            this.grpCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCustomer.Name = "grpCustomer";
            this.grpCustomer.TabIndex = 0;
            this.grpCustomer.TabStop = false;
            this.grpCustomer.Text = "Thông tin khách hàng & Vận chuyển";

            // lblSender
            this.lblSender.AutoSize = true;
            this.lblSender.Location = new System.Drawing.Point(12, 30);
            this.lblSender.Name = "lblSender";
            this.lblSender.TabIndex = 0;
            this.lblSender.Text = "Người gửi:";

            // txtSender
            this.txtSender.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.txtSender.Location = new System.Drawing.Point(120, 27);
            this.txtSender.Name = "txtSender";
            this.txtSender.Size = new System.Drawing.Size(170, 23);
            this.txtSender.TabIndex = 1;

            // lblReceiver
            this.lblReceiver.AutoSize = true;
            this.lblReceiver.Location = new System.Drawing.Point(12, 68);
            this.lblReceiver.Name = "lblReceiver";
            this.lblReceiver.TabIndex = 2;
            this.lblReceiver.Text = "Người nhận:";

            // txtReceiver
            this.txtReceiver.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.txtReceiver.Location = new System.Drawing.Point(120, 65);
            this.txtReceiver.Name = "txtReceiver";
            this.txtReceiver.Size = new System.Drawing.Size(170, 23);
            this.txtReceiver.TabIndex = 3;

            // lblAddress
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(12, 106);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.TabIndex = 4;
            this.lblAddress.Text = "Địa chỉ giao:";

            // txtAddress
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.txtAddress.Location = new System.Drawing.Point(120, 103);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(170, 55);
            this.txtAddress.TabIndex = 5;

            // lblShipType
            this.lblShipType.AutoSize = true;
            this.lblShipType.Location = new System.Drawing.Point(12, 175);
            this.lblShipType.Name = "lblShipType";
            this.lblShipType.TabIndex = 6;
            this.lblShipType.Text = "Loại vận chuyển:";

            // cboShipType
            this.cboShipType.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.cboShipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShipType.Items.AddRange(new object[] { "Giao hàng nhanh", "Giao hàng tiêu chuẩn", "Giao hàng tiết kiệm" });
            this.cboShipType.Location = new System.Drawing.Point(120, 172);
            this.cboShipType.Name = "cboShipType";
            this.cboShipType.Size = new System.Drawing.Size(170, 23);
            this.cboShipType.TabIndex = 7;
            this.cboShipType.SelectedIndex = 0;

            // lblHotkey
            this.lblHotkey.AutoSize = false;
            this.lblHotkey.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblHotkey.ForeColor = System.Drawing.Color.Gray;
            this.lblHotkey.Location = new System.Drawing.Point(12, 230);
            this.lblHotkey.Name = "lblHotkey";
            this.lblHotkey.Size = new System.Drawing.Size(280, 45);
            this.lblHotkey.TabIndex = 8;
            this.lblHotkey.Text = "💡 Phím tắt bảng hàng hóa:\n  F2 = Thêm dòng mới\n  Delete = Xóa dòng đang chọn";

            // grpItems
            this.grpItems.Controls.Add(this.dgvItems);
            this.grpItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpItems.Name = "grpItems";
            this.grpItems.TabIndex = 0;
            this.grpItems.TabStop = false;
            this.grpItems.Text = "Danh mục hàng hóa (F2: thêm dòng | Delete: xóa dòng)";

            // dgvItems
            this.dgvItems.AllowUserToAddRows = true;
            this.dgvItems.AutoGenerateColumns = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.TabIndex = 0;
            this.dgvItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellValueChanged);
            this.dgvItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellEndEdit);

            // statusStrip
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.lblTime, this.lblSep1, this.lblTotalQty,
                this.lblSep2, this.lblTotalWeight, this.lblSep3, this.lblTotalMoney });
            this.statusStrip.Location = new System.Drawing.Point(0, 528);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1000, 22);
            this.statusStrip.TabIndex = 1;

            this.lblTime.Name = "lblTime";
            this.lblTime.Text = "🕐 --:--:--";

            this.lblSep1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblSep1.Name = "lblSep1";
            this.lblSep1.Text = "";

            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Text = "Tổng SL: 0";

            this.lblSep2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblSep2.Name = "lblSep2";
            this.lblSep2.Text = "";

            this.lblTotalWeight.Name = "lblTotalWeight";
            this.lblTotalWeight.Text = "Tổng KL: 0 kg";

            this.lblSep3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblSep3.Name = "lblSep3";
            this.lblSep3.Text = "";

            this.lblTotalMoney.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalMoney.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotalMoney.Name = "lblTotalMoney";
            this.lblTotalMoney.Text = "Tổng tiền: 0 VNĐ";

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.statusStrip);
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BT5 - Bảng điều khiển Quản lý Đơn giao hàng";

            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            this.splitMain.ResumeLayout(false);
            this.grpCustomer.ResumeLayout(false);
            this.grpCustomer.PerformLayout();
            this.grpItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.GroupBox grpCustomer;
        private System.Windows.Forms.Label lblSender;
        private System.Windows.Forms.TextBox txtSender;
        private System.Windows.Forms.Label lblReceiver;
        private System.Windows.Forms.TextBox txtReceiver;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblShipType;
        private System.Windows.Forms.ComboBox cboShipType;
        private System.Windows.Forms.Label lblHotkey;
        private System.Windows.Forms.GroupBox grpItems;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblTime;
        private System.Windows.Forms.ToolStripStatusLabel lblSep1;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalQty;
        private System.Windows.Forms.ToolStripStatusLabel lblSep2;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalWeight;
        private System.Windows.Forms.ToolStripStatusLabel lblSep3;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalMoney;
    }
}
