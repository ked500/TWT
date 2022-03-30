using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWT.Business_Layer.Models;

namespace TWT.Data_Layer.DAO
{
    public class TweetDAO
    {
        public List<Tweet> GetTweets()
        {
            return DB.GetInstance().Tweets;
        }

        public List<Tweet> GetUnknownTweets()
        {
            return DB.GetInstance().UnknownTweets;
        }

        public void ClearUnknownTweets()
        {
            DB.GetInstance().UnknownTweets.Clear();
        }


        //INSERT NEW UNKNOWN TWEET
        public void InsertUnknownTweet(Tweet Tweet)
        {
            GetUnknownTweets().Add(Tweet);
        }

        //REREAD ALL TWEETS FROM FILE
        public void UpdateTweets(string tweetFileName)
        {
            DB.GetInstance().ReadTweets(tweetFileName);
        }

    }
}
