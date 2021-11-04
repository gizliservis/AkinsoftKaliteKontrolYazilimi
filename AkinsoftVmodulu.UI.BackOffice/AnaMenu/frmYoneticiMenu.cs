using AkinsoftVmodulu.UI.BackOffice.YöneticiEkrani;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkinsoftVmodulu.UI.BackOffice.AnaMenu
{
    public partial class frmYoneticiMenu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmYoneticiMenu()
        {
            InitializeComponent();
        }

        private void btnV1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmYonetici frm = new frmYonetici();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnV2_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmYoneticiV2 frm = new frmYoneticiV2();
            frm.MdiParent = this;
            frm.Show();
        }

       
    }
}