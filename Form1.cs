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
	public partial class Form1 : Form
	{

        #region Game Rules
        private bool do_DrawtoMatch = false;
		private bool do_Flip = false;
		private int PlayerAmount = 0;
		private bool do_ChainAdds = false;
		private int CardAmount = 7;
        private bool do_2v2 = false;
        #endregion

        public Form1()
		{
			InitializeComponent();
            normalGameBT.BackColor = Color.Red;
            flipGameBT.BackColor = Color.LightGray;
            twoPlayersBT.BackColor = Color.LightGray;
            threePlayersBT.BackColor = Color.LightGray;
            fourPlayersBT.BackColor = Color.LightGray;
            twoVtwoBT.BackColor = Color.LightGray;
        }
        //gamelogic game = new gamelogic(PlayerAmount, do_Flip, do_DrawtoMatch, do_ChainAdds, CardAmount);

        private void normalGameBT_Click(object sender, EventArgs e)
        {
			do_Flip = false;
			normalGameBT.BackColor = Color.Red;
			flipGameBT.BackColor = Color.LightGray;
        }

        private void flipGameBT_Click(object sender, EventArgs e)
        {
			do_Flip = true;
			flipGameBT.BackColor = Color.Purple;
			normalGameBT.BackColor = Color.LightGray;
        }

        private void DrawToMatchBT_Click(object sender, EventArgs e)
        {
			if (!do_DrawtoMatch)
			{
				DrawToMatchBT.Text = "True";
				do_DrawtoMatch = true;
			}
            else if (do_DrawtoMatch)
            {
                DrawToMatchBT.Text = "False";
                do_DrawtoMatch = false;
            }
        }

        private void ChainAddsBT_Click(object sender, EventArgs e)
        {
            if (!do_ChainAdds)
            {
                ChainAddsBT.Text = "True";
                do_ChainAdds = true;
            }
            else if (do_ChainAdds)
            {
                ChainAddsBT.Text = "False";
                do_ChainAdds = false;
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
            if (PlayerAmount != 0) { Form3 form3 = new Form3(); gamelogic game = new gamelogic(PlayerAmount, do_Flip, do_DrawtoMatch, do_ChainAdds, do_2v2, form3, CardAmount); this.Hide(); form3.Show(); }
        }

        private void twoPlayersBT_Click(object sender, EventArgs e)
        {
            twoPlayersBT.BackColor = Color.Gray;
            threePlayersBT.BackColor = Color.LightGray;
            fourPlayersBT.BackColor = Color.LightGray;
            twoVtwoBT.BackColor = Color.LightGray;
            PlayerAmount = 2;
            do_2v2 = false;
        }

        private void threePlayersBT_Click(object sender, EventArgs e)
        {
            twoPlayersBT.BackColor = Color.LightGray;
            threePlayersBT.BackColor = Color.Gray;
            fourPlayersBT.BackColor = Color.LightGray;
            twoVtwoBT.BackColor = Color.LightGray;
            PlayerAmount = 4;
            do_2v2 = false;
        }

        private void fourPlayersBT_Click(object sender, EventArgs e)
        {
            twoPlayersBT.BackColor = Color.LightGray;
            threePlayersBT.BackColor = Color.LightGray;
            fourPlayersBT.BackColor = Color.Gray;
            twoVtwoBT.BackColor = Color.LightGray;
            PlayerAmount = 4;
            do_2v2 = false;
        }

        private void twoVtwoBT_Click(object sender, EventArgs e)
        {
            twoPlayersBT.BackColor = Color.LightGray;
            threePlayersBT.BackColor = Color.LightGray;
            fourPlayersBT.BackColor = Color.LightGray;
            twoVtwoBT.BackColor = Color.Gray;
            PlayerAmount = 4;
            do_2v2 = true;
        }
    }
}