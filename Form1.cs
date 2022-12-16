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

namespace uno
{
	public partial class Form1 : Form
	{
		private bool do_DrawtoMatch = false;
		private bool do_Flip = false;
		private int PlayerAmount = 0;
		private bool do_ChainAdds = false;
		private int CardAmount = 0;

		public Form1()
		{
			InitializeComponent();
            normalGameBT.BackColor = Color.LightGray;
            flipGameBT.BackColor = Color.LightGray;
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
    }
}