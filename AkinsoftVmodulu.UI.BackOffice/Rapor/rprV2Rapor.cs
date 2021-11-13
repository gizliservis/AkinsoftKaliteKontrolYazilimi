using AkinsoftVmodulu.UI.BackOffice.Fonksiyonlar;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Drawing;
using System.Data.Linq.SqlClient;

namespace AkinsoftVmodulu.UI.BackOffice.Rapor
{
    public partial class rprV2Rapor : DevExpress.XtraReports.UI.XtraReport
    {
        DatabaseDataContext db = new DatabaseDataContext();
        public rprV2Rapor(string kullanici,string durumu)
        {
            InitializeComponent();
       
        }

    }
}
