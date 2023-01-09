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
            MessageBox.Show("AI e_Hand count " + player.e_Hand.Count);
            if (player.e_Hand.Count == 0) { game.DrawPileClickLogic(); return;  }
            int rand = RandomNumber.Between(0, player.e_Hand.Count - 1);
            MessageBox.Show("AI index: " + game.FindPictureInList(player.Hand, player.e_Hand[rand].cardPB[game.is_Flipped.ToInt()]).ToString());
            game.CardClickLogic(game.FindPictureInList(player.Hand, player.e_Hand[rand].cardPB[game.is_Flipped.ToInt()]));
        }
    }
}
