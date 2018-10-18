using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaInventory.Services
{
    class MegaService
    {
        public static string GetComputerCode()
        {
            return Properties.Settings.Default.ComputerCode;
        }

        public static DateTime GetComputeTime()
        {
            return DateTime.Now;
        }

        public static void FormatDataGridView(DataGridView dgv)
        {
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToOrderColumns = false;
        }

        public static void FormatDialog(Form frm)
        {
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        public static void FormatView(Form frm)
        {
            
        }

        public static void SwitchKeyboardLayout(string lang)
        {
            string keyboard_lang = InputLanguage.CurrentInputLanguage.Culture.TwoLetterISOLanguageName;
            if (keyboard_lang != lang)
            {
                int en_index = -1;
                for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count - 1; i++)
                {
                    try
                    {
                        if (InputLanguage.InstalledInputLanguages[i].Culture.TwoLetterISOLanguageName == lang)
                        { en_index = i; break; }
                    }
                    catch { break; }
                }

                if (en_index != -1)
                {
                    InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[en_index];
                }
            }
        }
    }
}
