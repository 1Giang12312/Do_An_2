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
    public class HangHoa_DAO
    {
        static SqlConnection con;
        public static List<HangHoa_DTO> LayHangHoa()
        {
            string sTruyVan = "select * from TblSua";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<HangHoa_DTO> lstsua = new List<HangHoa_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HangHoa_DTO sua = new HangHoa_DTO();
                sua.SMaSua = dt.Rows[i]["MaSua"].ToString();
                sua.STenSua = dt.Rows[i]["TenSua"].ToString();
                sua.SMaLoaiSua = dt.Rows[i]["MaLoaiSua"].ToString();
                sua.ISoLuong = int.Parse(dt.Rows[i]["SoLuong"].ToString());
                sua.FDonGiaNhap = float.Parse(dt.Rows[i]["DonGiaNhap"].ToString());
                sua.FDonGiaBan = float.Parse(dt.Rows[i]["DonGiaBan"].ToString());
                sua.SAnh = dt.Rows[i]["Anh"].ToString();
                sua.SGhiChu = dt.Rows[i]["GhiChu"].ToString();
                sua.DtHanSuDung = DateTime.Parse(dt.Rows[i]["HanSuDung"].ToString());
                sua.SMaPhanLoai = dt.Rows[i]["MaPhanLoai"].ToString();
                lstsua.Add(sua);
            }
            DataProvider.DongKetNoi(con);
            return lstsua;
        }
        public static HangHoa_DTO TimHangHoaThemMa(string ma)
        {
            string sTruyVan = string.Format(@"select * from TblSua where MaSua=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            HangHoa_DTO sua = new HangHoa_DTO();
            sua.SMaSua = dt.Rows[0]["MaSua"].ToString();
            sua.STenSua = dt.Rows[0]["TenSua"].ToString();
            sua.SMaLoaiSua = dt.Rows[0]["MaLoaiSua"].ToString();
            sua.ISoLuong = int.Parse(dt.Rows[0]["SoLuong"].ToString());
            sua.FDonGiaNhap = float.Parse(dt.Rows[0]["DonGiaNhap"].ToString());
            sua.FDonGiaBan = float.Parse(dt.Rows[0]["DonGiaBan"].ToString());
            sua.SAnh = dt.Rows[0]["Anh"].ToString();
            sua.SGhiChu = dt.Rows[0]["GhiChu"].ToString();
            sua.DtHanSuDung = DateTime.Parse(dt.Rows[0]["HanSuDung"].ToString());
            sua.SMaPhanLoai = dt.Rows[0]["MaPhanLoai"].ToString();
            DataProvider.DongKetNoi(con);
            return sua;
            
        }
        public static bool ThemSua(HangHoa_DTO sua)
        {
            string sTruyVan = string.Format(@"insert into TblSua values(N'{0}',
                N'{1}',N'{2}',N'{3}','{4}',N'{5}',N'{6}',N'{7}',N'{8}',N'{9}')", sua.SMaSua, sua.STenSua, sua.SMaLoaiSua,
                sua.ISoLuong, sua.FDonGiaNhap, sua.FDonGiaBan,sua.SAnh,sua.SGhiChu,sua.DtHanSuDung,sua.SMaPhanLoai);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool XoaSua(HangHoa_DTO sua)
        {
            string sTruyVan = string.Format(@"delete from TblSua where MaSua=N'{0}'", sua.SMaSua);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool CapNhatHangHoa(HangHoa_DTO sua)
        {
            string sTruyVan = string.Format(@"update TblSua set TenSua=N'{0}',
                                                MaLoaiSua=N'{1}',
                                                SoLuong='{2}',
                                                DonGiaNhap='{3}',
                                                DonGiaBan='{4}',
                                                Anh=N'{5}',
                                                GhiChu=N'{6}',
                                                HanSuDung='{7}',
                                                MaPhanLoai=N'{8}'
                                                where MaSua='{9}'",
               sua.STenSua, sua.SMaLoaiSua, sua.ISoLuong, sua.FDonGiaNhap, sua.FDonGiaBan, sua.SAnh, sua.SGhiChu,sua.DtHanSuDung,sua.SMaPhanLoai, sua.SMaSua);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        //tìm theo mã tên mã loại sữa
        public static List<HangHoa_DTO> TimKiemSua(string ma)
        {
            string sTruyVan = string.Format(@"select * from TblSua where MaSua LIKE N'%{0}%' or TenSua LIKE N'%{0}%' or MaLoaiSua LIKE N'%{0}%'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<HangHoa_DTO> lstSua = new List<HangHoa_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HangHoa_DTO sua = new HangHoa_DTO();
                sua.SMaSua = dt.Rows[0]["MaSua"].ToString();
                sua.STenSua = dt.Rows[0]["TenSua"].ToString();
                sua.SMaLoaiSua = dt.Rows[0]["MaLoaiSua"].ToString();
                sua.ISoLuong = int.Parse(dt.Rows[0]["SoLuong"].ToString());
                sua.FDonGiaNhap = float.Parse(dt.Rows[0]["DonGiaNhap"].ToString());
                sua.FDonGiaBan = float.Parse(dt.Rows[0]["DonGiaBan"].ToString());
                sua.SAnh = dt.Rows[0]["Anh"].ToString();
                sua.SGhiChu = dt.Rows[0]["GhiChu"].ToString();
                sua.DtHanSuDung = DateTime.Parse(dt.Rows[0]["HanSuDung"].ToString());
                sua.SMaPhanLoai = dt.Rows[0]["MaPhanLoai"].ToString();
                lstSua.Add(sua);
            }
            return lstSua;
        }


        //kiểm tra hạn sử dụng
        public static bool KiemTraHanSuDung()
        {
            int soluong=0;
            string ghichu = "Sản phẩm đã hết hạn sử dụng!";
            string sTruyVan = string.Format(@"update TblSua set SoLuong=N'{0}',
                                                                GhiChu=N'{1}'
                                                where HanSuDung<GETDATE()",
               soluong,ghichu);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        //lấy hàng hóa có số lượng >0
        public static List<HangHoa_DTO> LayHangHoaCoSLLH0()
        {
            string sTruyVan = "select * from TblSua where SoLuong > 0";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<HangHoa_DTO> lstsua = new List<HangHoa_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HangHoa_DTO sua = new HangHoa_DTO();
                sua.SMaSua = dt.Rows[i]["MaSua"].ToString();
                sua.STenSua = dt.Rows[i]["TenSua"].ToString();
                sua.SMaLoaiSua = dt.Rows[i]["MaLoaiSua"].ToString();
                sua.ISoLuong = int.Parse(dt.Rows[i]["SoLuong"].ToString());
                sua.FDonGiaNhap = float.Parse(dt.Rows[i]["DonGiaNhap"].ToString());
                sua.FDonGiaBan = float.Parse(dt.Rows[i]["DonGiaBan"].ToString());
                sua.SAnh = dt.Rows[i]["Anh"].ToString();
                sua.SGhiChu = dt.Rows[i]["GhiChu"].ToString();
                sua.DtHanSuDung = DateTime.Parse(dt.Rows[i]["HanSuDung"].ToString());
                sua.SMaPhanLoai = dt.Rows[i]["MaPhanLoai"].ToString();
                lstsua.Add(sua);
            }
            DataProvider.DongKetNoi(con);
            return lstsua;
        }
        public static int DemHangHoa()
        {
            string sTruyVan = string.Format(@"select * from TblSua");
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            return dt.Rows.Count;
        }
        
    }
}
