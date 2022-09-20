using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
namespace DoAnCuoiKi
{
    public partial class frmLoaiSua : Form
    {
        public frmLoaiSua()
        {
            InitializeComponent();
        }

        private void frmLoaiSua_Load(object sender, EventArgs e)
        {
          HienDsLoaiSuaLenDgv();
        }
        private void HienDsLoaiSuaLenDgv()
        {
            List<LoaiSua_DTO> lstLoaiSua = LoaiSua_BUS.LayLoaiSua();
            dgvLoaiSua.DataSource = lstLoaiSua;
            if (lstLoaiSua == null)
                return;
            dgvLoaiSua.Columns["SMaLoaiSua"].HeaderText = "Mã loại sữa";
            dgvLoaiSua.Columns["STenLoaiSua"].HeaderText = "Tên loại sữa";
            dgvLoaiSua.Columns["SMaLoaiSua"].Width = 250;
            dgvLoaiSua.Columns["STenLoaiSua"].Width = 120;
            txtMaLoaiSua.ReadOnly = true;
            btnTim.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            dgvLoaiSua.Enabled = true;
            txtTim.ReadOnly = false;

        }
        private void dgvLoaiSua_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dgvLoaiSua.SelectedRows[0];
            txtMaLoaiSua.Text = r.Cells["sMaLoaiSua"].Value.ToString();
            txtTenLoaiSua.Text = r.Cells["sTenLoaiSua"].Value.ToString();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenLoaiSua.Text=="")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            LoaiSua_DTO ls = new LoaiSua_DTO();
            ls.SMaLoaiSua = txtMaLoaiSua.Text;
            ls.STenLoaiSua = txtTenLoaiSua.Text;
            if (LoaiSua_BUS.CapNhatLoaiSua(ls) == false)
            {
                MessageBox.Show("Không cập nhật được.");
                return;
            }
            HienDsLoaiSuaLenDgv();
            MessageBox.Show("Đã cập nhật tên loại sữa.");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(LoaiSua_BUS.TimSuaThoeMa(txtMaLoaiSua.Text)==null)
            {
                MessageBox.Show("Mã loại sữa không tồn tại!");
                return;
            }
            if (MessageBox.Show("Xóa loại sữa " + txtTenLoaiSua.Text , "Thông báo..", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                LoaiSua_DTO ls = new LoaiSua_DTO();
                ls.SMaLoaiSua = txtMaLoaiSua.Text;

                // Thực hiện xóa (xóa quá trình lương trước khi xóa nhân viên)
                if (LoaiSua_BUS.XoaLoaiSua(ls) == false)
                {
                    MessageBox.Show("Không xóa được.");
                    return;
                }
                HienDsLoaiSuaLenDgv();
                MessageBox.Show("Đã xóa thành công.");
            }
            
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            txtMaLoaiSua.Text = "";
            txtTenLoaiSua.Text = "";
            btnLuu.Enabled = true;
            txtMaLoaiSua.ReadOnly = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            dgvLoaiSua.Enabled = false;
            txtTim.ReadOnly = true;
            btnTim.Enabled = false;
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
                if (txtMaLoaiSua.Text == "" || txtTenLoaiSua.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                    return;
                }
                if (txtMaLoaiSua.Text.Length != 4)
                {
                    MessageBox.Show("Mã loại sữa gồm 4 kí tự");
                    return;
                }
                if (LoaiSua_BUS.TimSuaThoeMa(txtMaLoaiSua.Text) != null)
                {
                    MessageBox.Show("Mã loại sữa đã tồn tại! Vui lòng chọn mã khác.");
                    return;
                }
                LoaiSua_DTO ls = new LoaiSua_DTO();
                ls.SMaLoaiSua = txtMaLoaiSua.Text;
                ls.STenLoaiSua = txtTenLoaiSua.Text;
                if (LoaiSua_BUS.ThemLoaiSua(ls) == false)
                {
                    MessageBox.Show("Không thêm được.");
                    return;
                }
            MessageBox.Show("Thêm thành công.");
            HienDsLoaiSuaLenDgv();
                
            
        }


        private void btnBoQua_Click(object sender, EventArgs e)
        {
            frmLoaiSua_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTim.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập nội dung tìm kiếm");
                return;
            }
            else
            {
                List<LoaiSua_DTO> kq = LoaiSua_BUS.TimKiemLoaiSua(txtTim.Text);
                dgvLoaiSua.DataSource = kq;
            }
        }
    }
}
