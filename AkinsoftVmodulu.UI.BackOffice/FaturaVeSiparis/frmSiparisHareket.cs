using AkinsoftVmodulu.UI.BackOffice.Fonksiyonlar;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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

namespace AkinsoftVmodulu.UI.BackOffice.FaturaVeSiparis
{
    public partial class frmSiparisHareket : DevExpress.XtraEditors.XtraForm
    {
        DatabaseDataContext DB = new DatabaseDataContext();
        DatabaseResimlerDataContext dr = new DatabaseResimlerDataContext();
       public  int kod;
        string _carigrubu = "";
        string _kargofirmasi = "";
        string _kullanici;
        public frmSiparisHareket(int BlKodu,string cariGrubu ,string kargoFirmasi,string kullanici)
        {
            InitializeComponent();
           kod = BlKodu;
            _kargofirmasi = kargoFirmasi;
            _carigrubu = cariGrubu;
            txtCariGrubu.Text = _carigrubu;
            txtKargoFirması.Text = _kargofirmasi;
            _kullanici = kullanici;

           

            hareketListele(DB, kod);

            acilis();

            if (gridViewSiparisListe.RowCount == 0)
            {
                btnTamamla.Enabled = true;
            }
            else if (gridViewSiparisListe.RowCount > 0)
            {
                btnTamamla.Enabled = false;
            }




        }
        private static SqlConnection baglanti;
        private static SqlConnection baglanti2;
        public static SqlConnection Baglanti //resim connection string
        {
            get
            {
                if (baglanti == null) baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["AkinsoftVmodulu.UI.BackOffice.Properties.Settings.D__AKINSOFT_WOLVOX8_DOSYAConnectionString"].ConnectionString);

                return baglanti;
            }
        }
        public static SqlConnection Baglanti2 // volvox connection string
        {
            get
            {
                if (baglanti2 == null) baglanti2 = new SqlConnection(ConfigurationManager.ConnectionStrings["AkinsoftVmodulu.UI.BackOffice.Properties.Settings.D__AKINSOFT_WOLVOX8_001_2020_WOLVOXConnectionString"].ConnectionString);

                return baglanti2;
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
        public bool onayselect(int urunBlkodu)//urun onaylama tiki procedure
        {
            //SqlConnection bg = new SqlConnection(@"Data Source=GIZLISERVIS\MSSQLMASTER;Initial Catalog=D:\AKINSOFT_WOLVOX8_001_2020_WOLVOX;Persist Security Info=True;User ID=sa;Password=17421742");
            // bg.Open();
            SqlCommand adp = new SqlCommand(string.Format("SP_ONAY"), Baglanti2);
            adp.CommandType = CommandType.StoredProcedure;
            adp.Parameters.AddWithValue("@blkodu", urunBlkodu);
            return KomutGetir(adp);
        }
        public DataTable ImageSelect(int blstkod)//Resim eşleştirme procedure
        {
            SqlDataAdapter adp = new SqlDataAdapter(string.Format("Sp_GetImage"), Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.AddWithValue("@blstkodu", blstkod);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            //dt içindeki file data verisini resim getire gönderiyoruz sonrasında stream olarak geri dönüyor

            return dt;
        }
        public bool FaturahrIptal(int blftkodu,string kullanici)//fatura hareketleri iptal
        {

            SqlCommand adp = new SqlCommand(string.Format("SP_V1_VAZGEC"), Baglanti2);
            adp.CommandType = CommandType.StoredProcedure;
            adp.Parameters.AddWithValue("@blftkodu", blftkodu);
            adp.Parameters.AddWithValue("@kullanici", kullanici);
            return KomutGetir(adp);

        }
        public bool FaturaTamamlandı(int blftkodu,string kullanici)//fatura hareketleri iptal
        {

            SqlCommand adp = new SqlCommand(string.Format("SP_TOPLANDI"), Baglanti2);
            adp.CommandType = CommandType.StoredProcedure;
            adp.Parameters.AddWithValue("@blkodu", blftkodu);
            adp.Parameters.AddWithValue("@kullanici", kullanici);
            return KomutGetir(adp);




        }
        //void heketListele(DatabaseResimlerDataContext db, int blstkoduu)//resim getir
        //{

        //     DataTable dt = ImageSelect(blstkoduu);

        //     byte[] image = (byte[])dt.Rows[0].ItemArray[0];

        //      Stream imageFile = NefesWolvoxResimGetir.NTools.ResimGetir(image);
        //     pictureEdit1.Image = Image.FromStream(imageFile);




        //}
        void heketListele(DatabaseResimlerDataContext db, string stokkodu)//resim getir
        {
            string url = "http://192.168.44.254/"+stokkodu.Substring(0,stokkodu.Length-3)+".jpg";
            pictureEdit1.LoadAsync(url);



        }
        public object hareketListele(DatabaseDataContext db, int blkodu)
        {

            var lst = from s in db.FATURAHR where s.BLFTKODU == blkodu && s.ONAYLAMA == null select s;
            gridSiparisListe.DataSource = lst.ToList();
            return lst;
        }
        public object UrunAra(DatabaseDataContext dc, int blkoduu)
        {

            var lst = from s in dc.FATURAHR where s.BARKODU.Contains(txtBarkodNo.Text) && s.BLFTKODU == blkoduu && s.ONAYLAMA == null select s;
            gridSiparisListe.DataSource = lst.ToList();
            return lst;
        }

        private void frmSiparisHareket_Load(object sender, EventArgs e)
        {
            txtBarkodNo.Focus();

        }

        private void txtBarkodNo_EditValueChanged(object sender, EventArgs e)
        {
            //UrunAra(DB,kod);
        }
        void acilis()
        {
            int index = gridViewSiparisListe.FocusedRowHandle;
            int Id;
            string stokKodu = "";
            int blkodu;
            int miktar=0;
            index = gridViewSiparisListe.FocusedRowHandle;

            Id = Convert.ToInt32(gridViewSiparisListe.GetRowCellValue(index, "BLSTKODU").ToString());
            blkodu = Convert.ToInt32(gridViewSiparisListe.GetRowCellValue(index, "BLKODU").ToString());
            stokKodu = gridViewSiparisListe.GetRowCellValue(index, "STOKKODU").ToString();
            miktar = Convert.ToInt32(gridViewSiparisListe.GetRowCellValue(index, "MIKTARI").ToString());
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
            heketListele(dr, stokKodu);
       
            lblStkKodu.Text = stokKodu;
            if (miktar > 1)
            {
                txtMiktar.Text = miktar.ToString();
            }
            txtBarkodNo.Text = null;
            txtBarkodNo.Focus();
        }
        void urunac()
        {
            int index = gridViewSiparisListe.FocusedRowHandle;
            int Id;
            string stokKodu = "";
            int miktar = 0;
            int blkodu;
            index = gridViewSiparisListe.FocusedRowHandle;

            Id = Convert.ToInt32(gridViewSiparisListe.GetRowCellValue(index, "BLSTKODU").ToString());
            miktar = Convert.ToInt32(gridViewSiparisListe.GetRowCellValue(index, "MIKTARI").ToString());
            blkodu = Convert.ToInt32(gridViewSiparisListe.GetRowCellValue(index, "BLKODU").ToString());
            stokKodu = gridViewSiparisListe.GetRowCellValue(index, "STOKKODU").ToString();
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
            heketListele(dr, stokKodu);
            lblStkKodu.Text = stokKodu;
            if (miktar > 1)
            {
                txtMiktar.Text = miktar.ToString();
            }
            txtBarkodNo.Text = null;
            txtBarkodNo.Focus();
        }
        void urunAra()//ürün arama komutu bu değildir
        {
            int index = gridViewSiparisListe.FocusedRowHandle;
            int Id;
            string stokKodu = "";

            int blkodu;
            UrunAra(DB, kod);
            index = gridViewSiparisListe.FocusedRowHandle;
            Id = Convert.ToInt32(gridViewSiparisListe.GetRowCellValue(index, "BLSTKODU").ToString());
            blkodu = Convert.ToInt32(gridViewSiparisListe.GetRowCellValue(index, "BLKODU").ToString());
            stokKodu = gridViewSiparisListe.GetRowCellValue(index, "STOKKODU").ToString();
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
            heketListele(dr, stokKodu);
            txtBarkodNo.Text = null;
            txtBarkodNo.Focus();
        }
        private void txtBarkodNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBarkodNo.Text == "")
                {
                    MessageBox.Show("Barkod Alanı Boş Geçilemez");
                    txtBarkodNo.Focus();
                    return;

                }
               
                if (txtBarkodNo.Text == "URUNAC") //urun gösterme barkodu bu barkodda yok oldu şuan
                {
                    urunac();

                }
                else if (txtBarkodNo.Text == "URUNONAYLA")//onay Barkodu
                {
                    urunOnayla();
                }

                else if (txtBarkodNo.Text == "TUMURUNLERIPTAL") // vazgeç butonu
                {
                    faturaIptal();

                }
                else if (txtBarkodNo.Text == "FATURATAMAMLANDI")//bu barkod yok oldu suan
                {
                    FaturaTamamla();

                }
                else
                {
                    urunAra();
                }


            }
        }


