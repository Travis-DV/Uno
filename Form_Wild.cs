﻿using System;
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
            console.Log("method; (wildFormClass.wildFormClass)");
        }

        private void redBT_Click(object sender, EventArgs e)
        {
            // Set the DialogResult property to OK and the Tag property to "Red".
            this.DialogResult = DialogResult.OK;
            this.Tag = "red";
            console.Log("method; (wildFormClass.redBT_Click) [this.Tag = red]");
            this.Close();
        }

        private void blueBT_Click(object sender, EventArgs e)
        {
            // Set the DialogResult property to OK and the Tag property to "Blue".
            this.DialogResult = DialogResult.OK;
            this.Tag = "blue";
            console.Log("method; (wildFormClass.blueBT_Click) [this.Tag = blue]");
            this.Close();
        }

        private void greenBT_Click(object sender, EventArgs e)
        {
            // Set the DialogResult property to OK and the Tag property to "Green".
            this.DialogResult = DialogResult.OK;
            this.Tag = "green";
            console.Log("method; (wildFormClass.greenBT_Click) [this.Tag = green]");
            this.Close();
        }

        private void yellowBT_Click(object sender, EventArgs e)
        {
            // Set the DialogResult property to OK and the Tag property to "Yellow".
            this.DialogResult = DialogResult.OK;
            this.Tag = "yellow";
            console.Log("method; (wildFormClass.yellowBT_Click) [this.Tag = yellow]");
            this.Close();
        }
    }
}
