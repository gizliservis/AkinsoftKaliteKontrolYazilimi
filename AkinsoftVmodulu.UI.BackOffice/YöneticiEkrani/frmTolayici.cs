using AkinsoftVmodulu.UI.BackOffice.Fonksiyonlar;
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

namespace AkinsoftVmodulu.UI.BackOffice.YöneticiEkrani
{
    public partial class frmTolayici : DevExpress.XtraEditors.XtraForm
    {
        DatabaseKullaniciDataContext Db = new DatabaseKullaniciDataContext();
        public List<PERSONEL> secilen = new List<PERSONEL>();
        public bool secildi = false;
        public frmTolayici()
        {
            InitializeComponent();
            listele();
        }
        public void listele()
        {
            var lst = from s in Db.PERSONEL where s.ACIKLAMA1 == "Toplayıcı" select s;
            gridControl1.DataSource = lst;
        }
       
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (gridView1.GetSelectedRows().Length != 0)
            {

                foreach (var row in gridView1.GetSelectedRows())
                {
                    string kullaniciadi = gridView1.GetRowCellValue(row, colUsarName).ToString();
                    secilen.Add(Db.PERSONEL.SingleOrDefault(c => c.USERNAME == kullaniciadi));

                }

                secildi = true;
                this.Close();
            }

            else
            {
                MessageBox.Show("Seçilen Bir Cari Bulunamadı");
            }
        }

    }
}