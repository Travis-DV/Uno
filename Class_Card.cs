using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uno
{
    internal class CardClass
    {
        //Colorss Numberss points and picture boxes [0] = normal [1] = flip
        public string[] Colors = { "", "" };
        public string[] Numbers = { "", ""};
        public int[] Points = { -1, -1 };
        public PictureBox[] cardPB = { new PictureBox(), new PictureBox() };

        public CardClass(string Colors, string Numbers, int points)
        {
            console.Log("method; (CardClass.CardClass) [Card INIT]");
            //Set the normal Colors Numberss points suze and sizemodes
            this.Colors[0] = Colors;
            this.Numbers[0] = Numbers;
            this.Points[0] = points;
            this.cardPB[0].Size = new System.Drawing.Size(50, 100);
            this.cardPB[0].Image = Image.FromFile(Application.StartupPath + "\\" + $"small\\{this.Colors[0]}_{this.Numbers[0]}.png");
            this.cardPB[0].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            
        }

        //set the up the flip stuff
        public void SetFlip(string Colors, string Numbers, int points)
        {
            console.Log("method; (CardClass.SetFlip) [Card Flip INIT]");
            this.Colors[1] = Colors;
            this.Numbers[1] = Numbers;
            this.Points[1] = points;
            this.cardPB[1].Size = new System.Drawing.Size(50, 100);
            this.cardPB[1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cardPB[0].Image = Image.FromFile(Application.StartupPath + "\\" + $"small\\{this.Colors[1]}_{this.Numbers[1]}.png");
        }

        //Set thhe locations
        public void SetPBLocation(int[] location)
        {
            console.Log($"method; (CardClass.SetPBLocation), x, y; ({location[0]}, {location[1]})");
            this.cardPB[0].Location = new Point(location[0], location[1]);
            this.cardPB[1].Location = new Point(location[0], location[1]);
        }
    }
}
