using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWT.Business_Layer.Models
{
    public class State
    {


        private List<Polygon> polygons = new List<Polygon>();
        
        //TWEETS INSIDE THE STATE
        private List<Tweet> tweets = new List<Tweet>();
        private string postcode;
        public List<Polygon> Polygons 
        { 
            get { return polygons; } 
        }

        public List<Tweet> Tweets
        {
            get { return tweets; }
            set { tweets = value; }
        }

        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }
        public double? Emotionality
        {
            get
            {
                double? emotionality = 0;
                foreach (var tweet in Tweets)
                {
                    emotionality += tweet.Emotionality;
                }
                return emotionality;
            }
        }
        public State()
        {


        }

        public bool AddTweet(Tweet Tweet)
        {
            try
            {
                Tweets.Add(Tweet);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AddPolygon(Polygon Polygon)
        {

            try
            {
                Polygons.Add(Polygon);
                return true;
            }
            catch
            {
                return false;
            }
        }




    }
}
