using AkinsoftVmodulu.UI.BackOffice.Fonksiyonlar;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace AkinsoftVmodulu.UI.BackOffice.Rapor
{
    public partial class rptBarkod : DevExpress.XtraReports.UI.XtraReport
    {
        DatabaseDataContext db = new DatabaseDataContext();
        public rptBarkod(int blKodu)
        {

            InitializeComponent();
            var lst = from s in db.STOK where s.BLKODU == blKodu select s;
            this.DataSource = lst;
            txtStokKodu.DataBindings.Add("Text", this.DataSource, "STOKKODU");
            xrBarCode1.DataBindings.Add("Text", this.DataSource, "BARKODU");

        }

    }
}
