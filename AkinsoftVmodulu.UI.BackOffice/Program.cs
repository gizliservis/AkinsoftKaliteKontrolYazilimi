using AkinsoftVmodulu.UI.BackOffice.AnaMenu;
using AkinsoftVmodulu.UI.BackOffice.Ayarlar;
using AkinsoftVmodulu.UI.BackOffice.FaturaVeSiparis;
using AkinsoftVmodulu.UI.BackOffice.Rapor;
using AkinsoftVmodulu.UI.BackOffice.V2;
using AkinsoftVmodulu.UI.BackOffice.YöneticiEkrani;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AkinsoftVmodulu.UI.BackOffice
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmKullanici());
        }
    }
}
