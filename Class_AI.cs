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
            console.Log("method; (AIClass.AIClass()) [AI INIT]");
            this.Anger = new int[PlayerAmount];
        }

        public void Play(PlayerClass player, GameLogicClass game)
        {
            player.EligableCards(game.DiscardPile[game.DiscardPile.Count - 1], game.is_Flipped.ToInt());
            if (player.e_Hand.Count < 1) { game.DrawPileClickLogic(); return;  }
            int rand = RandomNumber.Between(0, player.e_Hand.Count - 1);
            console.Log($"Method; (AIClass.Play()) [AI Play], Current player; ({player}), Player e_Hand amount; ({player.e_Hand.Count}), Card index; ({rand}), Card (e_Hand); ({player.e_Hand[rand]}), game.is_Flipped; ({game.is_Flipped}); Card (Hand); {game.FindPictureInList(player.Hand, player.e_Hand[rand].cardPB[game.is_Flipped.ToInt()])}");
            game.CardClickLogic(game.FindPictureInList(player.Hand, player.e_Hand[rand].cardPB[game.is_Flipped.ToInt()]));
        }
    }
}
