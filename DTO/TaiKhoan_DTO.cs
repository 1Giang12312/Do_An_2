using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoan_DTO
    {
        string sMaNhanVien;
        string sHoTen;
        string sTenDangNhap;
        string sMatKhau;
        string sGhiChu;
        int iQuyenHan;
        public string SMaNhanVien { get => sMaNhanVien; set => sMaNhanVien = value; }
        public string SHoTen { get => sHoTen; set => sHoTen = value; }
        public string STenDangNhap { get => sTenDangNhap; set => sTenDangNhap = value; }
        public string SMatKhau { get => sMatKhau; set => sMatKhau = value; }
        public int IQuyenHan { get => iQuyenHan; set => iQuyenHan = value; }
        public string SGhiChu { get => sGhiChu; set => sGhiChu = value; }
       
    }
}
