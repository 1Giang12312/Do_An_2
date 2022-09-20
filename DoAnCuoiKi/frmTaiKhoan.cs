using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using System.Security.Cryptography;

namespace DoAnCuoiKi
{
    public partial class frmTaiKhoan : Form
    {
        public frmTaiKhoan()
        {
            InitializeComponent();
        }
        private void HienDsTKLenDgv()
        {
            List<TaiKhoan_DTO> lstNV = TaiKhoan_BUS.LayTaiKhoan();
            dgv.DataSource = lstNV;
            if (lstNV == null)
                return;
            dgv.Columns["SMaNhanVien"].HeaderText = "Mã nhân viên";
            dgv.Columns["SHoTen"].HeaderText = "Họ tên";
            dgv.Columns["STenDangNhap"].HeaderText = "Tên đăng nhập";
            dgv.Columns["SMatKhau"].Visible = false;
            
            dgv.Columns["IQuyenHan"].HeaderText = "Quyền";
            dgv.Columns["SGhiChu"].HeaderText = "Ghi chú";
            dgv.Enabled = true;
            txtTimKiem.ReadOnly = false;
            btnLuu.Enabled = false;
            btnTim.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            cboMaNhanVien.Enabled = false;
            txtHoVaTen.ReadOnly = true;
            dgv.Enabled = true;
            txtTenDangNhap.ReadOnly = true;
            txtMatKhau.ReadOnly = true;
        }
        private void HienMaNVLenCB()
        {
            List<NhanVien_DTO> lstMaSua = NhanVien_BUS.LayNhanVien();
            cboMaNhanVien.DataSource = lstMaSua;
            cboMaNhanVien.DisplayMember = "SMaNhanVien";
            cboMaNhanVien.ValueMember = "SMaNhanVien";
        }
        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            HienDsTKLenDgv();
            HienMaNVLenCB();
        }

