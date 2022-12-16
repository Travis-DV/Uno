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
            this.GameRuleGB = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ChainAddsBT = new System.Windows.Forms.Button();
            this.DrawToMatchBT = new System.Windows.Forms.Button();
            this.AmountOfCardsLB = new System.Windows.Forms.Label();
            this.ChainAddsLB = new System.Windows.Forms.Label();
            this.DrawToMatchLB = new System.Windows.Forms.Label();
            this.GameModeGB = new System.Windows.Forms.GroupBox();
            this.flipGameBT = new System.Windows.Forms.Button();
            this.normalGameBT = new System.Windows.Forms.Button();
            this.GameRuleGB.SuspendLayout();
            this.GameModeGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameRuleGB
            // 
            this.GameRuleGB.Controls.Add(this.textBox1);
            this.GameRuleGB.Controls.Add(this.ChainAddsBT);
            this.GameRuleGB.Controls.Add(this.DrawToMatchBT);
            this.GameRuleGB.Controls.Add(this.AmountOfCardsLB);
            this.GameRuleGB.Controls.Add(this.ChainAddsLB);
            this.GameRuleGB.Controls.Add(this.DrawToMatchLB);
            this.GameRuleGB.Location = new System.Drawing.Point(12, 144);
            this.GameRuleGB.Name = "GameRuleGB";
            this.GameRuleGB.Size = new System.Drawing.Size(200, 100);
            this.GameRuleGB.TabIndex = 0;
            this.GameRuleGB.TabStop = false;
            this.GameRuleGB.Text = "Game Options";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(90, 74);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(75, 20);
            this.textBox1.TabIndex = 2;
            // 
            // ChainAddsBT
            // 
            this.ChainAddsBT.Location = new System.Drawing.Point(90, 44);
            this.ChainAddsBT.Name = "ChainAddsBT";
            this.ChainAddsBT.Size = new System.Drawing.Size(75, 23);
            this.ChainAddsBT.TabIndex = 4;
            this.ChainAddsBT.Text = "False";
            this.ChainAddsBT.UseVisualStyleBackColor = true;
            this.ChainAddsBT.Click += new System.EventHandler(this.ChainAddsBT_Click);
            // 
            // DrawToMatchBT
            // 
            this.DrawToMatchBT.Location = new System.Drawing.Point(90, 15);
            this.DrawToMatchBT.Name = "DrawToMatchBT";
            this.DrawToMatchBT.Size = new System.Drawing.Size(75, 23);
            this.DrawToMatchBT.TabIndex = 3;
            this.DrawToMatchBT.Text = "False";
            this.DrawToMatchBT.UseVisualStyleBackColor = true;
            this.DrawToMatchBT.Click += new System.EventHandler(this.DrawToMatchBT_Click);
            // 
            // AmountOfCardsLB
            // 
            this.AmountOfCardsLB.AutoSize = true;
            this.AmountOfCardsLB.Location = new System.Drawing.Point(7, 76);
            this.AmountOfCardsLB.Name = "AmountOfCardsLB";
            this.AmountOfCardsLB.Size = new System.Drawing.Size(85, 13);
            this.AmountOfCardsLB.TabIndex = 2;
            this.AmountOfCardsLB.Text = "Amount of Cards";
            // 
            // ChainAddsLB
            // 
            this.ChainAddsLB.AutoSize = true;
            this.ChainAddsLB.Location = new System.Drawing.Point(7, 49);
            this.ChainAddsLB.Name = "ChainAddsLB";
            this.ChainAddsLB.Size = new System.Drawing.Size(50, 13);
            this.ChainAddsLB.TabIndex = 1;
            this.ChainAddsLB.Text = "Chain +\'s";
            // 
            // DrawToMatchLB
            // 
            this.DrawToMatchLB.AutoSize = true;
            this.DrawToMatchLB.Location = new System.Drawing.Point(7, 20);
            this.DrawToMatchLB.Name = "DrawToMatchLB";
            this.DrawToMatchLB.Size = new System.Drawing.Size(77, 13);
            this.DrawToMatchLB.TabIndex = 0;
            this.DrawToMatchLB.Text = "Draw to Match";
            // 
            // GameModeGB
            // 
            this.GameModeGB.Controls.Add(this.flipGameBT);
            this.GameModeGB.Controls.Add(this.normalGameBT);
            this.GameModeGB.Location = new System.Drawing.Point(168, 12);
            this.GameModeGB.Name = "GameModeGB";
            this.GameModeGB.Size = new System.Drawing.Size(200, 100);
            this.GameModeGB.TabIndex = 1;
            this.GameModeGB.TabStop = false;
            this.GameModeGB.Text = "Game Mode";
            // 
            // flipGameBT
            // 
            this.flipGameBT.Location = new System.Drawing.Point(100, 37);
            this.flipGameBT.Name = "flipGameBT";
            this.flipGameBT.Size = new System.Drawing.Size(75, 23);
            this.flipGameBT.TabIndex = 1;
            this.flipGameBT.Text = "Flip";
            this.flipGameBT.UseVisualStyleBackColor = true;
            this.flipGameBT.Click += new System.EventHandler(this.flipGameBT_Click);
            // 
            // normalGameBT
            // 
            this.normalGameBT.BackColor = System.Drawing.SystemColors.Control;
            this.normalGameBT.Location = new System.Drawing.Point(19, 37);
            this.normalGameBT.Name = "normalGameBT";
            this.normalGameBT.Size = new System.Drawing.Size(75, 23);
            this.normalGameBT.TabIndex = 0;
            this.normalGameBT.Text = "Normal";
            this.normalGameBT.UseVisualStyleBackColor = false;
            this.normalGameBT.Click += new System.EventHandler(this.normalGameBT_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 353);
            this.Controls.Add(this.GameModeGB);
            this.Controls.Add(this.GameRuleGB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Uno Setup";
            this.GameRuleGB.ResumeLayout(false);
            this.GameRuleGB.PerformLayout();
            this.GameModeGB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GameRuleGB;
        private System.Windows.Forms.Label DrawToMatchLB;
        private System.Windows.Forms.Label AmountOfCardsLB;
        private System.Windows.Forms.Label ChainAddsLB;
        private System.Windows.Forms.GroupBox GameModeGB;
        private System.Windows.Forms.Button flipGameBT;
        private System.Windows.Forms.Button normalGameBT;
        private System.Windows.Forms.Button ChainAddsBT;
        private System.Windows.Forms.Button DrawToMatchBT;
        private System.Windows.Forms.TextBox textBox1;
    }
}

