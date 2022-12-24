namespace uno
{
    partial class wildFormClass
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
            this.pickacolorGB = new System.Windows.Forms.GroupBox();
            this.redBT = new System.Windows.Forms.Button();
            this.blueBT = new System.Windows.Forms.Button();
            this.greenBT = new System.Windows.Forms.Button();
            this.yellowBT = new System.Windows.Forms.Button();
            this.pickacolorGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // pickacolorGB
            // 
            this.pickacolorGB.Controls.Add(this.yellowBT);
            this.pickacolorGB.Controls.Add(this.greenBT);
            this.pickacolorGB.Controls.Add(this.blueBT);
            this.pickacolorGB.Controls.Add(this.redBT);
            this.pickacolorGB.Location = new System.Drawing.Point(83, 56);
            this.pickacolorGB.Name = "pickacolorGB";
            this.pickacolorGB.Size = new System.Drawing.Size(207, 133);
            this.pickacolorGB.TabIndex = 0;
            this.pickacolorGB.TabStop = false;
            this.pickacolorGB.Text = "Pick A color";
            // 
            // redBT
            // 
            this.redBT.BackColor = System.Drawing.Color.Tomato;
            this.redBT.Location = new System.Drawing.Point(17, 29);
            this.redBT.Name = "redBT";
            this.redBT.Size = new System.Drawing.Size(83, 40);
            this.redBT.TabIndex = 0;
            this.redBT.Text = "Red";
            this.redBT.UseVisualStyleBackColor = false;
            this.redBT.Click += new System.EventHandler(this.redBT_Click);
            // 
            // blueBT
            // 
            this.blueBT.BackColor = System.Drawing.Color.CornflowerBlue;
            this.blueBT.Location = new System.Drawing.Point(106, 29);
            this.blueBT.Name = "blueBT";
            this.blueBT.Size = new System.Drawing.Size(83, 40);
            this.blueBT.TabIndex = 1;
            this.blueBT.Text = "Blue";
            this.blueBT.UseVisualStyleBackColor = false;
            this.blueBT.Click += new System.EventHandler(this.blueBT_Click);
            // 
            // greenBT
            // 
            this.greenBT.BackColor = System.Drawing.Color.LimeGreen;
            this.greenBT.Location = new System.Drawing.Point(17, 75);
            this.greenBT.Name = "greenBT";
            this.greenBT.Size = new System.Drawing.Size(83, 40);
            this.greenBT.TabIndex = 2;
            this.greenBT.Text = "Green";
            this.greenBT.UseVisualStyleBackColor = false;
            this.greenBT.Click += new System.EventHandler(this.greenBT_Click);
            // 
            // yellowBT
            // 
            this.yellowBT.BackColor = System.Drawing.Color.Gold;
            this.yellowBT.Location = new System.Drawing.Point(106, 75);
            this.yellowBT.Name = "yellowBT";
            this.yellowBT.Size = new System.Drawing.Size(83, 40);
            this.yellowBT.TabIndex = 3;
            this.yellowBT.Text = "Yellow";
            this.yellowBT.UseVisualStyleBackColor = false;
            this.yellowBT.Click += new System.EventHandler(this.yellowBT_Click);
            // 
            // wildFormClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 245);
            this.Controls.Add(this.pickacolorGB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "wildFormClass";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "wildFormClass";
            this.TopMost = true;
            this.pickacolorGB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox pickacolorGB;
        private System.Windows.Forms.Button yellowBT;
        private System.Windows.Forms.Button greenBT;
        private System.Windows.Forms.Button blueBT;
        private System.Windows.Forms.Button redBT;
    }
}