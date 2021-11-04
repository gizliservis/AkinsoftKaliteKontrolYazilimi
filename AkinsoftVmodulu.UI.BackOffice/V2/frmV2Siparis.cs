using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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

namespace AkinsoftVmodulu.UI.BackOffice.V2
{
    public partial class frmV2Siparis : DevExpress.XtraEditors.XtraForm
    {
        string _kullaniciad = "";
        int kod=0;
        public frmV2Siparis(string kullaniciAd)
        {
            InitializeComponent();
            _kullaniciad = kullaniciAd;
            txtUrunBarkod.Enabled = false;
            txtSiparisBarkod.Focus();
        }
        private static SqlConnection baglanti2;
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
        public DataTable SiparisListele(string cariKodu)//cariye ait siparişleri listeleme
        {
            SqlDataAdapter adp = new SqlDataAdapter(string.Format("SP_V2_TOPLAYICISIPARISLISTE"), Baglanti2);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.AddWithValue("@carikodu", cariKodu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            //dt içindeki file data verisini resim getire gönderiyoruz sonrasında stream olarak geri dönüyor

            return dt;
        }

        public bool Onaylandi_Iptal(int blkod, int teslimMiktar, int kalanMiktar, string durum, string kullanici)//siparişlerin satırlarını onaylama ve iptal etme
        {
            // SqlConnection bg = new SqlConnection(@"Data Source=GIZLISERVIS\MSSQLMASTER;Initial Catalog=D:\AKINSOFT_WOLVOX8_001_2020_WOLVOX;Persist Security Info=True;User ID=sa;Password=17421742");
            //bg.Open();
            SqlCommand adp = new SqlCommand(string.Format("SP_ONAYLANDI_IPTAL"), Baglanti2);
            adp.CommandType = CommandType.StoredProcedure;
            adp.Parameters.AddWithValue("@blkodu", blkod);
            adp.Parameters.AddWithValue("@teslimmiktar", teslimMiktar);
            adp.Parameters.AddWithValue("@kalanmiktar", kalanMiktar);
            adp.Parameters.AddWithValue("@durum", durum);
            adp.Parameters.AddWithValue("@kullanici", kullanici);

            return KomutGetir(adp);

            // bg.Close();

            //dt içindeki file data verisini resim getire gönderiyoruz sonrasında stream olarak geri dönüyor


        }
        public bool GeriAl(int blkod)//siparişlerin satırlarını onaylama ve iptal etme
        {
            SqlCommand adp = new SqlCommand(string.Format("SP_V2_SONISLEMGERIAL"), Baglanti2);
            adp.CommandType = CommandType.StoredProcedure;
            adp.Parameters.AddWithValue("@blkodu", blkod);
            return KomutGetir(adp);

        }

        private void gridViewSiparisListe_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;

            if (e.RowHandle > 0)
            {
                string onay = view.GetRowCellValue(e.RowHandle, "OZELALANTANIM_17").ToString();
                if (onay == "Onaylandı")
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.BackColor2 = Color.DarkGreen;
                    e.Appearance.ForeColor = Color.White;
                }
                else
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.BackColor2 = Color.DarkRed;
                    e.Appearance.ForeColor = Color.White;


                }
            }





        }
        void SiparisleriListele()
        {
            gridSiparisListe.DataSource = SiparisListele(txtSiparisBarkod.Text);
        }

        private void txtSiparisBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SiparisleriListele();
                    txtSiparisBarkod.Enabled = false;
                    txtUrunBarkod.Enabled = true;
                    txtUrunBarkod.Focus();
                }
            }
            catch (Exception)
            {
                txtSiparisBarkod.Text = null;
                MessageBox.Show("Bu Cariye Ait Sipariş Bulunmamakta");
                txtSiparisBarkod.Focus();
            }

        }

        private void gridSiparisListe_Click(object sender, EventArgs e)
        {
            if (txtSiparisBarkod.Enabled == false)
            {
                txtUrunBarkod.Focus();
            }
            else if (txtSiparisBarkod.Enabled == true)
            {
                txtSiparisBarkod.Focus();
            }
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            if (txtSiparisBarkod.Enabled == false)
            {
                txtUrunBarkod.Focus();
            }
            else if (txtSiparisBarkod.Enabled == true)
            {
                txtSiparisBarkod.Focus();
            }
        }



        private void frmV2Siparis_Load(object sender, EventArgs e)
        {
            txtSiparisBarkod.Focus();
        }

        private void gridViewSiparisListe_Click(object sender, EventArgs e)
        {
            if (txtSiparisBarkod.Enabled == false)
            {
                txtUrunBarkod.Focus();
            }
            else if (txtSiparisBarkod.Enabled == true)
            {
                txtSiparisBarkod.Focus();
            }
        }

        void heketListele(string stokkodu)//resim getir
        {
            string url = "http://192.168.44.254/" + stokkodu.Substring(0, stokkodu.Length - 3) + ".jpg";
            pictureEdit1.LoadAsync(url);



        }
        void urunOnay()
        {

            if (txtKalanMiktar.Value != 0)
            {
                txtKalanMiktar.Value -= 1;
                txtTeslimMiktari.Value += 1;
                txtUrunBarkod.Text = null;
                txtUrunBarkod.Focus();
                int index = gridViewSiparisListe.FocusedRowHandle;
                int blkodu = Convert.ToInt32(gridViewSiparisListe.GetRowCellValue(index, "BLKODU").ToString());
                kod = blkodu;
                Onaylandi_Iptal(blkodu, Convert.ToInt32(txtTeslimMiktari.Value), Convert.ToInt32(txtKalanMiktar.Value), "Onaylandı", _kullaniciad);
                gridViewSiparisListe.ActiveFilter.Clear();
                SiparisleriListele();
                xtraTabControl1.SelectedTabPage = tabPageUrunler;

            }
     
        }
        void urunIptal()
        {
            if (txtTeslimMiktari.Value != 0)
            {
                txtKalanMiktar.Value += 1;
                txtTeslimMiktari.Value -= 1;
                txtUrunBarkod.Text = null;
                txtUrunBarkod.Focus();
                int index = gridViewSiparisListe.FocusedRowHandle;
                int blkodu = Convert.ToInt32(gridViewSiparisListe.GetRowCellValue(index, "BLKODU").ToString());
                Onaylandi_Iptal(blkodu, Convert.ToInt32(txtTeslimMiktari.Value), Convert.ToInt32(txtKalanMiktar.Value), "Onaylanmadı", _kullaniciad);
                gridViewSiparisListe.ActiveFilter.Clear();
                SiparisleriListele();
                xtraTabControl1.SelectedTabPage = tabPageUrunler;
            }
      
        }
        void siparisKapat()
        {
            int index = gridViewSiparisListe.FocusedRowHandle;
            int blkodu = Convert.ToInt32(gridViewSiparisListe.GetRowCellValue(index, "BLKODU").ToString());
            Onaylandi_Iptal(blkodu, Convert.ToInt32(txtTeslimMiktari.Value), Convert.ToInt32(txtKalanMiktar.Value), "Onaylandı", _kullaniciad);
            gridViewSiparisListe.ActiveFilter.Clear();
            xtraTabControl1.SelectedTabPage = tabPageUrunler;
            SiparisleriListele();
            txtUrunBarkod.Text = null;
            txtUrunBarkod.Focus();
        }
        void siparisAra()
        {
            gridViewSiparisListe.ActiveFilterString = (new OperandProperty("BARKODU") == txtUrunBarkod.Text).ToString();
            gridViewSiparisListe.ActiveFilterEnabled = true;
            int index = gridViewSiparisListe.FocusedRowHandle;
            int Id;
            string stokKodu = "";
            int blkodu;
            int miktarTeslim = 0;
            int MiktarKalan = 0;
            index = gridViewSiparisListe.FocusedRowHandle;

            Id = Convert.ToInt32(gridViewSiparisListe.GetRowCellValue(index, "BLSTKODU").ToString());
            blkodu = Convert.ToInt32(gridViewSiparisListe.GetRowCellValue(index, "BLKODU").ToString());
            stokKodu = gridViewSiparisListe.GetRowCellValue(index, "STOKKODU").ToString();
            miktarTeslim = Convert.ToInt32(gridViewSiparisListe.GetRowCellValue(index, "OZELALANTANIM_20").ToString());
            MiktarKalan = Convert.ToInt32(gridViewSiparisListe.GetRowCellValue(index, "OZELALANTANIM_19").ToString());


            heketListele(stokKodu);
            txtKalanMiktar.Value = MiktarKalan;
            txtTeslimMiktari.Value = miktarTeslim;
            lblStkKodu.Text = stokKodu;
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
            txtUrunBarkod.Text = null;
            txtUrunBarkod.Focus();
        }
        private void txtUrunBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtUrunBarkod.Text == null || txtUrunBarkod.Text=="")
                {
                    MessageBox.Show("Lütfen ürünün barkodunu okutunuz");
                    return;
                }
                else if (txtUrunBarkod.Text == "URUNONAYLA")
                {
                    urunOnay();

                }
                else if (txtUrunBarkod.Text == "TUMURUNLERIPTAL")
                {
                    urunIptal();
                }
                else if (txtUrunBarkod.Text == "SIPARISKAPAT")
                {
                    siparisKapat();
                }
                else if (txtUrunBarkod.Text != null || txtUrunBarkod.Text!="" || txtUrunBarkod.Text != "URUNONAYLA" || txtUrunBarkod.Text != "TUMURUNLERIPTAL" || txtUrunBarkod.Text != "SIPARISKAPAT")
                {
                    try
                    {
                        siparisAra();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Ürün Onaylanmış");
                        txtUrunBarkod.Text = null;
                        gridViewSiparisListe.ActiveFilter.Clear();
                        txtUrunBarkod.Focus();
                    }
                 
                }
            }
        }



        private void simpleButton1_Click(object sender, EventArgs e)
        {
            urunOnay();

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            urunIptal();

        }
        void bitir()
        {
            gridSiparisListe.DataSource = null;
            txtSiparisBarkod.Enabled = true;
            txtSiparisBarkod.Text = null;
            txtSiparisBarkod.Focus();
            txtUrunBarkod.Text = null;
            txtUrunBarkod.Enabled = false;

        }


        private void simpleButton3_Click(object sender, EventArgs e)
        {
            bitir();
        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            bitir();
        }

        private void btnIslemGeriAl_Click(object sender, EventArgs e)
        {
            GeriAl(kod);
            SiparisleriListele();
        }
    }
}