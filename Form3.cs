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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.FormClosing += Form3_FormClosing;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close the form?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }

    class card
    {
        public string n_color = "";
        public string n_number = "";
        public int n_points = -1;
        public string f_color = "";
        public string f_number = "";
        public int f_points = -1;
        public PictureBox cardPB = new PictureBox();
        public int[] location = { 0, 0 };

        public card(string color, string number, int points) 
        {
            this.n_color = color;
            this.n_number = number;
            this.n_points = points;
            cardPB.SizeMode = PictureBoxSizeMode.AutoSize; 
        }

        public void setflip(string color, string number, int points)
        {
            this.f_color = color; 
            this.f_number = number;
            this.f_points = points;
        }

        public void setPB_Location(int[] location) 
        {
            this.location = location;
            cardPB.Location = new Point(location[0], location[1]);
        }
    }

    class player
    {
        public List<card> cards = new List<card>();
        //x, y
        public int[] StartPosition = {0, 0, 0};

        public player(int StartingPositionIndex) 
        {
            StartPosition[2] = StartingPositionIndex;
        }

        public void setpicts(bool do_flip, Form3 from3)
        {
            this.findCardPosition(do_flip);
            for (int i = 0; i < cards.Count; i++) 
            {
                cards[i].cardPB.Image = Image.FromFile(Application.StartupPath + "\\" + this.n_findimage(i));
                from3.Controls.Add(cards[i].cardPB);
            }
        }

        public string n_findimage(int index) 
        { return $"small\\{cards[index].n_color}_{cards[index].n_number}.png"; }

        public string f_findimage(int index)
        { return $"small\\{cards[index].f_color}_{cards[index].f_number}.png"; }

        public void setSartPosition(int[] StartPosition)  
        { this.StartPosition = StartPosition; }

        public void findCardPosition(bool do_flip) 
        {
            if (cards.Count % 2 == 0) { cards[0].setPB_Location(new int[] { (cards.Count / 2) * 140, 0 });  }
            if (cards.Count % 2 == 1) { cards[0].setPB_Location(new int[] { ((cards.Count / 2) - 1) * 140, 0}); }
            for (int card_index = 1; card_index < cards.Count; card_index++) 
            {
                cards[card_index].setPB_Location(new int[] { cards[card_index - 1].location[0] + 140, 0 });
            }
        }
    }

    //add flip cards and change 

    internal class gamelogic
    {

        #region Game Rules
        //game rules
        private bool do_DrawtoMatch = false;
        private bool do_Flip = false;
        private int PlayerAmount = -1;
        private bool do_ChainAdds = false;
        private bool do_2v2 = false;
        #endregion

        //setup
        public List<card> deck = new List<card>();
        public List<player> players = new List<player>();

        //game states
        public bool is_Fliped = false;
        public bool is_reverced = false;
        public int PlayerIndex = -1;

        private Form3 form3;


        //On init
        public gamelogic(int PlayerAmount, bool do_Flip, bool do_DrawtoMatch, bool do_ChainAdds, bool do_2v2, Form3 form3, int CardAmount = 7)
        {

            #region Setting Game Rules
            //setting game rules
            this.PlayerAmount = PlayerAmount;
            this.do_DrawtoMatch = do_DrawtoMatch;
            this.do_Flip = do_Flip;
            this.do_ChainAdds = do_ChainAdds;
            this.do_2v2 = do_2v2;
            #endregion

            this.form3 = form3;

            //Setting up players
            for (int i = 0; i < PlayerAmount; i++) { players.Add(new player(i)); }

            //making deck
            this.makedeck();

            //Deal
            this.PlayerIndex = RandomNumber.Between(0, players.Count);
            for (int change = 0; change < players.Count; change++)
            {
                this.deal(CardAmount);
                this.nextplayer();
            }

            players[0].setpicts(this.do_Flip, this.form3);
        }

        private void makedeck()
        {
            if (!this.do_Flip) { deck = new List<card>() { new card("red", "0", 0), new card("red", "1", 1), new card("red", "2", 2), new card("red", "3", 3), new card("red", "4", 4), new card("red", "5", 5), new card("red", "6", 6), new card("red", "7", 7), new card("red", "8", 8), new card("red", "9", 9), new card("red", "+2", 10), new card("red", "reverse", 20), new card("red", "skip", 20), new card("yellow", "0", 0), new card("yellow", "1", 1), new card("yellow", "2", 2), new card("yellow", "3", 3), new card("yellow", "4", 4), new card("yellow", "5", 5), new card("yellow", "6", 6), new card("yellow", "7", 7), new card("yellow", "8", 8), new card("yellow", "9", 9), new card("yellow", "+2", 10), new card("yellow", "reverse", 20), new card("yellow", "skip", 20), new card("green", "0", 0), new card("green", "1", 1), new card("green", "2", 2), new card("green", "3", 3), new card("green", "4", 4), new card("green", "5", 5), new card("green", "6", 6), new card("green", "7", 7), new card("green", "8", 8), new card("green", "9", 9), new card("green", "+2", 10), new card("green", "reverse", 20), new card("green", "skip", 20), new card("blue", "0", 0), new card("blue", "1", 1), new card("blue", "2", 2), new card("blue", "3", 3), new card("blue", "4", 4), new card("blue", "5", 5), new card("blue", "6", 6), new card("blue", "7", 7), new card("blue", "8", 8), new card("blue", "9", 9), new card("blue", "+2", 10), new card("blue", "reverse", 20), new card("blue", "skip", 20), new card("red", "1", 1), new card("red", "2", 2), new card("red", "3", 3), new card("red", "4", 4), new card("red", "5", 5), new card("red", "6", 6), new card("red", "7", 7), new card("red", "8", 8), new card("red", "9", 9), new card("red", "+2", 10), new card("red", "reverse", 20), new card("red", "skip", 20), new card("yellow", "1", 1), new card("yellow", "2", 2), new card("yellow", "3", 3), new card("yellow", "4", 4), new card("yellow", "5", 5), new card("yellow", "6", 6), new card("yellow", "7", 7), new card("yellow", "8", 8), new card("yellow", "9", 9), new card("yellow", "+2", 10), new card("yellow", "reverse", 20), new card("yellow", "skip", 20), new card("green", "1", 1), new card("green", "2", 2), new card("green", "3", 3), new card("green", "4", 4), new card("green", "5", 5), new card("green", "6", 6), new card("green", "7", 7), new card("green", "8", 8), new card("green", "9", 9), new card("green", "+2", 10), new card("green", "reverse", 20), new card("green", "skip", 20), new card("blue", "1", 1), new card("blue", "2", 2), new card("blue", "3", 3), new card("blue", "4", 4), new card("blue", "5", 5), new card("blue", "6", 6), new card("blue", "7", 7), new card("blue", "8", 8), new card("blue", "9", 9), new card("blue", "+2", 10), new card("blue", "reverse", 20), new card("blue", "skip", 20), new card("Wild", "+2_wild", 50), new card("Wild", "+4_wild", 50), new card("Wild", "+4_wild", 50), new card("Wild", "+4_wild", 50), new card("Wild", "wild", 40), new card("Wild", "wild", 40), new card("Wild", "wild", 40), new card("Wild", "wild", 40) }; return; }
            deck = new List<card>() { new card("red", "1", 1), new card("red", "2", 2), new card("red", "3", 3), new card("red", "4", 4), new card("red", "5", 5), new card("red", "6", 6), new card("red", "7", 7), new card("red", "8", 8), new card("red", "9", 9), new card("red", "+1", 10), new card("red", "flip", 20), new card("red", "reverse", 20), new card("red", "skip", 20), new card("yellow", "1", 1), new card("yellow", "2", 2), new card("yellow", "3", 3), new card("yellow", "4", 4), new card("yellow", "5", 5), new card("yellow", "6", 6), new card("yellow", "7", 7), new card("yellow", "8", 8), new card("yellow", "9", 9), new card("yellow", "+1", 10), new card("yellow", "flip", 20), new card("yellow", "reverse", 20), new card("yellow", "skip", 20), new card("green", "1", 1), new card("green", "2", 2), new card("green", "3", 3), new card("green", "4", 4), new card("green", "5", 5), new card("green", "6", 6), new card("green", "7", 7), new card("green", "8", 8), new card("green", "9", 9), new card("green", "+1", 10), new card("green", "flip", 20), new card("green", "reverse", 20), new card("green", "skip", 20), new card("blue", "1", 1), new card("blue", "2", 2), new card("blue", "3", 3), new card("blue", "4", 4), new card("blue", "5", 5), new card("blue", "6", 6), new card("blue", "7", 7), new card("blue", "8", 8), new card("blue", "9", 9), new card("blue", "+1", 10), new card("blue", "flip", 20), new card("blue", "reverse", 20), new card("blue", "skip", 20), new card("red", "2", 2), new card("red", "3", 3), new card("red", "4", 4), new card("red", "5", 5), new card("red", "6", 6), new card("red", "7", 7), new card("red", "8", 8), new card("red", "9", 9), new card("red", "+1", 10), new card("red", "flip", 20), new card("red", "reverse", 20), new card("red", "skip", 20), new card("yellow", "2", 2), new card("yellow", "3", 3), new card("yellow", "4", 4), new card("yellow", "5", 5), new card("yellow", "6", 6), new card("yellow", "7", 7), new card("yellow", "8", 8), new card("yellow", "9", 9), new card("yellow", "+1", 10), new card("yellow", "flip", 20), new card("yellow", "reverse", 20), new card("yellow", "skip", 20), new card("green", "2", 2), new card("green", "3", 3), new card("green", "4", 4), new card("green", "5", 5), new card("green", "6", 6), new card("green", "7", 7), new card("green", "8", 8), new card("green", "9", 9), new card("green", "+1", 10), new card("green", "flip", 20), new card("green", "reverse", 20), new card("green", "skip", 20), new card("blue", "2", 2), new card("blue", "3", 3), new card("blue", "4", 4), new card("blue", "5", 5), new card("blue", "6", 6), new card("blue", "7", 7), new card("blue", "8", 8), new card("blue", "9", 9), new card("blue", "+1", 10), new card("blue", "flip", 20), new card("blue", "reverse", 20), new card("blue", "skip", 20), new card("Wild", "+2_wild", 50), new card("Wild", "+2_wild", 50), new card("Wild", "+2_wild", 50), new card("Wild", "+2_wild", 50), new card("Wild", "wild", 40), new card("Wild", "wild", 40), new card("Wild", "wild", 40), new card("Wild", "wild", 40) };
            List<List<object>> f_deck = new List<List<object>>() { new List<object> { "purple", "1", 1 }, new List<object> { "purple", "2", 2 }, new List<object> { "purple", "3", 3 }, new List<object> { "purple", "4", 4 }, new List<object> { "purple", "5", 5 }, new List<object> { "purple", "6", 6 }, new List<object> { "purple", "7", 7 }, new List<object> { "purple", "8", 8 }, new List<object> { "purple", "9", 9 }, new List<object> { "purple", "+5", 20 }, new List<object> { "purple", "flip", 20 }, new List<object> { "purple", "reverse", 20 }, new List<object> { "purple", "skip_all", 30 }, new List<object> { "teal", "1", 1 }, new List<object> { "teal", "2", 2 }, new List<object> { "teal", "3", 3 }, new List<object> { "teal", "4", 4 }, new List<object> { "teal", "5", 5 }, new List<object> { "teal", "6", 6 }, new List<object> { "teal", "7", 7 }, new List<object> { "teal", "8", 8 }, new List<object> { "teal", "9", 9 }, new List<object> { "teal", "+5", 20 }, new List<object> { "teal", "flip", 20 }, new List<object> { "teal", "reverse", 20 }, new List<object> { "teal", "skip_all", 30 }, new List<object> { "orange", "1", 1 }, new List<object> { "orange", "2", 2 }, new List<object> { "orange", "3", 3 }, new List<object> { "orange", "4", 4 }, new List<object> { "orange", "5", 5 }, new List<object> { "orange", "6", 6 }, new List<object> { "orange", "7", 7 }, new List<object> { "orange", "8", 8 }, new List<object> { "orange", "9", 9 }, new List<object> { "orange", "+5", 20 }, new List<object> { "orange", "flip", 20 }, new List<object> { "orange", "reverse", 20 }, new List<object> { "orange", "skip_all", 30 }, new List<object> { "pink", "1", 1 }, new List<object> { "pink", "2", 2 }, new List<object> { "pink", "3", 3 }, new List<object> { "pink", "4", 4 }, new List<object> { "pink", "5", 5 }, new List<object> { "pink", "6", 6 }, new List<object> { "pink", "7", 7 }, new List<object> { "pink", "8", 8 }, new List<object> { "pink", "9", 9 }, new List<object> { "pink", "+5", 20 }, new List<object> { "pink", "flip", 20 }, new List<object> { "pink", "reverse", 20 }, new List<object> { "pink", "skip_all", 30 }, new List<object> { "purple", "2", 2 }, new List<object> { "purple", "3", 3 }, new List<object> { "purple", "4", 4 }, new List<object> { "purple", "5", 5 }, new List<object> { "purple", "6", 6 }, new List<object> { "purple", "7", 7 }, new List<object> { "purple", "8", 8 }, new List<object> { "purple", "9", 9 }, new List<object> { "purple", "+5", 20 }, new List<object> { "purple", "flip", 20 }, new List<object> { "purple", "reverse", 20 }, new List<object> { "purple", "skip_all", 30 }, new List<object> { "teal", "2", 2 }, new List<object> { "teal", "3", 3 }, new List<object> { "teal", "4", 4 }, new List<object> { "teal", "5", 5 }, new List<object> { "teal", "6", 6 }, new List<object> { "teal", "7", 7 }, new List<object> { "teal", "8", 8 }, new List<object> { "teal", "9", 9 }, new List<object> { "teal", "+5", 20 }, new List<object> { "teal", "flip", 20 }, new List<object> { "teal", "reverse", 20 }, new List<object> { "teal", "skip_all", 30 }, new List<object> { "orange", "2", 2 }, new List<object> { "orange", "3", 3 }, new List<object> { "orange", "4", 4 }, new List<object> { "orange", "5", 5 }, new List<object> { "orange", "6", 6 }, new List<object> { "orange", "7", 7 }, new List<object> { "orange", "8", 8 }, new List<object> { "orange", "9", 9 }, new List<object> { "orange", "+5", 20 }, new List<object> { "orange", "flip", 20 }, new List<object> { "orange", "reverse", 20 }, new List<object> { "orange", "skip_all", 30 }, new List<object> { "pink", "2", 2 }, new List<object> { "pink", "3", 3 }, new List<object> { "pink", "4", 4 }, new List<object> { "pink", "5", 5 }, new List<object> { "pink", "6", 6 }, new List<object> { "pink", "7", 7 }, new List<object> { "pink", "8", 8 }, new List<object> { "pink", "9", 9 }, new List<object> { "pink", "+5", 20 }, new List<object> { "pink", "flip", 20 }, new List<object> { "pink", "reverse", 20 }, new List<object> { "pink", "skip_all", 30 }, new List<object> { "Wild", "+draw_match", 60 }, new List<object> { "Wild", "+draw_match", 60 }, new List<object> { "Wild", "+draw_match", 60 }, new List<object> { "Wild", "+draw_match", 60 }, new List<object> { "Wild", "wild", 40 }, new List<object> { "Wild", "wild", 40 }, new List<object> { "Wild", "wild", 40 }, new List<object> { "Wild", "wild", 40 } };
            for (int i = 0; i < f_deck.Count; i++) 
            {
                deck[RandomNumber.Between(0, deck.Count)].setflip((string)f_deck[i][0], (string)f_deck[i][1], (int)f_deck[i][2]);
            }


        }

        private void deal(int CardAmount)
        {
            for (int cards = 0; cards < CardAmount; cards++)
            {
                int card_index = RandomNumber.Between(0, deck.Count);
                players[0].cards.Add(deck[card_index]);
                //players[PlayerIndex].cards.Add(deck[card_index]);
                deck.RemoveAt(card_index);
            }
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
            int range = (maximumValue-1) - minimumValue;
            double randomValueInRange = Math.Floor(multiplier * range);
            return (int)(minimumValue + randomValueInRange);
        }
    }
}
