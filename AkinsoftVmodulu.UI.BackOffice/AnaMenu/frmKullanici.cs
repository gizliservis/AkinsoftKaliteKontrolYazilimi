using AkinsoftVmodulu.UI.BackOffice.FaturaVeSiparis;
using AkinsoftVmodulu.UI.BackOffice.Fonksiyonlar;
using AkinsoftVmodulu.UI.BackOffice.YöneticiEkrani;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace AkinsoftVmodulu.UI.BackOffice.AnaMenu
{
    public partial class frmKullanici : Form
    {
        DatabaseKullaniciDataContext db = new DatabaseKullaniciDataContext();
        public frmKullanici()
        {
            InitializeComponent();

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
        private void btnGirisYap_Click(object sender, EventArgs e)
        {

            if (db.PERSONEL.Any(c => c.USERNAME == txtKullaniciAdi.Text && c.USERPWD == MD5Hash(txtSifre.Text) && c.ACIKLAMA1 == "yönetici"))
            {
                frmYoneticiMenu frm = new frmYoneticiMenu();
                this.Hide();
                frm.ShowDialog();
                this.Close();


            }
            else if (db.PERSONEL.Any(c => c.USERNAME == txtKullaniciAdi.Text && c.USERPWD == MD5Hash(txtSifre.Text) && c.ACIKLAMA1 == "kullanıcı"))
            {
                frmAnaMenu form = new frmAnaMenu(txtKullaniciAdi.Text);
                this.Hide();
                form.ShowDialog();
                this.Close();


            }
            else
            {
                MessageBox.Show("Giriş Başarısız");
            }
        }

        private void txtKullaniciAdi_Click(object sender, EventArgs e)
        {

        }
     
      
    }
}
