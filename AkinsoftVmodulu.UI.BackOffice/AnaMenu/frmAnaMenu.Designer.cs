
namespace AkinsoftVmodulu.UI.BackOffice.AnaMenu
{
    partial class frmAnaMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.btnKlavye = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.txtCikis = new DevExpress.XtraEditors.TextEdit();
            this.controlKeyboard1 = new IsbaRestaurant.UserControls.ControlKeyboard();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCikis.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.btnKlavye});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 5;
            this.ribbon.Name = "ribbon";
            this.ribbon.OptionsMenuMinWidth = 385;
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(1613, 159);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "V1";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.ImageOptions.LargeImage = global::AkinsoftVmodulu.UI.BackOffice.Properties.Resources.Alım_Faturası_fw;
            this.barButtonItem1.LargeWidth = 100;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "V2";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.ImageOptions.LargeImage = global::AkinsoftVmodulu.UI.BackOffice.Properties.Resources.Satış_Faturası_fw;
            this.barButtonItem2.LargeWidth = 100;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Program Kapat";
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.ImageOptions.LargeImage = global::AkinsoftVmodulu.UI.BackOffice.Properties.Resources.remove;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // btnKlavye
            // 
            this.btnKlavye.Caption = "Klavye";
            this.btnKlavye.Id = 4;
            this.btnKlavye.ImageOptions.LargeImage = global::AkinsoftVmodulu.UI.BackOffice.Properties.Resources.keyboard;
            this.btnKlavye.Name = "btnKlavye";
            this.btnKlavye.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKlavye_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Tüm Teknoloji V Modulu";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "İşlemler";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnKlavye);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Ayarlar";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 771);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1613, 21);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // txtCikis
            // 
            this.txtCikis.Location = new System.Drawing.Point(446, 100);
            this.txtCikis.MenuManager = this.ribbon;
            this.txtCikis.Name = "txtCikis";
            this.txtCikis.Properties.PasswordChar = '*';
            this.txtCikis.Size = new System.Drawing.Size(117, 22);
            this.txtCikis.TabIndex = 3;
            this.txtCikis.Visible = false;
            this.txtCikis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCikis_KeyDown);
            // 
            // controlKeyboard1
            // 
            this.controlKeyboard1.CapsLock = true;
            this.controlKeyboard1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlKeyboard1.FocusTextEdit = null;
            this.controlKeyboard1.KeyboardButtonType = IsbaRestaurant.UserControls.KeyboardButtonType.Standart;
            this.controlKeyboard1.Location = new System.Drawing.Point(0, 401);
            this.controlKeyboard1.Name = "controlKeyboard1";
            this.controlKeyboard1.Size = new System.Drawing.Size(1613, 370);
            this.controlKeyboard1.TabIndex = 6;
            this.controlKeyboard1.Visible = false;
            // 
            // frmAnaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Zoom;
            this.BackgroundImageStore = global::AkinsoftVmodulu.UI.BackOffice.Properties.Resources.Asset_21;
            this.ClientSize = new System.Drawing.Size(1613, 792);
            this.ControlBox = false;
            this.Controls.Add(this.controlKeyboard1);
            this.Controls.Add(this.txtCikis);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.IconOptions.Image = global::AkinsoftVmodulu.UI.BackOffice.Properties.Resources.Asset_2;
            this.IsMdiContainer = true;
            this.Name = "frmAnaMenu";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Toplayıcı Menüsü";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCikis.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnKlavye;
        private DevExpress.XtraEditors.TextEdit txtCikis;
        private IsbaRestaurant.UserControls.ControlKeyboard controlKeyboard1;
    }
}