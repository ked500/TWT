using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TWT.Data_Layer
{
    public class FilesManager
    {
        private static string dataFolderPath = "../../Data Layer/Data Files/";
        private static string tweetsFolderPath = dataFolderPath + "Tweets/";
        private static string statesFolderPath = dataFolderPath + "States/";
        private static string sentimentsFolderPath = dataFolderPath + "Sentiments/";

        
        public static string[] GetTweetFiles()
        {
            string[] files = Directory.GetFiles(tweetsFolderPath);
            Regex pattern = new Regex(@"\w+_tweets\d{4}.txt");
            return files.Select((x)=> Path.GetFileName(x)).Where((x)=> pattern.IsMatch(x)).ToArray();
        }

        public static string GetTweetFullPath(string tweetsFileName)
        {
            return tweetsFolderPath + tweetsFileName;
        }

        public static string GetStatesFullPath()
        {
            return statesFolderPath + "states.json";
        }

        public static string GetSentimnetsFullPath()
        {
            return sentimentsFolderPath + "sentiments.csv";
        }


    }
}
