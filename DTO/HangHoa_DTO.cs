using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class HangHoa_DTO
    {
        string sMaSua;
        string sTenSua;
        string sMaLoaiSua;
        int iSoLuong;
        float fDonGiaNhap;
        float fDonGiaBan;
        string sAnh;
        string sGhiChu;
        DateTime dtHanSuDung;
        string sMaPhanLoai;
        //string sTenLoaiSua;

        public string SMaSua { get => sMaSua; set => sMaSua = value; }
        public string STenSua { get => sTenSua; set => sTenSua = value; }
        public string SMaLoaiSua { get => sMaLoaiSua; set => sMaLoaiSua = value; }
        public int ISoLuong { get => iSoLuong; set => iSoLuong = value; }
        public float FDonGiaNhap { get => fDonGiaNhap; set => fDonGiaNhap = value; }
        public float FDonGiaBan { get => fDonGiaBan; set => fDonGiaBan = value; }
        public string SAnh { get => sAnh; set => sAnh = value; }
        public string SGhiChu { get => sGhiChu; set => sGhiChu = value; }
        public DateTime DtHanSuDung { get => dtHanSuDung; set => dtHanSuDung = value; }
        public string SMaPhanLoai { get => sMaPhanLoai; set => sMaPhanLoai = value; }
        // public string STenLoaiSua { get => sTenLoaiSua; set => sTenLoaiSua = value; }
    }
}
