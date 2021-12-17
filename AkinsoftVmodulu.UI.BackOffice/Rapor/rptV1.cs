using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace AkinsoftVmodulu.UI.BackOffice.Rapor
{
    public partial class rptV1 : DevExpress.XtraReports.UI.XtraReport
    {
        public rptV1(DataTable kontrol,DateTime tarihB,DateTime tarihBi)
        {
            InitializeComponent();
            this.DataSource = kontrol;
            XRSummary sumMiktar = new XRSummary();
            sumMiktar.Func = SummaryFunc.Sum;
            sumMiktar.Running = SummaryRunning.Group;
            lblMiktar.DataBindings.Add("Text", null, "Miktar");
            lblMiktar.Summary = sumMiktar;
            xrLabel1.Text = tarihB.ToString();
            xrLabel3.Text = tarihBi.ToString();
      

        }

    }
}
