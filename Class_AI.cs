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

        public PictureBox Play(List<CardClass> p_e_Hand, bool is_Flipped)
        {
            return p_e_Hand[RandomNumber.Between(0, p_e_Hand.Count - 1)].cardPB[is_Flipped.ToInt()];
        }
    }
}
