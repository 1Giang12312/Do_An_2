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
    public class NhanVien_DAO
    {
        static SqlConnection con;
        public static List<NhanVien_DTO> LayNhanVien()
        {
            string sTruyVan = "select * from TblNhanVien";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<NhanVien_DTO> lstNV = new List<NhanVien_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NhanVien_DTO nv = new NhanVien_DTO();
                nv.SMaNhanVien = dt.Rows[i]["MaNhanVien"].ToString();
                nv.STenNhanVien = dt.Rows[i]["TenNhanVien"].ToString();
                nv.SGioiTinh = dt.Rows[i]["GioiTinh"].ToString();
                nv.SDiaChi = dt.Rows[i]["DiaChi"].ToString();
                nv.SDienThoai = dt.Rows[i]["DienThoai"].ToString();
                nv.SEmail = dt.Rows[i]["Email"].ToString();
                nv.DtNgaySinh = DateTime.Parse(dt.Rows[i]["NgaySinh"].ToString());
                lstNV.Add(nv);
            }
            return lstNV;
        }
        public static bool ThemNhanVien(NhanVien_DTO nv)
        {
            string sTruyVan = string.Format(@"insert into TblNhanVien values(N'{0}',
                N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}')", nv.SMaNhanVien,nv.STenNhanVien,nv.SGioiTinh,nv.SDiaChi,nv.SDienThoai,nv.SEmail,nv.DtNgaySinh );
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static NhanVien_DTO TimNhanVienTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select * from TblNhanVien where MaNhanVien=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // Nếu có chuyển dữ liệu thành kiểu NhanVienDTO
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.SMaNhanVien = dt.Rows[0]["MaNhanVien"].ToString();
            nv.STenNhanVien = dt.Rows[0]["TenNhanVien"].ToString();
            nv.SGioiTinh = dt.Rows[0]["GioiTinh"].ToString();
            nv.SDiaChi = dt.Rows[0]["DiaChi"].ToString();
            nv.SDienThoai = dt.Rows[0]["DienThoai"].ToString();
            nv.SEmail = dt.Rows[0]["Email"].ToString();
            nv.DtNgaySinh = DateTime.Parse(dt.Rows[0]["NgaySinh"].ToString());
            DataProvider.DongKetNoi(con);
            return nv;
        } // dùng trong phép thêm để kiểm tra trùng
        public static bool CapNhatNhanVien(NhanVien_DTO nv)
        {
            string sTruyVan = string.Format(@"update TblNhanVien set TenNhanVien=N'{0}',
                                            GioiTinh=N'{1}',
                                            DiaChi=N'{2}',
                                            DienThoai=N'{3}',
                                            Email =N'{4}',
                                            NgaySinh=N'{5}'
                                            where MaNhanVien=N'{6}'"
                                , nv.STenNhanVien,nv.SGioiTinh,nv.SDiaChi,nv.SDienThoai,nv.SEmail,nv.DtNgaySinh,nv.SMaNhanVien);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool XoaNhanVien(NhanVien_DTO nv)
        {
            string sTruyVan = string.Format(@"delete from TblNhanVien where MaNhanVien=N'{0}'", nv.SMaNhanVien);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static List<NhanVien_DTO> TimKiemNhanVien(string ma)
        {
            string sTruyVan = string.Format(@"select * from TblNhanVien where MaNhanVien LIKE N'%{0}%' or TenNhanVien LIKE N'%{0}%'", ma);//tìm theo mã và theo tên nhân viên
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<NhanVien_DTO> lstNV = new List<NhanVien_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NhanVien_DTO nv = new NhanVien_DTO();
                nv.SMaNhanVien = dt.Rows[i]["MaNhanVien"].ToString();
                nv.STenNhanVien = dt.Rows[i]["TenNhanVien"].ToString();
                nv.SGioiTinh = dt.Rows[i]["GioiTinh"].ToString();
                nv.SDiaChi = dt.Rows[i]["DiaChi"].ToString();
                nv.SDienThoai = dt.Rows[i]["DienThoai"].ToString();
                nv.SEmail = dt.Rows[i]["Email"].ToString();
                nv.DtNgaySinh = DateTime.Parse(dt.Rows[i]["NgaySinh"].ToString());
                lstNV.Add(nv);
            }
            return lstNV;
        }
        //dùng trong form quên mật khẩu
        public static NhanVien_DTO TimNhanVienDMK(string manv, string sdt, string email)
        {
            string sTruyVan = string.Format(@"select * from TblNhanVien where MaNhanVien=N'{0}'and DienThoai=N'{1}' and Email=N'{2}'", manv, sdt, email);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // Nếu có chuyển dữ liệu thành kiểu NhanVienDTO
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.SMaNhanVien = dt.Rows[0]["MaNhanVien"].ToString();
            nv.STenNhanVien = dt.Rows[0]["TenNhanVien"].ToString();
            nv.SGioiTinh = dt.Rows[0]["GioiTinh"].ToString();
            nv.SDiaChi = dt.Rows[0]["DiaChi"].ToString();
            nv.SDienThoai = dt.Rows[0]["DienThoai"].ToString();
            nv.SEmail = dt.Rows[0]["Email"].ToString();
            nv.DtNgaySinh = DateTime.Parse(dt.Rows[0]["NgaySinh"].ToString());
            DataProvider.DongKetNoi(con);
            return nv;
        } // dùng trong phép thêm để kiểm tra trùng
        public static int DemNhanVien()
        {
            string sTruyVan = string.Format(@"select * from TblNhanVien");
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            return dt.Rows.Count;
        }
    }
}

