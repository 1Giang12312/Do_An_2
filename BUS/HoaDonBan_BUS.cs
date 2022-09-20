using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class HoaDonBan_BUS
    {
        public static bool ThemHDBan(HoaDonBan_DTO hd)
        {
            return HoaDonBan_DAO.ThemHDBan(hd);
        }
        public static HoaDonBan_DTO TimHDTheoMa(string ma)
        {
            return HoaDonBan_DAO.TimHangHoaTheoMa(ma);
        }
        public static bool CapNhatTien(HoaDonBan_DTO hd)
        {
            return HoaDonBan_DAO.CapNhatTien(hd);
        }
        public static List<HoaDonBan_DTO> LayHoaDonBan()
        {
            return HoaDonBan_DAO.LayHoaDonBan();
        }
        public static List<HoaDonBan_DTO> TimHDBan(string ma)
        {
            return HoaDonBan_DAO.TimKiemHD(ma);
        }
        public static bool XoaHD(HoaDonBan_DTO hd)
        {
            return HoaDonBan_DAO.XoaHD(hd);
        }
        public static HoaDonBan_DTO LayHDBanDauTien()
        {
            return HoaDonBan_DAO.LayHDBanDauTien();
        }
        public static bool KiemTraTongTien()
        {
            return HoaDonBan_DAO.KiemTraTongTien();
        }
        public static HoaDonBan_DTO TongHoaDonBan()
        {
            return HoaDonBan_DAO.TongHoaDonBan();
        }
    }
}
