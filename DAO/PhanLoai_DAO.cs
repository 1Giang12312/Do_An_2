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
    public class PhanLoai_DAO
    {
            static SqlConnection con;
            public static List<PhanLoai_DTO> LayPhanLoai()
            {
                string sTruyVan = "select * from TblPhanLoai";
                con = DataProvider.MoKetNoi();
                DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                List<PhanLoai_DTO> lstPhanLoai = new List<PhanLoai_DTO>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PhanLoai_DTO pl = new PhanLoai_DTO();
                    pl.SMaPhanLoai= dt.Rows[i]["MaPhanLoai"].ToString();
                    pl.STenPhanLoai = dt.Rows[i]["TenPhanLoai"].ToString();
                    lstPhanLoai.Add(pl);
                }
                return lstPhanLoai;
            }
            public static bool ThemPhanLoai(PhanLoai_DTO pl)
            {
                string sTruyVan = string.Format(@"insert into TblPhanLoai values(N'{0}',
                N'{1}')", pl.SMaPhanLoai,pl.STenPhanLoai);
                con = DataProvider.MoKetNoi();
                bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return kq;
            }
            public static PhanLoai_DTO TimPhanLoaiTheoMa(string ma)
            {
                string sTruyVan = string.Format(@"select * from TblPhanLoai where MaPhanLoai=N'{0}'", ma);
                con = DataProvider.MoKetNoi();
                DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                // Nếu có chuyển dữ liệu thành kiểu NhanVienDTO
                PhanLoai_DTO pl = new PhanLoai_DTO();
                pl.SMaPhanLoai = dt.Rows[0]["MaPhanLoai"].ToString();
                pl.STenPhanLoai = dt.Rows[0]["TenPhanLoai"].ToString();
                DataProvider.DongKetNoi(con);
                return pl;
            } // dùng trong phép thêm để kiểm tra trùng
            public static bool CapNhatPhanLoai(PhanLoai_DTO pl)
            {
                string sTruyVan = string.Format(@"update TblPhanLoai set TenPhanLoai=N'{0}' where MaPhanLoai=N'{1}'", pl.STenPhanLoai, pl.SMaPhanLoai); ;
                con = DataProvider.MoKetNoi();
                bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return kq;
            }
            public static bool XoaPhanLoai(PhanLoai_DTO pl)
            {
                string sTruyVan = string.Format(@"delete from TblPhanLoai where MaPhanLoai=N'{0}'", pl.SMaPhanLoai);
                con = DataProvider.MoKetNoi();
                bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return kq;
            }
            public static List<PhanLoai_DTO> TimKiemPhanLoai(string ma)
            {
                string sTruyVan = string.Format(@"select * from TblPhanLoai where TenPhanLoai LIKE N'%{0}%' or MaPhanLoai LIKE N'%{0}%'", ma);
                con = DataProvider.MoKetNoi();
                DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                List<PhanLoai_DTO> lstpl = new List<PhanLoai_DTO>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PhanLoai_DTO pl = new PhanLoai_DTO();
                    pl.SMaPhanLoai = dt.Rows[i]["MaPhanLoai"].ToString();
                    pl.STenPhanLoai = dt.Rows[i]["TenPhanLoai"].ToString();
                    lstpl.Add(pl);
                }
                return lstpl;
            }
        }
    }
