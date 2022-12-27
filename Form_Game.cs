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
    public partial class GameForm : Form
    {

        private Form_PauseMenu pause = new Form_PauseMenu();

        public GameForm(Dictionary<string, bool> GameRules, int PlayerAmount, int CardAmount = 7)
        {
            InitializeComponent();
            this.FormClosing += GameForm_FormClosing;
            this.KeyDown += openPauseMenu;
            MessageBox.Show($"Width: {this.Width}, Height: {this.Height}, Size: {this.Size}");
            GameLogicClass game = new GameLogicClass(GameRules, this, PlayerAmount, CardAmount);
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
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

    //add flip Hand and change 

    

    public static class RandomNumber
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();
        public static int Between(int minimumValue, int maximumValue)
        {
            byte[] randomNumbers = new byte[1];
            _generator.GetBytes(randomNumbers);
            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumbers[0]);
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

        public static int ToInt(this bool value)
        {
            return value ? 1 : 0;
        }
    }
}