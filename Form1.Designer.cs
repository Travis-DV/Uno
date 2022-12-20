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
            this.AmountOfCardsTB = new System.Windows.Forms.TextBox();
            this.ChainAddsBT = new System.Windows.Forms.Button();
            this.DrawToMatchBT = new System.Windows.Forms.Button();
            this.AmountOfCardsLB = new System.Windows.Forms.Label();
            this.ChainAddsLB = new System.Windows.Forms.Label();
            this.DrawToMatchLB = new System.Windows.Forms.Label();
            this.GameModeGB = new System.Windows.Forms.GroupBox();
            this.flipGameBT = new System.Windows.Forms.Button();
            this.normalGameBT = new System.Windows.Forms.Button();
            this.amountOfPlayersGB = new System.Windows.Forms.GroupBox();
            this.twoVtwoBT = new System.Windows.Forms.Button();
            this.fourPlayersBT = new System.Windows.Forms.Button();
            this.threePlayersBT = new System.Windows.Forms.Button();
            this.twoPlayersBT = new System.Windows.Forms.Button();
            this.doneBT = new System.Windows.Forms.Button();
            this.GameRuleGB.SuspendLayout();
            this.GameModeGB.SuspendLayout();
            this.amountOfPlayersGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameRuleGB
            // 
            this.GameRuleGB.Controls.Add(this.AmountOfCardsTB);
            this.GameRuleGB.Controls.Add(this.ChainAddsBT);
            this.GameRuleGB.Controls.Add(this.DrawToMatchBT);
            this.GameRuleGB.Controls.Add(this.AmountOfCardsLB);
            this.GameRuleGB.Controls.Add(this.ChainAddsLB);
            this.GameRuleGB.Controls.Add(this.DrawToMatchLB);
            this.GameRuleGB.Location = new System.Drawing.Point(168, 224);
            this.GameRuleGB.Name = "GameRuleGB";
            this.GameRuleGB.Size = new System.Drawing.Size(200, 100);
            this.GameRuleGB.TabIndex = 0;
            this.GameRuleGB.TabStop = false;
            this.GameRuleGB.Text = "Game Options";
            // 
            // AmountOfCardsTB
            // 
            this.AmountOfCardsTB.Location = new System.Drawing.Point(90, 74);
            this.AmountOfCardsTB.Name = "AmountOfCardsTB";
            this.AmountOfCardsTB.Size = new System.Drawing.Size(75, 20);
            this.AmountOfCardsTB.TabIndex = 2;
            this.AmountOfCardsTB.Text = "7";
            this.AmountOfCardsTB.TextChanged += new System.EventHandler(this.AmountOfCardsTB_TextChanged);
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
            // amountOfPlayersGB
            // 
            this.amountOfPlayersGB.Controls.Add(this.twoVtwoBT);
            this.amountOfPlayersGB.Controls.Add(this.fourPlayersBT);
            this.amountOfPlayersGB.Controls.Add(this.threePlayersBT);
            this.amountOfPlayersGB.Controls.Add(this.twoPlayersBT);
            this.amountOfPlayersGB.Location = new System.Drawing.Point(145, 118);
            this.amountOfPlayersGB.Name = "amountOfPlayersGB";
            this.amountOfPlayersGB.Size = new System.Drawing.Size(252, 100);
            this.amountOfPlayersGB.TabIndex = 2;
            this.amountOfPlayersGB.TabStop = false;
            this.amountOfPlayersGB.Text = "Amount Of Players";
            // 
            // twoVtwoBT
            // 
            this.twoVtwoBT.Location = new System.Drawing.Point(88, 54);
            this.twoVtwoBT.Name = "twoVtwoBT";
            this.twoVtwoBT.Size = new System.Drawing.Size(75, 23);
            this.twoVtwoBT.TabIndex = 3;
            this.twoVtwoBT.Text = "2v2";
            this.twoVtwoBT.UseVisualStyleBackColor = true;
            this.twoVtwoBT.Click += new System.EventHandler(this.twoVtwoBT_Click);
            // 
            // fourPlayersBT
            // 
            this.fourPlayersBT.Location = new System.Drawing.Point(169, 25);
            this.fourPlayersBT.Name = "fourPlayersBT";
            this.fourPlayersBT.Size = new System.Drawing.Size(75, 23);
            this.fourPlayersBT.TabIndex = 2;
            this.fourPlayersBT.Text = "4 Players";
            this.fourPlayersBT.UseVisualStyleBackColor = true;
            this.fourPlayersBT.Click += new System.EventHandler(this.fourPlayersBT_Click);
            // 
            // threePlayersBT
            // 
            this.threePlayersBT.Location = new System.Drawing.Point(88, 25);
            this.threePlayersBT.Name = "threePlayersBT";
            this.threePlayersBT.Size = new System.Drawing.Size(75, 23);
            this.threePlayersBT.TabIndex = 1;
            this.threePlayersBT.Text = "3 Players";
            this.threePlayersBT.UseVisualStyleBackColor = true;
            this.threePlayersBT.Click += new System.EventHandler(this.threePlayersBT_Click);
            // 
            // twoPlayersBT
            // 
            this.twoPlayersBT.Location = new System.Drawing.Point(7, 25);
            this.twoPlayersBT.Name = "twoPlayersBT";
            this.twoPlayersBT.Size = new System.Drawing.Size(75, 23);
            this.twoPlayersBT.TabIndex = 0;
            this.twoPlayersBT.Text = "2 Players";
            this.twoPlayersBT.UseVisualStyleBackColor = true;
            this.twoPlayersBT.Click += new System.EventHandler(this.twoPlayersBT_Click);
            // 
            // doneBT
            // 
            this.doneBT.Location = new System.Drawing.Point(222, 330);
            this.doneBT.Name = "doneBT";
            this.doneBT.Size = new System.Drawing.Size(75, 23);
            this.doneBT.TabIndex = 3;
            this.doneBT.Text = "Done";
            this.doneBT.UseVisualStyleBackColor = true;
            this.doneBT.Click += new System.EventHandler(this.doneBT_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 377);
            this.Controls.Add(this.doneBT);
            this.Controls.Add(this.amountOfPlayersGB);
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
            this.amountOfPlayersGB.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox AmountOfCardsTB;
        private System.Windows.Forms.GroupBox amountOfPlayersGB;
        private System.Windows.Forms.Button twoVtwoBT;
        private System.Windows.Forms.Button fourPlayersBT;
        private System.Windows.Forms.Button threePlayersBT;
        private System.Windows.Forms.Button twoPlayersBT;
        private System.Windows.Forms.Button doneBT;
    }
}

