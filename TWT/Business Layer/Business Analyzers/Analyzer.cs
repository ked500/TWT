using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWT.Business_Layer.Models;
using TWT.Data_Layer.DAO;

namespace TWT.Business_Layer.Business_Analyzers
{
    public class Analyzer : BusinessObject
    {
        private void AnalyzeTweets()
        {
            foreach (var tweet in tweetDAO.GetTweets())
            {
                tweet.Analyse(sentimentsDAO.GetSentiments());
            }
        }


                
        private bool SetState(Tweet tweet)
        {
            foreach (var state in stateDAO.GetStates())
            {
                if (state.isInside(tweet))
                {
                    stateDAO.InsertTweet(state, tweet);
                    return true;
                }
            }

            return false;
        }

        public bool Update(string tweetFileName)
        {
            stateDAO.ClearTweetsInStates();
            tweetDAO.ClearUnknownTweets();

            try
            {
                tweetDAO.UpdateTweets(tweetFileName);
            }
            catch
            {
                return false;
            }

            this.AnalyzeTweets();

            foreach (var tweet in tweetDAO.GetTweets())
            {
                if (!SetState(tweet))
                    tweetDAO.InsertUnknownTweet(tweet);
            }

            return true;
        }


    }
}
