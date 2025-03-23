
namespace QLDSV.View
{
    partial class FormDiem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxHocKy = new System.Windows.Forms.ComboBox();
            this.comboBoxLopHoc = new System.Windows.Forms.ComboBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxKhoaHoc = new System.Windows.Forms.ComboBox();
            this.comboBoxNganhHoc = new System.Windows.Forms.ComboBox();
            this.ID_LopHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_MonHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_HinhThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_GiaoVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLopHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMonHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenHinhThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoBuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenGiaoVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhoaHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNganhHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenHocKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Controls.Add(this.comboBoxHocKy, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxLopHoc, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxKhoaHoc, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxNganhHoc, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(774, 532);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // comboBoxHocKy
            // 
            this.comboBoxHocKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxHocKy.FormattingEnabled = true;
            this.comboBoxHocKy.Location = new System.Drawing.Point(215, 104);
            this.comboBoxHocKy.Name = "comboBoxHocKy";
            this.comboBoxHocKy.Size = new System.Drawing.Size(168, 21);
            this.comboBoxHocKy.TabIndex = 2;
            this.comboBoxHocKy.SelectedIndexChanged += new System.EventHandler(this.comboBoxHocKy_SelectedIndexChanged);
            // 
            // comboBoxLopHoc
            // 
            this.comboBoxLopHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxLopHoc.FormattingEnabled = true;
            this.comboBoxLopHoc.Location = new System.Drawing.Point(563, 104);
            this.comboBoxLopHoc.Name = "comboBoxLopHoc";
            this.comboBoxLopHoc.Size = new System.Drawing.Size(168, 21);
            this.comboBoxLopHoc.TabIndex = 5;
            this.comboBoxLopHoc.SelectedIndexChanged += new System.EventHandler(this.comboBoxLopHoc_SelectedIndexChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_LopHoc,
            this.ID_MonHoc,
            this.ID_HinhThuc,
            this.ID_GiaoVien,
            this.TenLopHoc,
            this.TenMonHoc,
            this.TenHinhThuc,
            this.SoBuoi,
            this.TenGiaoVien,
            this.TenKhoaHoc,
            this.TenNganhHoc,
            this.TenHocKy,
            this.ID});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView, 4);
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(41, 131);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(690, 398);
            this.dataGridView.TabIndex = 11;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(41, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 27);
            this.label4.TabIndex = 12;
            this.label4.Text = "HocKy";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(389, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 27);
            this.label7.TabIndex = 15;
            this.label7.Text = "LopHoc";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 4);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(41, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(690, 47);
            this.label1.TabIndex = 8;
            this.label1.Text = "Điểm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(41, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 27);
            this.label3.TabIndex = 10;
            this.label3.Text = "KhoaHoc";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(41, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 27);
            this.label2.TabIndex = 9;
            this.label2.Text = "NganhHoc";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxKhoaHoc
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxKhoaHoc, 3);
            this.comboBoxKhoaHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxKhoaHoc.FormattingEnabled = true;
            this.comboBoxKhoaHoc.Location = new System.Drawing.Point(215, 50);
            this.comboBoxKhoaHoc.Name = "comboBoxKhoaHoc";
            this.comboBoxKhoaHoc.Size = new System.Drawing.Size(516, 21);
            this.comboBoxKhoaHoc.TabIndex = 0;
            this.comboBoxKhoaHoc.SelectedIndexChanged += new System.EventHandler(this.comboBoxKhoaHoc_SelectedIndexChanged);
            // 
            // comboBoxNganhHoc
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxNganhHoc, 3);
            this.comboBoxNganhHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxNganhHoc.FormattingEnabled = true;
            this.comboBoxNganhHoc.Location = new System.Drawing.Point(215, 77);
            this.comboBoxNganhHoc.Name = "comboBoxNganhHoc";
            this.comboBoxNganhHoc.Size = new System.Drawing.Size(516, 21);
            this.comboBoxNganhHoc.TabIndex = 1;
            this.comboBoxNganhHoc.SelectedIndexChanged += new System.EventHandler(this.comboBoxNganhHoc_SelectedIndexChanged);
            // 
            // ID_LopHoc
            // 
            this.ID_LopHoc.HeaderText = "ID_LopHoc";
            this.ID_LopHoc.Name = "ID_LopHoc";
            this.ID_LopHoc.ReadOnly = true;
            this.ID_LopHoc.Visible = false;
            // 
            // ID_MonHoc
            // 
            this.ID_MonHoc.HeaderText = "ID_MonHoc";
            this.ID_MonHoc.Name = "ID_MonHoc";
            this.ID_MonHoc.ReadOnly = true;
            this.ID_MonHoc.Visible = false;
            // 
            // ID_HinhThuc
            // 
            this.ID_HinhThuc.HeaderText = "ID_HinhThuc";
            this.ID_HinhThuc.Name = "ID_HinhThuc";
            this.ID_HinhThuc.ReadOnly = true;
            this.ID_HinhThuc.Visible = false;
            // 
            // ID_GiaoVien
            // 
            this.ID_GiaoVien.HeaderText = "ID_GiaoVien";
            this.ID_GiaoVien.Name = "ID_GiaoVien";
            this.ID_GiaoVien.ReadOnly = true;
            this.ID_GiaoVien.Visible = false;
            // 
            // TenLopHoc
            // 
            this.TenLopHoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TenLopHoc.HeaderText = "TenLopHoc";
            this.TenLopHoc.Name = "TenLopHoc";
            this.TenLopHoc.ReadOnly = true;
            this.TenLopHoc.Visible = false;
            this.TenLopHoc.Width = 89;
            // 
            // TenMonHoc
            // 
            this.TenMonHoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TenMonHoc.HeaderText = "TenMonHoc";
            this.TenMonHoc.Name = "TenMonHoc";
            this.TenMonHoc.ReadOnly = true;
            this.TenMonHoc.Width = 92;
            // 
            // TenHinhThuc
            // 
            this.TenHinhThuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TenHinhThuc.HeaderText = "TenHinhThuc";
            this.TenHinhThuc.Name = "TenHinhThuc";
            this.TenHinhThuc.ReadOnly = true;
            this.TenHinhThuc.Width = 98;
            // 
            // SoBuoi
            // 
            this.SoBuoi.HeaderText = "SoBuoi";
            this.SoBuoi.Name = "SoBuoi";
            this.SoBuoi.ReadOnly = true;
            // 
            // TenGiaoVien
            // 
            this.TenGiaoVien.HeaderText = "TenGiaoVien";
            this.TenGiaoVien.Name = "TenGiaoVien";
            this.TenGiaoVien.ReadOnly = true;
            // 
            // TenKhoaHoc
            // 
            this.TenKhoaHoc.HeaderText = "TenKhoaHoc";
            this.TenKhoaHoc.Name = "TenKhoaHoc";
            this.TenKhoaHoc.ReadOnly = true;
            this.TenKhoaHoc.Visible = false;
            // 
            // TenNganhHoc
            // 
            this.TenNganhHoc.HeaderText = "TenNganhHoc";
            this.TenNganhHoc.Name = "TenNganhHoc";
            this.TenNganhHoc.ReadOnly = true;
            this.TenNganhHoc.Visible = false;
            // 
            // TenHocKy
            // 
            this.TenHocKy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TenHocKy.HeaderText = "TenHocKy";
            this.TenHocKy.Name = "TenHocKy";
            this.TenHocKy.ReadOnly = true;
            this.TenHocKy.Visible = false;
            this.TenHocKy.Width = 83;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 43;
            // 
            // FormDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 532);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormDiem";
            this.Text = "FormDiem";
            this.Load += new System.EventHandler(this.FormDiem_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBoxKhoaHoc;
        private System.Windows.Forms.ComboBox comboBoxHocKy;
        private System.Windows.Forms.ComboBox comboBoxNganhHoc;
        private System.Windows.Forms.ComboBox comboBoxLopHoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_LopHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_MonHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_HinhThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_GiaoVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLopHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMonHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenHinhThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoBuoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenGiaoVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhoaHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNganhHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenHocKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}