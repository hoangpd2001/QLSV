
namespace QLDSV.View
{
    partial class FormLichDay
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
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxKhoaHoc = new System.Windows.Forms.ComboBox();
            this.comboBoxNganhHoc = new System.Windows.Forms.ComboBox();
            this.comboBoxHocKy = new System.Windows.Forms.ComboBox();
            this.comboBoxHinhThuc = new System.Windows.Forms.ComboBox();
            this.comboBoxMonHoc = new System.Windows.Forms.ComboBox();
            this.comboBoxLopHoc = new System.Windows.Forms.ComboBox();
            this.comboBoxGiaoVien = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ID_LopHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_MonHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_HinhThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_GIaoVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLopHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMonHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenHinhThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoBuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenGiaoVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhoaHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNganhHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenHocKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonThem = new System.Windows.Forms.Button();
            this.buttonSua = new System.Windows.Forms.Button();
            this.buttonXoa = new System.Windows.Forms.Button();
            this.buttonThoat = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(830, 438);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(44, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(740, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "LỊCH DẠY";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.81356F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.18644F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxKhoaHoc, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxNganhHoc, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxHocKy, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxHinhThuc, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxMonHoc, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxLopHoc, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxGiaoVien, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 6);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(44, 43);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel2, 3);
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.36842F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.63158F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(740, 217);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "Khoa Hoc";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nganh Hoc";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 30);
            this.label4.TabIndex = 2;
            this.label4.Text = "HocKy";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(207, 29);
            this.label5.TabIndex = 3;
            this.label5.Text = "Hình Thức";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 31);
            this.label6.TabIndex = 4;
            this.label6.Text = "Môn Học";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxKhoaHoc
            // 
            this.comboBoxKhoaHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxKhoaHoc.FormattingEnabled = true;
            this.comboBoxKhoaHoc.Location = new System.Drawing.Point(216, 3);
            this.comboBoxKhoaHoc.Name = "comboBoxKhoaHoc";
            this.comboBoxKhoaHoc.Size = new System.Drawing.Size(521, 21);
            this.comboBoxKhoaHoc.TabIndex = 5;
            this.comboBoxKhoaHoc.SelectedIndexChanged += new System.EventHandler(this.comboBoxKhoaHoc_SelectedIndexChanged);
            // 
            // comboBoxNganhHoc
            // 
            this.comboBoxNganhHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxNganhHoc.FormattingEnabled = true;
            this.comboBoxNganhHoc.Location = new System.Drawing.Point(216, 30);
            this.comboBoxNganhHoc.Name = "comboBoxNganhHoc";
            this.comboBoxNganhHoc.Size = new System.Drawing.Size(521, 21);
            this.comboBoxNganhHoc.TabIndex = 6;
            this.comboBoxNganhHoc.SelectedIndexChanged += new System.EventHandler(this.comboBoxNganhHoc_SelectedIndexChanged);
            // 
            // comboBoxHocKy
            // 
            this.comboBoxHocKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxHocKy.FormattingEnabled = true;
            this.comboBoxHocKy.Location = new System.Drawing.Point(216, 60);
            this.comboBoxHocKy.Name = "comboBoxHocKy";
            this.comboBoxHocKy.Size = new System.Drawing.Size(521, 21);
            this.comboBoxHocKy.TabIndex = 7;
            this.comboBoxHocKy.SelectedIndexChanged += new System.EventHandler(this.comboBoxHocKy_SelectedIndexChanged);
            // 
            // comboBoxHinhThuc
            // 
            this.comboBoxHinhThuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxHinhThuc.FormattingEnabled = true;
            this.comboBoxHinhThuc.Location = new System.Drawing.Point(216, 90);
            this.comboBoxHinhThuc.Name = "comboBoxHinhThuc";
            this.comboBoxHinhThuc.Size = new System.Drawing.Size(521, 21);
            this.comboBoxHinhThuc.TabIndex = 8;
            this.comboBoxHinhThuc.SelectedIndexChanged += new System.EventHandler(this.comboBoxHinhThuc_SelectedIndexChanged);
            // 
            // comboBoxMonHoc
            // 
            this.comboBoxMonHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxMonHoc.FormattingEnabled = true;
            this.comboBoxMonHoc.Location = new System.Drawing.Point(216, 119);
            this.comboBoxMonHoc.Name = "comboBoxMonHoc";
            this.comboBoxMonHoc.Size = new System.Drawing.Size(521, 21);
            this.comboBoxMonHoc.TabIndex = 9;
            this.comboBoxMonHoc.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonHoc_SelectedIndexChanged);
            // 
            // comboBoxLopHoc
            // 
            this.comboBoxLopHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxLopHoc.FormattingEnabled = true;
            this.comboBoxLopHoc.Location = new System.Drawing.Point(216, 150);
            this.comboBoxLopHoc.Name = "comboBoxLopHoc";
            this.comboBoxLopHoc.Size = new System.Drawing.Size(521, 21);
            this.comboBoxLopHoc.TabIndex = 10;
            this.comboBoxLopHoc.SelectedIndexChanged += new System.EventHandler(this.comboBoxLopHoc_SelectedIndexChanged);
            // 
            // comboBoxGiaoVien
            // 
            this.comboBoxGiaoVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxGiaoVien.FormattingEnabled = true;
            this.comboBoxGiaoVien.Location = new System.Drawing.Point(216, 186);
            this.comboBoxGiaoVien.Name = "comboBoxGiaoVien";
            this.comboBoxGiaoVien.Size = new System.Drawing.Size(521, 21);
            this.comboBoxGiaoVien.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(207, 36);
            this.label7.TabIndex = 12;
            this.label7.Text = "Lớp Học";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(207, 34);
            this.label8.TabIndex = 13;
            this.label8.Text = "Giáo Viên";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_LopHoc,
            this.ID_MonHoc,
            this.ID_HinhThuc,
            this.ID_GIaoVien,
            this.TenLopHoc,
            this.TenMonHoc,
            this.TenHinhThuc,
            this.SoBuoi,
            this.TenGiaoVien,
            this.TenKhoaHoc,
            this.TenNganhHoc,
            this.TenHocKy,
            this.ID});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView, 2);
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(44, 306);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(740, 129);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
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
            // ID_GIaoVien
            // 
            this.ID_GIaoVien.HeaderText = "ID_GiaoVien";
            this.ID_GIaoVien.Name = "ID_GIaoVien";
            this.ID_GIaoVien.ReadOnly = true;
            this.ID_GIaoVien.Visible = false;
            // 
            // TenLopHoc
            // 
            this.TenLopHoc.HeaderText = "TenLopHoc";
            this.TenLopHoc.Name = "TenLopHoc";
            this.TenLopHoc.ReadOnly = true;
            // 
            // TenMonHoc
            // 
            this.TenMonHoc.HeaderText = "TenMonHoc";
            this.TenMonHoc.Name = "TenMonHoc";
            this.TenMonHoc.ReadOnly = true;
            // 
            // TenHinhThuc
            // 
            this.TenHinhThuc.HeaderText = "TenHinhThuc";
            this.TenHinhThuc.Name = "TenHinhThuc";
            this.TenHinhThuc.ReadOnly = true;
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
            this.TenHocKy.HeaderText = "TenHocKy";
            this.TenHocKy.Name = "TenHocKy";
            this.TenHocKy.ReadOnly = true;
            this.TenHocKy.Visible = false;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.buttonReset, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonThem, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonSua, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonXoa, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonThoat, 4, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(44, 266);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(740, 34);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // buttonReset
            // 
            this.buttonReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonReset.Location = new System.Drawing.Point(3, 3);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(142, 28);
            this.buttonReset.TabIndex = 0;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonThem
            // 
            this.buttonThem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonThem.Location = new System.Drawing.Point(151, 3);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(142, 28);
            this.buttonThem.TabIndex = 1;
            this.buttonThem.Text = "Them";
            this.buttonThem.UseVisualStyleBackColor = true;
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // buttonSua
            // 
            this.buttonSua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSua.Location = new System.Drawing.Point(299, 3);
            this.buttonSua.Name = "buttonSua";
            this.buttonSua.Size = new System.Drawing.Size(142, 28);
            this.buttonSua.TabIndex = 2;
            this.buttonSua.Text = "Sua";
            this.buttonSua.UseVisualStyleBackColor = true;
            this.buttonSua.Click += new System.EventHandler(this.buttonSua_Click);
            // 
            // buttonXoa
            // 
            this.buttonXoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonXoa.Location = new System.Drawing.Point(447, 3);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(142, 28);
            this.buttonXoa.TabIndex = 3;
            this.buttonXoa.Text = "Xoa";
            this.buttonXoa.UseVisualStyleBackColor = true;
            this.buttonXoa.Click += new System.EventHandler(this.buttonXoa_Click);
            // 
            // buttonThoat
            // 
            this.buttonThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonThoat.Location = new System.Drawing.Point(595, 3);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(142, 28);
            this.buttonThoat.TabIndex = 4;
            this.buttonThoat.Text = "Thoat";
            this.buttonThoat.UseVisualStyleBackColor = true;
            // 
            // FormLichDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 438);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormLichDay";
            this.Text = "FormLichDay";
            this.Load += new System.EventHandler(this.FormLichDay_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxKhoaHoc;
        private System.Windows.Forms.ComboBox comboBoxNganhHoc;
        private System.Windows.Forms.ComboBox comboBoxHocKy;
        private System.Windows.Forms.ComboBox comboBoxHinhThuc;
        private System.Windows.Forms.ComboBox comboBoxMonHoc;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonThem;
        private System.Windows.Forms.Button buttonSua;
        private System.Windows.Forms.Button buttonXoa;
        private System.Windows.Forms.Button buttonThoat;
        private System.Windows.Forms.ComboBox comboBoxLopHoc;
        private System.Windows.Forms.ComboBox comboBoxGiaoVien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_LopHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_MonHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_HinhThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_GIaoVien;
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