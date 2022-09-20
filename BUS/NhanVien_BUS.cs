using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class NhanVien_BUS
    {
        public static List<NhanVien_DTO> LayNhanVien()
        {
            return NhanVien_DAO.LayNhanVien();
        }
        public static bool ThemNhanVien(NhanVien_DTO nv)
        {
            return NhanVien_DAO.ThemNhanVien(nv);
        }
        public static NhanVien_DTO TimNhanVienTheoMa(string ma)
        {
            return NhanVien_DAO.TimNhanVienTheoMa(ma);
        }
        public static bool CapNhatNhanVien(NhanVien_DTO nv)
        {
            return NhanVien_DAO.CapNhatNhanVien(nv);
        }
        public static bool XoaNhanVien(NhanVien_DTO nv)
        {
            return NhanVien_DAO.XoaNhanVien(nv);
        }
        public static List<NhanVien_DTO> TimKiemNhanVien(string ma)
        {
            return NhanVien_DAO.TimKiemNhanVien(ma);
        }
        public static NhanVien_DTO TimNhanVienDMK(string manv, string sdt, string email)
        {
            return NhanVien_DAO.TimNhanVienDMK(manv, sdt, email);
        }
        public static int DemNhanVien()
        {
            return NhanVien_DAO.DemNhanVien();
        }
    }
}
