using AkinsoftVmodulu.UI.BackOffice.Fonksiyonlar;
using AkinsoftVmodulu.UI.BackOffice.Rapor;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkinsoftVmodulu.UI.BackOffice.V2
{

    public partial class frmStokEtiket : DevExpress.XtraEditors.XtraForm
    {
        DatabaseDataContext db = new DatabaseDataContext();
        STOK stk = new STOK();
        public frmStokEtiket()
        {
            InitializeComponent();
            var lst = (from s in db.STOK select s).ToList();
            foreach (STOK i in lst)
            {
                i.OZELALANTANIM_212 = 1;
            }
            gridControl1.DataSource = lst;
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            

        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            int[] RowHandles = gridView1.GetSelectedRows();
            foreach (int i in RowHandles)
            {
                int blkod = Convert.ToInt32(gridView1.GetRowCellValue(i, gridView1.Columns["BLKODU"]));
                string miktar = gridView1.GetRowCellValue(i, gridView1.Columns["OZELALANTANIM_212"]).ToString();
                rptBarkod fis = new rptBarkod(blkod);
                ReportPrintTool barkode = new ReportPrintTool(fis);
                for (int s = 1; s <= int.Parse(miktar); s++)
                {
                    barkode.Print();
                }
            }
        }

        private void frmStokEtiket_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Control && e.KeyCode==Keys.Shift && e.KeyCode==Keys.F10)
            {

            }
        }
    }
}