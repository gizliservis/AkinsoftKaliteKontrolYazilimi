using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaRestaurant.UserControls
{
   public class KeybordButton:SimpleButton
    {
        public char First { get; set; }
        public char Second { get; set; }
        public char Third { get; set; }
    }
}
