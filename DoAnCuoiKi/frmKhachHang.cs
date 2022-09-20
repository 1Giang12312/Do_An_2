using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
namespace DoAnCuoiKi
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        private void HienDSLenDGV()
        {
            List<KhachHang_DTO> lstkh = KhachHang_BUS.LayKhachHang();
            dgv.DataSource = lstkh;
            if (lstkh == null)
                return;
            dgv.Columns["SMaKhachHang"].HeaderText = "Mã khách hàng";
            dgv.Columns["SMaKhachHang"].Width = 80;
            dgv.Columns["STenKhachHang"].HeaderText = "Tên khách hàng";
            dgv.Columns["STenKhachHang"].Width = 200;
            dgv.Columns["SDienThoai"].HeaderText = "Số điện thoại";
            dgv.Columns["SDienThoai"].Width = 80;
            dgv.Columns["SEmail"].HeaderText = "Email";
            dgv.Columns["SEmail"].Width = 80;
            dgv.Columns["SDiaChi"].HeaderText = "Địa chỉ";
            dgv.Columns["SEmail"].Width = 80;

            txtMaKH.ReadOnly = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnTimKiem.Enabled = true;
            txtTim.ReadOnly = false;
            dgv.Enabled = true;
        }
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            HienDSLenDGV();
        }
        private void resetValues()
        {
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            txtEmail.Clear();
            txtMaKH.Clear();
            txtTen.Clear();
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
            if (txtDiaChi.Text.Trim() == "" ||
              txtDienThoai.Text.Trim() == "" ||
              txtEmail.Text.Trim() == "" ||
              txtMaKH.Text.Trim() == "" ||
              txtTen.Text.Trim() == ""
              )
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin");
                return;
            }
            if(KhachHang_BUS.TimKhachHangTheoMa(txtMaKH.Text)!= null)
            {
                MessageBox.Show("Mã khách hàng đã tồn tại đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            if(IsNumber(txtDienThoai.Text)==false || txtDienThoai.Text.Length<10 || txtDienThoai.Text.Length > 10)
            {
                MessageBox.Show("Số điện thoại phải là số và 10 số");
                return;
            }
            if(isEmail(txtEmail.Text)==false)
            {
                MessageBox.Show("Email chưa đúng định dạng(abc@gmail.com)");
                return;
            }
            KhachHang_DTO kh = new KhachHang_DTO();
            kh.SMaKhachHang = txtMaKH.Text;
            kh.STenKhachHang = txtTen.Text;
            kh.SDiaChi = txtDiaChi.Text;
            kh.SDienThoai = txtDienThoai.Text;
            kh.SEmail=txtEmail.Text;
            // Thực hiện thêm
            if (KhachHang_BUS.ThemKH(kh) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            HienDSLenDGV();
            MessageBox.Show("Đã thêm khách hàng thành công!");
        }

        private void dgv_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dgv.SelectedRows[0];
            txtMaKH.Text = r.Cells["SMaKhachHang"].Value.ToString();
            txtTen.Text = r.Cells["STenKhachHang"].Value.ToString();
            txtDienThoai.Text = r.Cells["SDienThoai"].Value.ToString();
            txtDiaChi.Text = r.Cells["SDiaChi"].Value.ToString();
            txtEmail.Text = r.Cells["SEmail"].Value.ToString();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            resetValues();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            txtMaKH.ReadOnly = false;
            dgv.Enabled = false;
            btnTimKiem.Enabled = false;
            txtTim.ReadOnly = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (KhachHang_BUS.TimKhachHangTheoMa(txtMaKH.Text) == null)
            {
                MessageBox.Show("Mã loại sữa không tồn tại!");
                return;
            }
            if (MessageBox.Show("Xóa khách hàng " + txtTen.Text, "Thông báo..", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                KhachHang_DTO kh = new KhachHang_DTO();
                kh.SMaKhachHang = txtMaKH.Text;


                // Thực hiện xóa 
                if (KhachHang_BUS.XoaKhachHang(kh) == false)
                {
                    MessageBox.Show("Không xóa được.");
                    return;
                }
                HienDSLenDGV();
                MessageBox.Show("Đã xóa thành công.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtDiaChi.Text.Trim() == "" ||
              txtDienThoai.Text.Trim() == "" ||
              txtEmail.Text.Trim() == "" ||
              txtMaKH.Text.Trim() == "" ||
              txtTen.Text.Trim() == ""
              )
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin");
                return;
            }
            if (IsNumber(txtDienThoai.Text) == false || txtDienThoai.Text.Length < 10 || txtDienThoai.Text.Length > 10)
            {
                MessageBox.Show("Số điện thoại phải là số và 10 số");
                return;
            }
            if (isEmail(txtEmail.Text) == false)
            {
                MessageBox.Show("Email chưa đúng định dạng(abc@gmail.com)");
                return;
            }
            KhachHang_DTO kh = new KhachHang_DTO();
            kh.SMaKhachHang = txtMaKH.Text;
            kh.STenKhachHang = txtTen.Text;
            kh.SDiaChi = txtDiaChi.Text;
            kh.SDienThoai = txtDienThoai.Text;
            kh.SEmail = txtEmail.Text;
            // Thực hiện thêm
            if (KhachHang_BUS.CapNhaKH(kh) == false)
            {
                MessageBox.Show("Không cập nhật được.");
                return;
            }
            HienDSLenDGV();
            MessageBox.Show("Cập nhật khách hàng thành công!");
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            frmKhachHang_Load(sender, e);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTim.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập nội dung tìm kiếm");
            }
            else
            {
                List<KhachHang_DTO> kq = KhachHang_BUS.TimKiemKH(txtTim.Text); // tim theo ma va theo tên
                dgv.DataSource = kq;
            }
        }
    }
}
