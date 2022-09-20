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
    public partial class frmPhanLoai : Form
    {
        public frmPhanLoai()
        {
            InitializeComponent();
        }
        private void HienDsLoaiSuaLenDgv()
        {
            List<PhanLoai_DTO> lstpl = PhanLoai_BUS.LayPhanLoai();
            dgvPhanLoai.DataSource = lstpl;
            if (lstpl == null)
                return;
            dgvPhanLoai.Columns["SMaPhanLoai"].HeaderText = "Mã phân loại";
            dgvPhanLoai.Columns["STenPhanLoai"].HeaderText = "Tên phân loại";
            dgvPhanLoai.Columns["SMaPhanLoai"].Width = 250;
            dgvPhanLoai.Columns["STenPhanLoai"].Width = 120;
            txtMaPhanLoai.ReadOnly = true;
            btnTim.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            dgvPhanLoai.Enabled = true;
            txtTim.ReadOnly = false;

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaPhanLoai.Text = "";
            txtTenPhanLoai.Text = "";
            txtMaPhanLoai.ReadOnly = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            dgvPhanLoai.Enabled = false;
            txtTim.ReadOnly = true;
            btnTim.Enabled = false;
        }

        private void frmPhanLoai_Load(object sender, EventArgs e)
        {
            HienDsLoaiSuaLenDgv();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (PhanLoai_BUS.TimPhanLoaiTheoMa(txtMaPhanLoai.Text) == null)
            {
                MessageBox.Show("Mã loại sữa không tồn tại!");
                return;
            }
            if (MessageBox.Show("Xóa loại sữa " + txtTenPhanLoai.Text, "Thông báo..", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                PhanLoai_DTO pl = new PhanLoai_DTO();
                pl.SMaPhanLoai = txtMaPhanLoai.Text;

                // Thực hiện xóa (xóa quá trình lương trước khi xóa nhân viên)
                if (PhanLoai_BUS.XoaPhanLoai(pl) == false)
                {
                    MessageBox.Show("Không xóa được.");
                    return;
                }
                HienDsLoaiSuaLenDgv();
                MessageBox.Show("Đã xóa thành công.");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaPhanLoai.Text == "" || txtTenPhanLoai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            if (txtMaPhanLoai.Text.Length != 4)
            {
                MessageBox.Show("Mã loại sữa gồm 4 kí tự");
                return;
            }
            if (LoaiSua_BUS.TimSuaThoeMa(txtMaPhanLoai.Text) != null)
            {
                MessageBox.Show("Mã loại sữa đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            PhanLoai_DTO pl = new PhanLoai_DTO();
            pl.SMaPhanLoai = txtMaPhanLoai.Text;
            pl.STenPhanLoai = txtTenPhanLoai.Text;
            if (PhanLoai_BUS.ThemPhanLoai(pl) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            MessageBox.Show("Thêm thành công.");
            HienDsLoaiSuaLenDgv();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            frmPhanLoai_Load(sender, e);
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
                List<PhanLoai_DTO> kq = PhanLoai_BUS.TimKiemPhanLoai(txtTim.Text);
                dgvPhanLoai.DataSource = kq;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenPhanLoai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            PhanLoai_DTO pl = new PhanLoai_DTO();
            pl.SMaPhanLoai = txtMaPhanLoai.Text;
            pl.STenPhanLoai = txtTenPhanLoai.Text;
            if (PhanLoai_BUS.CapNhatPhanLoai(pl) == false)
            {
                MessageBox.Show("Không cập nhật được.");
                return;
            }
            HienDsLoaiSuaLenDgv();
            MessageBox.Show("Đã cập nhật tên loại sữa.");
        }

        private void dgvPhanLoai_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dgvPhanLoai.SelectedRows[0];
            txtMaPhanLoai.Text = r.Cells["sMaPhanLoai"].Value.ToString();
            txtTenPhanLoai.Text = r.Cells["sTenPhanLoai"].Value.ToString();
        }
    }
}
