using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class ThongKePL_DAO
    {
        static SqlConnection conn;
        public static List<ThongKePL_DTO> LayTKPL()
        {
            string sql = @"select sum(a.SoLuong) as Tong, b.TenSua  from TblChiTietHDBanSua a ,TblSua b where a.MaSua = b.MaSua group by b.TenSua";
            conn = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sql, conn);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<ThongKePL_DTO> lstHoaDon = new List<ThongKePL_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ThongKePL_DTO hd = new ThongKePL_DTO();
                hd.TenPhanLoai = dt.Rows[i]["TenSua"].ToString();
                hd.SoLuong = int.Parse(dt.Rows[i]["Tong"].ToString());
                lstHoaDon.Add(hd);
            }
            conn.Close();
            return lstHoaDon;
        }
    }
}
