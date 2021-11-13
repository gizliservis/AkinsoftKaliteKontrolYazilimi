using AkinsoftVmodulu.UI.BackOffice.Fonksiyonlar;
using AkinsoftVmodulu.UI.BackOffice.Rapor;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;

namespace AkinsoftVmodulu.UI.BackOffice.YöneticiEkrani
{
    public partial class frmYonetici : Form
    {
        DatabaseKullaniciDataContext Db = new DatabaseKullaniciDataContext();
        DatabaseDataContext ds = new DatabaseDataContext();
        DataTable dt;

        public frmYonetici()
        {
            InitializeComponent();
            listele();

            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
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
        public DataTable Faturaselect()//fatura listele procedure
        {
            SqlDataAdapter adp = new SqlDataAdapter(string.Format("SP_SIPARISONAY"), Baglanti2);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            // adp.SelectCommand.Parameters.AddWithValue("@blstkodu", blstkod);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            //dt içindeki file data verisini resim getire gönderiyoruz sonrasında stream olarak geri dönüyor
            return dt;
        }
        public DataTable FiltreSelect(string stokKd, string renkk, string bedenn)//filtreleme özellikleri
        {
            SqlDataAdapter adp = new SqlDataAdapter(string.Format("SP_FATURAKT"), Baglanti2);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.AddWithValue("@stokkodu", stokKd);
            adp.SelectCommand.Parameters.AddWithValue("@renk", renkk);
            adp.SelectCommand.Parameters.AddWithValue("@beden", bedenn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        public DataTable ToplayıcıListele()//toplayıcıda olanları listele procedure
        {
            SqlDataAdapter adp = new SqlDataAdapter(string.Format("SP_TOPLAYICIDA"), Baglanti2);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        public DataTable SipariHareketSelect(int blkod)//fatura hareketlerini gösterme procedure
        {
            SqlDataAdapter adp = new SqlDataAdapter(string.Format("SP_SIPARISHAREKETSELECT"), Baglanti2);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.AddWithValue("@urnBlkod", blkod);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            //dt içindeki file data verisini resim getire gönderiyoruz sonrasında stream olarak geri dönüyor

            return dt;
        }
        void listele()
        {
            trendyolGuncelle();
            gridControl1.DataSource = Faturaselect();
            lblDegisiklik.Text = "ATANMAYAN FATURALAR";
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        public bool kullaniciata(int blkod, string isim)//kullanıcılara atama işlemi burada yapılır 
        {
            SqlCommand adp = new SqlCommand(string.Format("SP_KULLANICIATA"), Baglanti2);
            adp.CommandType = CommandType.StoredProcedure;
            adp.Parameters.AddWithValue("@kullanici", isim);
            adp.Parameters.AddWithValue("@blkodu", blkod);
            return KomutGetir(adp);
        }
        public bool kullaniciataGeriAl(int blkod)//kullanıcılara atama işlemi burada yapılır 
        {
            SqlCommand adp = new SqlCommand(string.Format("SP_KULLANICIATAGERIAL"), Baglanti2);
            adp.CommandType = CommandType.StoredProcedure;
            adp.Parameters.AddWithValue("@blkodu", blkod);
            return KomutGetir(adp);
        }
        public bool otoFaturaBitir(int blkod)//kullanıcılara atama işlemi burada yapılır 
        {
            SqlCommand adp = new SqlCommand(string.Format("SP_V1_YONETICI_FAT_ONAY"), Baglanti2);
            adp.CommandType = CommandType.StoredProcedure;
            adp.Parameters.AddWithValue("@blkodu", blkod);
            return KomutGetir(adp);
        }
        public bool trendyolGuncelle()//kullanıcılara atama işlemi burada yapılır 
        {
            SqlCommand adp = new SqlCommand(string.Format("SP_TRENYOL_ETTN"), Baglanti2);
            adp.CommandType = CommandType.StoredProcedure;
            return KomutGetir(adp);
        }

        private void btnYetkiVer_Click(object sender, EventArgs e)
        {


            if (txtKullanici.Text != "")
            {
                int[] RowHandles = gridView1.GetSelectedRows();
                dt = new DataTable();
                dt.Columns.Add("BlKodu");
                foreach (int i in RowHandles)
                {
                    
                    
                    int blkod = Convert.ToInt32(gridView1.GetRowCellValue(i, gridView1.Columns["BLKODU"]));
                    int efatura = Convert.ToInt32(gridView1.GetRowCellValue(i, gridView1.Columns["efaturayir"]));
                    decimal genelkbp = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridView1.Columns["TOPLAM_GENEL_KPB"]));
                    dt.Rows.Add(blkod);
                    kullaniciata(blkod, txtKullanici.Text);
                    rptFis fis = new rptFis(blkod, efatura, genelkbp);
                    ReportPrintTool rpr = new ReportPrintTool(fis);
                    rpr.Print();
                }


                MessageBox.Show(txtKullanici.Text + " Kullanıcısına Seçili Siparişler" + "\n" + "Başarıyla Atanmıştır");
                txtKullanici.Text = null;
                try
                {
                    listele();
                }
                catch (Exception)
                {

                    MessageBox.Show("listeleme yapılamadı");
                }

            }
            else
            {
                MessageBox.Show("Lütfen Bir Toplayıcı Seçiniz");
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
       
            listele();
            btnYetkiVer.Enabled = true;
            btnTkrYazdir.Enabled = false;
            txtFaturaOnayla.Enabled = false;
        }
        void TopListeMet()
        {
            gridControl1.DataSource = ToplayıcıListele();
            lblDegisiklik.Text = "ATANAN FATURALAR";
        }
        private void btnToplayici_Click(object sender, EventArgs e)
        {
            TopListeMet();
            btnYetkiVer.Enabled = false;
            btnTkrYazdir.Enabled = true;
            txtFaturaOnayla.Enabled = true;
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            int[] RowHandles = gridView1.GetSelectedRows();
            foreach (int i in RowHandles)
            {
                int blkod = Convert.ToInt32(gridView1.GetRowCellValue(i, gridView1.Columns["BLKODU"]));
                gridControl2.DataSource = SipariHareketSelect(blkod);


            }
        }

        private void btnTkrYazdir_Click(object sender, EventArgs e)
        {
            int[] RowHandles = gridView1.GetSelectedRows();
            foreach (int i in RowHandles)
            {
                int blkod = Convert.ToInt32(gridView1.GetRowCellValue(i, gridView1.Columns["BLKODU"]));
                int efatura = Convert.ToInt32(gridView1.GetRowCellValue(i, gridView1.Columns["efaturayir"]));
                decimal genlkbp = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridView1.Columns["TOPLAM_GENEL_KPB"]));
                rptFis fis = new rptFis(blkod, efatura, genlkbp);
                ReportPrintTool rpr = new ReportPrintTool(fis);
                rpr.Print();
            }
        }

        private void btnFiltre_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = FiltreSelect(txtStokKodu.Text, txtRenk.Text, txtBeden.Text);
           
        }

        private void txtFaturaOnayla_Click(object sender, EventArgs e)
        {
            int[] RowHandles = gridView1.GetSelectedRows();
            foreach (int i in RowHandles)
            {
                int blkod = Convert.ToInt32(gridView1.GetRowCellValue(i, gridView1.Columns["BLKODU"]));
                otoFaturaBitir(blkod);
                gridControl1.DataSource = ToplayıcıListele();

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            foreach (DataRow item in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    int blk = Convert.ToInt32(item["BlKodu"]);
                    kullaniciataGeriAl(blk);
                   
                }
                
            }
            MessageBox.Show("işlem tamamladı");
            listele();


        }
    }
}
