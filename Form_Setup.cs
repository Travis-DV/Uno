using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace uno
{
	public partial class SetupFormClass : Form
	{

        #region Game Rules
        private Dictionary<string, bool> GameRules = new Dictionary<string, bool>
        {
            { "do_DrawtoMatch", false},
            { "do_Flip", false},
            { "do_ChainAdds", false},
            { "do_2v2", false }
        };
		private int CardAmount = 7;
        private int PlayerAmount = 0;
        #endregion

        public SetupFormClass()
		{
			InitializeComponent();
            normalGameBT.BackColor = Color.Red;
            flipGameBT.BackColor = Color.LightGray;
            twoPlayersBT.BackColor = Color.LightGray;
            threePlayersBT.BackColor = Color.LightGray;
            fourPlayersBT.BackColor = Color.LightGray;
            twoVtwoBT.BackColor = Color.LightGray;
        }
        //GameLogicClass game = new GameLogicClass(PlayerAmount, GameRules["do_Flip"], GameRules["do_DrawtoMatch"], GameRules["do_ChainAdds"], CardAmount);

        private void normalGameBT_Click(object sender, EventArgs e)
        {
			GameRules["do_Flip"] = false;
			normalGameBT.BackColor = Color.Red;
			flipGameBT.BackColor = Color.LightGray;
        }

        private void flipGameBT_Click(object sender, EventArgs e)
        {
			GameRules["do_Flip"] = true;
			flipGameBT.BackColor = Color.Purple;
			normalGameBT.BackColor = Color.LightGray;
        }

        private void DrawToMatchBT_Click(object sender, EventArgs e)
        {
			if (!GameRules["do_DrawtoMatch"])
			{
				DrawToMatchBT.Text = "True";
				GameRules["do_DrawtoMatch"] = true;
			}
            else if (GameRules["do_DrawtoMatch"])
            {
                DrawToMatchBT.Text = "False";
                GameRules["do_DrawtoMatch"] = false;
            }
        }

        private void ChainAddsBT_Click(object sender, EventArgs e)
        {
            if (!GameRules["do_ChainAdds"])
            {
                ChainAddsBT.Text = "True";
                GameRules["do_ChainAdds"] = true;
            }
            else if (GameRules["do_ChainAdds"])
            {
                ChainAddsBT.Text = "False";
                GameRules["do_ChainAdds"] = false;
            }
        }

        private void AmountOfCardsTB_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(AmountOfCardsTB.Text, out var amount)) 
            {
                AmountOfCardsTB.Text = $"{CardAmount}";
                return;
            }
            if (int.Parse(AmountOfCardsTB.Text) < 0)
            {
                AmountOfCardsTB.Text = $"{CardAmount}";
                return;
            }
            CardAmount = int.Parse(AmountOfCardsTB.Text.Trim());
            AmountOfCardsTB.Text = AmountOfCardsTB.Text.Trim();
            AmountOfCardsTB.SelectionStart = AmountOfCardsTB.Text.Length;
        }

        private void doneBT_Click(object sender, EventArgs e)
        {
            if (PlayerAmount != 0) 
            { 
                GameForm gameForm = new GameForm(GameRules, PlayerAmount, CardAmount); 
                this.Hide(); 
                gameForm.Show(); 
            }
        }

        private void twoPlayersBT_Click(object sender, EventArgs e)
        {
            twoPlayersBT.BackColor = Color.Gray;
            threePlayersBT.BackColor = Color.LightGray;
            fourPlayersBT.BackColor = Color.LightGray;
            twoVtwoBT.BackColor = Color.LightGray;
            PlayerAmount = 2;
            GameRules["do_2v2"] = false;
        }

        private void threePlayersBT_Click(object sender, EventArgs e)
        {
            twoPlayersBT.BackColor = Color.LightGray;
            threePlayersBT.BackColor = Color.Gray;
            fourPlayersBT.BackColor = Color.LightGray;
            twoVtwoBT.BackColor = Color.LightGray;
            PlayerAmount = 4;
            GameRules["do_2v2"] = false;
        }

        private void fourPlayersBT_Click(object sender, EventArgs e)
        {
            twoPlayersBT.BackColor = Color.LightGray;
            threePlayersBT.BackColor = Color.LightGray;
            fourPlayersBT.BackColor = Color.Gray;
            twoVtwoBT.BackColor = Color.LightGray;
            PlayerAmount = 4;
            GameRules["do_2v2"] = false;
        }

        private void twoVtwoBT_Click(object sender, EventArgs e)
        {
            twoPlayersBT.BackColor = Color.LightGray;
            threePlayersBT.BackColor = Color.LightGray;
            fourPlayersBT.BackColor = Color.LightGray;
            twoVtwoBT.BackColor = Color.Gray;
            PlayerAmount = 4;
            GameRules["do_2v2"] = true;
        }
    }
}