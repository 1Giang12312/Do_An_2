using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
namespace DoAnCuoiKi
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
            MenuDropDown();
        }
        frmHangHoa fHH;
        frmKhachHang fKH;
        frmLoaiSua fLS;
        frmNhanVien fNV;
        frmTaiKhoan fTK;
        frmHoaDon fHD;
        frmDangNhap fDN;
        frmDoiMatKhau fDMK;
        frmHoaDonBan fHDB;
        frmPhanLoai fPL;
        frmThongKe fThK;
        public static TaiKhoan_DTO taikhoan;
        public bool bDangNhap = false; // tình trạng đăng nhập
        #region code dropDownmenu
        private void MenuDropDown()
        {
            pnTaiKhoan.Visible = false;
            pnDanhMuc.Visible = false;
            pnHoaDon.Visible = false;
        }
        private void HideMenuDropDown()
        {
            if(pnTaiKhoan.Visible == true)
                pnTaiKhoan.Visible = false;
            if(pnDanhMuc.Visible == true)
                pnDanhMuc.Visible = false;
            if (pnHoaDon.Visible == true)
                pnHoaDon.Visible = false;
        }
        private void ShowMenuDropDown(Panel subMenu)
        {
            if(subMenu.Visible == false )
            {
                //HideMenuDropDown();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        #endregion
        #region Tài khoản
        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            ShowMenuDropDown(pnTaiKhoan);
        }
        private void HienThiMenu()
        {
            btnDangNhap.Enabled = !bDangNhap;
            btnDangXuat.Enabled = bDangNhap;
            btnDangXuat2.Enabled = bDangNhap;
            if (bDangNhap == true)
            {
                string sQuyen;
                if (taikhoan.IQuyenHan == 1)
                    sQuyen = "Quản trị viên";
                else
                    sQuyen = "Nhân viên";
                int iQuyen;
                if (taikhoan == null)
                {
                    iQuyen = 0;
                }
                else
                {
                    iQuyen = int.Parse(taikhoan.IQuyenHan.ToString());
                }
                switch (iQuyen)
                {
                    
                    case 1:  // QuanTri

                        lbName.Text = "Chào " + taikhoan.SHoTen.ToString() + "      Bạn đã đăng nhập vào lúc " +DateTime.Now.ToString() +"      Bằng quyền  :  "+sQuyen;
                        btnQLTaiKhoan.Enabled = true;
                        btnNhanVien.Enabled = true;
                        btnKhachHang.Enabled = true;
                        btnLoaiSua.Enabled = true;
                        btnHangHoa.Enabled = true;
                        btnNhapHoaDon.Enabled = true;
                        btnDoiMatKhau.Enabled = true;
                        btnTimKiemHoaDon.Enabled = true;
                        btnPhanLoai.Enabled = true;
                        btnThongKe.Enabled = true;
                        break;
                    case 0: //NhanVien
                        lbName.Text = "Chào " + taikhoan.SHoTen.ToString() + "      Bạn đã đăng nhập vào lúc " + DateTime.Now.ToString() + "      Bằng quyền  :  " + sQuyen;
                        btnQLTaiKhoan.Enabled = false;
                        btnNhanVien.Enabled = false;
                        btnKhachHang.Enabled = true;
                        btnLoaiSua.Enabled = true;
                        btnHangHoa.Enabled = true;
                        btnNhapHoaDon.Enabled = true;
                        btnDoiMatKhau.Enabled = true;
                        btnTimKiemHoaDon.Enabled = false;
                        btnPhanLoai.Enabled = true;
                        btnThongKe.Enabled = false;
                        break;
                    default:
                        btnDangNhap.Enabled = true;
                        break;
                }
            }
            else
            {
                btnDangNhap.Enabled = true;
                btnDangXuat.Enabled = false;
                btnDangXuat2.Enabled = false;
                btnQLTaiKhoan.Enabled = false;
                btnNhanVien.Enabled = false;
                btnKhachHang.Enabled = false;
                btnLoaiSua.Enabled = false;
                btnHangHoa.Enabled = false;
                btnNhapHoaDon.Enabled = false;
                btnDoiMatKhau.Enabled = false;
                btnTimKiemHoaDon.Enabled = false;
                btnPhanLoai.Enabled = false;
                btnThongKe.Enabled = false;
                lbName.Text = "Chưa đăng nhập.";
            }
        }
        private void DangNhap()
        {
            if (fDN.ShowDialog() == DialogResult.OK)
            {
                if (fDN.txtTenDangNhap.Text.Trim() == "")
                {
                    MessageBox.Show("Chưa nhập tài khoản!");
                    fDN.txtTenDangNhap.Focus();
                    return;
                }
                if (fDN.txtMatKhau.Text.Trim() == "")
                {
                    MessageBox.Show("Chưa nhập mật khẩu!");
                    fDN.txtMatKhau.Focus();
                    return;
                }
                string sTenDangNhap = fDN.txtTenDangNhap.Text;
                string sMatKhau = fDN.txtMatKhau.Text;
                taikhoan = new TaiKhoan_DTO();
                taikhoan = TaiKhoan_BUS.KiemTraTaiKhoan(sTenDangNhap, sMatKhau);
                if (taikhoan != null)
                {
                    bDangNhap = true;
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!");
                    bDangNhap = false;
                }
            }
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            fDN = new frmDangNhap();
            if (fDN == null || fDN.IsDisposed)
            {
                fDN = new frmDangNhap();
                fDN.MdiParent = this;
                fDN.Show();
                fDN.Dock = DockStyle.Fill;
                pnMain.SendToBack();
            }
            fDN.BringToFront();
            DangNhap();
            HienThiMenu();
            HideMenuDropDown();
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            bDangNhap = false;
            HienThiMenu();
            foreach (Form child in MdiChildren)
                child.Close();
            HideMenuDropDown();
        }
        private void btnQLTaiKhoan_Click(object sender, EventArgs e)
        {
            if (fTK == null || fTK.IsDisposed)
            {
                fTK = new frmTaiKhoan();
                fTK.MdiParent = this;
                fTK.Show();
                fTK.Dock=DockStyle.Fill ;
                pnMain.SendToBack();
            }
            fTK.BringToFront();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq;
            kq = MessageBox.Show("Bạn có muốn đóng chương trình không??", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                Application.Exit();
            }
            HideMenuDropDown();
        }
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (fDMK == null || fDMK.IsDisposed)
            {
                fDMK = new frmDoiMatKhau();
                fDMK.MdiParent = this;
                fDMK.Show();
                fDMK.Dock = DockStyle.Fill;
                pnMain.SendToBack();
            }
            fDMK.BringToFront();
        }
        #endregion
        #region Danh mục
        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            ShowMenuDropDown(pnDanhMuc);
        }
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            if (fNV == null || fNV.IsDisposed)
            {
                fNV = new frmNhanVien();
                fNV.MdiParent = this;
                fNV.Show();
                fNV.Dock = DockStyle.Fill;
                pnMain.SendToBack();
            }
            fNV.BringToFront();
        }
        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            if (fKH == null || fKH.IsDisposed)
            {
                fKH = new frmKhachHang();
                fKH.MdiParent = this;
                fKH.Show();
                fKH.Dock = DockStyle.Fill;
                pnMain.SendToBack();
            }
            fKH.BringToFront();
        }

        private void btnLoaiSua_Click(object sender, EventArgs e)
        {
            if (fLS == null || fLS.IsDisposed)
            {
                fLS = new frmLoaiSua();
                fLS.MdiParent = this;
                fLS.Show();
                fLS.Dock = DockStyle.Fill;
                pnMain.SendToBack();
            }
            fLS.BringToFront();
        }

        private void btnHangHoa_Click(object sender, EventArgs e)
        {
            if (fHH == null || fHH.IsDisposed)
            {
                fHH = new frmHangHoa();
                fHH.MdiParent = this;
                fHH.Show();
                fHH.Dock = DockStyle.Fill;
                pnMain.SendToBack();
            }
            fHH.BringToFront();
        }
        #endregion
        #region Hóa đơn
        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            ShowMenuDropDown(pnHoaDon);
        }

        private void btnNhapHoaDon_Click(object sender, EventArgs e)
        {

            if (fHD == null || fHD.IsDisposed)
            {
                fHD = new frmHoaDon();
                fHD.MdiParent = this;
                fHD.Show();
                fHD.Dock = DockStyle.Fill;
                pnMain.SendToBack();
            }
            fHD.BringToFront();
        }

        private void btnTimKiemHoaDon_Click(object sender, EventArgs e)
        {
            if (fHDB == null || fHDB.IsDisposed)
            {
                fHDB = new frmHoaDonBan();
                fHDB.MdiParent = this;
                fHDB.Show();
                fHDB.Dock = DockStyle.Fill;
                pnMain.SendToBack();
            }
            fHDB.BringToFront();
        }
        #endregion
        private void formMain_Load(object sender, EventArgs e)
        {
            HienThiMenu();
            fDN = new frmDangNhap();
            DangNhap();
            HienThiMenu();
            if (HangHoa_BUS.KiemTraHanSuDung() == false)
            {
                MessageBox.Show("Kiểm tra hạn sử dụng lỗi!");
            }
        }
        private void btnDangXuat2_Click(object sender, EventArgs e)
        {
            bDangNhap = false;
            foreach (Form child in MdiChildren)
                child.Close();
            HienThiMenu();
            HideMenuDropDown();
            //formMain_Load(sender, e);
        }

        private void btnPhanLoai_Click(object sender, EventArgs e)
        {
            if (fPL == null || fPL.IsDisposed)
            {
                fPL = new frmPhanLoai();
                fPL.MdiParent = this;
                fPL.Show();
                fPL.Dock = DockStyle.Fill;
                pnMain.SendToBack();
            }
            fPL.BringToFront();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (fThK == null || fThK.IsDisposed)
            {
                fThK = new frmThongKe();
                fThK.MdiParent = this;
                fThK.Show();
                fThK.Dock = DockStyle.Fill;
                pnMain.SendToBack();
            }
            fThK.BringToFront();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "HSD.chm");
        }
    }
}