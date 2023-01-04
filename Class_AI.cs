using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uno
{
    internal class AIClass
    {

        private int[] Anger;

        public AIClass(int PlayerAmount)
        {
            this.Anger = new int[PlayerAmount];
        }

        public void Play(List<CardClass> p_e_Hand, GameLogicClass game)
        {
            MessageBox.Show("AI Play");
            if (p_e_Hand.Count == 0) { game.DrawPileClickLogic(); return;  }
            game.CardClickLogic(p_e_Hand[RandomNumber.Between(0, p_e_Hand.Count - 1)].cardPB[game.is_Flipped.ToInt()]);
        }
    }
}
