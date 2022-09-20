using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhanLoai_DTO
    {
        string sMaPhanLoai;
        string sTenPhanLoai;

        public string SMaPhanLoai { get => sMaPhanLoai; set => sMaPhanLoai = value; }
        public string STenPhanLoai { get => sTenPhanLoai; set => sTenPhanLoai = value; }
    }
}