        private void dgv_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dgv.SelectedRows[0];
            txtGhiChu.Text = r.Cells["sGhiChu"].Value.ToString();
            //txtHoVaTen.Text = r.Cells["sHoTen"].Value.ToString();
            txtMatKhau.Text = r.Cells["sMatKhau"].Value.ToString();
            txtTenDangNhap.Text = r.Cells["sTenDangNhap"].Value.ToString();
            cboMaNhanVien.SelectedValue = r.Cells["sMaNhanVien"].Value.ToString();
            if (int.Parse(r.Cells["iQuyenHan"].Value.ToString()) == 1)
                cboQuyen.Text = "admin";
            else
                cboQuyen.Text = "user";

        }
        private void resetValues()
        {
            txtGhiChu.Clear();
            txtHoVaTen.Clear();
            txtMatKhau.Clear();
            txtTenDangNhap.Clear();
            cboMaNhanVien.SelectedIndex = 0;
            cboQuyen.SelectedIndex = 0;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            resetValues();
            // chỉ hiện nhân viên chưa có tài khoản
            if(TaiKhoan_BUS.LayNhanVienCombobox()!=null)
            {
                List<NhanVien_DTO> lstMaSua = TaiKhoan_BUS.LayNhanVienCombobox();
                cboMaNhanVien.DataSource = lstMaSua;
                cboMaNhanVien.DisplayMember = "SMaNhanVien";
                cboMaNhanVien.ValueMember = "SMaNhanVien";
                cboMaNhanVien.Enabled = true;
                btnLuu.Enabled = true;
                txtTimKiem.ReadOnly = true;
                btnTim.Enabled = false;
                btnSua.Enabled = false;
                btnTim.Enabled = false;
                dgv.Enabled = false;
                txtTenDangNhap.ReadOnly = false;
                txtMatKhau.ReadOnly = false;
            }
            else
            {
                MessageBox.Show("Tất cả nhân viên đều đã có tài khoản");
                return;
            }
            
            
        }
        private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NhanVien_BUS.TimNhanVienTheoMa(cboMaNhanVien.Text)!=null)// == null là không có nhân viên phù hợp
            {
                //MessageBox.Show("asdfa");
                NhanVien_DTO nv = NhanVien_BUS.TimNhanVienTheoMa(cboMaNhanVien.Text);
                txtHoVaTen.Text=nv.STenNhanVien;
            }
            
        }
        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa tài khoản " + txtHoVaTen.Text, "Thông báo..", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                TaiKhoan_DTO tk = new TaiKhoan_DTO();
                tk.SMaNhanVien = cboMaNhanVien.Text;
                // Thực hiện xóa (xóa quá trình lương trước khi xóa nhân viên)
                if (TaiKhoan_BUS.XoaTaiKhoan(tk) == false)
                {
                    MessageBox.Show("Không xóa được.");
                    return;
                }
                frmTaiKhoan_Load(sender, e);
                MessageBox.Show("Đã xóa thành công.");
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (txtHoVaTen.Text.Trim() == "" ||
              txtMatKhau.Text.Trim() == "" ||
              txtTenDangNhap.Text.Trim() == "" ||
              cboMaNhanVien.Text.Trim() == "" ||
              cboQuyen.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            if (TaiKhoan_BUS.TimTaiKhoanTheoMa(cboMaNhanVien.Text,txtTenDangNhap.Text) == null)
            {
                MessageBox.Show("Mã tài khoản không tồn tại!");
                return;
            }
            TaiKhoan_DTO tk = new TaiKhoan_DTO();
            tk.SGhiChu = txtGhiChu.Text;
            tk.SHoTen = txtHoVaTen.Text;
            tk.SMaNhanVien = cboMaNhanVien.SelectedValue.ToString();
            if (cboQuyen.SelectedIndex == 0)
                tk.IQuyenHan = 0;
            else
                tk.IQuyenHan = 1;
            tk.STenDangNhap = txtTenDangNhap.Text;
            tk.SMatKhau = txtMatKhau.Text;
            if (TaiKhoan_BUS.CapNhatTaiKhoan(tk) == false)
            {
                MessageBox.Show("Cập nhật không được!.");
                return;
            }
            MessageBox.Show("Cập nhật thành công.");
            frmTaiKhoan_Load(sender, e);
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (txtHoVaTen.Text.Trim() == "" ||
                txtMatKhau.Text.Trim() == "" ||
                txtTenDangNhap.Text.Trim() == "" ||
                cboMaNhanVien.Text.Trim() == "" ||
                cboQuyen.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            if (TaiKhoan_BUS.TimTaiKhoanTheoMa(cboMaNhanVien.Text,txtTenDangNhap.Text) != null)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại");
                return;
            }
            if(NhanVien_BUS.TimNhanVienTheoMa(cboMaNhanVien.Text)==null)
            {
                MessageBox.Show("Mã nhân viên không hợp lệ!");
                cboMaNhanVien.SelectedIndex = 0;
                return;
            }
            TaiKhoan_DTO tk = new TaiKhoan_DTO();
            tk.SGhiChu = txtGhiChu.Text;
            tk.SHoTen = txtHoVaTen.Text;
            tk.SMaNhanVien = cboMaNhanVien.SelectedValue.ToString();
            if (cboQuyen.SelectedIndex == 0)
                tk.IQuyenHan = 0;
            else
                tk.IQuyenHan = 1;
            tk.STenDangNhap = txtTenDangNhap.Text;
            //mã hóa mật khẩu trước khi lưu
            MD5 hashmd5 = MD5.Create();
            string MatKhauMaHoa = TaiKhoan_BUS.GetMD5Hash(hashmd5,txtMatKhau.Text);
            tk.SMatKhau = MatKhauMaHoa;
            if (TaiKhoan_BUS.ThemTaiKhoan(tk) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            MessageBox.Show("Thêm thành công.");
            frmTaiKhoan_Load(sender, e);
        }
        //tìm theo tên nhân viên và theo tên đăng nhập
        private void btnTim_Click_1(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập nội dung tìm kiếm");
                return;
            }
            else
            {
                //tìm theo mã nv và tên nv
                List<TaiKhoan_DTO> kq = TaiKhoan_BUS.TimKiemTaiKhoan(txtTimKiem.Text);
                dgv.DataSource = kq;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            frmTaiKhoan_Load(sender, e);
        }
    }
}
