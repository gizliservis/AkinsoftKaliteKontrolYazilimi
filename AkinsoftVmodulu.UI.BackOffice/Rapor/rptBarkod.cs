using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace AkinsoftVmodulu.UI.BackOffice.Rapor
{
    public partial class rptBarkod : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBarkod(string barkod,string stokkodu)
        {

            InitializeComponent();
           
            xrBarCode1.Text = barkod;
            txtStokKodu.Text = stokkodu;
        
        }

    }
}
