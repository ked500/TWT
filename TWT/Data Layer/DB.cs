using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System.Drawing;
using TWT.Business_Layer.Models;
using TWT.Data_Layer.Parsers;

namespace TWT.Data_Layer
{
    public class DB
    {

        private static DB instance;

        private Dictionary<string, double> sentiments;
        private List<State> states;
        
        private List<Tweet> unknownTweets = new List<Tweet>();
        
        private List<Tweet> tweets;


        public List<State> States
        {
            private set { states = value; }
            get { return states; }
        }

        public List<Tweet> Tweets
        {
            private set { tweets = value; }
            get { return tweets; }
        }

        public List<Tweet> UnknownTweets
        {
            get { return unknownTweets; }
        }

        public Dictionary<string, double> Sentiments
        {
            private set { sentiments = value; }
            get { return sentiments; }
        }
        private DB()
        {
            //EXCEPTION
            
            this.States = StateParser.Parse();
            
            //EXCEPTION
            this.Sentiments = SentimentsParser.Parse();
        }


        public static DB GetInstance()
        {
            if (instance == null) instance = new DB();
            return instance;
        }
        
        public void ReadTweets(string tweetFileName)
        {
            //EXCEPTION
            this.tweets = TweetParser.Parse(tweetFileName);
        }


 


       

    }
}