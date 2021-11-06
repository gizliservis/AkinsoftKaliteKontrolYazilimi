using AkinsoftVmodulu.UI.BackOffice.Fonksiyonlar;
using AkinsoftVmodulu.UI.BackOffice.Rapor;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
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

namespace AkinsoftVmodulu.UI.BackOffice.YöneticiEkrani
{
    public partial class frmYoneticiV2 : DevExpress.XtraEditors.XtraForm
    {
        public frmYoneticiV2()
        {
            InitializeComponent();

            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            SiparisleriListele();
        }
        private static SqlConnection baglanti;
        public static SqlConnection Baglanti2
        {

            get
            {



                if (baglanti == null) baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["AkinsoftVmodulu.UI.BackOffice.Properties.Settings.D__AKINSOFT_WOLVOX8_001_2020_WOLVOXConnectionString"].ConnectionString);

                return baglanti;
            }

        }
        public static bool KomutGetir(SqlCommand cmd)
        {
            try
            {
                if (cmd.Connection.State != ConnectionState.Open) cmd.Connection.Open();
                int etk = cmd.ExecuteNonQuery();
                return etk > 0 ? true : false;


            }
            catch (Exception)
            {
                return false;

            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed) cmd.Connection.Close();


            }
        }
        public DataTable V2SiparisListe()//v2 sipariş listeleme
        {
            SqlDataAdapter adp = new SqlDataAdapter(string.Format("SP_V2_SIPARISLISTE"), Baglanti2);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            // adp.SelectCommand.Parameters.AddWithValue("@blstkodu", blstkod);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            //dt içindeki file data verisini resim getire gönderiyoruz sonrasında stream olarak geri dönüyor
            return dt;
        }
        public DataTable V2AtananListele()//v2 sipariş listeleme
        {
            SqlDataAdapter adp = new SqlDataAdapter(string.Format("SP_V2_ALISTELE"), Baglanti2);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            // adp.SelectCommand.Parameters.AddWithValue("@blstkodu", blstkod);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            //dt içindeki file data verisini resim getire gönderiyoruz sonrasında stream olarak geri dönüyor
            return dt;
        }
        public bool kullaniciatamak(int blkod, string isim)
        {
            // SqlConnection bg = new SqlConnection(@"Data Source=GIZLISERVIS\MSSQLMASTER;Initial Catalog=D:\AKINSOFT_WOLVOX8_001_2020_WOLVOX;Persist Security Info=True;User ID=sa;Password=17421742");
            //bg.Open();
            SqlCommand adp = new SqlCommand(string.Format("SP_V2_TOPLAYICIGUNCELLE"), Baglanti2);
            adp.CommandType = CommandType.StoredProcedure;
            adp.Parameters.AddWithValue("@kullanici", isim);
            adp.Parameters.AddWithValue("@blkod", blkod);
            return KomutGetir(adp);

            // bg.Close();

            //dt içindeki file data verisini resim getire gönderiyoruz sonrasında stream olarak geri dönüyor


        }
        void SiparisleriListele()
        {
            gridContSiparisHlL.DataSource = V2SiparisListe();
        }
        void atananListele()
        {
            gridContSiparisHlL.DataSource = V2AtananListele();
        }
      //List<string> miktarlar = new List<string>();
      // List<string> stokkodlar = new List<string>();
        void YazdirA4()
        {
           
            int[] RowHandles = gridView1.GetSelectedRows();
            DataTable dt = new DataTable();
            dt.Columns.Add("stokkodu");
            dt.Columns.Add("Miktar");
            dt.Columns.Add("carikod");
            foreach (int i in RowHandles)
            {
                string miktar = gridView1.GetRowCellValue(i, gridView1.Columns["MIKTARI"]).ToString();
                string stokkodu = gridView1.GetRowCellValue(i, gridView1.Columns["STOKKODU"]).ToString();
                string carikod = gridView1.GetRowCellValue(i, gridView1.Columns["carikodu"]).ToString();
                string barkod = gridView1.GetRowCellValue(i, gridView1.Columns["BARKODU"]).ToString();
               
                dt.Rows.Add(stokkodu, miktar,carikod);
            }
            rptStok rpr = new rptStok(dt);
            frmRaporGoruntule frm = new frmRaporGoruntule(rpr);
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            //int genelkbp = gridView1.GetRowCellValue(Convert.ToInt32(RowHandles), gridView1.Columns["TOPLAM_GENEL_KPB"]);
        }
        void barkoyazdir()
        {
            int[] RowHandles = gridView1.GetSelectedRows();
     
            foreach (int i in RowHandles)
            {
                string miktar = gridView1.GetRowCellValue(i, gridView1.Columns["MIKTARI"]).ToString();
                string carikod = gridView1.GetRowCellValue(i, gridView1.Columns["carikodu"]).ToString();
                int blkod = Convert.ToInt32(gridView1.GetRowCellValue(i, gridView1.Columns["BLSTKODU"]));
                rptBarkod fis = new rptBarkod(blkod);
                ReportPrintTool barkode = new ReportPrintTool(fis);
                for (int s = 1; s <= int.Parse(miktar); s++)
                {
                    barkode.Print();
                }
            }
        }
        

        private void btnYetkiVer_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKullanici.Text == null || txtKullanici.Text=="" )
                {
                    MessageBox.Show("Lütfen kullanıcı Alanını Doldurun");
                    return;
                }
                else if (txtKullanici.Text != null || txtKullanici.Text!="")
                {
                    barkoyazdir();
                    YazdirA4();
                    int[] RowHandles = gridView1.GetSelectedRows();
                    foreach (int i in RowHandles)
                    {
                        int blkod = Convert.ToInt32(gridView1.GetRowCellValue(i, gridView1.Columns["BLKODU"]));
                        kullaniciatamak(blkod, txtKullanici.Text);
                    }
                    SiparisleriListele();
                    gridView1.ClearColumnsFilter();

                    MessageBox.Show("Siparişler "+txtKullanici.Text.ToUpper()+" Atandı");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
         
            
        }

        private void txtKullanici_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmTolayici frm = new frmTolayici();
            frm.ShowDialog();
            if (frm.secildi == true)
            {
                PERSONEL entity = frm.secilen.FirstOrDefault();
                txtKullanici.Text = entity.USERNAME;

            }
        }

        private void btnSiparisler_Click(object sender, EventArgs e)
        {
            SiparisleriListele();
        }

        private void btnToplayici_Click(object sender, EventArgs e)
        {
            atananListele();
        }

        private void btnTkrYazdir_Click(object sender, EventArgs e)
        {
            YazdirA4();
            barkoyazdir();
        
        }
    }
}