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
    public class HoaDonBan_DAO
    {
        static SqlConnection con;
        //thêm hóa đơn mới
        public static HoaDonBan_DTO TimHangHoaTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select * from TblHDBanSua where MaHDBan=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            HoaDonBan_DTO hd = new HoaDonBan_DTO();
            hd.SMaHoaDonBan = dt.Rows[0]["MaHDBan"].ToString();
            hd.SMaNhanVien = dt.Rows[0]["MaNhanVien"].ToString();
            hd.DtNgayBan = DateTime.Parse(dt.Rows[0]["NgayBan"].ToString());
            hd.SMaKhachHang = dt.Rows[0]["MaKhachHang"].ToString();
            hd.FTongTien = float.Parse(dt.Rows[0]["TongTien"].ToString());
            DataProvider.DongKetNoi(con);
            return hd;
        }
        public static bool ThemHDBan(HoaDonBan_DTO hd)
        {
            string sTruyVan = string.Format(@"insert into TblHDBanSua values(N'{0}',
                N'{1}',N'{2}',N'{3}',N'{4}')",hd.SMaHoaDonBan,hd.SMaNhanVien,hd.DtNgayBan,hd.SMaKhachHang,hd.FTongTien);

           // string sTruyVan = string.Format(@"insert into TblKhachHang values(N'{0}',
               // N'{1}',N'{2}',N'{3}',N'{4}')", kh.SMaKhachHang, kh.STenKhachHang, kh.SDiaChi, kh.SDienThoai, kh.SEmail);

            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        //lấy tiền từ trong database ra
        public static HoaDonBan_DTO LayTienTheoMa(string maHD)
        {
            string sTruyVan = string.Format(@"select TongTien from TblHDBanSua where MaHDBan=N'{0}'", maHD);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            HoaDonBan_DTO tt = new HoaDonBan_DTO();
            tt.FTongTien = int.Parse(dt.Rows[0]["TongTien"].ToString());
            DataProvider.DongKetNoi(con);
            return tt;
        }
        //update tiền
        public static bool CapNhatTien(HoaDonBan_DTO hd)
        {
            string sTruyVan = string.Format(@"update TblHDBanSua set TongTien=N'{0}' where MaHDBan=N'{1}'", hd.FTongTien,hd.SMaHoaDonBan);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        //hiện HD bán
        public static List<HoaDonBan_DTO> LayHoaDonBan()
        {
            string sTruyVan = "select * from TblHDBanSua";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<HoaDonBan_DTO> lsthdb = new List<HoaDonBan_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HoaDonBan_DTO hd = new HoaDonBan_DTO();
                hd.SMaHoaDonBan = dt.Rows[i]["MaHDBan"].ToString();
                hd.SMaNhanVien = dt.Rows[i]["MaNhanVien"].ToString();
                hd.DtNgayBan = DateTime.Parse(dt.Rows[i]["NgayBan"].ToString());
                hd.SMaKhachHang = dt.Rows[i]["MaKhachHang"].ToString();
                hd.FTongTien = float.Parse(dt.Rows[i]["TongTien"].ToString());
                lsthdb.Add(hd);
            }
            DataProvider.DongKetNoi(con);
            return lsthdb;
        }
        public static List<HoaDonBan_DTO> TimKiemHD(string ma)
        {
            string sTruyVan = string.Format(@"select * from TblHDBanSua where MaKhachHang LIKE N'%{0}%' or MaNhanVien LIKE N'%{0}%'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<HoaDonBan_DTO> lsthdb = new List<HoaDonBan_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HoaDonBan_DTO hd = new HoaDonBan_DTO();
                hd.SMaHoaDonBan = dt.Rows[i]["MaHDBan"].ToString();
                hd.SMaNhanVien = dt.Rows[i]["MaNhanVien"].ToString();
                hd.DtNgayBan = DateTime.Parse(dt.Rows[i]["NgayBan"].ToString());
                hd.SMaKhachHang = dt.Rows[i]["MaKhachHang"].ToString();
                hd.FTongTien = float.Parse(dt.Rows[i]["TongTien"].ToString());
                lsthdb.Add(hd);
            }
            DataProvider.DongKetNoi(con);
            return lsthdb;
        }
        public static bool XoaHD(HoaDonBan_DTO hd)
        {
            string sTruyVan = string.Format(@"delete from TblHDBanSua where MaHDBan=N'{0}'", hd.SMaHoaDonBan);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        // lấy mã HD đầu tiên
        public static HoaDonBan_DTO LayHDBanDauTien()
        {
            string sTruyVan = string.Format(@"select top(1) * from TblHDBanSua order by MaHDBan desc");
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            HoaDonBan_DTO hd = new HoaDonBan_DTO();
            hd.SMaHoaDonBan = dt.Rows[0]["MaHDBan"].ToString();
            hd.SMaNhanVien = dt.Rows[0]["MaNhanVien"].ToString();
            hd.DtNgayBan = DateTime.Parse(dt.Rows[0]["NgayBan"].ToString());
            hd.SMaKhachHang = dt.Rows[0]["MaKhachHang"].ToString();
            hd.FTongTien = float.Parse(dt.Rows[0]["TongTien"].ToString());
            DataProvider.DongKetNoi(con);
            return hd;
        }
        public static bool KiemTraTongTien()
        {
            //nếu tổng tiền =0 thì xóa
            string sTruyVan = string.Format(@"delete TblHDBanSua where TongTien=0");
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static HoaDonBan_DTO TongHoaDonBan()
        {
            string sTruyVan = string.Format(@"select sum(TongTien) as TongTien from TblHDBanSua");
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            HoaDonBan_DTO tt = new HoaDonBan_DTO();
            tt.FTongTien = int.Parse(dt.Rows[0]["TongTien"].ToString());
            DataProvider.DongKetNoi(con);
            return tt;
        }
    }
}
