using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace uno
{
    internal class GameLogicClass
    {

        #region Game Rules
        //game rules
        public Dictionary<string, bool> GameRules = new Dictionary<string, bool>();
        public int PlayerAmount = -1;
        public int CardAmount = -1;
        #endregion

        //Game Lists
        public List<CardClass> DrawPile = new List<CardClass>();
        public List<CardClass> DiscardPile = new List<CardClass>();
        public List<PlayerClass> PlayerList = new List<PlayerClass>();

        //game states
        public bool is_Flipped = false;
        public bool is_Reverced = false;
        public int PlayerIndex = 0;
        public int PlusAmount = 0;
        public List<int[]> StartingPositions;

        //form to act on
        public GameForm GameForm;


        //On init
        public GameLogicClass(Dictionary<string, bool> GameRules, GameForm GameForm, int PlayerAmount, int CardAmount = 7)
        {
            #region Setting Game Rules
            //setting game rules
            this.GameRules = GameRules;
            this.PlayerAmount = PlayerAmount;
            this.CardAmount = CardAmount;
            #endregion

            //set the form
            this.GameForm = GameForm;

            //set the teams
            int[] teams = { 1, 1, 3, 4 };
            if (this.GameRules["do_2v2"]) { teams = new int[] { 1, 2, 1, 2 }; }

            #region starting locations
            string consolemsg;
            if (this.PlayerAmount == 2)
            {
                this.StartingPositions = new List<int[]>() { new int[] { GameForm.Width / 2, GameForm.Height - 105, 0 }, new int[] { GameForm.Width / 2, 5, 0 } };
                consolemsg = $"{this.StartingPositions[0]}, {this.StartingPositions[1]}";
            }
            else if (this.PlayerAmount == 3)
            {
                this.StartingPositions = new List<int[]>() { new int[] { GameForm.Width / 2, GameForm.Height - 105, 0 }, new int[] { 5, GameForm.Height / 2, 1 }, new int[] { GameForm.Width / 2, 5, 0 } };
                consolemsg = $"{this.StartingPositions[0]}, {this.StartingPositions[1]}, {this.StartingPositions[2]}";
            }
            else if (this.PlayerAmount == 4)
            {
                this.StartingPositions = new List<int[]>() { new int[] { GameForm.Width / 2, GameForm.Height - 105, 0 }, new int[] { 5, GameForm.Height / 2, 1 }, new int[] { GameForm.Width / 2, 5, 0 }, new int[] { GameForm.Width - 105, GameForm.Height / 2, 1 } };
                consolemsg = $"{this.StartingPositions[0]}, {this.StartingPositions[1]}, {this.StartingPositions[2]}, {this.StartingPositions[3]}";
            }
            #endregion

            //Setting up PlayerList
            for (int i = 0; i < this.PlayerAmount; i++) { PlayerList.Add(new PlayerClass(teams[i], !(i == 0), this.PlayerAmount)); }

            //making DrawPile
            this.MakeDrawPile();

            //Deal
            for (int player = 0; player < PlayerList.Count; player++)
            {
                this.PlayerIndex = player;
                this.Deal();
            }
            this.PlayerIndex = 0;

            while (this.DiscardPile.Count == 0)
            {
                //add to the top of the DrawPile
                this.DiscardPile.Add(Draw());
                if (this.DiscardPile[this.DiscardPile.Count - 1].Numbers[this.is_Flipped.ToInt()].Contains("+") || this.DiscardPile[this.DiscardPile.Count - 1].Numbers[this.is_Flipped.ToInt()].Contains("reverce") || this.DiscardPile[this.DiscardPile.Count - 1].Numbers[this.is_Flipped.ToInt()].Contains("flip") || this.DiscardPile[this.DiscardPile.Count - 1].Colors[this.is_Flipped.ToInt()].Contains("wild"))
                {
                    this.DrawPile.Add(this.DiscardPile.pop());
                    this.DiscardPile.Add(Draw());
                }
            }
            //Draw the Draw pile
            DisplayDrawPile(true);

            console.Log(
                $@"method; (GameLogicClass.GameLogicClass) [Game INIT], Gamerules;
                \n\tdo_DrawtoMatch ({this.GameRules["do_DrawtoMatch"]}),
                \n\tdo_Flip ({this.GameRules["do_Flip"]}),
                \n\tdo_ChianAdds ({this.GameRules["do_ChainAdds"]}),
                \n\tdo_2v2 ({this.GameRules["do_2v2"]}, teams ({teams[0]}, {teams[1]}, {teams[2]}, {teams[3]})
                \n\tPlayer Amount ({this.PlayerAmount})
                \n\tCard Amount ({this.CardAmount})
                \nPlayer Index; ({PlayerIndex}), Discard Pile Count; ({DiscardPile.Count}), Top Card; ({DiscardPile[DiscardPile.Count-1]})"
            );
            //Card draw location; ({consolemsg}), brok idk why dont think it was improtant 

            UpdateScreen();
        }

        //Logic for making the DrawPile
        private void MakeDrawPile()
        {
            console.Log("method; (GameLogicClass.MakeDrawPile)");
            //DrawPile for not doing flip then return before doing anything else
            if (!this.GameRules["do_Flip"]) { this.DrawPile = new List<CardClass>() { new CardClass("red", "0", 0), new CardClass("red", "1", 1), new CardClass("red", "2", 2), new CardClass("red", "3", 3), new CardClass("red", "4", 4), new CardClass("red", "5", 5), new CardClass("red", "6", 6), new CardClass("red", "7", 7), new CardClass("red", "8", 8), new CardClass("red", "9", 9), new CardClass("red", "+2", 10), new CardClass("red", "reverse", 20), new CardClass("red", "skip", 20), new CardClass("yellow", "0", 0), new CardClass("yellow", "1", 1), new CardClass("yellow", "2", 2), new CardClass("yellow", "3", 3), new CardClass("yellow", "4", 4), new CardClass("yellow", "5", 5), new CardClass("yellow", "6", 6), new CardClass("yellow", "7", 7), new CardClass("yellow", "8", 8), new CardClass("yellow", "9", 9), new CardClass("yellow", "+2", 10), new CardClass("yellow", "reverse", 20), new CardClass("yellow", "skip", 20), new CardClass("green", "0", 0), new CardClass("green", "1", 1), new CardClass("green", "2", 2), new CardClass("green", "3", 3), new CardClass("green", "4", 4), new CardClass("green", "5", 5), new CardClass("green", "6", 6), new CardClass("green", "7", 7), new CardClass("green", "8", 8), new CardClass("green", "9", 9), new CardClass("green", "+2", 10), new CardClass("green", "reverse", 20), new CardClass("green", "skip", 20), new CardClass("blue", "0", 0), new CardClass("blue", "1", 1), new CardClass("blue", "2", 2), new CardClass("blue", "3", 3), new CardClass("blue", "4", 4), new CardClass("blue", "5", 5), new CardClass("blue", "6", 6), new CardClass("blue", "7", 7), new CardClass("blue", "8", 8), new CardClass("blue", "9", 9), new CardClass("blue", "+2", 10), new CardClass("blue", "reverse", 20), new CardClass("blue", "skip", 20), new CardClass("red", "1", 1), new CardClass("red", "2", 2), new CardClass("red", "3", 3), new CardClass("red", "4", 4), new CardClass("red", "5", 5), new CardClass("red", "6", 6), new CardClass("red", "7", 7), new CardClass("red", "8", 8), new CardClass("red", "9", 9), new CardClass("red", "+2", 10), new CardClass("red", "reverse", 20), new CardClass("red", "skip", 20), new CardClass("yellow", "1", 1), new CardClass("yellow", "2", 2), new CardClass("yellow", "3", 3), new CardClass("yellow", "4", 4), new CardClass("yellow", "5", 5), new CardClass("yellow", "6", 6), new CardClass("yellow", "7", 7), new CardClass("yellow", "8", 8), new CardClass("yellow", "9", 9), new CardClass("yellow", "+2", 10), new CardClass("yellow", "reverse", 20), new CardClass("yellow", "skip", 20), new CardClass("green", "1", 1), new CardClass("green", "2", 2), new CardClass("green", "3", 3), new CardClass("green", "4", 4), new CardClass("green", "5", 5), new CardClass("green", "6", 6), new CardClass("green", "7", 7), new CardClass("green", "8", 8), new CardClass("green", "9", 9), new CardClass("green", "+2", 10), new CardClass("green", "reverse", 20), new CardClass("green", "skip", 20), new CardClass("blue", "1", 1), new CardClass("blue", "2", 2), new CardClass("blue", "3", 3), new CardClass("blue", "4", 4), new CardClass("blue", "5", 5), new CardClass("blue", "6", 6), new CardClass("blue", "7", 7), new CardClass("blue", "8", 8), new CardClass("blue", "9", 9), new CardClass("blue", "+2", 10), new CardClass("blue", "reverse", 20), new CardClass("blue", "skip", 20), new CardClass("wild", "+4_wild", 50), new CardClass("wild", "+4_wild", 50), new CardClass("wild", "+4_wild", 50), new CardClass("wild", "+4_wild", 50), new CardClass("wild", "wild", 40), new CardClass("wild", "wild", 40), new CardClass("wild", "wild", 40), new CardClass("wild", "wild", 40) }; return; }

            //Normal side for doing flip
            this.DrawPile = new List<CardClass>() { new CardClass("red", "1", 1), new CardClass("red", "2", 2), new CardClass("red", "3", 3), new CardClass("red", "4", 4), new CardClass("red", "5", 5), new CardClass("red", "6", 6), new CardClass("red", "7", 7), new CardClass("red", "8", 8), new CardClass("red", "9", 9), new CardClass("red", "+1", 10), new CardClass("red", "flip", 20), new CardClass("red", "reverse", 20), new CardClass("red", "skip", 20), new CardClass("yellow", "1", 1), new CardClass("yellow", "2", 2), new CardClass("yellow", "3", 3), new CardClass("yellow", "4", 4), new CardClass("yellow", "5", 5), new CardClass("yellow", "6", 6), new CardClass("yellow", "7", 7), new CardClass("yellow", "8", 8), new CardClass("yellow", "9", 9), new CardClass("yellow", "+1", 10), new CardClass("yellow", "flip", 20), new CardClass("yellow", "reverse", 20), new CardClass("yellow", "skip", 20), new CardClass("green", "1", 1), new CardClass("green", "2", 2), new CardClass("green", "3", 3), new CardClass("green", "4", 4), new CardClass("green", "5", 5), new CardClass("green", "6", 6), new CardClass("green", "7", 7), new CardClass("green", "8", 8), new CardClass("green", "9", 9), new CardClass("green", "+1", 10), new CardClass("green", "flip", 20), new CardClass("green", "reverse", 20), new CardClass("green", "skip", 20), new CardClass("blue", "1", 1), new CardClass("blue", "2", 2), new CardClass("blue", "3", 3), new CardClass("blue", "4", 4), new CardClass("blue", "5", 5), new CardClass("blue", "6", 6), new CardClass("blue", "7", 7), new CardClass("blue", "8", 8), new CardClass("blue", "9", 9), new CardClass("blue", "+1", 10), new CardClass("blue", "flip", 20), new CardClass("blue", "reverse", 20), new CardClass("blue", "skip", 20), new CardClass("red", "2", 2), new CardClass("red", "3", 3), new CardClass("red", "4", 4), new CardClass("red", "5", 5), new CardClass("red", "6", 6), new CardClass("red", "7", 7), new CardClass("red", "8", 8), new CardClass("red", "9", 9), new CardClass("red", "+1", 10), new CardClass("red", "flip", 20), new CardClass("red", "reverse", 20), new CardClass("red", "skip", 20), new CardClass("yellow", "2", 2), new CardClass("yellow", "3", 3), new CardClass("yellow", "4", 4), new CardClass("yellow", "5", 5), new CardClass("yellow", "6", 6), new CardClass("yellow", "7", 7), new CardClass("yellow", "8", 8), new CardClass("yellow", "9", 9), new CardClass("yellow", "+1", 10), new CardClass("yellow", "flip", 20), new CardClass("yellow", "reverse", 20), new CardClass("yellow", "skip", 20), new CardClass("green", "2", 2), new CardClass("green", "3", 3), new CardClass("green", "4", 4), new CardClass("green", "5", 5), new CardClass("green", "6", 6), new CardClass("green", "7", 7), new CardClass("green", "8", 8), new CardClass("green", "9", 9), new CardClass("green", "+1", 10), new CardClass("green", "flip", 20), new CardClass("green", "reverse", 20), new CardClass("green", "skip", 20), new CardClass("blue", "2", 2), new CardClass("blue", "3", 3), new CardClass("blue", "4", 4), new CardClass("blue", "5", 5), new CardClass("blue", "6", 6), new CardClass("blue", "7", 7), new CardClass("blue", "8", 8), new CardClass("blue", "9", 9), new CardClass("blue", "+1", 10), new CardClass("blue", "flip", 20), new CardClass("blue", "reverse", 20), new CardClass("blue", "skip", 20), new CardClass("wild", "+2_wild", 50), new CardClass("wild", "+2_wild", 50), new CardClass("wild", "+2_wild", 50), new CardClass("wild", "+2_wild", 50), new CardClass("wild", "wild", 40), new CardClass("wild", "wild", 40), new CardClass("wild", "wild", 40), new CardClass("wild", "wild", 40) };
            //Make the flip side DrawPile
            List<List<object>> f_DrawPile = new List<List<object>>() { new List<object> { "purple", "1", 1 }, new List<object> { "purple", "2", 2 }, new List<object> { "purple", "3", 3 }, new List<object> { "purple", "4", 4 }, new List<object> { "purple", "5", 5 }, new List<object> { "purple", "6", 6 }, new List<object> { "purple", "7", 7 }, new List<object> { "purple", "8", 8 }, new List<object> { "purple", "9", 9 }, new List<object> { "purple", "+5", 20 }, new List<object> { "purple", "flip", 20 }, new List<object> { "purple", "reverse", 20 }, new List<object> { "purple", "skip_all", 30 }, new List<object> { "teal", "1", 1 }, new List<object> { "teal", "2", 2 }, new List<object> { "teal", "3", 3 }, new List<object> { "teal", "4", 4 }, new List<object> { "teal", "5", 5 }, new List<object> { "teal", "6", 6 }, new List<object> { "teal", "7", 7 }, new List<object> { "teal", "8", 8 }, new List<object> { "teal", "9", 9 }, new List<object> { "teal", "+5", 20 }, new List<object> { "teal", "flip", 20 }, new List<object> { "teal", "reverse", 20 }, new List<object> { "teal", "skip_all", 30 }, new List<object> { "orange", "1", 1 }, new List<object> { "orange", "2", 2 }, new List<object> { "orange", "3", 3 }, new List<object> { "orange", "4", 4 }, new List<object> { "orange", "5", 5 }, new List<object> { "orange", "6", 6 }, new List<object> { "orange", "7", 7 }, new List<object> { "orange", "8", 8 }, new List<object> { "orange", "9", 9 }, new List<object> { "orange", "+5", 20 }, new List<object> { "orange", "flip", 20 }, new List<object> { "orange", "reverse", 20 }, new List<object> { "orange", "skip_all", 30 }, new List<object> { "pink", "1", 1 }, new List<object> { "pink", "2", 2 }, new List<object> { "pink", "3", 3 }, new List<object> { "pink", "4", 4 }, new List<object> { "pink", "5", 5 }, new List<object> { "pink", "6", 6 }, new List<object> { "pink", "7", 7 }, new List<object> { "pink", "8", 8 }, new List<object> { "pink", "9", 9 }, new List<object> { "pink", "+5", 20 }, new List<object> { "pink", "flip", 20 }, new List<object> { "pink", "reverse", 20 }, new List<object> { "pink", "skip_all", 30 }, new List<object> { "purple", "2", 2 }, new List<object> { "purple", "3", 3 }, new List<object> { "purple", "4", 4 }, new List<object> { "purple", "5", 5 }, new List<object> { "purple", "6", 6 }, new List<object> { "purple", "7", 7 }, new List<object> { "purple", "8", 8 }, new List<object> { "purple", "9", 9 }, new List<object> { "purple", "+5", 20 }, new List<object> { "purple", "flip", 20 }, new List<object> { "purple", "reverse", 20 }, new List<object> { "purple", "skip_all", 30 }, new List<object> { "teal", "2", 2 }, new List<object> { "teal", "3", 3 }, new List<object> { "teal", "4", 4 }, new List<object> { "teal", "5", 5 }, new List<object> { "teal", "6", 6 }, new List<object> { "teal", "7", 7 }, new List<object> { "teal", "8", 8 }, new List<object> { "teal", "9", 9 }, new List<object> { "teal", "+5", 20 }, new List<object> { "teal", "flip", 20 }, new List<object> { "teal", "reverse", 20 }, new List<object> { "teal", "skip_all", 30 }, new List<object> { "orange", "2", 2 }, new List<object> { "orange", "3", 3 }, new List<object> { "orange", "4", 4 }, new List<object> { "orange", "5", 5 }, new List<object> { "orange", "6", 6 }, new List<object> { "orange", "7", 7 }, new List<object> { "orange", "8", 8 }, new List<object> { "orange", "9", 9 }, new List<object> { "orange", "+5", 20 }, new List<object> { "orange", "flip", 20 }, new List<object> { "orange", "reverse", 20 }, new List<object> { "orange", "skip_all", 30 }, new List<object> { "pink", "2", 2 }, new List<object> { "pink", "3", 3 }, new List<object> { "pink", "4", 4 }, new List<object> { "pink", "5", 5 }, new List<object> { "pink", "6", 6 }, new List<object> { "pink", "7", 7 }, new List<object> { "pink", "8", 8 }, new List<object> { "pink", "9", 9 }, new List<object> { "pink", "+5", 20 }, new List<object> { "pink", "flip", 20 }, new List<object> { "pink", "reverse", 20 }, new List<object> { "pink", "skip_all", 30 }, new List<object> { "wild", "draw_match", 60 }, new List<object> { "wild", "draw_match", 60 }, new List<object> { "wild", "draw_match", 60 }, new List<object> { "wild", "draw_match", 60 }, new List<object> { "wild", "wild", 40 }, new List<object> { "wild", "wild", 40 }, new List<object> { "wild", "wild", 40 }, new List<object> { "wild", "wild", 40 } };
            //for every CardClass
            for (int i = 0; i < f_DrawPile.Count; i++)
            {
                //Pick a random one and add a flip CardClass
                this.DrawPile[RandomNumber.Between(0, DrawPile.Count)].SetFlip((string)f_DrawPile[i][0], (string)f_DrawPile[i][1], (int)f_DrawPile[i][2]);
            }
        }

        //Deal to the PlayerClass
        private void Deal()
        {
            console.Log("method; (GameLogicClass.Deal)");
            //Add Hand to the PlayerClass untill they reach the CardClass amount they set
            for (int cards = 0; cards < this.CardAmount; cards++)
            {
                this.PlayerList[this.PlayerIndex].Hand.Add(Draw());
            }
        }

        //Logic needed to update the screen
        private void UpdateScreen()
        {
            //go through every PlayerClass
            for (int i = 0; i < this.PlayerList.Count; i++)
            {
                //Check if they have no Hand left, if they have do win screen and condition
                if (this.PlayerList[i].Hand.Count == 0)
                {
                    WinConditonForm win_condition = new WinConditonForm();
                    win_condition.Show();
                    this.GameForm.Hide();
                }

                this.PlayerList[i].DeactivateClick(this);

                //set the lcoations of the Hand; kinda busted becuase of copying problems
                this.PlayerList[i].FindCardPosition(this.StartingPositions[i][0], this.StartingPositions[i][1], this.StartingPositions[i][2]);

                //update the players points
                this.PlayerList[i].UpdatePoints(this.GameRules["do_Flip"]);

                //draw cards
                this.PlayerList[i].DrawCards(this, this.PlayerList[i]);

                //Find the eligable Hand using the topcard;
                this.PlayerList[i].EligableCards(this.DiscardPile[this.DiscardPile.Count - 1], this.is_Flipped.ToInt());
            }

            //If there are to few Hand in the DrawPile then reshuffle the discard pile into the DrawPile
            if (this.DrawPile.Count < 11)
            {
                DiscardPileRemove();
            }

            //Reactivate the click event for the next PlayerClass
            PlayerList[this.PlayerIndex].ActivateClick(this);

            //redraw discard pile and Draw pile
            DisplayDiscardPile();
            DisplayDrawPile(false);

            if (this.PlayerList[this.PlayerIndex].AI != null) { this.PlayerList[this.PlayerIndex].AI.Play(this.PlayerList[this.PlayerIndex], this); }

            console.Log(
                $@"method; (GameLogicClass.GameLogicClass) [Game INIT], Gamerules;
                \n\tis_Flipped ({is_Flipped}),
                \n\tis_Reverced ({is_Reverced}),
                \n\tPlayerIndex ({PlayerIndex}, card amount {PlayerList[PlayerIndex].Hand.Count}),
                \n\tPlusAmount ({PlusAmount})
                \nDiscard Pile Count; ({DiscardPile.Count}), Top Card; ({this.DiscardPile[this.DiscardPile.Count - 1].Colors[this.is_Flipped.ToInt()]}, {this.DiscardPile[this.DiscardPile.Count - 1].Numbers[this.is_Flipped.ToInt()]})"
            );

        }

        //runs everytime the current PlayerClass clicks a CardClass
        public void cardPB_Click(object sender, EventArgs e)
        {
            int index = FindPictureInList(this.PlayerList[this.PlayerIndex].Hand, sender as PictureBox);
            console.Log($"method; (GameLogicClass.cardPB_Click), Card Index ({index})");
            CardClickLogic(index);
        }

        public void CardClickLogic(int Card_Index)
        {
            //for every CardClass in that PlayerList DrawPile find the CardClass object with the picture box that matches the one clicked
            CardClass c_card = this.PlayerList[this.PlayerIndex].Hand[Card_Index];

            //If the CardClass clicked is not in the eligable Hand then stop doing logic
            if (!this.PlayerList[this.PlayerIndex].e_Hand.Contains(c_card)) { return; }

            //Do the logic to see if the CardClass was "special" in any way and needs logic for it
            if (!this.is_Flipped) { CardPlay(c_card); }

            //Add this CardClass to the dicard pile and remove it from the PlayerList hand
            this.DiscardPile.Add(this.PlayerList[this.PlayerIndex].Hand.pop(Card_Index));

            //Check if the next PlayerClass needs Hand added to their hand and if so add them
            AddLogic(this.NextPlayer(this.PlayerIndex, this.PlayerList.Count));

            //Remove this click event from the picture box in the CardClass so that you can't click a non existent CardClass
            this.DiscardPile[this.DiscardPile.Count - 1].cardPB[this.is_Flipped.ToInt()].Click -= cardPB_Click;
            //remove the picture off of the screen
            this.GameForm.Controls.Remove(c_card.cardPB[this.is_Flipped.ToInt()]);

            //skip
            if (c_card.Numbers.Contains("skip"))
            {
                MessageBox.Show("In skip");
                this.PlayerIndex = NextPlayer(this.PlayerIndex, this.PlayerList.Count);
            }

            //Find the next PlayerClass
            this.PlayerIndex = NextPlayer(this.PlayerIndex, this.PlayerList.Count);

            console.Log($"method; (GameLogicClass.CardClickLogic), Card Index; ({Card_Index}), Top Deck ({this.DiscardPile[this.DiscardPile.Count - 1].Colors[this.is_Flipped.ToInt()]}, {this.DiscardPile[this.DiscardPile.Count - 1].Numbers[this.is_Flipped.ToInt()]}), Player Index ({this.PlayerIndex})");

            //update the screen
            UpdateScreen();
        }

        //CHANGE WITH is_Flipped
        private void CardPlay(CardClass c_card)
        {
            string log = "error";

            //If it is a wild CardClass then get what Colors the user wants and then place do normal remove stuff on it as if it was that Colors
            if (c_card.Numbers[this.is_Flipped.ToInt()].Contains("wild"))
            {
                //MAKE WILD FORM WORK WITH FLIP
                wildFormClass wildform = new wildFormClass();
                if (wildform.ShowDialog() == DialogResult.OK)
                {
                    c_card.Colors[this.is_Flipped.ToInt()] = wildform.Tag as string;
                }
                log = $"wild, {wildform.Tag as string}";
            }
            //If the CardClass is an addition CardClass then add to the plus amount for add logic
            if (c_card.Numbers[this.is_Flipped.ToInt()].Contains("+"))
            {
                PlusAmount += int.Parse(c_card.Numbers[this.is_Flipped.ToInt()][1].ToString());
                log = $"add, {PlusAmount}";
            }
            //If the CardClass is an addition CardClass then add to the plus amount for add logic
            if (c_card.Numbers[this.is_Flipped.ToInt()].Contains("reverse"))
            {
                this.is_Reverced = !this.is_Reverced;
                log = $"reverce, {this.is_Reverced}";
            }
            //if it is a flip CardClass then flip it
            if (c_card.Colors[this.is_Flipped.ToInt()] == "flip")
            {
                is_Flipped = !is_Flipped;
                log = $"flip, {is_Flipped}";
            }

            console.Log($"method; (GameLogicClass.CardPlay), c_card; ({c_card.Colors[is_Flipped.ToInt()]}) ({c_card.Numbers[this.is_Flipped.ToInt()]}), {log}");

        }

        //Check the logic of the adding
        private void AddLogic(int index)
        {
            //If not doing chain adds and plus amount is more then zero then add stuff
            if (!this.GameRules["do_ChainAdds"] && this.PlusAmount > 0) { AddCards(index); }
            //If doing chain adds and it is not flipped and if the next PlayerClass does not have a addidion CardClass
            if (this.GameRules["do_ChainAdds"] && CheckAdd(index)) { AddCards(index); }

            console.Log($"method; (GameLogicClass.AddLogic)");
        }

        //CHANGE WITH is_Flipped
        private bool CheckAdd(int index)
        {
            console.Log($"method; (GameLogicClass.CheckAdd)");
            //Check every CardClass to see if it is an addition CardClass if it is return true if not return false
            foreach (CardClass c in this.PlayerList[index].e_Hand)
            {
                if (c.Numbers[this.is_Flipped.ToInt()].Contains("+")) { return true; }
            }
            return false;
        }

        //add Hand for every Numbers in Plus amount then set the plus amount to zero
        private void AddCards(int index)
        {
            string log = "";
            for (int i = 0; i < this.PlusAmount; i++)
            {
                log += "AddCards Index: " + index + " ";
                this.PlayerList[index].Hand.Add(Draw());
            }
            this.PlusAmount = 0;

            console.Log($"method; (GameLogicClass.AddCards), cards added; ({log})");

        }

        //Runs whenver the CardClass ontop of the Draw pile is clicked
        public void DrawPile_Clicked(object sender, EventArgs e)
        {
            if (GameRules["do_Flip"])
            {
                int card_index = FindPictureInList(this.DrawPile, sender as PictureBox);
                this.PlayerList[this.PlayerIndex].Hand.Add(DrawPile.pop(card_index));
            }

            console.Log($"method; (GameLogicClass.DrawPile_Clicked)");

            DrawPileClickLogic();
        }

        public void DrawPileClickLogic()
        {

            string log = "ERROR";

            //If doing Draw to match add a random CardClass to the PlayerList DrawPile and remove it from the DrawPile at the same time
            if (!this.GameRules["do_DrawtoMatch"]) { log = "add one"; this.PlayerList[this.PlayerIndex].Hand.Add(Draw()); }
            //run Draw to match if needed
            if (this.GameRules["do_DrawtoMatch"]) { log = "draw to match"; DrawToMatch(this.DiscardPile[this.DiscardPile.Count - 1]); }
            //Find the next PlayerClass
            this.PlayerIndex = NextPlayer(this.PlayerIndex, this.PlayerList.Count);

            console.Log($"method; (GameLogicClass.DrawPileClickLogic), Player index; ({this.PlayerIndex}), {log}");
            
            UpdateScreen();
        }

        //Find the next PlayerClass
        private int NextPlayer(int current, int max)
        {
            if (!this.is_Reverced && current + 1 < max) { console.Log($"method; (GameLogicClass.NextPlayer), current; ({current}), max ({max}), next player +1"); return current + 1; }
            else if (!this.is_Reverced && current == max - 1) { console.Log($"method; (GameLogicClass.NextPlayer), current; ({current}), max ({max}), next player 0"); return 0;  }
            else if (this.is_Reverced && current - 1 > -1) { console.Log($"method; (GameLogicClass.NextPlayer), current; ({current}), max ({max}), next player -1 {current - 1}"); return current - 1; }
            else if (this.is_Reverced && current - 1 == -1) { console.Log($"method; (GameLogicClass.NextPlayer), current; ({current}), max ({max}), next player max-1"); return max - 1; }
            return -1;
        }

        //Display the Draw pile runs one time
        public void DisplayDrawPile(bool start)
        {
            if (!this.GameRules["do_Flip"] && !start) { console.Log("method; (GameLogicClass.DisplayDrawPile) [nothing to do]"); return; }
            //Draw 10 Hand
            for (int i = DrawPile.Count - 1; i > DrawPile.Count - 10 && i > -1; i--)
            {
                PictureBox tempPB = new PictureBox();
                // - i so that the Hand move over and you can see the amount of Hand
                tempPB.Location = new Point((this.GameForm.Width / 2 - i), (this.GameForm.Height / 2));
                //if not doing flip show the back of Hand
                if (!this.GameRules["do_Flip"]) { tempPB.Image = Image.FromFile(Application.StartupPath + "\\small\\" + "card_back_alt.png"); }
                //Draw the image if doing flip and it is not flipped
                else if (!is_Flipped) { tempPB.Image = DrawPile[RandomNumber.Between(0, DrawPile.Count - 1)].cardPB[this.is_Flipped.ToInt()].Image; }
                tempPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                tempPB.Size = new System.Drawing.Size(50, 100);
                //add it to the form
                this.GameForm.Controls.Add(tempPB);
                //make it so that if it is clicked then something happens
                tempPB.Click += DrawPile_Clicked;
            }
            console.Log("method; (GameLogicClass.DisplayDrawPile) [drew stuff]");
        }

        //Draw the discard pile with the actual images
        public void DisplayDiscardPile()
        {
            //for the last 10 images
            for (int i = this.DiscardPile.Count-1; i > this.DiscardPile.Count - 10 && i > -1; i--)
            {
                //get a location that is +-10 from the center
                this.DiscardPile[i].cardPB[this.is_Flipped.ToInt()].Location = new Point((this.GameForm.Width / 2 + RandomNumber.Between(-10, 10)), (this.GameForm.Height / 2 + RandomNumber.Between(-10, 10)));
                //Add the actual image
                this.GameForm.Controls.Add(this.DiscardPile[i].cardPB[this.is_Flipped.ToInt()]);
            }

            console.Log("method; (GameLogicClass.DisplayDiscardPile)");
        }

        //Redistribute the discard pile into the Draw pile
        public void DiscardPileRemove()
        {
            //for all but the last CardClass
            for (int i = 0; i < DiscardPile.Count - 1; i++)
            {
                //add a random CardClass to the end of the Draw pile
                DrawPile.Add(DiscardPile.pop(RandomNumber.Between(0, DiscardPile.Count - 1)));
            }

            console.Log("method; (GameLogicClass.DiscardPileRemove)");

        }

        //return a random CardClass from the Draw pile
        private CardClass Draw()
        {
            console.Log("method; (GameLogicClass.CardClass)");
            return DrawPile.pop(RandomNumber.Between(0, DrawPile.Count - 1));
        }

        //draw to match logic
        private void DrawToMatch(CardClass topdeck)
        {
            console.Log("method; (GameLogicClass.DrawToMatch)");
            while (true)
            {
                //add a CardClass
                this.PlayerList[this.PlayerIndex].Hand.Add(Draw());
                //find eligable Hand with new CardClass
                PlayerList[PlayerIndex].EligableCards(topdeck, this.is_Flipped.ToInt());
                //if the last CardClass in the players deck and eligable Hand is the same then the last CardClass was eligable and then stop drawing
                if (this.PlayerList[this.PlayerIndex].Hand[this.PlayerList[this.PlayerIndex].Hand.Count - 1] == this.PlayerList[this.PlayerIndex].e_Hand[this.PlayerList[this.PlayerIndex].e_Hand.Count - 1]) { return; }
            }
        }

        //find the picture from the list and then return its index
        public int FindPictureInList(List<CardClass> list, PictureBox find)
        {
            console.Log("method; (GameLogicClass.FindPictureInList)");
            int card_index = -1;
            //search through the whole list
            for (int i = 0; i < list.Count; i++)
            {
                //if they match then break out of the loop to save time
                if (list[i].cardPB[this.is_Flipped.ToInt()] == find) { card_index = i; break; }
            }
            return card_index;
        }
    }
}
