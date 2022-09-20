using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class HangHoa_BUS
    {
        public static List<HangHoa_DTO> LayHangHoa()
        {
            return HangHoa_DAO.LayHangHoa();
        }
        //lấy hàng hóa có số lượng >0
        public static List<HangHoa_DTO> LayHHCoSLLH0()
        {
            return HangHoa_DAO.LayHangHoaCoSLLH0();
        }
        public static bool ThemSua(HangHoa_DTO sua)
        {
            return HangHoa_DAO.ThemSua(sua);
        }
        public static HangHoa_DTO TimHangHoaTheoMa(string ma)
        {
            return HangHoa_DAO.TimHangHoaThemMa(ma);
        }
        public static bool XoaSua(HangHoa_DTO sua)
        {
            return HangHoa_DAO.XoaSua(sua);
        }
        public static bool CapNhatHangHoa(HangHoa_DTO sua)
        {
            return HangHoa_DAO.CapNhatHangHoa(sua);
        }
        public static List<HangHoa_DTO> TimKiemHangHoa(string ma)
        {
            return HangHoa_DAO.TimKiemSua(ma);
        }
        public static bool KiemTraHanSuDung()
        {
            return HangHoa_DAO.KiemTraHanSuDung();
        }
        public static int DemHangHoa()
        {
            return HangHoa_DAO.DemHangHoa();
        }
       
    }
}
