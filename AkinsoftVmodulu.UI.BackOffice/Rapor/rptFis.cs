using AkinsoftVmodulu.UI.BackOffice.Fonksiyonlar;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using DevExpress.DataAccess;

namespace AkinsoftVmodulu.UI.BackOffice.Rapor
{
    public partial class rptFis : DevExpress.XtraReports.UI.XtraReport
    {
        DatabaseDataContext db = new DatabaseDataContext();
        public rptFis(int blKodu,int efaturaKullan,decimal genelkpb)
        {
            InitializeComponent();
            int siraNo=1;
            var lst = (from s in db.FATURA
                       join shr in db.FATURAHR on s.BLKODU equals shr.BLFTKODU
                       join cr in db.CARI on s.BLCRKODU equals cr.BLKODU
                       where shr.BLFTKODU == blKodu
                       select new
                       {
                          
                           cr.ADI_SOYADI,
                           s.SEVK_ADRESI,
                           cr.E_MAIL,
                           cr.TEL1,
                           cr.TC_KIMLIK_NO,
                           s.EFATURA_SITE_ADI,
                           s.TARIHI,
                           s.DEGISTIRME_TARIHI,
                           s.EFATURA_TFIRMA_VKN,
                           s.EFATURA_TFIRMA_ADI,
                           s.EFATURA_ODEME_TURU,
                           s.FATURA_NO,
                           s.TOPLAM_ALT_KPB,
                           s.TOPLAM_ARA_KPB,
                           s.TOPLAM_KDV_KPB,
                           s.TOPLAM_GENEL_KPB,
                           s.KARGO_NO,
                           shr.BARKODU,
                           shr.STOKKODU,
                           shr.STOK_ADI,
                           shr.MIKTARI,
                           shr.KPB_FIYATI,
                           shr.KPB_KDVLI_TUTAR,
                           s.TOPLAM_ISK_KPB,
                           s.EFATURA_GUID,
                           s.SEVK_YETKILISI,
                           s.KARGO_FIRMASI,
                           s.KARGO_TARIHI,
                           s.OZELALANTANIM_13,
                           s.ADRESI
                      
                           
                          
                          
                          
                       }).ToList();
            this.DataSource = lst;
            txtSiraNo.Text = siraNo.ToString();
            siraNo++;
            txtBrkdKargoNo.DataBindings.Add("Text", this.DataSource, "KARGO_NO");
            txtCariAdi.DataBindings.Add("Text", this.DataSource, "ADI_SOYADI");
            txtCariAdres.DataBindings.Add("Text", this.DataSource, "ADRESI");
            txtCariEPosta.DataBindings.Add("Text", this.DataSource, "E_MAIL");
            txtCariTel.DataBindings.Add("Text", this.DataSource, "TEL1");
            txtCariTCKN.DataBindings.Add("Text", this.DataSource, "TC_KIMLIK_NO");
            txtSiparisWebAdres.DataBindings.Add("Text", this.DataSource, "EFATURA_SITE_ADI");
            txtOdemeTarihi.DataBindings.Add("Text", this.DataSource, "TARIHI");
            txtGonderimTarihi.DataBindings.Add("Text", this.DataSource, "TARIHI");
            txtTasiyanVKN.DataBindings.Add("Text", this.DataSource, "EFATURA_TFIRMA_VKN");
            txtTasiyanUnvani.DataBindings.Add("Text", this.DataSource, "EFATURA_TFIRMA_ADI");
            txtDuzenlenmeTarihi.DataBindings.Add("Text", this.DataSource, "TARIHI");
            txtSiparisNo.DataBindings.Add("Text", this.DataSource, "FATURA_NO");
            txtSiparisTarihi.DataBindings.Add("Text", this.DataSource, "TARIHI");
            txtStkBarkod.DataBindings.Add("Text", this.DataSource, "BARKODU");
            txtStkKodu.DataBindings.Add("Text", this.DataSource, "STOKKODU");
           
            txtMiktar.DataBindings.Add("Text", this.DataSource, "MIKTARI");
            txtBirimFiyat.DataBindings.Add("Text", this.DataSource, "KPB_FIYATI");
            txtUrunToplamTutar.DataBindings.Add("Text", this.DataSource, "KPB_KDVLI_TUTAR");
            txtKdvHaricToplamT.DataBindings.Add("Text", this.DataSource, "TOPLAM_ALT_KPB");
            txtToplamIsk.DataBindings.Add("Text", this.DataSource, "TOPLAM_ISK_KPB");
            txtKDVMatrah.DataBindings.Add("Text", this.DataSource, "TOPLAM_ARA_KPB");
            txtKdvTutar.DataBindings.Add("Text", this.DataSource, "TOPLAM_KDV_KPB");
            txtVDToplamTutar.DataBindings.Add("Text", this.DataSource, "TOPLAM_GENEL_KPB");
            txtOdenecekTutar.DataBindings.Add("Text", this.DataSource, "TOPLAM_GENEL_KPB");
            txtKargoNo.DataBindings.Add("Text", this.DataSource, "KARGO_NO");
            txtSevkYetkilisi.DataBindings.Add("Text", this.DataSource, "SEVK_YETKILISI");
            txtEttnNo.DataBindings.Add("Text", this.DataSource, "EFATURA_GUID");
            txtKargoFirmasi.DataBindings.Add("Text", this.DataSource, "KARGO_FIRMASI");
            txtKargoTarihi.DataBindings.Add("Text", this.DataSource, "KARGO_TARIHI");
            txtSipNo.DataBindings.Add("Text", this.DataSource, "OZELALANTANIM_13");
            txtYaziIle.Text = yaziyaCevir(genelkpb);
            if (efaturaKullan==1)
            {
                txtEfaturaDurum.Text = "e-Fatura";
                picImza.Visible = false;
            }
            else
            {
                txtEfaturaDurum.Text = "e-Arşiv Fatura";
            }


        }

