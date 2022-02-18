using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWT.Business_Layer.Models;

namespace TWT.Data_Layer.Parsers
{
    class TxtParser
    {
        public static List<Tweet> ParseTweets(string path)
        {
            List<Tweet> tweets = new List<Tweet>();
            string[] file = File.ReadAllLines(path);
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
            else
                return new Tweet(sentences[0].Trim('[',']'), sentences[2], sentences[3]);
            //THINK ABOUT THIS TROUBLE ^
            //                         |
        }
    }
}
