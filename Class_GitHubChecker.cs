using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Net.Http.Headers;

namespace uno
{
    internal class GitHubCheckerClass
    {
        public static void StartUp()
        {
            string apiUrl = "https://api.github.com/Travis-Findley/uno/main";
            /*
            using (WebClient client = new WebClient())
            {
                if (client.DownloadString(apiUrl) != File.ReadAllText($"{Application.StartupPath}\\version.txt") )
                {
                    MessageBox.Show("in");
                }
            }
            */
        }
    }
}
