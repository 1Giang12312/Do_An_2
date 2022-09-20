
namespace DoAnCuoiKi
{
    partial class formMain
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
            this.pnMenu = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThongKe = new FontAwesome.Sharp.IconButton();
            this.pnHoaDon = new System.Windows.Forms.Panel();
            this.btnTimKiemHoaDon = new FontAwesome.Sharp.IconButton();
            this.btnNhapHoaDon = new FontAwesome.Sharp.IconButton();
            this.btnHoaDon = new FontAwesome.Sharp.IconButton();
            this.pnDanhMuc = new System.Windows.Forms.Panel();
            this.btnPhanLoai = new FontAwesome.Sharp.IconButton();
            this.btnHangHoa = new FontAwesome.Sharp.IconButton();
            this.btnLoaiSua = new FontAwesome.Sharp.IconButton();
            this.btnKhachHang = new FontAwesome.Sharp.IconButton();
            this.btnNhanVien = new FontAwesome.Sharp.IconButton();
            this.btnDanhMuc = new FontAwesome.Sharp.IconButton();
            this.pnTaiKhoan = new System.Windows.Forms.Panel();
            this.btnDoiMatKhau = new FontAwesome.Sharp.IconButton();
            this.btnQLTaiKhoan = new FontAwesome.Sharp.IconButton();
            this.btnThoat = new FontAwesome.Sharp.IconButton();
            this.btnDangXuat = new FontAwesome.Sharp.IconButton();
            this.btnDangNhap = new FontAwesome.Sharp.IconButton();
            this.btnDangXuat2 = new FontAwesome.Sharp.IconButton();
            this.btnTaiKhoan = new FontAwesome.Sharp.IconButton();
            this.pnLogo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnBar = new System.Windows.Forms.Panel();
            this.lbName = new System.Windows.Forms.Label();
            this.pnMain = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.pnMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnHoaDon.SuspendLayout();
            this.pnDanhMuc.SuspendLayout();
            this.pnTaiKhoan.SuspendLayout();
            this.pnLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMenu
            // 
            this.pnMenu.AutoScroll = true;
            this.pnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnMenu.Controls.Add(this.panel1);
            this.pnMenu.Controls.Add(this.pnHoaDon);
            this.pnMenu.Controls.Add(this.btnHoaDon);
            this.pnMenu.Controls.Add(this.pnDanhMuc);
            this.pnMenu.Controls.Add(this.btnDanhMuc);
            this.pnMenu.Controls.Add(this.pnTaiKhoan);
            this.pnMenu.Controls.Add(this.btnDangXuat2);
            this.pnMenu.Controls.Add(this.btnTaiKhoan);
            this.pnMenu.Controls.Add(this.pnLogo);
            this.pnMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnMenu.Location = new System.Drawing.Point(0, 0);
            this.pnMenu.Name = "pnMenu";
            this.pnMenu.Size = new System.Drawing.Size(201, 461);
            this.pnMenu.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnThongKe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 882);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 55);
            this.panel1.TabIndex = 13;
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThongKe.FlatAppearance.BorderSize = 0;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Arial", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnThongKe.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.btnThongKe.IconColor = System.Drawing.Color.White;
            this.btnThongKe.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThongKe.Location = new System.Drawing.Point(0, 0);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btnThongKe.Size = new System.Drawing.Size(184, 47);
            this.btnThongKe.TabIndex = 12;
            this.btnThongKe.Tag = "";
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // pnHoaDon
            // 
            this.pnHoaDon.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pnHoaDon.Controls.Add(this.btnTimKiemHoaDon);
            this.pnHoaDon.Controls.Add(this.btnNhapHoaDon);
            this.pnHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHoaDon.Location = new System.Drawing.Point(0, 785);
            this.pnHoaDon.Name = "pnHoaDon";
            this.pnHoaDon.Size = new System.Drawing.Size(184, 97);
            this.pnHoaDon.TabIndex = 12;
            // 
            // btnTimKiemHoaDon
            // 
            this.btnTimKiemHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTimKiemHoaDon.FlatAppearance.BorderSize = 0;
            this.btnTimKiemHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiemHoaDon.Font = new System.Drawing.Font("Arial", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemHoaDon.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnTimKiemHoaDon.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnTimKiemHoaDon.IconColor = System.Drawing.Color.White;
            this.btnTimKiemHoaDon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTimKiemHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiemHoaDon.Location = new System.Drawing.Point(0, 47);
            this.btnTimKiemHoaDon.Name = "btnTimKiemHoaDon";
            this.btnTimKiemHoaDon.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnTimKiemHoaDon.Size = new System.Drawing.Size(184, 47);
            this.btnTimKiemHoaDon.TabIndex = 11;
            this.btnTimKiemHoaDon.Tag = "";
            this.btnTimKiemHoaDon.Text = "Tìm kiếm hóa đơn";
            this.btnTimKiemHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiemHoaDon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTimKiemHoaDon.UseVisualStyleBackColor = true;
            this.btnTimKiemHoaDon.Click += new System.EventHandler(this.btnTimKiemHoaDon_Click);
            // 
            // btnNhapHoaDon
            // 
            this.btnNhapHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhapHoaDon.FlatAppearance.BorderSize = 0;
            this.btnNhapHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhapHoaDon.Font = new System.Drawing.Font("Arial", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapHoaDon.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNhapHoaDon.IconChar = FontAwesome.Sharp.IconChar.Desktop;
            this.btnNhapHoaDon.IconColor = System.Drawing.Color.White;
            this.btnNhapHoaDon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNhapHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapHoaDon.Location = new System.Drawing.Point(0, 0);
            this.btnNhapHoaDon.Name = "btnNhapHoaDon";
            this.btnNhapHoaDon.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnNhapHoaDon.Size = new System.Drawing.Size(184, 47);
            this.btnNhapHoaDon.TabIndex = 10;
            this.btnNhapHoaDon.Tag = "";
            this.btnNhapHoaDon.Text = "Nhập hóa đơn";
            this.btnNhapHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapHoaDon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNhapHoaDon.UseVisualStyleBackColor = true;
            this.btnNhapHoaDon.Click += new System.EventHandler(this.btnNhapHoaDon_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHoaDon.FlatAppearance.BorderSize = 0;
            this.btnHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoaDon.Font = new System.Drawing.Font("Arial", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoaDon.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnHoaDon.IconChar = FontAwesome.Sharp.IconChar.Book;
            this.btnHoaDon.IconColor = System.Drawing.Color.White;
            this.btnHoaDon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHoaDon.Location = new System.Drawing.Point(0, 738);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btnHoaDon.Size = new System.Drawing.Size(184, 47);
            this.btnHoaDon.TabIndex = 11;
            this.btnHoaDon.Tag = "";
            this.btnHoaDon.Text = "Hóa đơn";
            this.btnHoaDon.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnHoaDon.UseVisualStyleBackColor = false;
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // pnDanhMuc
            // 
            this.pnDanhMuc.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pnDanhMuc.Controls.Add(this.btnPhanLoai);
            this.pnDanhMuc.Controls.Add(this.btnHangHoa);
            this.pnDanhMuc.Controls.Add(this.btnLoaiSua);
            this.pnDanhMuc.Controls.Add(this.btnKhachHang);
            this.pnDanhMuc.Controls.Add(this.btnNhanVien);
            this.pnDanhMuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnDanhMuc.Location = new System.Drawing.Point(0, 453);
            this.pnDanhMuc.Name = "pnDanhMuc";
            this.pnDanhMuc.Size = new System.Drawing.Size(184, 285);
            this.pnDanhMuc.TabIndex = 10;
            // 
            // btnPhanLoai
            // 
            this.btnPhanLoai.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPhanLoai.FlatAppearance.BorderSize = 0;
            this.btnPhanLoai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhanLoai.Font = new System.Drawing.Font("Arial", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhanLoai.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPhanLoai.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.btnPhanLoai.IconColor = System.Drawing.Color.White;
            this.btnPhanLoai.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPhanLoai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPhanLoai.Location = new System.Drawing.Point(0, 212);
            this.btnPhanLoai.Name = "btnPhanLoai";
            this.btnPhanLoai.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnPhanLoai.Size = new System.Drawing.Size(184, 59);
            this.btnPhanLoai.TabIndex = 14;
            this.btnPhanLoai.Tag = "";
            this.btnPhanLoai.Text = "Phân loại";
            this.btnPhanLoai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPhanLoai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPhanLoai.UseVisualStyleBackColor = true;
            this.btnPhanLoai.Click += new System.EventHandler(this.btnPhanLoai_Click);
            // 
            // btnHangHoa
            // 
            this.btnHangHoa.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHangHoa.FlatAppearance.BorderSize = 0;
            this.btnHangHoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHangHoa.Font = new System.Drawing.Font("Arial", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHangHoa.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnHangHoa.IconChar = FontAwesome.Sharp.IconChar.Dropbox;
            this.btnHangHoa.IconColor = System.Drawing.Color.White;
            this.btnHangHoa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHangHoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHangHoa.Location = new System.Drawing.Point(0, 153);
            this.btnHangHoa.Name = "btnHangHoa";
            this.btnHangHoa.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnHangHoa.Size = new System.Drawing.Size(184, 59);
            this.btnHangHoa.TabIndex = 13;
            this.btnHangHoa.Tag = "";
            this.btnHangHoa.Text = "Hàng hóa";
            this.btnHangHoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHangHoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHangHoa.UseVisualStyleBackColor = true;
            this.btnHangHoa.Click += new System.EventHandler(this.btnHangHoa_Click);
            // 
            // btnLoaiSua
            // 
            this.btnLoaiSua.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoaiSua.FlatAppearance.BorderSize = 0;
            this.btnLoaiSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoaiSua.Font = new System.Drawing.Font("Arial", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoaiSua.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnLoaiSua.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.btnLoaiSua.IconColor = System.Drawing.Color.White;
            this.btnLoaiSua.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLoaiSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoaiSua.Location = new System.Drawing.Point(0, 94);
            this.btnLoaiSua.Name = "btnLoaiSua";
            this.btnLoaiSua.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnLoaiSua.Size = new System.Drawing.Size(184, 59);
            this.btnLoaiSua.TabIndex = 12;
            this.btnLoaiSua.Tag = "";
            this.btnLoaiSua.Text = "Loại sữa";
            this.btnLoaiSua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoaiSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoaiSua.UseVisualStyleBackColor = true;
            this.btnLoaiSua.Click += new System.EventHandler(this.btnLoaiSua_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhachHang.FlatAppearance.BorderSize = 0;
            this.btnKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhachHang.Font = new System.Drawing.Font("Arial", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhachHang.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnKhachHang.IconChar = FontAwesome.Sharp.IconChar.Child;
            this.btnKhachHang.IconColor = System.Drawing.Color.White;
            this.btnKhachHang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnKhachHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhachHang.Location = new System.Drawing.Point(0, 47);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnKhachHang.Size = new System.Drawing.Size(184, 47);
            this.btnKhachHang.TabIndex = 11;
            this.btnKhachHang.Tag = "";
            this.btnKhachHang.Text = "Khách hàng";
            this.btnKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhachHang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKhachHang.UseVisualStyleBackColor = true;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhanVien.FlatAppearance.BorderSize = 0;
            this.btnNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhanVien.Font = new System.Drawing.Font("Arial", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanVien.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNhanVien.IconChar = FontAwesome.Sharp.IconChar.Stamp;
            this.btnNhanVien.IconColor = System.Drawing.Color.White;
            this.btnNhanVien.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNhanVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhanVien.Location = new System.Drawing.Point(0, 0);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnNhanVien.Size = new System.Drawing.Size(184, 47);
            this.btnNhanVien.TabIndex = 10;
            this.btnNhanVien.Tag = "";
            this.btnNhanVien.Text = "Nhân viên";
            this.btnNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhanVien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnDanhMuc
            // 
            this.btnDanhMuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnDanhMuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDanhMuc.FlatAppearance.BorderSize = 0;
            this.btnDanhMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDanhMuc.Font = new System.Drawing.Font("Arial", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDanhMuc.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDanhMuc.IconChar = FontAwesome.Sharp.IconChar.Box;
            this.btnDanhMuc.IconColor = System.Drawing.Color.White;
            this.btnDanhMuc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDanhMuc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDanhMuc.Location = new System.Drawing.Point(0, 406);
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btnDanhMuc.Size = new System.Drawing.Size(184, 47);
            this.btnDanhMuc.TabIndex = 9;
            this.btnDanhMuc.Tag = "";
            this.btnDanhMuc.Text = "Danh mục";
            this.btnDanhMuc.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDanhMuc.UseVisualStyleBackColor = false;
            this.btnDanhMuc.Click += new System.EventHandler(this.btnDanhMuc_Click);
            // 
            // pnTaiKhoan
            // 
            this.pnTaiKhoan.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pnTaiKhoan.Controls.Add(this.iconButton1);
            this.pnTaiKhoan.Controls.Add(this.btnDoiMatKhau);
            this.pnTaiKhoan.Controls.Add(this.btnQLTaiKhoan);
            this.pnTaiKhoan.Controls.Add(this.btnThoat);
            this.pnTaiKhoan.Controls.Add(this.btnDangXuat);
            this.pnTaiKhoan.Controls.Add(this.btnDangNhap);
            this.pnTaiKhoan.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTaiKhoan.Location = new System.Drawing.Point(0, 118);
            this.pnTaiKhoan.Name = "pnTaiKhoan";
            this.pnTaiKhoan.Size = new System.Drawing.Size(184, 288);
            this.pnTaiKhoan.TabIndex = 8;
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDoiMatKhau.FlatAppearance.BorderSize = 0;
            this.btnDoiMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoiMatKhau.Font = new System.Drawing.Font("Arial", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoiMatKhau.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDoiMatKhau.IconChar = FontAwesome.Sharp.IconChar.Code;
            this.btnDoiMatKhau.IconColor = System.Drawing.Color.White;
            this.btnDoiMatKhau.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDoiMatKhau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoiMatKhau.Location = new System.Drawing.Point(0, 186);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnDoiMatKhau.Size = new System.Drawing.Size(184, 46);
            this.btnDoiMatKhau.TabIndex = 14;
            this.btnDoiMatKhau.Tag = "";
            this.btnDoiMatKhau.Text = "Đổi mật khẩu";
            this.btnDoiMatKhau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoiMatKhau.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDoiMatKhau.UseVisualStyleBackColor = true;
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // btnQLTaiKhoan
            // 
            this.btnQLTaiKhoan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQLTaiKhoan.FlatAppearance.BorderSize = 0;
            this.btnQLTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLTaiKhoan.Font = new System.Drawing.Font("Arial", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLTaiKhoan.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnQLTaiKhoan.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.btnQLTaiKhoan.IconColor = System.Drawing.Color.White;
            this.btnQLTaiKhoan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQLTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLTaiKhoan.Location = new System.Drawing.Point(0, 140);
            this.btnQLTaiKhoan.Name = "btnQLTaiKhoan";
            this.btnQLTaiKhoan.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnQLTaiKhoan.Size = new System.Drawing.Size(184, 46);
            this.btnQLTaiKhoan.TabIndex = 13;
            this.btnQLTaiKhoan.Tag = "";
            this.btnQLTaiKhoan.Text = "Bảng tài khoản";
            this.btnQLTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLTaiKhoan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQLTaiKhoan.UseVisualStyleBackColor = true;
            this.btnQLTaiKhoan.Click += new System.EventHandler(this.btnQLTaiKhoan_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Arial", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnThoat.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.btnThoat.IconColor = System.Drawing.Color.White;
            this.btnThoat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(0, 94);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnThoat.Size = new System.Drawing.Size(184, 46);
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Tag = "";
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Arial", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDangXuat.IconChar = FontAwesome.Sharp.IconChar.LockOpen;
            this.btnDangXuat.IconColor = System.Drawing.Color.White;
            this.btnDangXuat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDangXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.Location = new System.Drawing.Point(0, 47);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnDangXuat.Size = new System.Drawing.Size(184, 47);
            this.btnDangXuat.TabIndex = 11;
            this.btnDangXuat.Tag = "";
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDangNhap.FlatAppearance.BorderSize = 0;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.Font = new System.Drawing.Font("Arial", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDangNhap.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.btnDangNhap.IconColor = System.Drawing.Color.White;
            this.btnDangNhap.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDangNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangNhap.Location = new System.Drawing.Point(0, 0);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnDangNhap.Size = new System.Drawing.Size(184, 47);
            this.btnDangNhap.TabIndex = 10;
            this.btnDangNhap.Tag = "";
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangNhap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnDangXuat2
            // 
            this.btnDangXuat2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnDangXuat2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDangXuat2.FlatAppearance.BorderSize = 0;
            this.btnDangXuat2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat2.Font = new System.Drawing.Font("Arial", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDangXuat2.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.btnDangXuat2.IconColor = System.Drawing.Color.White;
            this.btnDangXuat2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDangXuat2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat2.Location = new System.Drawing.Point(0, 937);
            this.btnDangXuat2.Name = "btnDangXuat2";
            this.btnDangXuat2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 15);
            this.btnDangXuat2.Size = new System.Drawing.Size(184, 52);
            this.btnDangXuat2.TabIndex = 7;
            this.btnDangXuat2.Tag = "exit";
            this.btnDangXuat2.Text = "Đăng xuất";
            this.btnDangXuat2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDangXuat2.UseVisualStyleBackColor = false;
            this.btnDangXuat2.Click += new System.EventHandler(this.btnDangXuat2_Click);
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnTaiKhoan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTaiKhoan.FlatAppearance.BorderSize = 0;
            this.btnTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiKhoan.Font = new System.Drawing.Font("Arial", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiKhoan.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnTaiKhoan.IconChar = FontAwesome.Sharp.IconChar.User;
            this.btnTaiKhoan.IconColor = System.Drawing.Color.White;
            this.btnTaiKhoan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTaiKhoan.Location = new System.Drawing.Point(0, 65);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btnTaiKhoan.Size = new System.Drawing.Size(184, 53);
            this.btnTaiKhoan.TabIndex = 2;
            this.btnTaiKhoan.Tag = "";
            this.btnTaiKhoan.Text = "Tài khoản ";
            this.btnTaiKhoan.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnTaiKhoan.UseVisualStyleBackColor = false;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // pnLogo
            // 
            this.pnLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnLogo.Controls.Add(this.label1);
            this.pnLogo.Controls.Add(this.picLogo);
            this.pnLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLogo.Location = new System.Drawing.Point(0, 0);
            this.pnLogo.Name = "pnLogo";
            this.pnLogo.Size = new System.Drawing.Size(184, 65);
            this.pnLogo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(104, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sữa vui vẻ";
            // 
            // picLogo
            // 
            this.picLogo.Image = global::DoAnCuoiKi.Properties.Resources.nilk;
            this.picLogo.Location = new System.Drawing.Point(0, -11);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(96, 96);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // pnBar
            // 
            this.pnBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnBar.Controls.Add(this.lbName);
            this.pnBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnBar.Location = new System.Drawing.Point(201, 0);
            this.pnBar.Name = "pnBar";
            this.pnBar.Size = new System.Drawing.Size(863, 43);
            this.pnBar.TabIndex = 1;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.SystemColors.Control;
            this.lbName.Location = new System.Drawing.Point(6, 12);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(122, 16);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Chưa đăng nhập:";
            // 
            // pnMain
            // 
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(201, 43);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(863, 418);
            this.pnMain.TabIndex = 2;
            // 
            // iconButton1
            // 
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Arial", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Heart;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(0, 232);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.iconButton1.Size = new System.Drawing.Size(184, 46);
            this.iconButton1.TabIndex = 15;
            this.iconButton1.Tag = "";
            this.iconButton1.Text = "Hướng dẫn";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 461);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnBar);
            this.Controls.Add(this.pnMenu);
            this.IsMdiContainer = true;
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.formMain_Load);
            this.pnMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnHoaDon.ResumeLayout(false);
            this.pnDanhMuc.ResumeLayout(false);
            this.pnTaiKhoan.ResumeLayout(false);
            this.pnLogo.ResumeLayout(false);
            this.pnLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnBar.ResumeLayout(false);
            this.pnBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMenu;
        private System.Windows.Forms.Panel pnBar;
        private FontAwesome.Sharp.IconButton btnTaiKhoan;
        private System.Windows.Forms.Panel pnTaiKhoan;
        private FontAwesome.Sharp.IconButton btnDangXuat;
        private FontAwesome.Sharp.IconButton btnDangNhap;
        private FontAwesome.Sharp.IconButton btnThoat;
        private System.Windows.Forms.Panel pnDanhMuc;
        private FontAwesome.Sharp.IconButton btnLoaiSua;
        private FontAwesome.Sharp.IconButton btnKhachHang;
        private FontAwesome.Sharp.IconButton btnNhanVien;
        private FontAwesome.Sharp.IconButton btnDanhMuc;
        private System.Windows.Forms.Panel pnLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picLogo;
        private FontAwesome.Sharp.IconButton btnHangHoa;
        private System.Windows.Forms.Panel pnHoaDon;
        private FontAwesome.Sharp.IconButton btnTimKiemHoaDon;
        private FontAwesome.Sharp.IconButton btnNhapHoaDon;
        private FontAwesome.Sharp.IconButton btnHoaDon;
        private FontAwesome.Sharp.IconButton btnQLTaiKhoan;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Label lbName;
        private FontAwesome.Sharp.IconButton btnDoiMatKhau;
        private FontAwesome.Sharp.IconButton btnPhanLoai;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnThongKe;
        private FontAwesome.Sharp.IconButton btnDangXuat2;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}

