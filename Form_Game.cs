using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.ComponentModel.Design;

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
            console.Log($"method; (GameForm.GameForm), Width: ({this.Width}), Height; ({this.Height}), Size; ({this.Size})");
            GameLogicClass game = new GameLogicClass(GameRules, this, PlayerAmount, CardAmount);
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            console.Log("method; (GameForm.GameForm_FormClosing)");
            pause.Show();
        }

        private void openPauseMenu(object sender, KeyEventArgs e)
        {
            console.Log("method; (GameForm.openPauseMenu)");
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
            if (minimumValue == 0 && maximumValue == 0) {return 0;}
            byte[] randomNumbers = new byte[1];
            _generator.GetBytes(randomNumbers);
            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumbers[0]);
            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);
            int range = (maximumValue - 1) - minimumValue;
            double randomValueInRange = Math.Floor(multiplier * range);
            console.Log($"method; (RandomNumber.Between), Between; (min: {minimumValue}, max: {maximumValue}), Value; ({(int)(minimumValue + randomValueInRange)})");
            return (int)(minimumValue + randomValueInRange);
        }
    }

    public static class Extensions
    {
        public static T pop<T>(this List<T> list, int index = -1)
        {
            if (list.Count == 0) { throw new InvalidOperationException("Cannot pop from an empty list"); }

            if (index == -1) { index = list.Count - 1; }

            T temp = list[index];
            list.RemoveAt(index);
            console.Log($"method; (Extensions.pop), Thing Popped; ({temp})");
            return temp;
        }

        public static int ToInt(this bool value)
        {
            return value ? 1 : 0;
        }
    }

    public static class console
    {

        private static string FilePath = $"{System.Windows.Forms.Application.StartupPath}\\logs/logs.txt";
        //"G:\githubstuff\uno\bin\Debug\logs\logs.txt"

        public static void Log(string message) 
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
            }
            using (StreamWriter sw = new StreamWriter(FilePath, true)) 
            { 
                sw.WriteLine($"({DateTime.Now}) |> {message}");
            }
        }

        public static void CleanUp(int daysold = 30)
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
                return;
            }
            List<string> lines = System.IO.File.ReadAllLines(FilePath).ToList();
            if (!lines.Any()) { return; }
            int i = 0;
            while (true)
            {
                if ((int)(DateTime.Now - DateTime.Parse(lines[i].Split(' ')[0].Replace("(", "").Replace(")", ""))).TotalDays > daysold)
                {
                    lines.Remove(lines[i]);
                    i--;
                }
                else
                {
                    System.IO.File.WriteAllLines(FilePath, lines.ToArray());
                    break;
                }
                i++;
            }
        }
    }
}