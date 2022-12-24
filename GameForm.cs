using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace uno
{
    public partial class gameFormClass : Form
    {

        private pauseMenuForm pause = new pauseMenuForm();

        public gameFormClass(int PlayerAmount, bool do_Flip, bool do_DrawtoMatch, bool do_ChainAdds, bool do_2v2, Size screensize, int CardAmount = 7)
        {
            InitializeComponent();
            gamelogic game = new gamelogic(PlayerAmount, do_Flip, do_DrawtoMatch, do_ChainAdds, do_2v2, this, CardAmount);
            this.FormClosing += gameForm_FormClosing;
            this.KeyDown += openPauseMenu;
            label1.Text = $"Width: {screensize.Width}, Height: {screensize.Height}, Size: {screensize}";
        }

        private void gameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            pause.Show();
        }
        private void openPauseMenu(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                pause.Show();
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
            cardPB.Size = new System.Drawing.Size(50, 100);
            cardPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
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
        public List<card> e_cards = new List<card>();
        //x, y
        public int[] StartPosition = { 0, 0, 0 };
        public int team = -1;

        public player(int[] StartingPosition, int team)
        {
            StartPosition = StartingPosition;
            this.team = team;
        }

        public void n_eligablecards(card topdeck)
        {
            foreach (card c in cards)
            {
                if (c.n_color == topdeck.n_color || c.n_number == topdeck.n_number || c.n_color == "wild")
                {
                    e_cards.Add(c);
                }
            }
        }

        public void setpicts(gameFormClass from3, int[] startingPosition, int team, bool is_Flipped)
        {
            this.findCardPosition(startingPosition);
            for (int i = 0; i < cards.Count; i++)
            {
                string fileName = "";
                if (!is_Flipped)
                {
                    fileName = this.n_findimage(i);
                    cards[i].cardPB.Name = cards[i].n_number;
                }
                else if (is_Flipped)
                {
                    fileName = this.f_findimage(i);
                    cards[i].cardPB.Name = cards[i].f_number;
                }

                Image image = Image.FromFile(Application.StartupPath + "\\" + fileName);

                cards[i].cardPB.Image = image;
                from3.Controls.Add(cards[i].cardPB);

            }
        }

        public void activateclick(gamelogic game)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].cardPB.Click += game.cardPB_Click;
            }

        }

        public void deactivateclick(gamelogic game)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].cardPB.Click -= game.cardPB_Click;
            }

        }

        public string n_findimage(int index)
        { return $"small\\{cards[index].n_color}_{cards[index].n_number}.png"; }

        public string f_findimage(int index)
        { return $"small\\{cards[index].f_color}_{cards[index].f_number}.png"; }

        public void setSartPosition(int[] StartPosition)
        { this.StartPosition = StartPosition; }

        public void findCardPosition(int[] StartPosition)
        {
            if (cards.Count % 2 == 0) { StartPosition[StartPosition[2]] -= ((cards.Count / 2) * 50) + ((cards.Count / 2) * 5); }
            if (cards.Count % 2 == 1) { StartPosition[StartPosition[2]] -= (25 + ((cards.Count-1) / 2) * 50) + (((cards.Count-1) / 2) * 5); }
            cards[0].setPB_Location(StartPosition);
            for (int card_index = 1; card_index < cards.Count; card_index++)
            {
                StartPosition[StartPosition[2]] = StartPosition[StartPosition[2]] += 55;
                cards[card_index].setPB_Location(StartPosition);
            }
        }
    }

    //add flip cards and change 

    internal class gamelogic
    {

        #region Game Rules
        //game rules
        public bool do_DrawtoMatch = false;
        public bool do_Flip = false;
        public int PlayerAmount = -1;
        public bool do_ChainAdds = false;
        public bool do_2v2 = false;
        public int CardAmount = 7;
        #endregion

        //setup
        public List<card> deck = new List<card>();
        public List<card> discardPile = new List<card>();
        public List<player> players = new List<player>();

        //game states
        public bool is_Flipped = false;
        public bool is_reverced = false;
        public int PlayerIndex = 0;
        public int PlusAmount = 0;

        //form to act on
        private gameFormClass gameForm;


        //On init
        public gamelogic(int PlayerAmount, bool do_Flip, bool do_DrawtoMatch, bool do_ChainAdds, bool do_2v2, gameFormClass gameForm, int CardAmount = 7)
        {

            #region Setting Game Rules
            //setting game rules
            this.PlayerAmount = PlayerAmount;
            this.do_DrawtoMatch = do_DrawtoMatch;
            this.do_Flip = do_Flip;
            this.do_ChainAdds = do_ChainAdds;
            this.do_2v2 = do_2v2;
            this.CardAmount = CardAmount;
            #endregion

            //set the form
            this.gameForm = gameForm;

            //set the teams
            int[] teams = { 1, 2, 3, 4 };
            if (do_2v2) { teams = new int[] { 1, 2, 1, 2 }; }

            #region starting locations
            List<int[]> startingPositions = new List<int[]>();
            if (this.PlayerAmount == 2)
            {
                startingPositions = new List<int[]>() { new int[] { gameForm.Width / 2, gameForm.Height - 105, 0 }, new int[] { gameForm.Width / 2, 5, 0 } };
            }
            else if (this.PlayerAmount == 3)
            {
                startingPositions = new List<int[]>() { new int[] { gameForm.Width / 2, gameForm.Height - 105, 0 }, new int[] { 5, gameForm.Height / 2, 1 }, new int[] { gameForm.Width / 2, 5, 0 } };
            }
            else if (this.PlayerAmount == 4)
            {
                startingPositions = new List<int[]>() { new int[] { gameForm.Width / 2, gameForm.Height - 105, 0 }, new int[] { 5, gameForm.Height / 2, 1 }, new int[] { gameForm.Width / 2, 5, 0 }, new int[] { gameForm.Width - 105, gameForm.Height / 2, 1 } };
            }
            #endregion

            //Setting up players
            for (int i = 0; i < PlayerAmount; i++) { players.Add(new player(startingPositions[i], teams[i])); }

            //making deck
            this.makedeck();

            //Deal
            for (int player = 0; player < players.Count; player++)
            {
                PlayerIndex = player;
                this.deal(CardAmount, gameForm);
                PlayerIndex = nextplayer();
            }
            PlayerIndex = 0;
        }

        private void gameloop()
        {
            updatescreen();
        }

        private void updatescreen()
        {
            for (int i = 0; i < players.Count; i++)
            {
                players[i].deactivateclick(this);
                while (players[i].cards.Count < CardAmount) { players[i].cards.Add(draw()); }
                players[i].setpicts(this.gameForm, players[i].StartPosition, players[i].team, this.is_Flipped);
                if (i == PlayerIndex) { players[i].activateclick(this); }
                if (is_Flipped) { players[i].n_eligablecards(discardPile[discardPile.Count - 1]); }

            }
            displayDrawPile();
            displayDiscardPile();
        }

        private void addlogic()
        {
            if (!do_ChainAdds && PlusAmount > 0) { addcards(); }
            if (do_ChainAdds && !is_Flipped && n_checkadd()) { addcards(); }
        }

        private bool n_checkadd()
        {
            int i = nextplayer();
            foreach (card c in players[i].e_cards)
            {
                if (c.n_number.Contains("+")) { return true; }
            }
            return false;
        }
        
        private void addcards()
        {
            for (int i = 0; i < PlusAmount; i++)
            {
                
            }
        }

        private void makedeck()
        {
            if (!this.do_Flip) { deck = new List<card>() { new card("red", "0", 0), new card("red", "1", 1), new card("red", "2", 2), new card("red", "3", 3), new card("red", "4", 4), new card("red", "5", 5), new card("red", "6", 6), new card("red", "7", 7), new card("red", "8", 8), new card("red", "9", 9), new card("red", "+2", 10), new card("red", "reverse", 20), new card("red", "skip", 20), new card("yellow", "0", 0), new card("yellow", "1", 1), new card("yellow", "2", 2), new card("yellow", "3", 3), new card("yellow", "4", 4), new card("yellow", "5", 5), new card("yellow", "6", 6), new card("yellow", "7", 7), new card("yellow", "8", 8), new card("yellow", "9", 9), new card("yellow", "+2", 10), new card("yellow", "reverse", 20), new card("yellow", "skip", 20), new card("green", "0", 0), new card("green", "1", 1), new card("green", "2", 2), new card("green", "3", 3), new card("green", "4", 4), new card("green", "5", 5), new card("green", "6", 6), new card("green", "7", 7), new card("green", "8", 8), new card("green", "9", 9), new card("green", "+2", 10), new card("green", "reverse", 20), new card("green", "skip", 20), new card("blue", "0", 0), new card("blue", "1", 1), new card("blue", "2", 2), new card("blue", "3", 3), new card("blue", "4", 4), new card("blue", "5", 5), new card("blue", "6", 6), new card("blue", "7", 7), new card("blue", "8", 8), new card("blue", "9", 9), new card("blue", "+2", 10), new card("blue", "reverse", 20), new card("blue", "skip", 20), new card("red", "1", 1), new card("red", "2", 2), new card("red", "3", 3), new card("red", "4", 4), new card("red", "5", 5), new card("red", "6", 6), new card("red", "7", 7), new card("red", "8", 8), new card("red", "9", 9), new card("red", "+2", 10), new card("red", "reverse", 20), new card("red", "skip", 20), new card("yellow", "1", 1), new card("yellow", "2", 2), new card("yellow", "3", 3), new card("yellow", "4", 4), new card("yellow", "5", 5), new card("yellow", "6", 6), new card("yellow", "7", 7), new card("yellow", "8", 8), new card("yellow", "9", 9), new card("yellow", "+2", 10), new card("yellow", "reverse", 20), new card("yellow", "skip", 20), new card("green", "1", 1), new card("green", "2", 2), new card("green", "3", 3), new card("green", "4", 4), new card("green", "5", 5), new card("green", "6", 6), new card("green", "7", 7), new card("green", "8", 8), new card("green", "9", 9), new card("green", "+2", 10), new card("green", "reverse", 20), new card("green", "skip", 20), new card("blue", "1", 1), new card("blue", "2", 2), new card("blue", "3", 3), new card("blue", "4", 4), new card("blue", "5", 5), new card("blue", "6", 6), new card("blue", "7", 7), new card("blue", "8", 8), new card("blue", "9", 9), new card("blue", "+2", 10), new card("blue", "reverse", 20), new card("blue", "skip", 20), new card("wild", "+4_wild", 50), new card("wild", "+4_wild", 50), new card("wild", "+4_wild", 50), new card("wild", "+4_wild", 50), new card("wild", "wild", 40), new card("wild", "wild", 40), new card("wild", "wild", 40), new card("wild", "wild", 40) }; return; }
            deck = new List<card>() { new card("red", "1", 1), new card("red", "2", 2), new card("red", "3", 3), new card("red", "4", 4), new card("red", "5", 5), new card("red", "6", 6), new card("red", "7", 7), new card("red", "8", 8), new card("red", "9", 9), new card("red", "+1", 10), new card("red", "flip", 20), new card("red", "reverse", 20), new card("red", "skip", 20), new card("yellow", "1", 1), new card("yellow", "2", 2), new card("yellow", "3", 3), new card("yellow", "4", 4), new card("yellow", "5", 5), new card("yellow", "6", 6), new card("yellow", "7", 7), new card("yellow", "8", 8), new card("yellow", "9", 9), new card("yellow", "+1", 10), new card("yellow", "flip", 20), new card("yellow", "reverse", 20), new card("yellow", "skip", 20), new card("green", "1", 1), new card("green", "2", 2), new card("green", "3", 3), new card("green", "4", 4), new card("green", "5", 5), new card("green", "6", 6), new card("green", "7", 7), new card("green", "8", 8), new card("green", "9", 9), new card("green", "+1", 10), new card("green", "flip", 20), new card("green", "reverse", 20), new card("green", "skip", 20), new card("blue", "1", 1), new card("blue", "2", 2), new card("blue", "3", 3), new card("blue", "4", 4), new card("blue", "5", 5), new card("blue", "6", 6), new card("blue", "7", 7), new card("blue", "8", 8), new card("blue", "9", 9), new card("blue", "+1", 10), new card("blue", "flip", 20), new card("blue", "reverse", 20), new card("blue", "skip", 20), new card("red", "2", 2), new card("red", "3", 3), new card("red", "4", 4), new card("red", "5", 5), new card("red", "6", 6), new card("red", "7", 7), new card("red", "8", 8), new card("red", "9", 9), new card("red", "+1", 10), new card("red", "flip", 20), new card("red", "reverse", 20), new card("red", "skip", 20), new card("yellow", "2", 2), new card("yellow", "3", 3), new card("yellow", "4", 4), new card("yellow", "5", 5), new card("yellow", "6", 6), new card("yellow", "7", 7), new card("yellow", "8", 8), new card("yellow", "9", 9), new card("yellow", "+1", 10), new card("yellow", "flip", 20), new card("yellow", "reverse", 20), new card("yellow", "skip", 20), new card("green", "2", 2), new card("green", "3", 3), new card("green", "4", 4), new card("green", "5", 5), new card("green", "6", 6), new card("green", "7", 7), new card("green", "8", 8), new card("green", "9", 9), new card("green", "+1", 10), new card("green", "flip", 20), new card("green", "reverse", 20), new card("green", "skip", 20), new card("blue", "2", 2), new card("blue", "3", 3), new card("blue", "4", 4), new card("blue", "5", 5), new card("blue", "6", 6), new card("blue", "7", 7), new card("blue", "8", 8), new card("blue", "9", 9), new card("blue", "+1", 10), new card("blue", "flip", 20), new card("blue", "reverse", 20), new card("blue", "skip", 20), new card("wild", "+2_wild", 50), new card("wild", "+2_wild", 50), new card("wild", "+2_wild", 50), new card("wild", "+2_wild", 50), new card("wild", "wild", 40), new card("wild", "wild", 40), new card("wild", "wild", 40), new card("wild", "wild", 40) };
            List<List<object>> f_deck = new List<List<object>>() { new List<object> { "purple", "1", 1 }, new List<object> { "purple", "2", 2 }, new List<object> { "purple", "3", 3 }, new List<object> { "purple", "4", 4 }, new List<object> { "purple", "5", 5 }, new List<object> { "purple", "6", 6 }, new List<object> { "purple", "7", 7 }, new List<object> { "purple", "8", 8 }, new List<object> { "purple", "9", 9 }, new List<object> { "purple", "+5", 20 }, new List<object> { "purple", "flip", 20 }, new List<object> { "purple", "reverse", 20 }, new List<object> { "purple", "skip_all", 30 }, new List<object> { "teal", "1", 1 }, new List<object> { "teal", "2", 2 }, new List<object> { "teal", "3", 3 }, new List<object> { "teal", "4", 4 }, new List<object> { "teal", "5", 5 }, new List<object> { "teal", "6", 6 }, new List<object> { "teal", "7", 7 }, new List<object> { "teal", "8", 8 }, new List<object> { "teal", "9", 9 }, new List<object> { "teal", "+5", 20 }, new List<object> { "teal", "flip", 20 }, new List<object> { "teal", "reverse", 20 }, new List<object> { "teal", "skip_all", 30 }, new List<object> { "orange", "1", 1 }, new List<object> { "orange", "2", 2 }, new List<object> { "orange", "3", 3 }, new List<object> { "orange", "4", 4 }, new List<object> { "orange", "5", 5 }, new List<object> { "orange", "6", 6 }, new List<object> { "orange", "7", 7 }, new List<object> { "orange", "8", 8 }, new List<object> { "orange", "9", 9 }, new List<object> { "orange", "+5", 20 }, new List<object> { "orange", "flip", 20 }, new List<object> { "orange", "reverse", 20 }, new List<object> { "orange", "skip_all", 30 }, new List<object> { "pink", "1", 1 }, new List<object> { "pink", "2", 2 }, new List<object> { "pink", "3", 3 }, new List<object> { "pink", "4", 4 }, new List<object> { "pink", "5", 5 }, new List<object> { "pink", "6", 6 }, new List<object> { "pink", "7", 7 }, new List<object> { "pink", "8", 8 }, new List<object> { "pink", "9", 9 }, new List<object> { "pink", "+5", 20 }, new List<object> { "pink", "flip", 20 }, new List<object> { "pink", "reverse", 20 }, new List<object> { "pink", "skip_all", 30 }, new List<object> { "purple", "2", 2 }, new List<object> { "purple", "3", 3 }, new List<object> { "purple", "4", 4 }, new List<object> { "purple", "5", 5 }, new List<object> { "purple", "6", 6 }, new List<object> { "purple", "7", 7 }, new List<object> { "purple", "8", 8 }, new List<object> { "purple", "9", 9 }, new List<object> { "purple", "+5", 20 }, new List<object> { "purple", "flip", 20 }, new List<object> { "purple", "reverse", 20 }, new List<object> { "purple", "skip_all", 30 }, new List<object> { "teal", "2", 2 }, new List<object> { "teal", "3", 3 }, new List<object> { "teal", "4", 4 }, new List<object> { "teal", "5", 5 }, new List<object> { "teal", "6", 6 }, new List<object> { "teal", "7", 7 }, new List<object> { "teal", "8", 8 }, new List<object> { "teal", "9", 9 }, new List<object> { "teal", "+5", 20 }, new List<object> { "teal", "flip", 20 }, new List<object> { "teal", "reverse", 20 }, new List<object> { "teal", "skip_all", 30 }, new List<object> { "orange", "2", 2 }, new List<object> { "orange", "3", 3 }, new List<object> { "orange", "4", 4 }, new List<object> { "orange", "5", 5 }, new List<object> { "orange", "6", 6 }, new List<object> { "orange", "7", 7 }, new List<object> { "orange", "8", 8 }, new List<object> { "orange", "9", 9 }, new List<object> { "orange", "+5", 20 }, new List<object> { "orange", "flip", 20 }, new List<object> { "orange", "reverse", 20 }, new List<object> { "orange", "skip_all", 30 }, new List<object> { "pink", "2", 2 }, new List<object> { "pink", "3", 3 }, new List<object> { "pink", "4", 4 }, new List<object> { "pink", "5", 5 }, new List<object> { "pink", "6", 6 }, new List<object> { "pink", "7", 7 }, new List<object> { "pink", "8", 8 }, new List<object> { "pink", "9", 9 }, new List<object> { "pink", "+5", 20 }, new List<object> { "pink", "flip", 20 }, new List<object> { "pink", "reverse", 20 }, new List<object> { "pink", "skip_all", 30 }, new List<object> { "wild", "draw_match", 60 }, new List<object> { "wild", "draw_match", 60 }, new List<object> { "wild", "draw_match", 60 }, new List<object> { "wild", "draw_match", 60 }, new List<object> { "wild", "wild", 40 }, new List<object> { "wild", "wild", 40 }, new List<object> { "wild", "wild", 40 }, new List<object> { "wild", "wild", 40 } };
            for (int i = 0; i < f_deck.Count; i++)
            {
                deck[RandomNumber.Between(0, deck.Count)].setflip((string)f_deck[i][0], (string)f_deck[i][1], (int)f_deck[i][2]);
            }
            deck.Shuffle();
        }

        private void deal(int CardAmount, gameFormClass gameForm)
        {
            for (int cards = 0; cards < CardAmount; cards++)
            {
                int card_index = RandomNumber.Between(0, deck.Count);
                players[PlayerIndex].cards.Add(deck.pop(card_index));
            }
        }

        private int nextplayer()
        {
            if (!is_reverced && PlayerIndex++ < players.Count-2) { return PlayerIndex++; }
            else if (!is_reverced && PlayerIndex++ == players.Count-2) { return 0; }
            else if (is_reverced && PlayerIndex-- > 0) { return PlayerIndex--; }
            else if (is_reverced && PlayerIndex-- == 0) {return PlayerIndex = players.Count - 1; }
            return -1;
        }

        public void displayDrawPile() 
        {
            if (deck.Count < 11) 
            {
                discardPileRemove();
            }
            for (int i = 55; i >= 5; i -= 5) 
            {
                addpictures(new int[] { gameForm.Width / 2 - i, gameForm.Height / 2 }, gameForm);

            }
        }


        //FIX TO SHOW THE ACTUAL CARDS 
        public void displayDiscardPile() 
        {
            for (int i = 0; i < discardPile.Count; i++) 
            {
                if (i > 9) {return;}
                addpictures(new int[] { gameForm.Height / 2 + RandomNumber.Between(-10, 10), gameForm.Height / 2 + RandomNumber.Between(-10, 10) }, gameForm);
            }
        }

        public void addpictures(int[] location, gameFormClass gameForm) 
        {
            PictureBox tempPB = new PictureBox();
            tempPB.Size = new System.Drawing.Size(100, 50);
            tempPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            tempPB.Image = Image.FromFile(Application.StartupPath + "\\" + "card_back_alt.png");
            tempPB.Location = new Point(location[0], location[1]);
            gameForm.Controls.Add(tempPB);
        }

        public void discardPileRemove()
        {
            for (int i = 0; i < discardPile.Count - 1; i++) 
            {
                int j = RandomNumber.Between(0, discardPile.Count-1);
                deck.Add(discardPile.pop(j));
            }
        }

        public void cardPB_Click(object sender, EventArgs e)
        {
            int cardindex = -1;
            for (int i = 0; i < players[PlayerIndex].cards.Count; i++)
            {
                if (players[PlayerIndex].cards[i].cardPB == sender) { cardindex = i; MessageBox.Show(i.ToString()); break; }
                if (!is_Flipped) { n_cardplay(players[PlayerIndex].cards[cardindex]); }
                discardPile.Add(players[PlayerIndex].cards.pop(cardindex));
            }
            
        }

        private void n_cardplay(card c_card)
        {
            if (c_card.n_color == "wild")
            {
                this.n_wild(c_card);
            }
            if (c_card.n_number.Contains("+"))
            {
                this.adder(c_card.n_number);
            }
            else if (players[PlayerIndex].cards[cardindex].n_color == "flip")
            {
                this.flip(psender.Name);
            }
            else
            {
                this.normal(psender.Name);
            }
        }

        private void n_wild(card c_card) 
        {
            wildFormClass wildform = new wildFormClass();
            if (wildform.ShowDialog() == DialogResult.OK)
            {
                c_card.n_color = wildform.Tag as string;
            }
        }

        private void adder(string cardname)
        {
            PlusAmount += int.Parse(cardname[1].ToString());
            return;
        }

        private void flip(string cardname)
        {

        }
        private void normal(string cardname)
        {

        }

        private card draw()
        {
            return deck.pop();
        }

        private void drawtomatch(string color)
        {
            card nextcard = this.deck.pop();
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
            int range = (maximumValue - 1) - minimumValue;
            double randomValueInRange = Math.Floor(multiplier * range);
            return (int)(minimumValue + randomValueInRange);
        }
    }

    public static class ListExtensions
    {
        public static T pop<T>(this List<T> list, int index = -1)
        {
            if (list.Count == 0) { throw new InvalidOperationException("Cannot pop from an empty list"); }

            if (index == -1) { index = list.Count - 1; }

            T temp = list[index];
            list.RemoveAt(index);
            return temp;
        }

        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            for (int n = list.Count; n > 1; n--)
            {
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}