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
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            ResponsiveEnd();
        }
        //Maximize & Restore "Event"
        const int WM_SYSCOMMAND = 0x0112;
        const int SC_MAXIMIZE = 0xF030;
        const int SC_RESTORE = 0xF120;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_SYSCOMMAND)
            {
                if (m.WParam == (IntPtr)SC_MAXIMIZE || m.WParam == (IntPtr)SC_RESTORE)
                    this.OnResizeEnd(EventArgs.Empty);
            }
        }
        //Responsive Form Finish Method
        private void ResponsiveEnd()
        {

           
            if (this.Height <= 775)
            {
                panel8.Height = 290;
            }
            else
            {
                panel8.Height = panel7.Height;
            }
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            ResponsiveEnd();
            using(QLBanSuaEntities db = new QLBanSuaEntities())
            {
                chart3.DataSource = db.TblHDBanSuas.ToList();
                chart3.Series["DoanhSo"].XValueMember = "NgayBan";
                chart3.Series["DoanhSo"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
                chart3.Series["DoanhSo"].YValueMembers = "TongTien";
                chart3.Series["DoanhSo"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            }
            lbNhanVien.Text = NhanVien_BUS.DemNhanVien().ToString();
            lbKhachHang.Text = KhachHang_BUS.DemKhachHang().ToString();
            lbSanPham.Text = HangHoa_BUS.DemHangHoa().ToString();
            HoaDonBan_DTO hd = new HoaDonBan_DTO();
            hd = HoaDonBan_BUS.TongHoaDonBan();
            float tongtien = hd.FTongTien /1000000;
            lbTongTien.Text= tongtien.ToString() +" triệu";
            HienThiChartPL();
            HienLS();
        }
        private void HienThiChartPL()
        {
            List<ThongKePL_DTO> lst = ThongKePL_BUS.LayTKPL();
            ChartPiePL.DataSource = lst;
            for (int i = 0; i < lst.Count; i++)
            {
                ChartPiePL.Series[0].XValueMember = "TenPhanLoai";
                ChartPiePL.Series[0].YValueMembers = "SoLuong";
                //ChartPiePL.Series[0].Points[i].Label = lst[i].SoLuong.ToString();
            }
        }
        private void HienLS()
        {
            List<LoaiSua_DTO> lstLoaiSua = LoaiSua_BUS.LayLoaiSua();
            dgv.DataSource = lstLoaiSua;
            if (lstLoaiSua == null)
                return;
            dgv.Columns["SMaLoaiSua"].HeaderText = "Mã loại sữa";
            dgv.Columns["STenLoaiSua"].HeaderText = "Tên loại sữa";
        }
    }
}
