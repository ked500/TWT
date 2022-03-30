using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWT.Business_Layer.Models;

namespace TWT.Data_Layer.DAO
{
    public class StateDAO
    {
        public List<State> GetStates()
        {
            return DB.GetInstance().States;
        }



        //CLEAR ALL TWEETS IN ALL STATES
        public void ClearTweetsInStates()
        {
            GetStates().ForEach((x) => x.Tweets.Clear());
        }

        public bool InsertTweet(State State, Tweet Tweet)
        {
            try
            {
                State findedState = GetStates().Find((x) => x == State);
                findedState.Tweets.Add(Tweet);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
