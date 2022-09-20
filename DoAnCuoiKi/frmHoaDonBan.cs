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
    public partial class frmHoaDonBan : Form
    {
        public frmHoaDonBan()
        {
            InitializeComponent();
        }
        private void HienDSLenDGV()
        {
            List<HoaDonBan_DTO> lsthdb = HoaDonBan_BUS.LayHoaDonBan();
            dgv.DataSource = lsthdb;
            if (lsthdb == null)
                return;
            dgv.Columns["SMaHoaDonBan"].HeaderText = "Mã hóa đơn bán";
            dgv.Columns["SMaHoaDonBan"].Width = 200;
            dgv.Columns["SMaNhanVien"].HeaderText = "Mã nhân viên";
           // dgv.Columns["SMaNhanVien"].Width = 200;
            dgv.Columns["DtNgayBan"].HeaderText = "Ngày bán";
            //.Columns["DtNgayBan"].Width = 80;
            dgv.Columns["SMaKhachHang"].HeaderText = "Mã khách hàng";
           // dgv.Columns["SMaKhachHang"].Width = 80;
            dgv.Columns["FTongTien"].HeaderText = "Tổng tiền";
           // dgv.Columns["FTongTien"].Width = 80;

            txtMaHoaDon.ReadOnly = true;
            dgv.Enabled = true;
        }
        private void HienTenNV()
        {
            List<NhanVien_DTO> lstnv = NhanVien_BUS.LayNhanVien() ;
            cboMaNhanVien.DataSource = lstnv;
            cboMaNhanVien.DisplayMember = "STenNhanVien";
            cboMaNhanVien.ValueMember = "SMaNhanVien";
        }
        private void HienTenKH()
        {
            List<KhachHang_DTO> lstkh = KhachHang_BUS.LayKhachHang();
            cboMaKhachHang.DataSource = lstkh;
            cboMaKhachHang.DisplayMember = "STenKhachHang";
            cboMaKhachHang.ValueMember = "SMaKhachHang";
        }
        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            if(HoaDonBan_BUS.KiemTraTongTien()==false)
            {
                MessageBox.Show("Kiểm tra tổng tiền lỗi!");
            }
            HienDSLenDGV();
            HienTenNV();
            HienTenKH();
        }

        private void dgv_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dgv.SelectedRows[0];
            cboMaKhachHang.SelectedValue = r.Cells["sMaKhachHang"].Value.ToString();
            //txtHoVaTen.Text = r.Cells["sHoTen"].Value.ToString();
            txtMaHoaDon.Text = r.Cells["sMaHoaDonBan"].Value.ToString();
            cboMaNhanVien.SelectedValue = r.Cells["sMaNhanVien"].Value.ToString();
            txtTongTien.Text = r.Cells["fTongTien"].Value.ToString();
            dtNgayBan.Value =DateTime.Parse(r.Cells["dtNgayBan"].Value.ToString());
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            frmHoaDonBan_Load(sender, e);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if(txtTimKiem.Text.Trim()=="")
            {
                MessageBox.Show("Hãy nhập thông tin tìm kiếm");
                return;
            }
            else
            {
                //tìm theo mã kh và ma nv
                List<HoaDonBan_DTO> kq = HoaDonBan_BUS.TimHDBan(txtTimKiem.Text);
                dgv.DataSource = kq;
                
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
                if (HoaDonBan_BUS.TimHDTheoMa(txtMaHoaDon.Text) == null)
                {
                    MessageBox.Show("Mã loại sữa không tồn tại!");
                    return;
                }
                if (MessageBox.Show("Xóa loại sữa " + txtMaHoaDon.Text, "Thông báo..", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    HoaDonBan_DTO hdb = new HoaDonBan_DTO();
                hdb.SMaHoaDonBan = txtMaHoaDon.Text;

                    // Thực hiện xóa (xóa quá trình lương trước khi xóa nhân viên)
                    if (HoaDonBan_BUS.XoaHD(hdb) == false)
                    {
                        MessageBox.Show("Không xóa được.");
                        return;
                    }
                frmHoaDonBan_Load(sender, e);
                    MessageBox.Show("Đã xóa thành công.");
                

            }
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            string mahd;
            float tongtien;
            tongtien = float.Parse(dgv.CurrentRow.Cells["FTongTien"].Value.ToString());
            if(tongtien ==0)
            {
                MessageBox.Show("Hóa đơn trống!");
                return;
            }
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mahd = dgv.CurrentRow.Cells["SMaHoaDonBan"].Value.ToString();
                frmHoaDon f = new frmHoaDon();
                f.txtMaHD.Text = mahd;
                f.txtTongTienBangSo.Text = tongtien.ToString();
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmInTongHoaDon f = new frmInTongHoaDon();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }
    }
}
