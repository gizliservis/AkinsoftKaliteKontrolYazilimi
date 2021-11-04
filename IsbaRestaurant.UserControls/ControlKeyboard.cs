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

namespace IsbaRestaurant.UserControls
{
    public partial class ControlKeyboard : DevExpress.XtraEditors.XtraUserControl
    {
        private bool capsLock = true;
        private KeyboardButtonType buttonType = KeyboardButtonType.Standart;
        private BaseEdit focusTextEdit = null;
        public ControlKeyboard()
        {
            InitializeComponent();
        }
        public BaseEdit FocusTextEdit
        {
            get
            {
                return focusTextEdit;
            }
            set
            {
                focusTextEdit = value;
            }
        }
        public KeyboardButtonType KeyboardButtonType
        {
            get
            {
                return buttonType;
            }
            set
            {
                buttonType = value;
                foreach (KeybordButton button in layoutControl1.Controls.OfType<KeybordButton>().ToList())
                {
                    switch (value)
                    {
                        case KeyboardButtonType.Standart:
                            button.Text = button.First.ToString();
                            break;
                        case KeyboardButtonType.Shift:
                            button.Text = button.Second.ToString();
                            if (button.Text == "&")
                            {
                                button.Text = "&&";
                            }
                            break;
                        case KeyboardButtonType.Alt:
                            button.Text = button.Third.ToString();
                            break;

                    }
                }
            }
        }
        public bool CapsLock
        {
            get
            {
                return capsLock;
            }
            set
            {

                capsLock = value;
                foreach (KeybordButton button in layoutControl1.Controls.OfType<KeybordButton>().ToList())
                {
                    if (value)
                    {
                        button.Text = button.Text.ToUpper();
                    }
                    else
                    {
                        button.Text = button.Text.ToLower();
                    }
                }
            }
        }

        private void KeybordButtonClick(object sender, EventArgs e)
        {
            KeybordButton button = (KeybordButton)sender;
            if (focusTextEdit!=null)
            {
                focusTextEdit.Focus();
            }
            if (!String.IsNullOrEmpty(button.Text))
            {
                if (button.Text == "&&")
                {
                    SendKeys.Send("{&}");
                }
                else
                {
                    SendKeys.Send("{" + button.Text + "}");
                }

            }

        }

        private void keyEsc_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{ESC}");
        }

        private void keyBackSpace_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{BACKSPACE}");
        }

        private void keyTab_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }

        private void keyEnter_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }

        private void keyYukariOk_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{UP}");
        }

        private void keyAsagiOk_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{DOWN}");
        }

        private void keySolOk_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{LEFT}");
        }

        private void keySagOk_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT}");
        }

        private void keyDel_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{DEL}");
        }

        private void keyCapsLock_CheckedChanged(object sender, EventArgs e)
        {
            CapsLock = keyCapsLock.Checked;
        }

        private void keySpace_Click(object sender, EventArgs e)
        {
            SendKeys.Send(" ");
        }

        private void keySolShift_CheckedChanged(object sender, EventArgs e)
        {
            if (keySolShift.Checked)
            {
                KeyboardButtonType = KeyboardButtonType.Shift;
            }
            else
            {
                KeyboardButtonType = KeyboardButtonType.Standart;
            }
        }

        private void keySagShift_CheckedChanged(object sender, EventArgs e)
        {
            if (keySagShift.Checked)
            {
                KeyboardButtonType = KeyboardButtonType.Shift;
            }
            else
            {
                KeyboardButtonType = KeyboardButtonType.Standart;
            }
        }

        private void keyAlt_CheckedChanged(object sender, EventArgs e)
        {
            if (keyAlt.Checked)
            {
                KeyboardButtonType = KeyboardButtonType.Alt;
            }
            else
            {
                KeyboardButtonType = KeyboardButtonType.Standart;
            }
        }
    }
}
