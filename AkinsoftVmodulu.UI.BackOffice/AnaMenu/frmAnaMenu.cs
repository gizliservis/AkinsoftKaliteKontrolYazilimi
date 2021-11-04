using AkinsoftVmodulu.UI.BackOffice.FaturaVeSiparis;
using AkinsoftVmodulu.UI.BackOffice.V2;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkinsoftVmodulu.UI.BackOffice.AnaMenu
{
    public partial class frmAnaMenu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string _kullaniciadi = "";
        public frmAnaMenu(string kullaniciadi)
        {
            InitializeComponent();
            _kullaniciadi = kullaniciadi;

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
           frmFaturaSiparis frm = new frmFaturaSiparis(_kullaniciadi);
            frm.MdiParent = this;
            frm.Show();
            frm.txtSiparisNo.Focus();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (txtCikis.Visible == false)
            {
                txtCikis.Visible = true;
                txtCikis.Focus();
            }
            else if (txtCikis.Visible == true)
            {
                txtCikis.Visible = false;
                txtCikis.Focus();
            }
          
         
        }

        private void btnKlavye_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (controlKeyboard1.Visible == false)
            {
                controlKeyboard1.Visible = true;
                txtCikis.Focus();
            }
            else if (controlKeyboard1.Visible == true)
            {
                controlKeyboard1.Visible = false;
                txtCikis.Focus();
            }

        }

        private void txtCikis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                if (txtCikis.Text == "123456")
                {
                    Close();
                }
                else
                {
                    MessageBox.Show("Lütfen Doğru Şifre Giriniz");
                }
            }
           
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmV2Siparis frm = new frmV2Siparis(_kullaniciadi);
            frm.ShowDialog();
        }
    }
}