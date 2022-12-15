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

namespace newuno
{

    //Add 3 buttens {2 players} {3 players} and {4 players}
    //only 2 player at this point

    //Add 2 more buttens {do_Flip} {do_DrawtoMatch}
    //When check if they are all done then pass through

	public partial class Form1 : Form
	{

        private bool do_DrawtoMatch? = null;
        private bool do_Flip? = null;
        private int PlayerAmount = 0;

		public Form1()
		{
			InitializeComponent();
		}

        private updatecheck() 
        {
            if (do_DrawtoMatch != null && do_Flip != null && PlayerAmount > 1) 
            {
                gamelogic game = new gamelogic(PlayerAmount, do_Flip, do_DrawtoMatch);
            }
        }
        
	}

    class card 
    {
        public card(string color, string number, int points)
    }

    class player {}

    //add flip cards and change 

    class gamelogic
    {
        //game rules
        private bool do_DrawtoMatch = false;
        private bool do_Flip = false;
        private int PlayerAmount = -1;

        //setup
        if (!do_Flip) {private List<List<card>> deck = new List<List<card>>() {{ new card("red", "0", 0), new card("red", "1", 1), new card("red", "2", 2), new card("red", "3", 3), new card("red", "4", 4), new card("red", "5", 5), new card("red", "6", 6), new card("red", "7", 7), new card("red", "8", 8), new card("red", "9", 9), new card("red", "+2"), new card("red", "reverse", 20), new card("red", "skip", 20), new card("yellow", "0", 0), new card("yellow", "1", 1), new card("yellow", "2", 2), new card("yellow", "3", 3), new card("yellow", "4", 4), new card("yellow", "5", 5), new card("yellow", "6", 6), new card("yellow", "7", 7), new card("yellow", "8", 8), new card("yellow", "9", 9), new card("yellow", "+2"), new card("yellow", "reverse", 20), new card("yellow", "skip", 20), new card("green", "0", 0), new card("green", "1", 1), new card("green", "2", 2), new card("green", "3", 3), new card("green", "4", 4), new card("green", "5", 5), new card("green", "6", 6), new card("green", "7", 7), new card("green", "8", 8), new card("green", "9", 9), new card("green", "+2"), new card("green", "reverse", 20), new card("green", "skip", 20), new card("blue", "0", 0), new card("blue", "1", 1), new card("blue", "2", 2), new card("blue", "3", 3), new card("blue", "4", 4), new card("blue", "5", 5), new card("blue", "6", 6), new card("blue", "7", 7), new card("blue", "8", 8), new card("blue", "9", 9), new card("blue", "+2"), new card("blue", "reverse", 20), new card("blue", "skip", 20), new card("red", "1", 1), new card("red", "2", 2), new card("red", "3", 3), new card("red", "4", 4), new card("red", "5", 5), new card("red", "6", 6), new card("red", "7", 7), new card("red", "8", 8), new card("red", "9", 9), new card("red", "+2"), new card("red", "reverse", 20), new card("red", "skip", 20), new card("yellow", "1", 1), new card("yellow", "2", 2), new card("yellow", "3", 3), new card("yellow", "4", 4), new card("yellow", "5", 5), new card("yellow", "6", 6), new card("yellow", "7", 7), new card("yellow", "8", 8), new card("yellow", "9", 9), new card("yellow", "+2"), new card("yellow", "reverse", 20), new card("yellow", "skip", 20), new card("green", "1", 1), new card("green", "2", 2), new card("green", "3", 3), new card("green", "4", 4), new card("green", "5", 5), new card("green", "6", 6), new card("green", "7", 7), new card("green", "8", 8), new card("green", "9", 9), new card("green", "+2"), new card("green", "reverse", 20), new card("green", "skip", 20), new card("blue", "1", 1), new card("blue", "2", 2), new card("blue", "3", 3), new card("blue", "4", 4), new card("blue", "5", 5), new card("blue", "6", 6), new card("blue", "7", 7), new card("blue", "8", 8), new card("blue", "9", 9), new card("blue", "+2"), new card("blue", "reverse", 20), new card("blue", "skip", 20), new card("Wild", "+2_wild", 50), new card("Wild", "+4_wild", 50), new card("Wild", "+4_wild", 50), new card("Wild", "+4_wild", 50), new card("Wild", "wild", 40), new card("Wild", "wild", 40), new card("Wild", "wild", 40), new card("Wild", "wild", 40)}};
        if (do_Flip) {private List<List<card>> deck = new List<List<card>>() {{ new card("red", "1", 1), new card("red", "2", 2), new card("red", "3", 3), new card("red", "4", 4), new card("red", "5", 5), new card("red", "6", 6), new card("red", "7", 7), new card("red", "8", 8), new card("red", "9", 9), new card("red", "+1", 10, 10), new card("red", "flip", 20), new card("red", "reverse", 20), new card("red", "skip", 20), new card("yellow", "1", 1), new card("yellow", "2", 2), new card("yellow", "3", 3), new card("yellow", "4", 4), new card("yellow", "5", 5), new card("yellow", "6", 6), new card("yellow", "7", 7), new card("yellow", "8", 8), new card("yellow", "9", 9), new card("yellow", "+1", 10), new card("yellow", "flip", 20), new card("yellow", "reverse", 20), new card("yellow", "skip", 20), new card("green", "1", 1), new card("green", "2", 2), new card("green", "3", 3), new card("green", "4", 4), new card("green", "5", 5), new card("green", "6", 6), new card("green", "7", 7), new card("green", "8", 8), new card("green", "9", 9), new card("green", "+1", 10), new card("green", "flip", 20), new card("green", "reverse", 20), new card("green", "skip", 20), new card("blue", "1", 1), new card("blue", "2", 2), new card("blue", "3", 3), new card("blue", "4", 4), new card("blue", "5", 5), new card("blue", "6", 6), new card("blue", "7", 7), new card("blue", "8", 8), new card("blue", "9", 9), new card("blue", "+1", 10), new card("blue", "flip", 20), new card("blue", "reverse", 20), new card("blue", "skip", 20), new card("red", "2", 2), new card("red", "3", 3), new card("red", "4", 4), new card("red", "5", 5), new card("red", "6", 6), new card("red", "7", 7), new card("red", "8", 8), new card("red", "9", 9), new card("red", "+1", 10), new card("red", "flip", 20), new card("red", "reverse", 20), new card("red", "skip", 20), new card("yellow", "2", 2), new card("yellow", "3", 3), new card("yellow", "4", 4), new card("yellow", "5", 5), new card("yellow", "6", 6), new card("yellow", "7", 7), new card("yellow", "8", 8), new card("yellow", "9", 9), new card("yellow", "+1", 10), new card("yellow", "flip", 20), new card("yellow", "reverse", 20), new card("yellow", "skip", 20), new card("green", "2", 2), new card("green", "3", 3), new card("green", "4", 4), new card("green", "5", 5), new card("green", "6", 6), new card("green", "7", 7), new card("green", "8", 8), new card("green", "9", 9), new card("green", "+1", 10), new card("green", "flip", 20), new card("green", "reverse", 20), new card("green", "skip", 20), new card("blue", "2", 2), new card("blue", "3", 3), new card("blue", "4", 4), new card("blue", "5", 5), new card("blue", "6", 6), new card("blue", "7", 7), new card("blue", "8", 8), new card("blue", "9", 9), new card("blue", "+1", 10), new card("blue", "flip", 20), new card("blue", "reverse", 20), new card("blue", "skip", 20), new card("Wild", "+2_wild", 50), new card("Wild", "+2_wild", 50), new card("Wild", "+2_wild", 50), new card("Wild", "+2_wild", 50), new card("Wild", "wild", 40), new card("Wild", "wild", 40), new card("Wild", "wild", 40), new card("Wild", "wild", 40)}, {new card("purple", "1", 1), new card("purple", "2", 2), new card("purple", "3", 3), new card("purple", "4", 4), new card("purple", "5", 5), new card("purple", "6", 6), new card("purple", "7", 7), new card("purple", "8", 8), new card("purple", "9", 9), new card("purple", "+5", 20), new card("purple", "flip", 20), new card("purple", "reverse", 20), new card("purple", "skip_all", 30), new card("teal", "1", 1), new card("teal", "2", 2), new card("teal", "3", 3), new card("teal", "4", 4), new card("teal", "5", 5), new card("teal", "6", 6), new card("teal", "7", 7), new card("teal", "8", 8), new card("teal", "9", 9), new card("teal", "+5", 20), new card("teal", "flip", 20), new card("teal", "reverse", 20), new card("teal", "skip_all", 30), new card("orange", "1", 1), new card("orange", "2", 2), new card("orange", "3", 3), new card("orange", "4", 4), new card("orange", "5", 5), new card("orange", "6", 6), new card("orange", "7", 7), new card("orange", "8", 8), new card("orange", "9", 9), new card("orange", "+5", 20), new card("orange", "flip", 20), new card("orange", "reverse", 20), new card("orange", "skip_all", 30), new card("pink", "1", 1), new card("pink", "2", 2), new card("pink", "3", 3), new card("pink", "4", 4), new card("pink", "5", 5), new card("pink", "6", 6), new card("pink", "7", 7), new card("pink", "8", 8), new card("pink", "9", 9), new card("pink", "+5", 20), new card("pink", "flip", 20), new card("pink", "reverse", 20), new card("pink", "skip_all", 30), new card("purple", "2", 2), new card("purple", "3", 3), new card("purple", "4", 4), new card("purple", "5", 5), new card("purple", "6", 6), new card("purple", "7", 7), new card("purple", "8", 8), new card("purple", "9", 9), new card("purple", "+5", 20), new card("purple", "flip", 20), new card("purple", "reverse", 20), new card("purple", "skip_all", 30), new card("teal", "2", 2), new card("teal", "3", 3), new card("teal", "4", 4), new card("teal", "5", 5), new card("teal", "6", 6), new card("teal", "7", 7), new card("teal", "8", 8), new card("teal", "9", 9), new card("teal", "+5", 20), new card("teal", "flip", 20), new card("teal", "reverse", 20), new card("teal", "skip_all", 30), new card("orange", "2", 2), new card("orange", "3", 3), new card("orange", "4", 4), new card("orange", "5", 5), new card("orange", "6", 6), new card("orange", "7", 7), new card("orange", "8", 8), new card("orange", "9", 9), new card("orange", "+5", 20), new card("orange", "flip", 20), new card("orange", "reverse", 20), new card("orange", "skip_all", 30), new card("pink", "2", 2), new card("pink", "3", 3), new card("pink", "4", 4), new card("pink", "5", 5), new card("pink", "6", 6), new card("pink", "7", 7), new card("pink", "8", 8), new card("pink", "9", 9), new card("pink", "+5", 20), new card("pink", "flip", 20), new card("pink", "reverse", 20), new card("pink", "skip_all", 30), new card("Wild", "+draw_match", 60), new card("Wild", "+draw_match", 60), new card("Wild", "+draw_match", 60), new card("Wild", "+draw_match", 60), new card("Wild", "wild", 40), new card("Wild", "wild", 40), new card("Wild", "wild", 40), new card("Wild", "wild", 40)}};
		public List<player> players = new List<player>();

        //game states
        private bool is_Fliped = false;
        private bool is_reverced = false;
        private bool PlayerIndex = -1;

        //On init
        public gamelogic(int PlayerAmount, bool do_Flip, bool do_DrawtoMatch) 
        {
            //Setting up players
            for (int i = 0; i < PlayerAmount; i++) { players.Add(new player()); }

            //setting game rules
            this.do_DrawtoMatch = do_DrawtoMatch;
            this.do_Flip = do_Flip;
        }

        private void nextplayer()
		{
			if (!is_reverced && PlayerIndex++ < players.Count) { PlayerIndex++; }
			else if (!is_reverced && PlayerIndex++ == players.Count) { PlayerIndex = 0; }
			else if (is_reverced && PlayerIndex-- > 0) { PlayerIndex--; }
			else if (is_reverced && PlayerIndex-- == 0) { PlayerIndex = players.Count - 1; }
		}
    } 

    public static class RandomNumber
	{
		private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();
		public static int Between(int minimumValue, int maximumValue)
		{
			byte[] randomNumber = new byte[1];
			_generator.GetBytes(randomNumber);
			double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);
			double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);
			int range = maximumValue - minimumValue;
			double randomValueInRange = Math.Floor(multiplier * range);
			return (int)(minimumValue + randomValueInRange);
		}
	}
}