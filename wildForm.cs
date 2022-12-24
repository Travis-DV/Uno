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
    public partial class wildFormClass : Form
    {
        public wildFormClass()
        {
            InitializeComponent();
        }

        private void redBT_Click(object sender, EventArgs e)
        {
            // Set the DialogResult property to OK and the Tag property to "Red".
            this.DialogResult = DialogResult.OK;
            this.Tag = "Red";
            this.Close();
        }

        private void blueBT_Click(object sender, EventArgs e)
        {
            // Set the DialogResult property to OK and the Tag property to "Blue".
            this.DialogResult = DialogResult.OK;
            this.Tag = "Blue";
            this.Close();
        }

        private void greenBT_Click(object sender, EventArgs e)
        {
            // Set the DialogResult property to OK and the Tag property to "Green".
            this.DialogResult = DialogResult.OK;
            this.Tag = "Green";
            this.Close();
        }

        private void yellowBT_Click(object sender, EventArgs e)
        {
            // Set the DialogResult property to OK and the Tag property to "Yellow".
            this.DialogResult = DialogResult.OK;
            this.Tag = "Yellow";
            this.Close();
        }
    }
}
