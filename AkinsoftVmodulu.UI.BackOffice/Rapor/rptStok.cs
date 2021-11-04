using AkinsoftVmodulu.UI.BackOffice.YöneticiEkrani;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace AkinsoftVmodulu.UI.BackOffice.Rapor
{
    public partial class rptStok : DevExpress.XtraReports.UI.XtraReport
    {
  
        public rptStok(DataTable stok)
        {
            
            InitializeComponent();
            this.DataSource = stok;


            txtMiktar.DataBindings.Add("Text", this.DataSource, "Miktar");
            txtStokKodu.DataBindings.Add("Text", this.DataSource, "stokkodu");
            barcodeCariKodu.Text=stok.Rows[0][2].ToString();
            XRSummary sumMiktar = new XRSummary();
            sumMiktar.Func = SummaryFunc.Sum;
            sumMiktar.Running = SummaryRunning.Group;
            lblToplammiktar.DataBindings.Add("Text", null, "Miktar");
            lblToplammiktar.Summary = sumMiktar;
            // barcodeCariKodu.Text = tbl[0].ToString();
          
           // txtMiktar.DataBindings.Add("Text", this.DataSource, "MIKTARI");
           // txtStokKodu.DataBindings.Add("Text", this.DataSource, "STOKKODU");

        }


    }
}
