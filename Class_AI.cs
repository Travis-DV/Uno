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

        public void Play(PlayerClass player, GameLogicClass game)
        {
            MessageBox.Show("AI Play");
            player.EligableCards(game.DrawPile[game.DrawPile.Count-1], game.is_Flipped.ToInt());
            MessageBox.Show("AI e_Hand count " + player.e_Hand.Count);
            if (player.e_Hand.Count == 0) { game.DrawPileClickLogic(); return;  }
            int rand = RandomNumber.Between(0, player.e_Hand.Count - 1);
            MessageBox.Show("AI Rand: " + rand.ToString());
            game.CardClickLogic(rand);
        }
    }
}
