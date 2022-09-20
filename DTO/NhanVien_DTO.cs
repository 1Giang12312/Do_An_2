using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien_DTO
    {
        string sMaNhanVien;
        string sTenNhanVien;
        string sGioiTinh;
        string sDiaChi;
        string sDienThoai;
        DateTime dtNgaySinh;
        string sEmail;
        public string SMaNhanVien { get => sMaNhanVien; set => sMaNhanVien = value; }
        public string STenNhanVien { get => sTenNhanVien; set => sTenNhanVien = value; }
        public string SGioiTinh { get => sGioiTinh; set => sGioiTinh = value; }
        public string SDiaChi { get => sDiaChi; set => sDiaChi = value; }
        public string SDienThoai { get => sDienThoai; set => sDienThoai = value; }
        public DateTime DtNgaySinh { get => dtNgaySinh; set => dtNgaySinh = value; }
        public string SEmail { get => sEmail; set => sEmail = value; }
    }
}
