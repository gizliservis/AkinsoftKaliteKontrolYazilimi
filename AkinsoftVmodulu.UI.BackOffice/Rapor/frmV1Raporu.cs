using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkinsoftVmodulu.UI.BackOffice.Rapor
{
    public partial class frmV1Raporu : DevExpress.XtraEditors.XtraForm
    {
        public frmV1Raporu()
        {
            InitializeComponent();
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            dtBaslangic.DateTime = DateTime.Now;
            dtBitis.DateTime = DateTime.Now;
        }
        private static SqlConnection baglanti;
        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        public static SqlConnection Baglanti2
        {

            get
            {
                if (baglanti == null) baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["AkinsoftVmodulu.UI.BackOffice.Properties.Settings.D__AKINSOFT_WOLVOX8_001_2020_WOLVOXConnectionString"].ConnectionString);

                return baglanti;
            }

        }
        public DataTable listele(string baslangic,string bitis)//filtreleme özellikleri
        {
            SqlDataAdapter adp = new SqlDataAdapter(string.Format("SP_V1_RAPOR"), Baglanti2);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.AddWithValue("@baslangictarih", baslangic);
            adp.SelectCommand.Parameters.AddWithValue("@bitistarihi", bitis);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        private void btnFiltre_Click(object sender, EventArgs e)
        {
            string basla = dtBaslangic.DateTime.ToString("yyyy-MM-dd HH:mm:ss");
            string bitis = dtBitis.DateTime.ToString("yyyy-MM-dd HH:mm:ss");
            gridControl1.DataSource = listele(basla,bitis);
        }
        void yazdir()
        {

            int[] RowHandles = gridView1.GetSelectedRows();
            DataTable dt = new DataTable();
            dt.Columns.Add("kontrolcu");
            dt.Columns.Add("Miktar");
            dt.Columns.Add("grubu");
       
            foreach (int i in RowHandles)
            {
                string kontrolcu = gridView1.GetRowCellValue(i, gridView1.Columns["OZELALANTANIM_21"]).ToString();
                string miktar = gridView1.GetRowCellValue(i, gridView1.Columns["MIKTARI"]).ToString();
                string grup = gridView1.GetRowCellValue(i, gridView1.Columns["grubuu"]).ToString();

                dt.Rows.Add(kontrolcu, miktar,grup);
            }
           
            rptV1 rpr = new rptV1(dt,dtBaslangic.DateTime,dtBitis.DateTime);
            frmRaporGoruntule frm = new frmRaporGoruntule(rpr);
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            rptV1Toplam rpt = new rptV1Toplam(dt, dtBaslangic.DateTime, dtBitis.DateTime);
            frmRaporGoruntule frt = new frmRaporGoruntule(rpt);
            frt.WindowState = FormWindowState.Maximized;
            frt.Show();

        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            yazdir();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "V2 Raporu (" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ")";
            saveFileDialog1.Filter = "XLS Dosyaları (*.xls)|*.xls";
            saveFileDialog1.InitialDirectory = "c:";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                DevExpress.XtraPrinting.XlsExportOptions _Options = new DevExpress.XtraPrinting.XlsExportOptions();

                _Options.SheetName = "V2 Raporu(" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ")";

                gridView1.ExportToXls(saveFileDialog1.FileName, _Options);

                if (MessageBox.Show("Aktarılan dosyayı şimdi görmek ister misiniz?", "Excel dosyası", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                }

            }
        }
    }
}