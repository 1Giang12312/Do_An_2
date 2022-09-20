using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietHDBan_DTO
    {
        string sMaHoaDonBan;
        string sMaSua;
        int iSoLuong;
        float fDonGia;
        float fGiamGia;
        float fThanhTien;
        string sTenSua;
        
        public string SMaHoaDonBan { get => sMaHoaDonBan; set => sMaHoaDonBan = value; }
        public string STenSua { get => sTenSua; set => sTenSua = value; }
        public string SMaSua { get => sMaSua; set => sMaSua = value; }
        public int ISoLuong { get => iSoLuong; set => iSoLuong = value; }
        public float FDonGia { get => fDonGia; set => fDonGia = value; }
        public float FGiamGia { get => fGiamGia; set => fGiamGia = value; }
        public float FThanhTien { get => fThanhTien; set => fThanhTien = value; }
        
    }
}
