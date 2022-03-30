using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWT.Business_Layer.Models;

namespace TWT.Data_Layer.Parsers
{
    public class TweetParser
    {
        public static List<Tweet> Parse(string tweetsFileName)
        {
            List<Tweet> tweets = new List<Tweet>();
            string[] file = File.ReadAllLines(FilesManager.GetTweetFullPath(tweetsFileName));
            foreach (var line in file)
            {
                Tweet tweet = GetParsedTweet(line);
                if (tweet != null)
                    tweets.Add(tweet);
            }
            return tweets;
        }

        public static Tweet GetParsedTweet(string line)
        {
            string[] sentences = line.Split('\t');

            if (sentences.Length < 3)
                return null;
            else {
                string[] coordinates = sentences[0].Trim('[',']').Split(','); 
                return new Tweet(coordinates[0], coordinates[1], sentences[2], sentences[3]);
            }
        }
    }
}
