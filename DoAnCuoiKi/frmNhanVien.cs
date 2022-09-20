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
using System.Text.RegularExpressions;

namespace DoAnCuoiKi
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        private void HienDsNVLenDgv()
        {
            List<NhanVien_DTO> lstNV = NhanVien_BUS.LayNhanVien();
            dgv.DataSource = lstNV;
            if (lstNV == null)
                return;
            dgv.Columns["SMaNhanVien"].HeaderText = "Mã nhân viên";
            dgv.Columns["STenNhanVien"].HeaderText = "Tên nhân viên";
            dgv.Columns["SGioiTinh"].HeaderText = "Giới Tính";
            dgv.Columns["SDiaChi"].HeaderText = "Địa chỉ";
            dgv.Columns["SDienThoai"].HeaderText = "Số điện thoại";
            dgv.Columns["SEmail"].HeaderText = "Email";
            dgv.Columns["DtNgaySinh"].HeaderText = "Ngày sinh";

            txtMaNV.ReadOnly = true;
            dgv.Enabled = true;
            txtTimKiem.ReadOnly = false;
            btnLuu.Enabled = false;
            btnTim.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            HienDsNVLenDgv();
        }
        private void dgv_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dgv.SelectedRows[0];
            txtMaNV.Text = r.Cells["sMaNhanVien"].Value.ToString();
            txtHoTen.Text = r.Cells["sTenNhanVien"].Value.ToString();
            if (r.Cells["sGioiTinh"].Value.ToString() == "Nam")
            {
                ckbGioiTinh.Checked = true;
            }
            else
                ckbGioiTinh.Checked = false;
            txtDiaChi.Text = r.Cells["sDiaChi"].Value.ToString();
            txtDienThoai.Text = r.Cells["sDienThoai"].Value.ToString();
            txtEmail.Text = r.Cells["sEmail"].Value.ToString();
            dtpNgaySinh.Text = r.Cells["dtNgaySinh"].Value.ToString();
        }
        private void resetValues()
        {
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            txtEmail.Clear();
            txtHoTen.Clear();
            txtMaNV.Clear();
            dtpNgaySinh.Text = DateTime.Now.ToString();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            resetValues();
            txtMaNV.ReadOnly = false;
            btnLuu.Enabled = true;
            txtTimKiem.ReadOnly = true;
            btnTim.Enabled = false;
            btnSua.Enabled = false;
            btnTim.Enabled = false;
        }
        // hàm kiểm tra có phải số hay không
        private bool IsNumber(string pText)
        {
            Regex regex = null;
            try
            {
                regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$"); return regex.IsMatch(pText);
            }
            catch (Exception ex)
            {
                return regex.IsMatch(pText);
            }
        }
        //hàm kiểm tra có phải email theo định dạng abc@gmail.com không
        public static bool isEmail(string inputEmail)
        {
            inputEmail = inputEmail ?? string.Empty;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() == "" ||
                txtDiaChi.Text.Trim() == "" ||
                txtDienThoai.Text.Trim() == "" ||
                txtEmail.Text.Trim() == "" ||
                txtHoTen.Text.Trim() == "" ||
                dtpNgaySinh.Text.Trim() == ""
                )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            if (txtMaNV.Text.Length > 10)
            {
                MessageBox.Show("Mã nhân viên chỉ tối đa 10 kí tự!");
                return;
            }
            if(txtDienThoai.Text.Length<10 || txtDienThoai.Text.Length > 10 || IsNumber(txtDienThoai.Text)==false)
            {
                MessageBox.Show("Số điện thoại phải là số và có 10 số!");
                return;
            }
            if(isEmail(txtEmail.Text)==false)
            {
                MessageBox.Show("Email chưa đúng định dạng(abc@gmail.com)!");
                return;
            }
            if (NhanVien_BUS.TimNhanVienTheoMa(txtMaNV.Text) != null)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.SMaNhanVien = txtMaNV.Text;
            nv.STenNhanVien = txtHoTen.Text;
            if (ckbGioiTinh.Checked == true)
                nv.SGioiTinh = "Nam";
            else
                nv.SGioiTinh = "Nữ";
            nv.SDiaChi = txtDiaChi.Text;
            nv.SDienThoai = txtDienThoai.Text;
            nv.SEmail = txtEmail.Text;
            nv.DtNgaySinh =DateTime.Parse(dtpNgaySinh.Text);
            
            if (NhanVien_BUS.ThemNhanVien(nv) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            MessageBox.Show("Thêm thành công.");
            HienDsNVLenDgv();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (NhanVien_BUS.TimNhanVienTheoMa(txtMaNV.Text) == null)
            {
                MessageBox.Show("Mã nhân viên không tồn tại!");
                return;
            }
            if (MessageBox.Show("Xóa nhân viên " + txtHoTen.Text, "Thông báo..", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                NhanVien_DTO nv = new NhanVien_DTO();
                nv.SMaNhanVien = txtMaNV.Text;

                // Thực hiện xóa (xóa quá trình lương trước khi xóa nhân viên)
                if (NhanVien_BUS.XoaNhanVien(nv) == false)
                {
                    MessageBox.Show("Không xóa được.");
                    return;
                }
                HienDsNVLenDgv();
                MessageBox.Show("Đã xóa thành công.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() == "" ||
                txtDiaChi.Text.Trim() == "" ||
                txtDienThoai.Text.Trim() == "" ||
                txtEmail.Text.Trim() == "" ||
                txtHoTen.Text.Trim() == "" ||
                dtpNgaySinh.Text.Trim() == ""
                )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            if (txtMaNV.Text.Length > 10)
            {
                MessageBox.Show("Mã nhân viên chỉ tối đa 10 kí tự!");
                return;
            }
            if (txtDienThoai.Text.Length < 10 || txtDienThoai.Text.Length > 10 || IsNumber(txtDienThoai.Text) == false)
            {
                MessageBox.Show("Số điện thoại phải là số và có 10 số!");
                return;
            }
            if (isEmail(txtEmail.Text) == false)
            {
                MessageBox.Show("Email chưa đúng định dạng(abc@gmail.com)!");
                return;
            }
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.SMaNhanVien = txtMaNV.Text;
            nv.STenNhanVien = txtHoTen.Text;
            if (ckbGioiTinh.Checked == true)
                nv.SGioiTinh = "Nam";
            else
                nv.SGioiTinh = "Nữ";
            nv.SDiaChi = txtDiaChi.Text;
            nv.SDienThoai = txtDienThoai.Text;
            nv.SEmail = txtEmail.Text;
            nv.DtNgaySinh = DateTime.Parse(dtpNgaySinh.Text);
            if (NhanVien_BUS.CapNhatNhanVien(nv) == false)
            {
                MessageBox.Show("Không cập nhật được.");
                return;
            }
            HienDsNVLenDgv();
            MessageBox.Show("Đã cập nhật nhân viên thành công!.");
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập nội dung tìm kiếm");
                return;
            }
            else
            {
                //tìm theo mã nv và tên nv
                List<NhanVien_DTO> kq = NhanVien_BUS.TimKiemNhanVien(txtTimKiem.Text);
                dgv.DataSource = kq;
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            frmNhanVien_Load(sender, e);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
