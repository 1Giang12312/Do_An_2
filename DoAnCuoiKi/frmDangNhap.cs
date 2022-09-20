using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace DoAnCuoiKi
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTenDangNhap_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.BackColor = Color.White;
            pnTaiKhoan.BackColor = Color.White;
            pnMatKhau.BackColor = SystemColors.Control;
            txtMatKhau.BackColor = SystemColors.Control;
        }

        private void txtMatKhau_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.BackColor = SystemColors.Control;
            pnTaiKhoan.BackColor = SystemColors.Control;
            pnMatKhau.BackColor = Color.White;
            txtMatKhau.BackColor = Color.White;
        }



        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.UseSystemPasswordChar == true)
                txtMatKhau.UseSystemPasswordChar = false;
            else
                txtMatKhau.UseSystemPasswordChar = true;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            frmQuenMatKhau fQMK = new frmQuenMatKhau();
                fQMK = new frmQuenMatKhau();
                //fKH.MdiParent = this;
                fQMK.Show();
                fQMK.Dock = DockStyle.Fill;
        }
    }
}
