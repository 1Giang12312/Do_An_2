using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonBan_DTO
    {
        string sMaHoaDonBan;
        string sMaNhanVien;
        DateTime dtNgayBan;
        string sMaKhachHang;
        float fTongTien;

        public string SMaHoaDonBan { get => sMaHoaDonBan; set => sMaHoaDonBan = value; }
        public string SMaNhanVien { get => sMaNhanVien; set => sMaNhanVien = value; }
        public DateTime DtNgayBan { get => dtNgayBan; set => dtNgayBan = value; }
        public string SMaKhachHang { get => sMaKhachHang; set => sMaKhachHang = value; }
        public float FTongTien { get => fTongTien; set => fTongTien = value; }
    }
}
