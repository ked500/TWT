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
        //TEST ONLY
 
        //

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
        public double Emotionality
        {
            get
            {
                double emotionality = 0;
                int count = 0;
                foreach (var tweet in Tweets)
                {
                    if (!double.IsNaN(tweet.Emotionality))
                    {
                        emotionality += tweet.Emotionality;
                        count++;
                    }
                }
                return emotionality / count;
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

        //TEST ONLY

        //REFACTORING
        public bool isInside(Tweet Tweet)
        {
            return this.Polygons.Any((x) => x.IsInside(Tweet));
        }
    }
}
