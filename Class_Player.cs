using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uno
{
    internal class PlayerClass
    {
        //Set Lists
        public List<CardClass> Hand = new List<CardClass>();
        public List<CardClass> e_Hand = new List<CardClass>();
        public int Team = -1;
        public int Points = 0;
        public AIClass AI;

        //run on init
        public PlayerClass(int Team, bool AI, int PlayerAmount)
        {
            //set the Team
            this.Team = Team;
            if (AI)
            {
                this.AI = new AIClass(PlayerAmount);
            }
        }

        public void DrawCards(GameLogicClass Game, PlayerClass Player)
        {
            foreach (CardClass c in Hand)
            {
                Game.GameForm.Controls.Remove(c.cardPB[Game.is_Flipped.ToInt()]);
                if (Player.Team == 1 || Game.is_Flipped)
                {
                    Game.GameForm.Controls.Add(c.cardPB[Game.is_Flipped.ToInt()]);
                }
                else if (Player.Team != 1 && !Game.is_Flipped && Game.GameRules["do_Flip"])
                {
                    Game.GameForm.Controls.Add(c.cardPB[1]);
                }
                else if (Player.Team != 1 && !Game.GameRules["do_Flip"])
                {
                    PictureBox tempPB = new PictureBox();
                    tempPB.Location = c.cardPB[Game.is_Flipped.ToInt()].Location;
                    tempPB.Image = Image.FromFile(Application.StartupPath + "\\small\\" + "card_back_alt.png");
                    tempPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    tempPB.Size = new System.Drawing.Size(50, 100);
                    Game.GameForm.Controls.Add(tempPB);
                }
            }
        }

        //Find and add the eligable cards to the corasponding list
        public void EligableCards(CardClass TopOfDrawPile, int INTis_Flipped)
        {
            //for all the cards in their hand
            foreach (CardClass c in this.Hand)
            {
                //If the colors match or their numbers or the color is wild then it gets added
                if (c.Colors[INTis_Flipped] == TopOfDrawPile.Colors[INTis_Flipped] || c.Numbers[INTis_Flipped] == TopOfDrawPile.Numbers[INTis_Flipped] || c.Colors[INTis_Flipped] == "wild")
                {
                    this.e_Hand.Add(c);
                }
            }
        }

        //Make it so that if the person clicks on one of their cards it does something
        public void ActivateClick(GameLogicClass Game)
        {
            //for every card in their hand
            for (int i = 0; i < this.Hand.Count; i++)
            {
                //ad an on click event
                this.Hand[i].cardPB[Game.is_Flipped.ToInt()].Click += Game.cardPB_Click;
            }

        }

        //deactivate them so that the clicking cards does nothing if it is not their tern
        public void DeactivateClick(GameLogicClass Game)
        {
            //look at activate
            for (int i = 0; i < this.Hand.Count; i++)
            {
                this.Hand[i].cardPB[Game.is_Flipped.ToInt()].Click -= Game.cardPB_Click;
            }

        }

        //Do the math to find where to place the images
        public void FindCardPosition(int x, int y, int order)
        {
            //re assemble the list
            int[] Positions = { x, y };
            //MATH = half the amount of cards times the width + the half times the buffer so that it is easy to change both
            //if it is an even number
            if (this.Hand.Count % 2 == 0) { Positions[order] -= ((this.Hand.Count / 2) * 50) + ((this.Hand.Count / 2) * 5); }
            //if it is odd add half a card at the start
            if (this.Hand.Count % 2 == 1) { Positions[order] -= (25 + ((this.Hand.Count - 1) / 2) * 50) + (((this.Hand.Count - 1) / 2) * 5); }
            //set the first cards pos
            this.Hand[0].SetPBLocation(Positions);
            //for the rest of the cards
            for (int card_index = 1; card_index < this.Hand.Count; card_index++)
            {
                //add 50 for width and 5 for buffer
                Positions[order] += 50 + 5;
                //set their pos
                this.Hand[card_index].SetPBLocation(Positions);
            }
        }

        //Update the points for the Player
        public void UpdatePoints(bool do_Flip)
        {
            //for all the cards
            foreach (CardClass c in Hand)
            {
                //add the normal points
                Points += c.Points[0];
                //if doinng flip add that too
                if (do_Flip)
                {
                    Points += c.Points[1];
                }
            }
        }
    }
}
