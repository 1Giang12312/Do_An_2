using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang_DTO
    {
        string sMaKhachHang;
        string sTenKhachHang;
        string sDiaChi;
        string sEmail;
        string sDienThoai;

        public string SMaKhachHang { get => sMaKhachHang; set => sMaKhachHang = value; }
        public string STenKhachHang { get => sTenKhachHang; set => sTenKhachHang = value; }
        public string SDiaChi { get => sDiaChi; set => sDiaChi = value; }
        public string SEmail { get => sEmail; set => sEmail = value; }
        public string SDienThoai { get => sDienThoai; set => sDienThoai = value; }
    }
}
