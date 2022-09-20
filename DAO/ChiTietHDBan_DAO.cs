using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class ChiTietHDBan_DAO
    {
        static SqlConnection con;
        //thêm chi tiết hóa đơn
        // không cần kiểm tra trùng mã hóa đơn bán(MaHDBan)
        public static List<ChiTietHDBan_DTO> LayChiTietHDTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select a.*,b.TenSua from TblChiTietHDBanSua a,TblSua b where a.MaHDBan=N'{0}' and a.MaSua = b.MaSua", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<ChiTietHDBan_DTO> lstct = new List<ChiTietHDBan_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChiTietHDBan_DTO ct = new ChiTietHDBan_DTO();
                ct.SMaHoaDonBan = dt.Rows[i]["MaHDBan"].ToString();
                ct.SMaSua = dt.Rows[i]["MaSua"].ToString();
                ct.ISoLuong = int.Parse(dt.Rows[i]["SoLuong"].ToString());
                ct.FDonGia = float.Parse(dt.Rows[i]["DonGia"].ToString());
                ct.FGiamGia = float.Parse(dt.Rows[i]["GiamGia"].ToString());
                ct.FThanhTien = float.Parse(dt.Rows[i]["ThanhTien"].ToString());
                ct.STenSua = dt.Rows[i]["TenSua"].ToString();
                lstct.Add(ct);
            }
            DataProvider.DongKetNoi(con);
            return lstct;
        }
        public static ChiTietHDBan_DTO LayHDBan(string ma)
        {
            string sTruyVan = string.Format(@"select a.*,b.TenSua from TblChiTietHDBanSua a,TblSua b where a.MaHDBan=N'{0}' and a.MaSua = b.MaSua", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
                ChiTietHDBan_DTO ct = new ChiTietHDBan_DTO();
                ct.SMaHoaDonBan = dt.Rows[0]["MaHDBan"].ToString();
                ct.SMaSua = dt.Rows[0]["MaSua"].ToString();
                ct.ISoLuong = int.Parse(dt.Rows[0]["SoLuong"].ToString());
                ct.FDonGia = float.Parse(dt.Rows[0]["DonGia"].ToString());
                ct.FGiamGia = float.Parse(dt.Rows[0]["GiamGia"].ToString());
                ct.FThanhTien = float.Parse(dt.Rows[0]["ThanhTien"].ToString());
                ct.STenSua = dt.Rows[0]["TenSua"].ToString();
            DataProvider.DongKetNoi(con);
            return ct;
        }
        public static bool ThemChiTietHDBan(ChiTietHDBan_DTO ct)
        {
            string sTruyVan = string.Format(@"insert into TblChiTietHDBanSua values(N'{0}',
                N'{1}',N'{2}',N'{3}','{4}',N'{5}')", ct.SMaHoaDonBan, ct.SMaSua, ct.ISoLuong, ct.FDonGia, ct.FGiamGia, ct.FThanhTien);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        //xóa chi tiết hóa đơn
        public static bool XoaChiTietHDBan(ChiTietHDBan_DTO ct)
        {
            string sTruyVan = string.Format(@"delete from TblChiTietHDBanSua where MaSua=N'{0}'", ct.SMaSua);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        //kiểm tra trùng trong chi tiết hóa đơn(ChiTietHDBan)
        //mã sữa trùng trong chi tiết
        public static ChiTietHDBan_DTO TimMaHDBanTheoMa(string MaHD, string MaSua)
        {
            string sTruyVan = string.Format(@"select * from TblChiTietHDBanSua where MaHDBan=N'{0}' and MaSua=N'{1}'", MaHD, MaSua);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // Nếu có chuyển dữ liệu thành kiểu NhanVienDTO
            ChiTietHDBan_DTO ct = new ChiTietHDBan_DTO();
            ct.SMaHoaDonBan = dt.Rows[0]["MaHDBan"].ToString();
            ct.SMaSua = dt.Rows[0]["MaSua"].ToString();
            ct.ISoLuong = int.Parse(dt.Rows[0]["SoLuong"].ToString());
            ct.FDonGia = float.Parse(dt.Rows[0]["DonGia"].ToString());
            ct.FGiamGia = float.Parse(dt.Rows[0]["GiamGia"].ToString());
            ct.FThanhTien = float.Parse(dt.Rows[0]["ThanhTien"].ToString());
            DataProvider.DongKetNoi(con);
            return ct;
        }
        //cập nhật số lượng
        public static bool CapNhatSoLuong(HangHoa_DTO sua)
        {
            string sTruyVan = string.Format(@"update TblSua set SoLuong=N'{0}'
                                                where MaSua='{1}'",
              sua.ISoLuong,sua.SMaSua);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool CapNhatChiTietHDBan(ChiTietHDBan_DTO ct)
        {
            string sTruyVan = string.Format(@"update TblChiTietHDBanSua set SoLuong=N'{0}',
                                                                        GiamGia=N'{1}',
                                                                        ThanhTien=N'{2}'
                                                                        where MaHDBan='{3}'",
               ct.ISoLuong,ct.FGiamGia,ct.FThanhTien,ct.SMaHoaDonBan);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;  
        }
        
     
    }
}
