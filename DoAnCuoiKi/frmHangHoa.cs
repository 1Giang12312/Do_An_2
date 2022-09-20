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
    public partial class frmHangHoa : Form
    {
        public frmHangHoa()
        {
            InitializeComponent();

        }
        private void HienLoaiSuaLenCb()
        {
            List<LoaiSua_DTO> lstMaSua = LoaiSua_BUS.LayLoaiSua();
            cboMaLoaiSua.DataSource = lstMaSua;
            if (lstMaSua == null)
                return;
            cboMaLoaiSua.DisplayMember = "STenLoaiSua";
            cboMaLoaiSua.ValueMember = "SMaLoaiSua";
        }
        private void HienPhanLoaiLenCb()
        {
            List<PhanLoai_DTO> lstpl = PhanLoai_BUS.LayPhanLoai();
            cboMaPhanLoai.DataSource = lstpl;
            if (lstpl == null)
                return;
            cboMaPhanLoai.DisplayMember = "STenPhanLoai";
            cboMaPhanLoai.ValueMember = "SMaPhanLoai";
        }
        private void HienDSHangHoa()
        {
            List<HangHoa_DTO> lstSua = HangHoa_BUS.LayHangHoa();
            dgv.DataSource = lstSua;
            if (lstSua == null)
                return;
            dgv.Columns["SMaSua"].HeaderText = "Mã sữa";
            dgv.Columns["STenSua"].HeaderText = "Tên sữa";
            dgv.Columns["SMaLoaiSua"].HeaderText = "Tên loại sữa";
            dgv.Columns["ISoLuong"].HeaderText = "Số Lượng";
            dgv.Columns["FDonGiaNhap"].HeaderText = "Đơn giá nhập";
            dgv.Columns["FDonGiaBan"].HeaderText = "Đơn giá bán";
            dgv.Columns["SAnh"].HeaderText = "Ảnh";
            dgv.Columns["SGhiChu"].HeaderText = "Ghi chú";
            dgv.Columns["DtHanSuDung"].HeaderText = "Hạn sử dụng";
            dgv.Columns["SMaPhanLoai"].HeaderText = "Mã phân loại";

            dgv.Columns["SMaSua"].Width = 80;
            dgv.Columns["STenSua"].Width = 200;
            dgv.Columns["SMaLoaiSua"].Width = 80;
            dgv.Columns["ISoLuong"].Width = 80;
            dgv.Columns["FDonGiaNhap"].Width = 70;
            dgv.Columns["FDonGiaBan"].Width = 70;
            dgv.Columns["SAnh"].Width = 70;
            dgv.Columns["SGhiChu"].Width = 100;
            //set default values
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = true;
            btnTim.Enabled = true;
            txtTimKiem.ReadOnly = false;
            txtMaSua.ReadOnly = true;
        }
        private void dgv_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dgv.SelectedRows[0];
            txtMaSua.Text = r.Cells["SMaSua"].Value.ToString();
            txtTenSua.Text = r.Cells["STenSua"].Value.ToString();
            txtAnh.Text = r.Cells["SAnh"].Value.ToString();
            txtDGBan.Text = r.Cells["FDonGiaBan"].Value.ToString();
            txtDGNhap.Text = r.Cells["FDonGiaNhap"].Value.ToString();
            txtGhiChu.Text = r.Cells["SGhiChu"].Value.ToString();
            txtSoLuong.Text = r.Cells["ISoLuong"].Value.ToString();
            dtHanSuDung.Text = r.Cells["DtHanSuDung"].Value.ToString();
            cboMaPhanLoai.SelectedValue = r.Cells["SMaPhanLoai"].Value.ToString();
            cboMaLoaiSua.SelectedValue = r.Cells["SMaLoaiSua"].Value.ToString();
        }
        private void btnGui_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2; //ưu tiên ảnh đuôi .jpg trước
            dlgOpen.InitialDirectory = Application.StartupPath + "\\Resources\\AnhSanPham";
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                txtAnh.Text = System.IO.Path.GetFileName(dlgOpen.FileName);
                picAnh.Image = Image.FromFile(Application.StartupPath + "\\Resources\\AnhSanPham\\" + txtAnh.Text);
            }
        }
        void resetValues()
        {
            txtAnh.Clear();
            txtDGBan.Clear();
            txtDGNhap.Clear();
            txtGhiChu.Clear();
            txtMaSua.Clear();
            txtSoLuong.Clear();
            txtTenSua.Clear();
            txtTimKiem.Clear();
            cboMaLoaiSua.SelectedIndex = 0;
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
        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            
            if (HangHoa_BUS.KiemTraHanSuDung()==false)
            {
                MessageBox.Show("Kiểm tra hạn sử dụng lỗi!");
            }
            else
            {
                HienLoaiSuaLenCb();
                HienDSHangHoa();
                HienPhanLoaiLenCb();
            }
                

        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtAnh.Text.Trim() != "")
            {
                try
                {
                    picAnh.Image = Image.FromFile(Application.StartupPath + "\\Resources\\AnhSanPham\\" + txtAnh.Text);
                }
                catch
                {
                    picAnh.Image = Image.FromFile(Application.StartupPath + "\\Resources\\noimg.jpg");
                }
            }
            else
            {
                picAnh.Image = Image.FromFile(Application.StartupPath + "\\Resources\\noimg.jpg");
            }
        }
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            resetValues();
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnTim.Enabled = false;
            txtTimKiem.ReadOnly = true;
            txtMaSua.ReadOnly = false;
        }
        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra mã có tồn tại không
            if (HangHoa_BUS.TimHangHoaTheoMa(txtMaSua.Text) == null)
            {
                MessageBox.Show("Mã sữa không tồn tại!");
                return;
            }
            // Gán dữ liệu vào kiểu HangHoa_DTO
            if (MessageBox.Show("Xóa loại sữa " + txtTenSua.Text, "Thông báo..", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                HangHoa_DTO sua = new HangHoa_DTO();
                sua.SMaSua = txtMaSua.Text;
                // Thực hiện xóa
                if (HangHoa_BUS.XoaSua(sua) == false)
                {
                    MessageBox.Show("Không xóa được.");
                    return;
                }
            }
            HienDSHangHoa();
            MessageBox.Show("Đã xóa thành công!.");
        }
        private void btnSua_Click_1(object sender, EventArgs e)
        {

            // Kiểm tra dữ liệu có bị bỏ trống
            // ảnh & ghi chú có thể bỏ trống
            if (txtDGBan.Text.Trim() == "" ||
               txtDGNhap.Text.Trim() == "" ||
               txtMaSua.Text.Trim() == "" ||
               txtSoLuong.Text.Trim() == "" ||
               txtTenSua.Text.Trim() == "" ||
               dtHanSuDung.Text.Trim() == "" ||
               cboMaLoaiSua.Text.Trim() == "" ||
               cboMaPhanLoai.Text.Trim() == ""
               )
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin!");
                return;
            }
            if (txtMaSua.Text.Length > 10)// mã loại sữa giới hạn 10 ký tự
            {
                MessageBox.Show("Mã loại sữa chỉ tối đa 10 ký tự!");
                return;
            }
            if (IsNumber(txtSoLuong.Text) == false || IsNumber(txtDGBan.Text) == false || IsNumber(txtDGNhap.Text) == false)
            {
                MessageBox.Show("Ký tự không hợp lệ, hãy nhập số!");
                return;
            }
            // Kiểm tra mã nhân viên có tồn tại không
            if (HangHoa_BUS.TimHangHoaTheoMa(txtMaSua.Text) == null)
            {
                MessageBox.Show("Mã sữa không tồn tại!");
                return;
            }
            //kiểm tra loại hàng hóa trong combo
            if (LoaiSua_BUS.TimSuaThoeMa(cboMaLoaiSua.SelectedValue.ToString()) == null)
            {
                MessageBox.Show("Mã loại sữa không hợp lệ!");
                cboMaLoaiSua.SelectedIndex = 0;
                return;
            }
            if (PhanLoai_BUS.TimPhanLoaiTheoMa(cboMaPhanLoai.SelectedValue.ToString()) == null)
            {
                MessageBox.Show("Phân loại không tồn tại!");
                cboMaPhanLoai.SelectedIndex = 0;
                return;
            }
            // Gán dữ liệu vào kiểu NhanVienDTO
            HangHoa_DTO sua = new HangHoa_DTO();
            sua.SMaSua = txtMaSua.Text;
            sua.STenSua = txtTenSua.Text;
            sua.SMaLoaiSua = cboMaLoaiSua.SelectedValue.ToString();
            sua.ISoLuong = int.Parse(txtSoLuong.Text);
            sua.FDonGiaNhap = float.Parse(txtDGNhap.Text);
            sua.FDonGiaBan = float.Parse(txtDGBan.Text);
            sua.SAnh = txtAnh.Text;
            sua.SGhiChu = txtGhiChu.Text;
            sua.DtHanSuDung = DateTime.Parse(dtHanSuDung.Text);
            sua.SMaPhanLoai = cboMaPhanLoai.SelectedValue.ToString();
            // Thực hiện cập nhật
            if (HangHoa_BUS.CapNhatHangHoa(sua) == false)
            {
                MessageBox.Show("Không cập nhật được.");
                return;
            }
            HienDSHangHoa();
            MessageBox.Show("Đã cập nhật thành công!.");
        }
        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            // ảnh & ghi chú có thể bỏ trống
            if (txtDGBan.Text.Trim() == "" ||
               txtDGNhap.Text.Trim() == "" ||
               txtMaSua.Text.Trim() == "" ||
               txtSoLuong.Text.Trim() == "" ||
               txtTenSua.Text.Trim() == "" ||
               dtHanSuDung.Text.Trim()==""||
               cboMaLoaiSua.Text.Trim()==""||
               cboMaPhanLoai.Text.Trim() == ""
               )
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin!");
                return;
            }
            if (txtMaSua.Text.Length >= 10)// mã loại sữa giới hạn 10 ký tự
            {
                MessageBox.Show("Mã loại sữa chỉ tối đa 10 ký tự!");
                return;
            }
            if (IsNumber(txtSoLuong.Text) == false || IsNumber(txtDGBan.Text) == false || IsNumber(txtDGNhap.Text) == false)
            {
                MessageBox.Show("Ký tự không hợp lệ, hãy nhập số!");
                return;
            }
            if (HangHoa_BUS.TimHangHoaTheoMa(txtMaSua.Text) != null)
            {
                MessageBox.Show("Mã hàng hóa đã tồn tại đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            if(PhanLoai_BUS.TimPhanLoaiTheoMa(cboMaPhanLoai.SelectedValue.ToString()) ==null)
            {
                MessageBox.Show("Phân loại không tồn tại!");
                cboMaPhanLoai.SelectedIndex = 0;
                return;
            }
            //kiểm tra loại hàng hóa trong combo
            if(LoaiSua_BUS.TimSuaThoeMa(cboMaLoaiSua.SelectedValue.ToString()) ==null)
            {
                MessageBox.Show("Mã loại sữa không hợp lệ!");
                cboMaLoaiSua.SelectedIndex = 0;
                return;
            }
            HangHoa_DTO sua = new HangHoa_DTO();
            sua.SMaSua = txtMaSua.Text;
            sua.STenSua = txtTenSua.Text;
            sua.SMaLoaiSua = cboMaLoaiSua.SelectedValue.ToString();
            sua.ISoLuong = int.Parse(txtSoLuong.Text);
            sua.FDonGiaNhap = float.Parse(txtDGNhap.Text);
            sua.FDonGiaBan = float.Parse(txtDGBan.Text);
            sua.SAnh = txtAnh.Text;
            sua.SGhiChu = txtGhiChu.Text;
            sua.DtHanSuDung = DateTime.Parse(dtHanSuDung.Text);
            sua.SMaPhanLoai= cboMaPhanLoai.SelectedValue.ToString();
            // Thực hiện thêm
            if (HangHoa_BUS.ThemSua(sua) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            HienDSHangHoa();
            MessageBox.Show("Đã thêm sữa thành công!");
        }
        private void btnBoQua_Click_1(object sender, EventArgs e)
        {
            frmHangHoa_Load(sender, e);
        }
        private void btnTim_Click_1(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập nội dung tìm kiếm");
            }
            else
            {
                List<HangHoa_DTO> kq = HangHoa_BUS.TimKiemHangHoa(txtTimKiem.Text);// tìm kiếm theo mã, tên, ghi chú
                dgv.DataSource = kq;
            }
        }
        private void btnDong_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }
    }
}
