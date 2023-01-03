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

            // Create a request to the GitHub API
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Headers.Add("Authorization", "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");


            // Add a User-Agent header to the request to avoid being rate-limited by the API
            request.UserAgent = "GitHubUpdateExample";

            // Send the request and get the response from the API
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Read the response from the API as a string
            string json = new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();

            // Parse the JSON response into a string
            // (replace "files" with the key of the array you want to get from the JSON response)
            MessageBox.Show(json);
            string filesJson = json.Split(new string[] { "\"files\":" }, StringSplitOptions.None)[1].Split(']')[0];

            // Split the string of updated files into an array
            string[] fileStrings = filesJson.Split(new string[] { "},{", "{", "}" }, StringSplitOptions.None);

            // Iterate over the array of updated file strings
            foreach (string fileString in fileStrings)
            {
                // Split the file string into a dictionary of key-value pairs
                string[] fileEntries = fileString.Split(',');
                Dictionary<string, string> fileDict = new Dictionary<string, string>();
                foreach (string fileEntry in fileEntries)
                {
                    string[] keyValue = fileEntry.Split(':');
                    fileDict[keyValue[0].Trim('"')] = keyValue[1].Trim('"');
                }

                // Get the name and URL of the file from the dictionary
                string fileName = fileDict["filename"];
                string fileUrl = fileDict["raw_url"];

                // Download the updated file to a temporary location
                using (WebClient fileClient = new WebClient())
                {
                    fileClient.DownloadFile(fileUrl, "temp_" + fileName);
                }

                // Close the solution in Visual Studio
                // (replace "uno" with the name of your solution)
                System.Diagnostics.Process.Start("devenv", "uno.sln /command Exit");

                // Delete the old file from the project in the file system
                File.Delete(fileName);

                // Add the updated file to the project in the file system
                File.Move("temp_" + fileName, fileName);

                // Reopen the solution in Visual Studio
                System.Diagnostics.Process.Start("devenv", "uno.sln");
            }
        }
    }
}
