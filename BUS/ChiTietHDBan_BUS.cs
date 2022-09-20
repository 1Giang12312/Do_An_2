using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class ChiTietHDBan_BUS
    {
        public static bool ThemChiTietHDBan(ChiTietHDBan_DTO ct)
        {
            return ChiTietHDBan_DAO.ThemChiTietHDBan(ct);
        }
        public static bool XoaChiTietHDBan(ChiTietHDBan_DTO ct)
        {
            return ChiTietHDBan_DAO.XoaChiTietHDBan(ct);
        }
        public static List<ChiTietHDBan_DTO> LayChiTietHDBan(string ma)
        {
            return ChiTietHDBan_DAO.LayChiTietHDTheoMa(ma);
        }
        public static ChiTietHDBan_DTO TimChiTietHDBanTheoMa(string mahd,string masua)
        {
            return ChiTietHDBan_DAO.TimMaHDBanTheoMa(mahd, masua);
        }
        public static bool CapNhatSoLuong(HangHoa_DTO sua)
        {
            return ChiTietHDBan_DAO.CapNhatSoLuong(sua);
        }
        public static bool CapNhatChiTietHDBan(ChiTietHDBan_DTO sua)
        {
            return ChiTietHDBan_DAO.CapNhatChiTietHDBan(sua);
        }
        public static ChiTietHDBan_DTO LayHDBan(string ma)
        {
            return ChiTietHDBan_DAO.LayHDBan(ma);
        }
    }
}
