using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class KhachHang_BUS
    {
        public static List<KhachHang_DTO> LayKhachHang()
        {
            return KhachHang_DAO.LayKhachHang();
        }
        public static KhachHang_DTO TimKhachHangTheoMa(string ma)
        {
            return KhachHang_DAO.TimKhachHangTheoMa(ma);
        }
        public static bool ThemKH(KhachHang_DTO kh)
        {
            return KhachHang_DAO.ThemKhachHang(kh);
        }
        public static bool XoaKhachHang(KhachHang_DTO kh)
        {
            return KhachHang_DAO.XoaKH(kh);
        }
        public static bool CapNhaKH(KhachHang_DTO kh)
        {
            return KhachHang_DAO.CapNhatKH(kh);
        }
        public static List<KhachHang_DTO> TimKiemKH(string ma)
        {
            return KhachHang_DAO.TimKiemKH(ma);
        }
        public static int DemKhachHang()
        {
            return KhachHang_DAO.DemKhachHang();
        }
    }
}
