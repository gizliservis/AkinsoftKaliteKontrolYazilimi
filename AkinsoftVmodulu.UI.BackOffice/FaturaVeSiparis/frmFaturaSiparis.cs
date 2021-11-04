using AkinsoftVmodulu.UI.BackOffice.Fonksiyonlar;
using DevExpress.Data.Filtering;
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

namespace AkinsoftVmodulu.UI.BackOffice.FaturaVeSiparis
{
    public partial class frmFaturaSiparis : DevExpress.XtraEditors.XtraForm
    {
        DatabaseDataContext DB = new DatabaseDataContext();
        int oncekiBlkodu = 0;
        string _kullaniciAdi;
        public frmFaturaSiparis(string kullaniciAdi)
        {
            InitializeComponent();
           listele();
            _kullaniciAdi = kullaniciAdi;
         
           
           
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
        public bool faturaGeriGetir(int blftkodu)//fatura hareketleri iptal
        {

            SqlCommand adp = new SqlCommand(string.Format("SP_V1_URUNGETIR"), Baglanti2);
            adp.CommandType = CommandType.StoredProcedure;
            adp.Parameters.AddWithValue("@blftkodu", blftkodu);
            return KomutGetir(adp);

        }
        void listele()
        {
            var lst = from s in DB.FATURA join c in DB.CARI on s.BLCRKODU equals c.BLKODU where s.IPTAL == 0 && s.SILINDI==0 &&  s.OZELALANTANIM_14 == "Toplayıcıda" || s.IPTAL == 0 && s.SILINDI==0 && s.OZELALANTANIM_14 == "İptal Edildi" select new {
                c.GRUBU,
                s.OZELALANTANIM_15,
                s.CARIKODU,
                s.TICARI_UNVANI,
                s.ADI_SOYADI,
                s.FATURA_NO,
                s.KARGO_NO,
                s.BLKODU,
                s.MIKTAR1_TOPLAM,
                s.MIKTAR2_TOPLAM,
                s.EFATURA_TFIRMA_ADI,

                
               
            };
            gridListe.DataSource = lst;
        }
        void listedeara()
        {
            var lst = from s in DB.FATURA join c in DB.CARI on s.BLCRKODU equals c.BLKODU where  s.KARGO_NO.Contains(txtSiparisNo.Text)&& s.IPTAL == 0 && s.SILINDI == 0 && s.OZELALANTANIM_14 == "Toplayıcıda" || s.KARGO_NO.Contains(txtSiparisNo.Text) && s.SILINDI == 0 && s.IPTAL == 0 && s.OZELALANTANIM_14 == "İptal Edildi"  select new
            {
                c.GRUBU,
                s.OZELALANTANIM_15,
                s.CARIKODU,
                s.TICARI_UNVANI,
                s.ADI_SOYADI,
                s.FATURA_NO,
                s.KARGO_NO,
                s.BLKODU,
                s.MIKTAR1_TOPLAM,
                s.MIKTAR2_TOPLAM,
                s.EFATURA_TFIRMA_ADI
               
            };
            gridListe.DataSource = lst;
        }

        private void txtSiparisNo_EditValueChanged(object sender, EventArgs e)
        {
           // listedeara();
        }

        private void txtSiparisNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    listeView.ActiveFilterString = (new OperandProperty("KARGO_NO") == txtSiparisNo.Text).ToString();
                    listeView.ActiveFilterEnabled = true;
                    int index = listeView.FocusedRowHandle;
                    int Id;
                    string carigrubu = "";
                    string kargofirmasi = "";
                    Id = Convert.ToInt32(listeView.GetRowCellValue(index, "BLKODU").ToString());
                    carigrubu = listeView.GetRowCellValue(index, "GRUBU").ToString();
                    kargofirmasi = listeView.GetRowCellValue(index, "EFATURA_TFIRMA_ADI").ToString();
                    frmSiparisHareket form = new frmSiparisHareket(Id,carigrubu,kargofirmasi,_kullaniciAdi);
                    form.ShowDialog();
                oncekiBlkodu=form.kod;
                    listele();
                    listeView.ActiveFilter.Clear();
                    txtSiparisNo.Text = null;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Fatura Bulunamadı");
                txtSiparisNo.Text = null;
            }
          
        }

        private void gridListe_KeyDown(object sender, KeyEventArgs e)
        {
         
        }

        private void frmFaturaSiparis_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı '_D__AKINSOFT_WOLVOX8_001_2020_WOLVOXDataSet1.SIPARIS' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
          
            txtSiparisNo.Focus();
        }

        private void gridListe_Click(object sender, EventArgs e)
        {
            txtSiparisNo.Focus();
        }

        private void gridListe_DoubleClick(object sender, EventArgs e)
        {
            txtSiparisNo.Focus();
        }

        private void groupControl1_Click(object sender, EventArgs e)
        {
            txtSiparisNo.Focus();
        }

        private void frmFaturaSiparis_Click(object sender, EventArgs e)
        {
            txtSiparisNo.Focus();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            txtSiparisNo.Focus();
        }

        private void btnGeriAl_Click(object sender, EventArgs e)
        {
            if (oncekiBlkodu>0)
            {
                faturaGeriGetir(oncekiBlkodu);
                listele();
                txtSiparisNo.Focus();
            }
            else
            {
                MessageBox.Show("Herhangi bir fatura açılmamış");
                txtSiparisNo.Focus();
                return;
            }
        }
    }
}