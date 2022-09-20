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
using DoAnCuoiKi.Properties;
using DTO;
namespace DoAnCuoiKi
{
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }
        private void valuesDefutl()
        {
            cboMaNV.Enabled = true;
            cboMaKH.Enabled = true;
            btnLuu.Enabled = true;
            //in hoa đơn
            btnIn.Enabled = false;
            btnThem.Enabled = true;
            //btnTimKiem.Enabled = true;
            btnThem.Enabled = true;

            txtTenSua.ReadOnly = false;
            cboMaSua.Enabled = false;
            nSoLuong.Enabled = false;
            txtGiamGia.ReadOnly = true;
            //txtMaHD.Text = "";
            dtpNgayBan.Text = DateTime.Now.ToShortDateString();
            //cboMaNV.Text = "";
            //cboMaKH.Text = "";
            cboMaSua.Enabled = false;
            txtGiamGia.ReadOnly = true;
            txtTenSua.ReadOnly = true;
            txtThanhTien.Text = "";
            txtDonGia.Text = "0";
            txtGiamGia.Text = "0";
            
        }
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            //reset control
            valuesDefutl();
            //lấy mã nhân viên
            List<NhanVien_DTO> lstMaSua = NhanVien_BUS.LayNhanVien();
            cboMaNV.DataSource = lstMaSua;
            if (lstMaSua == null)
                return;
            cboMaNV.DisplayMember = "STenNhanVien";
            cboMaNV.ValueMember = "SMaNhanVien";
            //lấy mã khách hàng
            List<KhachHang_DTO> lstKH = KhachHang_BUS.LayKhachHang();
            cboMaKH.DataSource = lstKH;
            if (lstKH == null)
                return;
            cboMaKH.DisplayMember = "STenKhachHang";
            cboMaKH.ValueMember = "SMaKhachHang";
            //lấy mã sữa nếu số lượng của sữa là 0 thì không hiện
            List<HangHoa_DTO> lstSua = HangHoa_BUS.LayHHCoSLLH0();
            cboMaSua.DataSource = lstSua;
            if (lstSua == null)
                return;
            cboMaSua.DisplayMember = "STenSua";
            cboMaSua.ValueMember = "SMaSua";

            List<ChiTietHDBan_DTO> lstct = ChiTietHDBan_BUS.LayChiTietHDBan(txtMaHD.Text);
            dgv.DataSource = lstct;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtMaHD.Text != "")
            {
                btnIn.Enabled = false;
                btnThem.Enabled = false;
                dgv.Enabled = false;
                HienChiTietHDLendgv();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnIn.Enabled = true;
            if (txtMaHD.Text == "")
            {
                //MessageBox.Show("Mã hóa đơn chưa được tạo, hệ thống sẽ tự động thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHD.Text = HoaDon_BUS.TaoMaHD("HDB");
                //cboMaKH.Enabled = false;
                //cboMaNV.Enabled = false;
                if (cboMaNV.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaNV.Focus();
                    return;
                }
                if (cboMaKH.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaKH.Focus();
                    return;
                }
               
            }
            // kiểm tra mã hóa đơn
            if (KhachHang_BUS.TimKhachHangTheoMa(cboMaKH.SelectedValue.ToString()) == null)//không tìm thấy mã khách hàng
            {
                MessageBox.Show("Mã khách hàng không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaKH.SelectedIndex = 0;
                return;
            }
            if(NhanVien_BUS.TimNhanVienTheoMa(cboMaNV.SelectedValue.ToString()) ==null)
            {
                MessageBox.Show("Mã nhân viên không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaNV.SelectedIndex = 0;
                return;
            }
            if (HoaDonBan_BUS.TimHDTheoMa(txtMaHD.Text) != null)
            {
                MessageBox.Show("Mã hóa đơn trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // khởi tạo mã hóa đơn có tổng tiền là 0
            HoaDonBan_DTO hd = new HoaDonBan_DTO();
            hd.SMaHoaDonBan = txtMaHD.Text;
            hd.SMaNhanVien = cboMaNV.SelectedValue.ToString();
            hd.DtNgayBan = DateTime.Parse(dtpNgayBan.Text);
            hd.SMaKhachHang = cboMaKH.SelectedValue.ToString();
            hd.FTongTien = 0;
            // Thực hiện thêm
            if (HoaDonBan_BUS.ThemHDBan(hd) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            cboMaNV.Enabled = false;
            cboMaKH.Enabled = false;
            btnLuu.Enabled = true;
            btnIn.Enabled = true;
            btnThem.Enabled = false;
            //btnTimKiem.Enabled = false;
            btnThem.Enabled = false;

            txtTenSua.ReadOnly = true;
            cboMaSua.Enabled = true;
            nSoLuong.Enabled = true;
            txtGiamGia.ReadOnly = false;
            //txtMaHD.Text = "";
            dtpNgayBan.Text = DateTime.Now.ToShortDateString();
            //cboMaNV.Text = "";
            //cboMaKH.Text = "";
            txtThanhTien.Text = "0";
            nSoLuong.Text = "0";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
    }
        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NhanVien_BUS.TimNhanVienTheoMa(cboMaNV.SelectedValue.ToString()) != null)// == null là không có nhân viên phù hợp
            {
                //MessageBox.Show("asdfa");
                NhanVien_DTO nv = NhanVien_BUS.TimNhanVienTheoMa(cboMaNV.SelectedValue.ToString());
                txtTenNV.Text = nv.STenNhanVien;
            }
        }
        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (KhachHang_BUS.TimKhachHangTheoMa(cboMaKH.SelectedValue.ToString()) != null)// == null là không có phù hợp
            {
                //MessageBox.Show("asdfa");
                KhachHang_DTO kh = KhachHang_BUS.TimKhachHangTheoMa(cboMaKH.SelectedValue.ToString());
                txtTenKH.Text = kh.STenKhachHang;
            }
        }
        private void cboMaSua_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HangHoa_BUS.TimHangHoaTheoMa(cboMaSua.SelectedValue.ToString()) != null)// == null là không có nhân viên phù hợp
            {
                //MessageBox.Show("asdfa");
                HangHoa_DTO ls = HangHoa_BUS.TimHangHoaTheoMa(cboMaSua.SelectedValue.ToString());
                txtTenSua.Text = ls.STenSua;
                txtDonGia.Text = ls.FDonGiaBan.ToString();
            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = "";
            frmHoaDon_Load(sender, e);
        }
        //thêm khách hàng mới
        frmKhachHang fKH;
        private void lbThemKH_Click(object sender, EventArgs e)
        {

            if (fKH == null || fKH.IsDisposed)
            {
                fKH = new frmKhachHang();
                //fKH.MdiParent = this;
                fKH.Show();
                fKH.Dock = DockStyle.Fill;

            }
        }
        private void HienChiTietHDLendgv()
        {
            List<ChiTietHDBan_DTO> lstct = ChiTietHDBan_BUS.LayChiTietHDBan(txtMaHD.Text);
            dgv.DataSource = lstct;
            if (lstct == null)
                return;
            dgv.Columns["SMaHoaDonBan"].HeaderText = "Mã hóa đơn";
            dgv.Columns["SMaHoaDonBan"].Width = 150;
            dgv.Columns["SMaSua"].Visible = false;
            dgv.Columns["ISoLuong"].HeaderText = "Số lượng";
            dgv.Columns["FDonGia"].HeaderText = "Đơn giá";
            dgv.Columns["FGiamGia"].HeaderText = "Giảm giá";
            dgv.Columns["FThanhTien"].HeaderText = "Thành tiền";
            dgv.Columns["STenSua"].HeaderText = "Tên sữa";
            dgv.Columns["STenSua"].Width = 300;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboMaSua.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sữa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (nSoLuong.Value <= 0)
            {
                MessageBox.Show("Số lượng phải nhiều hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // lấy số lượng sữa trong database ra so sánh
            if (HangHoa_BUS.TimHangHoaTheoMa(cboMaSua.SelectedValue.ToString()) != null)
            {
                int soluong;
                HangHoa_DTO sua = HangHoa_BUS.TimHangHoaTheoMa(cboMaSua.SelectedValue.ToString());
                soluong = sua.ISoLuong;
                if (nSoLuong.Value > soluong) //nếu số lượng mua lớn hơn số lượng trong database
                {
                    MessageBox.Show("Số lượng sữa " + txtTenSua.Text + " không đủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else //số lượng trong database đủ đáp ứng
                {
                    //số lượng mới = soluong - iSoluong
                    int soluongUpdate = soluong - Convert.ToInt32(nSoLuong.Value);
                    HangHoa_DTO hh = new HangHoa_DTO();
                    hh.SMaSua = cboMaSua.SelectedValue.ToString();
                    hh.ISoLuong = soluongUpdate;
                    if (ChiTietHDBan_BUS.CapNhatSoLuong(hh) == false)
                    {
                        MessageBox.Show("Không cập nhật được.");
                        return;
                    }

                }
            }

            if (ChiTietHDBan_BUS.TimChiTietHDBanTheoMa(txtMaHD.Text, cboMaSua.SelectedValue.ToString()) != null)//tìm thấy
            {
                MessageBox.Show("Mã sữa đã tồn tại!");
                return;
            }
            ChiTietHDBan_DTO ct = new ChiTietHDBan_DTO();
            ct.SMaHoaDonBan = txtMaHD.Text;
            ct.SMaSua = cboMaSua.SelectedValue.ToString();
            ct.ISoLuong = int.Parse(nSoLuong.Value.ToString());
            ct.FDonGia = float.Parse(txtDonGia.Text);
            ct.FGiamGia = float.Parse(txtGiamGia.Text);
            ct.FThanhTien = float.Parse(txtThanhTien.Text);
            // Thực hiện thêm
            if (ChiTietHDBan_BUS.ThemChiTietHDBan(ct) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            //lấy thành tiền từ database lên
            if (HoaDonBan_BUS.TimHDTheoMa(txtMaHD.Text) != null)
            {
                float tongtienmoi;
                HoaDonBan_DTO hd = HoaDonBan_BUS.TimHDTheoMa(txtMaHD.Text);//tổng tiền =0
                hd.SMaHoaDonBan = txtMaHD.Text;
                //tính tổng tiền
                tongtienmoi = float.Parse(txtThanhTien.Text) + hd.FTongTien;
                hd.FTongTien = tongtienmoi;
                if (HoaDonBan_BUS.CapNhatTien(hd) == false)
                {
                    MessageBox.Show("Cập nhật tiền thất bại!");
                    return;
                }
                txtTongTienBangSo.Text = tongtienmoi.ToString();
            }
            HienChiTietHDLendgv();
        }
        private void nSoLuong_ValueChanged(object sender, EventArgs e)
        {
            if (txtGiamGia.Text.Trim() == "")
                txtGiamGia.Text = "0";
            else
            {
                double tt, sl, dg, gg;
                if (nSoLuong.Text == "0")
                    sl = 0;
                else
                    sl = Convert.ToDouble(nSoLuong.Text);
                if (txtGiamGia.Text == "0")
                    gg = 0;
                else
                    gg = Convert.ToDouble(txtGiamGia.Text);
                if (txtThanhTien.Text == "0")
                    dg = 0;
                else
                    dg = Convert.ToDouble(txtThanhTien.Text);
                tt = sl * dg - sl * dg * gg / 100;
                txtThanhTien.Text = tt.ToString();
            }
           
        }
        //hàm kiểm tra số
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*.?[0-9]+$");
            return regex.IsMatch(pText);
        }
        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            //txtGiamGia.Text = "0";
            //Khi thay đổi giảm giá thì tính lại thành tiền
            if (txtGiamGia.Text.Trim() == "")
                txtGiamGia.Text = "0";
            if (IsNumber(txtGiamGia.Text)==true) // là số
            {
                if (int.Parse(txtGiamGia.Text) >= 100)
                {
                    MessageBox.Show("Giảm giá không hợp lí!");
                    txtGiamGia.Text = "0";
                }
                double tt, sl, dg, gg;
                if (nSoLuong.Text == "0")
                    sl = 0;
                else
                    sl = Convert.ToDouble(nSoLuong.Text);
                if (txtGiamGia.Text == "0")
                    gg = 0;
                else
                    gg = Convert.ToDouble(txtGiamGia.Text);
                if (txtDonGia.Text == "0")
                    dg = 0;
                else
                    dg = Convert.ToDouble(txtDonGia.Text);
                tt = sl * dg - sl * dg * gg / 100;
                txtThanhTien.Text = tt.ToString();
                btnLuu.Enabled = true;
               // btnIn.Enabled = true;
            }

            else
            {
                btnLuu.Enabled = false;
                btnIn.Enabled = false;
                return;
            }
            
        }
        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            string mahangxoa;
            int soluongxoa;
            float ThanhTienxoa;
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                mahangxoa = dgv.CurrentRow.Cells["SMaSua"].Value.ToString();
                soluongxoa = Convert.ToInt32(dgv.CurrentRow.Cells["ISoLuong"].Value.ToString());
                ThanhTienxoa = float.Parse(dgv.CurrentRow.Cells["FThanhTien"].Value.ToString());
                // tiến hành xóa
                ChiTietHDBan_DTO ct = new ChiTietHDBan_DTO();
                ct.SMaSua = mahangxoa;
                if (ChiTietHDBan_BUS.XoaChiTietHDBan(ct) == false)
                {
                    MessageBox.Show("Không xóa chi tiết hóa đơn được!");
                    return;
                }
                // Cập nhật lại số lượng cho các mặt hàng
                if (HangHoa_BUS.TimHangHoaTheoMa(cboMaSua.SelectedValue.ToString()) != null)
                {
                    int SoLuongConLai, SoLuongTrongDatbase;
                    HangHoa_DTO sua = HangHoa_BUS.TimHangHoaTheoMa(cboMaSua.SelectedValue.ToString());
                    SoLuongTrongDatbase = sua.ISoLuong; // lấy số lương trong database
                    SoLuongConLai = SoLuongTrongDatbase + soluongxoa;
                    //cập nhật lại số lượng
                    HangHoa_DTO hh = new HangHoa_DTO();
                    hh.SMaSua = cboMaSua.SelectedValue.ToString();
                    hh.ISoLuong = SoLuongConLai;
                    if (ChiTietHDBan_BUS.CapNhatSoLuong(hh) == false)
                    {
                        MessageBox.Show("Không cập nhật được.");
                        return;
                    }
                }
                //cập nhật lại thành tiền
                if (HoaDonBan_BUS.TimHDTheoMa(txtMaHD.Text) != null)
                {
                    float tongtienmoi;
                    HoaDonBan_DTO hd = HoaDonBan_BUS.TimHDTheoMa(txtMaHD.Text);//tổng tiền =0
                    hd.SMaHoaDonBan = txtMaHD.Text;
                    //tính tổng tiền
                    tongtienmoi = float.Parse(txtTongTienBangSo.Text) - ThanhTienxoa;
                    hd.FTongTien = tongtienmoi;
                    if (HoaDonBan_BUS.CapNhatTien(hd) == false)
                    {
                        MessageBox.Show("Cập nhật tiền thất bại!");
                        return;
                    }
                    txtTongTienBangSo.Text = tongtienmoi.ToString();
                }
                HienChiTietHDLendgv();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cboMaSua.Text.Trim()==""||
                nSoLuong.Value.ToString().Trim()==""||
                txtGiamGia.Text.Trim()==""
               )
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin!");
                return;
            }
            // Gán dữ liệu vào kiểu NhanVienDTO
            ChiTietHDBan_DTO ct = new ChiTietHDBan_DTO();

            ct.SMaHoaDonBan = txtMaHD.Text;
            ct.ISoLuong = int.Parse(nSoLuong.Value.ToString());
            ct.FGiamGia = float.Parse(txtGiamGia.Text);
            ct.FThanhTien = float.Parse(txtThanhTien.Text);
            // Thực hiện cập nhật
            if (ChiTietHDBan_BUS.CapNhatChiTietHDBan(ct) == false)
            {
                MessageBox.Show("Không cập nhật được.");
                return;
            }
            // sửa = lấy tổng tiền - thành tiền + thành tiền mới
            if (HoaDonBan_BUS.TimHDTheoMa(txtMaHD.Text) != null)
            {
                float tongtienmoi;
                HoaDonBan_DTO hd = HoaDonBan_BUS.TimHDTheoMa(txtMaHD.Text);//tổng tiền =0
                hd.SMaHoaDonBan = txtMaHD.Text;
                //tính tổng tiền
                hd.FTongTien = float.Parse(txtThanhTien.Text);
                if (HoaDonBan_BUS.CapNhatTien(hd) == false)
                {
                    MessageBox.Show("Cập nhật tiền thất bại!");
                    return;
                }
                txtTongTienBangSo.Text = hd.FTongTien.ToString();
            }
            HienChiTietHDLendgv();
            MessageBox.Show("Đã cập nhật thành công!.");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            //string mahd;
           // mahd = txtMaHD.Text;
            frmInHoaDon f = new frmInHoaDon();
            
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void dgv_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dgv.SelectedRows[0];
            cboMaSua.SelectedValue = r.Cells["sMaSua"].Value.ToString();
            txtTenSua.Text = r.Cells["sTenSua"].Value.ToString();
            txtDonGia.Text = r.Cells["fDonGia"].Value.ToString();
            nSoLuong.Text = r.Cells["iSoLuong"].Value.ToString();
            txtGiamGia.Text = r.Cells["fGiamGia"].Value.ToString();
            txtThanhTien.Text = r.Cells["fThanhTien"].Value.ToString();
            
        }
    }
}

