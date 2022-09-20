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
    public class TaiKhoan_DAO
    {
        static SqlConnection con;
        //lấy combobox với những nhân viên chưa tạo tài khoản
        public static List<NhanVien_DTO> LayCombobox()
        {
            string sTruyVan = @"select * from TblNhanVien nv left join  TblTaiKhoan tk on nv.MaNhanVien = tk.MaNhanVien Where tk.MaNhanVien is null";
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
        public static List<TaiKhoan_DTO> LayTaiKhoan()
        {
            string sTruyVan = "select * from TblTaiKhoan";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<TaiKhoan_DTO> lstTK = new List<TaiKhoan_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TaiKhoan_DTO tk = new TaiKhoan_DTO();
                tk.SMaNhanVien = dt.Rows[i]["MaNhanVien"].ToString();
                tk.SHoTen = dt.Rows[i]["TenNhanVien"].ToString();
                tk.STenDangNhap = dt.Rows[i]["TenDangNhap"].ToString();
                tk.SMatKhau = dt.Rows[i]["MatKhau"].ToString();
                tk.IQuyenHan = int.Parse(dt.Rows[i]["QuyenHan"].ToString());
                tk.SGhiChu = dt.Rows[i]["GhiChu"].ToString();
                lstTK.Add(tk);
            }
            return lstTK;
        }
        public static bool ThemTaiKhoan(TaiKhoan_DTO tk)
        {
            
            string sTruyVan = string.Format(@"insert into TblTaiKhoan values(N'{0}',
                N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')",tk.SMaNhanVien,tk.SHoTen,tk.STenDangNhap,tk.SMatKhau,tk.IQuyenHan,tk.SGhiChu);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
       
        public static TaiKhoan_DTO TimTaiKhoanTheoMa(string manv,string tendn)
        {
            string sTruyVan = string.Format(@"select * from TblTaiKhoan where MaNhanVien=N'{0}' or TenDangNhap=N'{1}'", manv,tendn);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // Nếu có chuyển dữ liệu thành kiểu NhanVienDTO
            TaiKhoan_DTO tk = new TaiKhoan_DTO();
            tk.SMaNhanVien = dt.Rows[0]["MaNhanVien"].ToString();
            tk.SHoTen = dt.Rows[0]["TenNhanVien"].ToString();
            tk.STenDangNhap = dt.Rows[0]["TenDangNhap"].ToString();
            tk.SGhiChu = dt.Rows[0]["GhiChu"].ToString();
            tk.SMatKhau = dt.Rows[0]["MatKhau"].ToString();
            tk.IQuyenHan = int.Parse(dt.Rows[0]["QuyenHan"].ToString());
            DataProvider.DongKetNoi(con);
            return tk;
        } // dùng trong phép thêm để kiểm tra trùng
        public static TaiKhoan_DTO TimTaiKhoanTheoTenDangNhap(string ma)
        {
            string sTruyVan = string.Format(@"select * from TblTaiKhoan where TenDangNhap=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // Nếu có chuyển dữ liệu thành kiểu NhanVienDTO
            TaiKhoan_DTO tk = new TaiKhoan_DTO();
            tk.SMaNhanVien = dt.Rows[0]["MaNhanVien"].ToString();
            tk.SHoTen = dt.Rows[0]["TenNhanVien"].ToString();
            tk.STenDangNhap = dt.Rows[0]["TenDangNhap"].ToString();
            tk.SGhiChu = dt.Rows[0]["GhiChu"].ToString();
            tk.SMatKhau = dt.Rows[0]["MatKhau"].ToString();
            tk.IQuyenHan = int.Parse(dt.Rows[0]["QuyenHan"].ToString());
            DataProvider.DongKetNoi(con);
            return tk;
        } // dùng trong phép thêm để kiểm tra trùng
        public static bool CapNhatTaiKhoan(TaiKhoan_DTO tk)
        {
            string sTruyVan = string.Format(@"update TblTaiKhoan set TenNhanVien=N'{0}',
                                            MatKhau=N'{1}',
                                            QuyenHan=N'{2}',
                                            GhiChu =N'{3}'
                                            where MaNhanVien =N'{4}' and TenDangNhap=N'{5}'"
                                , tk.SHoTen,tk.SMatKhau,tk.IQuyenHan,tk.SGhiChu,tk.SMaNhanVien,tk.STenDangNhap);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool XoaTaiKhoan(TaiKhoan_DTO tk)
        {
            string sTruyVan = string.Format(@"delete from TblTaiKhoan where MaNhanVien=N'{0}'", tk.SMaNhanVien);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static List<TaiKhoan_DTO> TimKiemTaiKhoan(string ma)
        {
            string sTruyVan = string.Format(@"select * from TblTaiKhoan where TenDangNhap LIKE N'%{0}%' or TenNhanVien LIKE N'%{0}%'", ma);//tìm theo mã và theo tên nhân viên
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<TaiKhoan_DTO> lstTK = new List<TaiKhoan_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TaiKhoan_DTO tk = new TaiKhoan_DTO();
                tk.SMaNhanVien = dt.Rows[i]["MaNhanVien"].ToString();
                tk.SHoTen = dt.Rows[i]["TenNhanVien"].ToString();
                tk.STenDangNhap = dt.Rows[i]["TenDangNhap"].ToString();
                tk.SMatKhau = dt.Rows[i]["MatKhau"].ToString();
                tk.IQuyenHan = int.Parse(dt.Rows[i]["QuyenHan"].ToString());
                tk.SGhiChu = dt.Rows[i]["GhiChu"].ToString();
                lstTK.Add(tk);
            }
            return lstTK;
        }

        //lấy tài khoản để đăng nhập
        public static TaiKhoan_DTO LayTaiKhoanDangNhap(string sTen, string sMatKhau)
        {
            string sTruyVan = string.Format("select * from TblTaiKhoan where TenDangNhap=N'{0}' and MatKhau='{1}'", sTen, sMatKhau);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            TaiKhoan_DTO tk = new TaiKhoan_DTO();
            tk.SMaNhanVien = dt.Rows[0]["MaNhanVien"].ToString();
            tk.SHoTen = dt.Rows[0]["TenNhanVien"].ToString();
            tk.STenDangNhap = dt.Rows[0]["TenDangNhap"].ToString();
            tk.SGhiChu = dt.Rows[0]["GhiChu"].ToString();
            tk.SMatKhau = dt.Rows[0]["MatKhau"].ToString();
            tk.IQuyenHan = int.Parse(dt.Rows[0]["QuyenHan"].ToString());
            DataProvider.DongKetNoi(con);
            return tk;
        }
        public static bool CapNhatMK(TaiKhoan_DTO tk)
        {
            string sTruyVan = string.Format(@"update TblTaiKhoan set MatKhau=N'{0}' where MaNhanVien=N'{1}'",tk.SMatKhau,tk.SMaNhanVien);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool CapNhatMKTheoTenDangNhap(TaiKhoan_DTO tk)
        {
            string sTruyVan = string.Format(@"update TblTaiKhoan set MatKhau=N'{0}' where TenDangNhap=N'{1}'", tk.SMatKhau, tk.STenDangNhap);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
