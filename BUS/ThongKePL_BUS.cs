using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class ThongKePL_BUS
    {
        public static List<ThongKePL_DTO> LayTKPL()
        {
            return ThongKePL_DAO.LayTKPL();
        }
    }
}
