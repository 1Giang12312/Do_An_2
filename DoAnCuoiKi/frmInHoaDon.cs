using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
namespace DoAnCuoiKi
{
    public partial class frmInHoaDon : Form
    {
        public frmInHoaDon()
        {
            InitializeComponent();
        }
        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            //lấy txt mahd qua để hiện

            HoaDonBan_DTO hd = HoaDonBan_BUS.LayHDBanDauTien();
            IList<ChiTietHDBan_DTO> list = ChiTietHDBan_BUS.LayChiTietHDBan(hd.SMaHoaDonBan);
            ChiTietHDBan_DTOBindingSource.DataSource = list;

            this.reportViewer1.RefreshReport();
        }

    }
}
