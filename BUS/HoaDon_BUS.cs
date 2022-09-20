using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class HoaDon_BUS
    {
        public static string TaoMaHD(string key)
        {
            return HoaDon_DAO.CreateKey(key);
        }
    }
}
