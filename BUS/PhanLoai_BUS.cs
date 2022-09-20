using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class PhanLoai_BUS
    {
        public static List<PhanLoai_DTO> LayPhanLoai()
        {
            return PhanLoai_DAO.LayPhanLoai();
        }
        public static PhanLoai_DTO TimPhanLoaiTheoMa(string ma)
        {
            return PhanLoai_DAO.TimPhanLoaiTheoMa(ma);
        } // dùng trong phép thêm để kiểm tra trùng
        public static bool ThemPhanLoai(PhanLoai_DTO pl)
        {
            return PhanLoai_DAO.ThemPhanLoai(pl);
        }
        public static bool CapNhatPhanLoai(PhanLoai_DTO pl)
        {
            return PhanLoai_DAO.CapNhatPhanLoai(pl);
        }
        public static bool XoaPhanLoai(PhanLoai_DTO pl)
        {
            return PhanLoai_DAO.XoaPhanLoai(pl);
        }
        public static List<PhanLoai_DTO> TimKiemPhanLoai(string ma)//tìm theo tên
        {
            return PhanLoai_DAO.TimKiemPhanLoai(ma);
        }
    }
}
