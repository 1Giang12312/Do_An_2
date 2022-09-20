using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class HoaDon_DAO
    {
        //tạo mã khách hàng tự động, truyền kí tự đầu vào keyvalue
        //các kí tự sau gồm ngày-tháng-giờ-phút-giây-khắc
        // nên khó bị trùng mã HD bán
        public static string CreateKey(string keyvalue)
        {
            {
                string key = keyvalue;
                string[] partsDay;
                partsDay = DateTime.Now.ToShortDateString().Split('/');//cắt chuỗi ngày tháng
                //Ví dụ 12/13/2021
                string d = String.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);
                key = key + d;//HDB+12132021
                string[] partsTime;
                partsTime = DateTime.Now.ToLongTimeString().Split(':');//cắt chuỗi thời gian
                //Ví dụ 7:08:03 PM hoặc 7:08:03 AM
                if (partsTime[2].Substring(3, 2) == "PM")//nếu thời gian là PM từ thực hiện convertimeto24
                    partsTime[0] = ConvertTimeTo24(partsTime[0]);
                if (partsTime[2].Substring(3, 2) == "AM")
                    if (partsTime[0].Length == 1)
                        partsTime[0] = "0" + partsTime[0];//từ 1-9 thì hiển thị là 01,...09.
                //Xóa ký tự trắng và PM hoặc AM
                partsTime[2] = partsTime[2].Remove(2, 3);
                string t;
                t = String.Format("_{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);
                //ví dụ 9:23:00AM

                key = key + t;//key = HDB+12132021_092300
                return key;
            }
        }
        // chuyển đổi giờ để tạo mã khách hàng tự động
        public static string ConvertTimeTo24(string hour)
        {
            string h = "";
            switch (hour)
            {
                case "1":
                    h = "13";
                    break;
                case "2":
                    h = "14";
                    break;
                case "3":
                    h = "15";
                    break;
                case "4":
                    h = "16";
                    break;
                case "5":
                    h = "17";
                    break;
                case "6":
                    h = "18";
                    break;
                case "7":
                    h = "19";
                    break;
                case "8":
                    h = "20";
                    break;
                case "9":
                    h = "21";
                    break;
                case "10":
                    h = "22";
                    break;
                case "11":
                    h = "23";
                    break;
                case "12":
                    h = "0";
                    break;
            }
            return h;
        }
    }
}
