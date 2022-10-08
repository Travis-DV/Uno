namespace uno
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.player1LB = new System.Windows.Forms.Label();
            this.player2LB = new System.Windows.Forms.Label();
            this.player3LB = new System.Windows.Forms.Label();
            this.player4LB = new System.Windows.Forms.Label();
            this.la = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(540, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 127);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // player4LB
            // 
            this.player4LB.Location = new System.Drawing.Point(0, 0);
            this.player4LB.Name = "player4LB";
            this.player4LB.Size = new System.Drawing.Size(100, 23);
            this.player4LB.TabIndex = 9;
            // 
            // player1LB
            // 
            this.la.AutoSize = false;
            this.la.Location = new System.Drawing.Point(162, 622);
            this.la.Name = "player1LB";
            this.la.Size = new System.Drawing.Size(64, 25);
            this.la.TabIndex = 10;
            this.la.Text = "1";
            // 
            // player2LB
            // 
            this.label2.AutoSize = false;
            this.label2.Location = new System.Drawing.Point(1022, 622);
            this.label2.Name = "player2LB";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "2";
            // 
            // player3LB
            // 
            this.label3.AutoSize = false;
            this.label3.Location = new System.Drawing.Point(1022, 118);
            this.label3.Name = "player3LB";
            this.label3.Size = new System.Drawing.Size(64, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "2";
            // 
            // player4LB
            // 
            this.label4.AutoSize = false;
            this.label4.Location = new System.Drawing.Point(162, 118);
            this.label4.Name = "player4LB";
            this.label4.Size = new System.Drawing.Size(64, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 757);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.la);
            this.Controls.Add(this.player1LB);
            this.Controls.Add(this.player2LB);
            this.Controls.Add(this.player3LB);
            this.Controls.Add(this.player4LB);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label player1LB;
        public System.Windows.Forms.Label player2LB;
        public System.Windows.Forms.Label player3LB;
        public System.Windows.Forms.Label player4LB;
        private System.Windows.Forms.Label la;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

