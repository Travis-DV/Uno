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
            player.EligableCards(game.DiscardPile[game.DiscardPile.Count - 1], game.is_Flipped.ToInt());
            MessageBox.Show("AI Play");
            MessageBox.Show("AI e_Hand count " + player.e_Hand.Count);
            if (player.e_Hand.Count < 1) { game.DrawPileClickLogic(); return;  }
            int rand = RandomNumber.Between(0, player.e_Hand.Count - 1);
            if (player.e_Hand.Count == 1) { rand = 0; }
            MessageBox.Show($"Rand: {rand}, e_hand.Count: {player.e_Hand.Count}");
            string word = "AI";
            word += player.Hand.ToString();
            word += player.e_Hand[rand];
            word += game.is_Flipped.ToInt().ToString();
            word += player.e_Hand[rand].cardPB[game.is_Flipped.ToInt()].ToString();
            MessageBox.Show(word);
            MessageBox.Show("AI index: " + game.FindPictureInList(player.Hand, player.e_Hand[rand].cardPB[game.is_Flipped.ToInt()]).ToString());
            game.CardClickLogic(game.FindPictureInList(player.Hand, player.e_Hand[rand].cardPB[game.is_Flipped.ToInt()]));
        }
    }
}
