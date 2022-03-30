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
            get { return states; }
            set { states = value; }
        }



        private DB()
        {
            this.States = StateParser.Parse();
            this.sentiments = SentimentsParser.Parse();
        }


        public static DB GetInstance()
        {
            if (instance == null) instance = new DB();
            return instance;
        }
        
        private void ReadTweets(string tweetFileName)
        {
            this.tweets = TweetParser.Parse(tweetFileName);
            foreach (var tweet in tweets)
            {
                tweet.Analyse(this.sentiments);
            }
        }


        public bool IsUnknown(Tweet Tweet)
        {
            return this.unknownTweets.Any((x) => x == Tweet);
        }
        private void RefreshStates()
        {
            States.ForEach((x) => x.Tweets.Clear());
        }

        private bool SetState(Tweet tweet)
        {
            foreach (var state in states)
            {
               if (state.isInside(tweet))
               {
                    state.Tweets.Add(tweet);
                    return true;
               }
            }
            
            return false;
        }

        public void Update(string tweetFileName)
        {
            RefreshStates();
            ReadTweets(tweetFileName);
            this.unknownTweets.Clear();
            foreach (var tweet in tweets)
            {
                if (!SetState(tweet))
                    unknownTweets.Add(tweet);
            }

        }

        //TEST ONLY
        //private static void ParseStates()
        //{
        //    states = StateParser.ParseStates();
        //}

        //private static void ParseSentiments()
        //{
        //    sentiments = SentimentsParser.Parse(@"..\..\Data Layer\Data Files\sentiments.csv");
        //}

        //private static void ParseTweet(string path)
        //{
        //    ParseSentiments();
        //    tweets = TweetParser.ParseTweets(path);
        //    foreach (var item in tweets)
        //    {
        //        item.Analyse(sentiments);
        //    }
        //}

        //@"..\..\Data Layer\Data Files\cali_tweets2014.txt"

        //static Dictionary<string, State> ConvertStates()
        //{
        //    Dictionary<string, State> statesDic = new Dictionary<string, State>();
        //    foreach (var item in states)
        //    {
        //        statesDic.Add(item.Postcode, item);
        //    }
        //    return statesDic;
        //}

        //static private void countStates(string tweetsFileName)
        //{
        //    ParseStates();
        //    Dictionary<string, State> newStates = ConvertStates();         
        //    ParseTweet($@"..\..\Data Layer\Data Files\{tweetsFileName}");
        //    List<State> statesToColor = states;
        //    foreach (var tweet in tweets)
        //    {

        //        State state = AnalyseStates(statesToColor, tweet);
        //        if(!newStates.ContainsKey(state.Postcode))
        //        {
        //            state.AddTweet(tweet);
        //            newStates.Add(state.Postcode, state);
        //        }
        //        else
        //        {
        //            State newState = newStates[state.Postcode];
        //            newStates.Remove(state.Postcode);
        //            newState.AddTweet(tweet);
        //            newStates.Add(newState.Postcode, newState);
        //        }
        //    }
        //    states = new List<State>(newStates.Values);
        //}

        //static private State AnalyseStates(List<State> states,Tweet tweet)
        //{
        //    State stateToReturn = new State();
        //    stateToReturn.Postcode = "UNKNOWN";
        //    foreach (var state in states)
        //    {
        //        foreach (var polygon in state.Polygons)
        //        {

        //            if (state.isInside(tweet.Coordinates, polygon.Vertexes))
        //            {
        //                return state;
        //            }
        //        }
        //    }
        //    return stateToReturn;
        //}


    }
}