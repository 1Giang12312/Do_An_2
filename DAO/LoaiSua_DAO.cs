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
    public class LoaiSua_DAO
    {
        static SqlConnection con;
        public static List<LoaiSua_DTO> LayLoaiSua()
        {
            string sTruyVan = "select * from tblLoaiSua";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<LoaiSua_DTO> lstLoaiSua = new List<LoaiSua_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LoaiSua_DTO ls = new LoaiSua_DTO();
                ls.SMaLoaiSua = dt.Rows[i]["MaLoaiSua"].ToString();
                ls.STenLoaiSua = dt.Rows[i]["TenLoaiSua"].ToString();
                lstLoaiSua.Add(ls);
            }
            return lstLoaiSua;
        }
        public static bool ThemLoaiSua(LoaiSua_DTO ls)
        {
            string sTruyVan = string.Format(@"insert into tblLoaiSua values(N'{0}',
                N'{1}')", ls.SMaLoaiSua, ls.STenLoaiSua);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static LoaiSua_DTO TimSuaTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select * from tblLoaiSua where MaLoaiSua=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // Nếu có chuyển dữ liệu thành kiểu NhanVienDTO
            LoaiSua_DTO ls = new LoaiSua_DTO();
            ls.SMaLoaiSua = dt.Rows[0]["MaLoaiSua"].ToString();
            ls.STenLoaiSua = dt.Rows[0]["TenLoaiSua"].ToString();
            DataProvider.DongKetNoi(con);
            return ls;
        } // dùng trong phép thêm để kiểm tra trùng
        public static bool CapNhatSua(LoaiSua_DTO ls)
        {
            string sTruyVan = string.Format(@"update tblLoaiSua set TenLoaiSua=N'{0}' where MaLoaiSua=N'{1}'", ls.STenLoaiSua, ls.SMaLoaiSua);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool XoaLoaiSua(LoaiSua_DTO ls)
        {
            string sTruyVan = string.Format(@"delete from tblLoaiSua where MaLoaiSua=N'{0}'", ls.SMaLoaiSua);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static List<LoaiSua_DTO> TimKiemLoaiSua(string ma)
        {
            string sTruyVan = string.Format(@"select * from tblLoaiSua where MaLoaiSua LIKE N'%{0}%'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<LoaiSua_DTO> lstLoaiSua = new List<LoaiSua_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LoaiSua_DTO ls = new LoaiSua_DTO();
                ls.SMaLoaiSua = dt.Rows[i]["MaLoaiSua"].ToString();
                ls.STenLoaiSua = dt.Rows[i]["TenLoaiSua"].ToString();
                lstLoaiSua.Add(ls);
            }
            return lstLoaiSua;
        }
    }
}
