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
    public class KhachHang_DAO
    {
        static SqlConnection con;
        public static List<KhachHang_DTO> LayKhachHang()
        {
            string sTruyVan = "select * from TblKhachHang";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<KhachHang_DTO> lstkh = new List<KhachHang_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                KhachHang_DTO kh = new KhachHang_DTO();
                kh.SMaKhachHang = dt.Rows[i]["MaKhachHang"].ToString();
                kh.STenKhachHang = dt.Rows[i]["TenKhachHang"].ToString();
                kh.SDiaChi = dt.Rows[i]["DiaChi"].ToString();
                kh.SDienThoai = dt.Rows[i]["DienThoai"].ToString();
                kh.SEmail = dt.Rows[i]["Email"].ToString();

                lstkh.Add(kh);
            }
            DataProvider.DongKetNoi(con);
            return lstkh;
        }
        public static bool ThemKhachHang(KhachHang_DTO kh)
        {
            string sTruyVan = string.Format(@"insert into TblKhachHang values(N'{0}',
                N'{1}',N'{2}',N'{3}',N'{4}')", kh.SMaKhachHang,kh.STenKhachHang,kh.SDiaChi,kh.SDienThoai,kh.SEmail);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static KhachHang_DTO TimKhachHangTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select * from TblKhachHang where MaKhachHang=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // Nếu có chuyển dữ liệu thành kiểu NhanVienDTO
            KhachHang_DTO kh = new KhachHang_DTO();
            kh.SMaKhachHang = dt.Rows[0]["MaKhachHang"].ToString();
            kh.STenKhachHang = dt.Rows[0]["TenKhachHang"].ToString();
            kh.SDiaChi = dt.Rows[0]["DiaChi"].ToString();
            kh.SDienThoai = dt.Rows[0]["DienThoai"].ToString();
            kh.SEmail = dt.Rows[0]["Email"].ToString();
            DataProvider.DongKetNoi(con);
            return kh;
        } // dùng trong phép thêm để kiểm tra trùng
        public static bool XoaKH(KhachHang_DTO kh)
        {
            string sTruyVan = string.Format(@"delete from TblKhachHang where MaKhachHang=N'{0}'", kh.SMaKhachHang);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool CapNhatKH(KhachHang_DTO kh)
        {
            string sTruyVan = string.Format(@"update TblKhachHang set TenKhachHang=N'{0}'
                                    ,DiaChi=N'{1}'
                                     ,DienThoai=N'{2}'
                                     ,Email=N'{3}'
                                    where MaKhachHang=N'{4}'", 
                            kh.STenKhachHang, kh.SDiaChi,kh.SDienThoai,kh.SEmail,kh.SMaKhachHang);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static List<KhachHang_DTO> TimKiemKH(string ma)
        {
            string sTruyVan = string.Format(@"select * from TblKhachHang where MaKhachHang LIKE N'%{0}%' or TenKhachHang LIKE N'%{0}%'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<KhachHang_DTO> lstkh = new List<KhachHang_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                KhachHang_DTO kh = new KhachHang_DTO();
                kh.SMaKhachHang = dt.Rows[i]["MaKhachHang"].ToString();
                kh.STenKhachHang = dt.Rows[i]["TenKhachHang"].ToString();
                kh.SDiaChi = dt.Rows[i]["DiaChi"].ToString();
                kh.SDienThoai = dt.Rows[i]["DienThoai"].ToString();
                kh.SEmail = dt.Rows[i]["Email"].ToString();
                lstkh.Add(kh);
            }
            DataProvider.DongKetNoi(con);
            return lstkh;
        }
        public static int DemKhachHang()
        {
            string sTruyVan = string.Format(@"select * from TblKhachHang");
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            return dt.Rows.Count;
        }
    }
}
