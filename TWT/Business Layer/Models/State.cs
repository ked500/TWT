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
        public double min_long = 180;
        public double max_long = -180;
        public double min_lat = 180;
        public double max_lat = -180;
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

        //TEST ONLY

        private void SetMaxValues()
        {
            foreach (var polygon in polygons)
            {
                foreach (var vetrex in polygon.Vertexes)
                {
                    double x = vetrex.Longtitude;
                    double y = vetrex.Latitude;
                    if (x > max_long)
                    {
                        max_long = x;
                    }
                    if (x < min_long)
                    {
                        min_long = x;
                    }

                    if (y > max_lat)
                    {
                        max_lat = y;
                    }
                    if (y < min_lat)
                    {
                        min_lat = y;
                    }
                }
            }
        }
        public bool isInside(Coordinates p, List<Coordinates> polygonVertexes)
        {
            SetMaxValues();
            if (p.Latitude > max_long || p.Latitude < min_long || p.Longtitude > max_lat || p.Longtitude < min_lat)
            {
                return false;
            }

            int count = polygonVertexes.Count;

            if (count < 3)
            {
                return false;
            }

            bool result = false;

            for (int i = 0, j = count - 1; i < count; i++)
            {
                var p1 = polygonVertexes[i];
                var p2 = polygonVertexes[j];

                if (p1.Latitude < p.Longtitude && p2.Latitude >= p.Longtitude || p2.Latitude < p.Longtitude && p1.Latitude >= p.Longtitude)
                {
                    if (p1.Longtitude + (p.Longtitude - p1.Latitude) / (p2.Latitude - p1.Latitude) * (p2.Longtitude - p1.Longtitude) < p.Latitude)
                    {
                        result = !result;
                    }
                }

                j = i;
            }

            return result;
        }
    }
}
