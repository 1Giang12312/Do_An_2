using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
namespace DoAnCuoiKi
{
    public partial class frmInTongHoaDon : Form
    {
        public frmInTongHoaDon()
        {
            InitializeComponent();
        }

        private void frmInHangHoa_Load(object sender, EventArgs e)
        {
            //Hoad hd = HoaDonBan_BUS.LayHDBanDauTien();
            IList<HoaDonBan_DTO> list = HoaDonBan_BUS.LayHoaDonBan();
            HoaDonBan_DTOBindingSource.DataSource = list;
            this.reportViewer1.RefreshReport();
        }
    }
}
