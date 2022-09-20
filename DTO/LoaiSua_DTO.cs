using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiSua_DTO
    {
        private string sMaLoaiSua;
        private string sTenLoaiSua;

        public string SMaLoaiSua { get => sMaLoaiSua; set => sMaLoaiSua = value; }
        public string STenLoaiSua { get => sTenLoaiSua; set => sTenLoaiSua = value; }
    }
}
