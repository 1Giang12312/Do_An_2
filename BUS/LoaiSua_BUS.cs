using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class LoaiSua_BUS
    {
        public static List<LoaiSua_DTO> LayLoaiSua()
        {
            return LoaiSua_DAO.LayLoaiSua();
        }
        public static LoaiSua_DTO TimSuaThoeMa(string ma)
        {
            return LoaiSua_DAO.TimSuaTheoMa(ma);
        } // dùng trong phép thêm để kiểm tra trùng
        public static bool ThemLoaiSua(LoaiSua_DTO ls)
        {
            return LoaiSua_DAO.ThemLoaiSua(ls);
        }
        public static bool CapNhatLoaiSua(LoaiSua_DTO ls)
        {
            return LoaiSua_DAO.CapNhatSua(ls);
        }
        public static bool XoaLoaiSua(LoaiSua_DTO ls)
        {
            return LoaiSua_DAO.XoaLoaiSua(ls);
        }
        public static List<LoaiSua_DTO> TimKiemLoaiSua(string ma)
        {
            return LoaiSua_DAO.TimKiemLoaiSua(ma);
        }
    }
}
