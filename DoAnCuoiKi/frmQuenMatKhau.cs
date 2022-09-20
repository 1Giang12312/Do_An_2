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
    public partial class frmQuenMatKhau : Form
    {
        public frmQuenMatKhau()
        {
            InitializeComponent();
        }

      

        private void txtEmail_Click(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.White;
            pnEmail.BackColor = Color.White;
            pnsdt.BackColor = SystemColors.Control;
            txtsdt.BackColor = SystemColors.Control;
            cboMaNV.BackColor = SystemColors.Control;
            pnMaNV.BackColor = SystemColors.Control;
            pnsdt.BackColor = SystemColors.Control;
            txtsdt.BackColor = SystemColors.Control;
            pnMatKhau.BackColor = SystemColors.Control;
            txtMatKhauMoi.BackColor = SystemColors.Control;
        }

        private void txtsdt_Click(object sender, EventArgs e)
        {
            txtEmail.BackColor = SystemColors.Control;
            pnEmail.BackColor = SystemColors.Control;
            pnsdt.BackColor = Color.White;
            txtsdt.BackColor = Color.White;
            cboMaNV.BackColor = SystemColors.Control;
            pnMaNV.BackColor = SystemColors.Control;
            pnMatKhau.BackColor = SystemColors.Control;
            txtMatKhauMoi.BackColor = SystemColors.Control;
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQuenMatKhau_Load(object sender, EventArgs e)
        {
            //lấy mã nhân viên
            List<NhanVien_DTO> lstMaSua = NhanVien_BUS.LayNhanVien();
            cboMaNV.DataSource = lstMaSua;
            cboMaNV.DisplayMember = "SMaNhanVien";
            cboMaNV.ValueMember = "SMaNhanVien";
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {

            if (cboMaNV.SelectedValue.ToString().Trim()==""||
                txtEmail.Text==""||
                txtsdt.Text==""
                )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            if (NhanVien_BUS.TimNhanVienDMK(cboMaNV.Text,txtsdt.Text,txtEmail.Text) != null)
            {
                //thong tin dung thi thuc hien doi mat khau
                TaiKhoan_DTO tk = new TaiKhoan_DTO();
                tk.SMaNhanVien = cboMaNV.Text;
                tk.SMatKhau = txtMatKhauMoi.Text;
                if (TaiKhoan_BUS.CapNhatMatKhau(tk)==false)
                {
                    MessageBox.Show("Chưa cập nhật được!");
                    return;
                }
                MessageBox.Show("Cập nhật thành công!");
                return;
            }

            MessageBox.Show("Thông tin không chính xác");
            return;
        }
        private void txtMatKhauMoi_Click(object sender, EventArgs e)
        {
            txtEmail.BackColor = SystemColors.Control;
            pnEmail.BackColor = SystemColors.Control;
            pnsdt.BackColor = SystemColors.Control;
            txtsdt.BackColor = SystemColors.Control;
            cboMaNV.BackColor = SystemColors.Control;
            pnMaNV.BackColor = SystemColors.Control;
            pnMatKhau.BackColor = Color.White;
            txtMatKhauMoi.BackColor = Color.White;
        }

        private void cboMaNV_Click(object sender, EventArgs e)
        {
            txtEmail.BackColor = SystemColors.Control;
            pnEmail.BackColor = SystemColors.Control;
            pnsdt.BackColor = SystemColors.Control;
            txtsdt.BackColor = SystemColors.Control;
            cboMaNV.BackColor = Color.White;
            pnMaNV.BackColor = Color.White;
            pnMatKhau.BackColor = SystemColors.Control;
            txtMatKhauMoi.BackColor = SystemColors.Control;
        }
    }
}
