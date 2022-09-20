using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Security.Cryptography;

namespace BUS
{
    public class TaiKhoan_BUS
    {
        //lấy nhân viên combobox
        public static List<NhanVien_DTO> LayNhanVienCombobox()
        {
            return TaiKhoan_DAO.LayCombobox();
        }
        public static List<TaiKhoan_DTO> LayTaiKhoan()
        {
            return TaiKhoan_DAO.LayTaiKhoan();
        }
        public static bool ThemTaiKhoan(TaiKhoan_DTO tk)
        {
            return TaiKhoan_DAO.ThemTaiKhoan(tk);
        }
        public static TaiKhoan_DTO TimTaiKhoanTheoMa(string manv,string tendn)
        {
            return TaiKhoan_DAO.TimTaiKhoanTheoMa(manv,tendn);
        }
        public static TaiKhoan_DTO TimTaiKhoanTheoTenDangNhap(string tendn)
        {
            return TaiKhoan_DAO.TimTaiKhoanTheoTenDangNhap(tendn);
        }
        public static bool CapNhatTaiKhoan(TaiKhoan_DTO tk)
        {
            return TaiKhoan_DAO.CapNhatTaiKhoan(tk);
        }
        public static bool XoaTaiKhoan(TaiKhoan_DTO tk)
        {
            return TaiKhoan_DAO.XoaTaiKhoan(tk);
        }
        public static List<TaiKhoan_DTO> TimKiemTaiKhoan(string ma)
        {
            return TaiKhoan_DAO.TimKiemTaiKhoan(ma);
        }
        public static string GetMD5Hash(MD5 md5hash, string input)
        {
            byte[] data = md5hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString();
        }
        public static TaiKhoan_DTO KiemTraTaiKhoan(string sten, string smatkhau)
        {
            MD5 hashmd5 = MD5.Create();
            string MatKhauMH = TaiKhoan_BUS.GetMD5Hash(hashmd5, smatkhau);
            return TaiKhoan_DAO.LayTaiKhoanDangNhap(sten, MatKhauMH);
        }
        public static bool CapNhatMatKhau(TaiKhoan_DTO tk)
        {
            MD5 hashmd5 = MD5.Create();
            string MatKhauMH = TaiKhoan_BUS.GetMD5Hash(hashmd5, tk.SMatKhau);
            tk.SMatKhau = MatKhauMH;
            return TaiKhoan_DAO.CapNhatMK(tk);
        }
        public static bool CapNhatMKTheoTenDangNhap(TaiKhoan_DTO tk)
        {
            MD5 hashmd5 = MD5.Create();
            string MatKhauMH = TaiKhoan_BUS.GetMD5Hash(hashmd5, tk.SMatKhau);
            tk.SMatKhau = MatKhauMH;
            return TaiKhoan_DAO.CapNhatMKTheoTenDangNhap(tk);
        }
      
    }
}
