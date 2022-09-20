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
namespace DoAnCuoiKi
{
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void txtMatKhauCu_Click(object sender, EventArgs e)
        {
            txtMatKhauCu.BackColor = Color.White;
            pnEmail.BackColor = Color.White;
            pnMatKhau.BackColor = SystemColors.Control;
            txtMatKhauMoi.BackColor = SystemColors.Control;
        }

        private void txtMatKhauMoi_Click(object sender, EventArgs e)
        {
            txtMatKhauCu.BackColor = SystemColors.Control;
            pnEmail.BackColor = SystemColors.Control;
            pnMatKhau.BackColor = Color.White;
            txtMatKhauMoi.BackColor = Color.White;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (TaiKhoan_BUS.KiemTraTaiKhoan(txtTenDangNhap.Text, txtMatKhauCu.Text) == null)
            {
                MessageBox.Show("Mật khẩu chưa đúng!");
                return;
            }
            TaiKhoan_DTO tk = new TaiKhoan_DTO();
            tk.STenDangNhap = txtTenDangNhap.Text;
            tk.SMatKhau = txtMatKhauMoi.Text;
            if (!TaiKhoan_BUS.CapNhatMKTheoTenDangNhap(tk))
            {
                MessageBox.Show("Chưa cập nhật được!");
                return;
            }
            MessageBox.Show("Cập nhật thành công!");
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = formMain.taikhoan.STenDangNhap;
            txtTenDangNhap.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
