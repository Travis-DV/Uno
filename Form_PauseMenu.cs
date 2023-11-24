using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uno
{
    public partial class Form_PauseMenu : Form
    {
        public Form_PauseMenu()
        {
            InitializeComponent();
            this.FormClosing += gameForm_FormClosing;
            console.Log($"method; (Form_PauseMenu.Form_PauseMenu)");
        }

        private void closeBT_Click(object sender, EventArgs e)
        {
            console.Log($"method; (Form_PauseMenu.closeBT_Click) [closes here??] ---------------------------------------------------");
            // Find the main form.
            Form mainForm = Application.OpenForms[0];

            // Close the main form.
            mainForm.Close();
        }

        private void gameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            console.Log($"method; (Form_PauseMenu.gameForm_FormClosing) [closes here?? 2.0] ---------------------------------------------------");
            e.Cancel = true;
            this.Hide();
        }
    }
}