        private string yaziyaCevir(decimal tutar)
        {
            string sTutar = tutar.ToString("F2").Replace('.', ','); // Replace('.',',') ondalık ayracının . olma durumu için            
            string lira = sTutar.Substring(0, sTutar.IndexOf(',')); //tutarın tam kısmı
            string kurus = sTutar.Substring(sTutar.IndexOf(',') + 1, 2);
            string yazi = "";

            //string[] birler = { "", "BİR", "İKİ", "ÜÇ", "DÖRT", "BEŞ", "ALTI", "YEDİ", "SEKİZ", "DOKUZ" };
            //string[] onlar = { "", "ON", "YİRMİ", "OTUZ", "KIRK", "ELLİ", "ALTMIŞ", "YETMİŞ", "SEKSEN", "DOKSAN" };
            //string[] binler = { "KATRİLYON", "TRİLYON", "MİLYAR", "MİLYON", "BİN", "" }; //KATRİLYON'un önüne ekleme yapılarak artırabilir.

            string[] birler = { "", "Bir", "İki", "Üç", "Dört", "Beş", "Altı", "Yedi", "Sekiz", "Dokuz" };
            string[] onlar = { "", "On", "Yirmi", "Otuz", "Kırk", "Elli", "Altmış", "Yetmiş", "Seksen", "Doksan" };
            string[] binler = { "Katirilyon", "Trilyon", "Milyar", "Milyon", "Bin", "" }; //KATRİLYON'un önüne ekleme yapılarak artırabilir.

            int grupSayisi = 6; //sayıdaki 3'lü grup sayısı. katrilyon içi 6. (1.234,00 daki grup sayısı 2'dir.)
            //KATRİLYON'un başına ekleyeceğiniz her değer için grup sayısını artırınız.

            lira = lira.PadLeft(grupSayisi * 3, '0'); //sayının soluna '0' eklenerek sayı 'grup sayısı x 3' basakmaklı yapılıyor.            

            string grupDegeri;

            for (int i = 0; i < grupSayisi * 3; i += 3) //sayı 3'erli gruplar halinde ele alınıyor.
            {
                grupDegeri = "";

                if (lira.Substring(i, 1) != "0")
                    grupDegeri += birler[Convert.ToInt32(lira.Substring(i, 1))] + "Yüz"; //yüzler                

                if (grupDegeri == "BirYüz") //biryüz düzeltiliyor.
                    grupDegeri = "Yüz";

                grupDegeri += onlar[Convert.ToInt32(lira.Substring(i + 1, 1))]; //onlar

                grupDegeri += birler[Convert.ToInt32(lira.Substring(i + 2, 1))]; //birler                

                if (grupDegeri != "") //binler
                    grupDegeri += binler[i / 3];

                if (grupDegeri == "Birbin") //birbin düzeltiliyor.
                    grupDegeri = "Bin";

                yazi += grupDegeri;
            }

            if (yazi != "")
                yazi += "Türk Lirası ";

            int yaziUzunlugu = yazi.Length;

            if (kurus.Substring(0, 1) != "0") //kuruş onlar
                yazi += onlar[Convert.ToInt32(kurus.Substring(0, 1))];

            if (kurus.Substring(1, 1) != "0") //kuruş birler
                yazi += birler[Convert.ToInt32(kurus.Substring(1, 1))];

            if (yazi.Length > yaziUzunlugu)
                yazi += "Kuruş";
            else
                yazi += "";

            return yazi;
        }

    }
}
