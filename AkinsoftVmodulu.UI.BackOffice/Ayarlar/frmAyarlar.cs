using AkinsoftVmodulu.UI.BackOffice.Tools;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkinsoftVmodulu.UI.BackOffice.Ayarlar
{
    public partial class frmAyarlar : DevExpress.XtraEditors.XtraForm
    {
        public frmAyarlar()
        {
            InitializeComponent();
            OzelAlanListele();
            
        }
        void OzelAlanListele()
        {
            txtToplayiciDurum.Text = SettingsTool.AyarOku(SettingsTool.Ayarlar.OzelAlanTanimFatura_ToplayiciDurumu);
            txtToplayici.Text = SettingsTool.AyarOku(SettingsTool.Ayarlar.OzelAlanTanimFatura_Toplayici);
            txtKullanici.Text = SettingsTool.AyarOku(SettingsTool.Ayarlar.OzelAlanTanimFatura_Kullanici);
        }
        void OzelAlanTanim()
        {
            SettingsTool.AyarDegistir(SettingsTool.Ayarlar.OzelAlanTanimFatura_ToplayiciDurumu, txtToplayiciDurum.Text);
            SettingsTool.AyarDegistir(SettingsTool.Ayarlar.OzelAlanTanimFatura_Toplayici, txtToplayici.Text);
            SettingsTool.AyarDegistir(SettingsTool.Ayarlar.OzelAlanTanimFatura_Kullanici, txtKullanici.Text);
            SettingsTool.save();
            MessageBox.Show("İşlem Tmamlandı");
        }
        void FaturaDatabaseKaydet()
        {
            SettingsTool.AyarDegistir(SettingsTool.Ayarlar.DatabaseAyarlari_BaglantiCumlesi1, "Data Source="+txtServerAdi.Text+";"+ "Initial Catalog="+txtDbAdi.Text+ ";"+"Integrated Security=False"+";"+"User ID="+txtKullaniciAdi.Text+";"+"Password="+txtSifre.Text);
            SettingsTool.save();
            MessageBox.Show("İşlem Tmamlandı");
        }
        void KullaniciDatabaseKaydet()
        {
            SettingsTool.AyarDegistir(SettingsTool.Ayarlar.DatabaseAyarlari_BaglantiCumlesi2, "Data Source=" + txtKServerAdi.Text + ";" + "Initial Catalog=" + txtKDbAdi.Text + ";" + "Integrated Security=False" + ";" + "User ID=" + txtKKullaniciAdi.Text + ";" + "Password=" + txtKSifre.Text);
            SettingsTool.save();
            MessageBox.Show("İşlem Tmamlandı");
        }

        private void btn_Click(object sender, EventArgs e)
        {
            OzelAlanTanim();

        }
     

        private void btnFaturaKaydet_Click(object sender, EventArgs e)
        {
            FaturaDatabaseKaydet();
        }

        private void btnKullanici_Click(object sender, EventArgs e)
        {
            KullaniciDatabaseKaydet();
        }
    }
}