        private void gridViewSiparisListe_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            int onay = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "ONAYLAMA"));
            if (onay == 0)
            {
                e.Appearance.BackColor = Color.Red;
                e.Appearance.BackColor2 = Color.DarkRed;
                e.Appearance.ForeColor = Color.White;

            }
            else
            {
                e.Appearance.BackColor = Color.Green;
                e.Appearance.BackColor2 = Color.DarkGreen;
                e.Appearance.ForeColor = Color.White;
            }



        }
        void FaturaTamamla()
        {
            if (gridViewSiparisListe.RowCount == 0)
            {
                FaturaTamamlandı(kod,_kullanici);
                txtBarkodNo.Text = null;
                txtBarkodNo.Focus();
                this.Close();
            }
            else if (gridViewSiparisListe.RowCount > 0)
            {
                MessageBox.Show("Lütfen Hepsini Onayladıktan sonra bu işlemi yapınız");
                txtBarkodNo.Text = null;
                txtBarkodNo.Focus();
            }
        }

        private void btnTamamla_Click(object sender, EventArgs e)
        {
            FaturaTamamla();

        }
        void faturaIptal()
        {
            xtraTabControl1.SelectedTabPage = tabPageUrunler;
            FaturahrIptal(kod,_kullanici);
            hareketListele(DB, kod);
            txtBarkodNo.Text = null;
            txtBarkodNo.Focus();
            if (gridViewSiparisListe.RowCount > 0)
            {
                btnTamamla.Enabled = false;
            }
            this.Close();
        }
        private void btnİşlemİptal_Click(object sender, EventArgs e)
        {
            faturaIptal();
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            txtBarkodNo.Focus();
        }

        private void gridSiparisListe_Click(object sender, EventArgs e)
        {
            txtBarkodNo.Focus();
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            txtBarkodNo.Focus();
        }

        private void groupControl1_Click(object sender, EventArgs e)
        {
            txtBarkodNo.Focus();
        }
        void urunOnayla()
        {
            int index = gridViewSiparisListe.FocusedRowHandle;
            int Id;
            string stokKodu = "";
            int blkodu;
            int miktar = 0;

            index = gridViewSiparisListe.FocusedRowHandle;

            Id = Convert.ToInt32(gridViewSiparisListe.GetRowCellValue(index, "BLSTKODU").ToString());
            blkodu = Convert.ToInt32(gridViewSiparisListe.GetRowCellValue(index, "BLKODU").ToString());
            stokKodu = gridViewSiparisListe.GetRowCellValue(index, "STOKKODU").ToString();
            onayselect(blkodu);
            hareketListele(DB, kod);
            txtBarkodNo.Text = null;
            txtBarkodNo.Focus();
            if (gridViewSiparisListe.RowCount > 0)
            {
                index = gridViewSiparisListe.FocusedRowHandle;

                Id = Convert.ToInt32(gridViewSiparisListe.GetRowCellValue(index, "BLSTKODU").ToString());
                miktar = Convert.ToInt32(gridViewSiparisListe.GetRowCellValue(index, "MIKTARI").ToString());
                blkodu = Convert.ToInt32(gridViewSiparisListe.GetRowCellValue(index, "BLKODU").ToString());
                stokKodu = gridViewSiparisListe.GetRowCellValue(index, "STOKKODU").ToString();
                xtraTabControl1.SelectedTabPage = xtraTabPage2;
                heketListele(dr, stokKodu);
                lblStkKodu.Text = stokKodu;
                if (miktar > 1)
                {
                    txtMiktar.Text = miktar.ToString();
                }
                txtBarkodNo.Text = null;
                txtBarkodNo.Focus();
              
            }
            if (gridViewSiparisListe.RowCount == 0)
            {
                btnTamamla.Enabled = true;
                btnTamamla.PerformClick();

                this.Close();
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            urunOnayla();
           

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            faturaIptal();
        }
    }
}