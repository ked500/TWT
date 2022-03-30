using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWT.Business_Layer.Models
{
    public class Polygon
    {


        private List<Coordinates> vertexes  = new List<Coordinates>();

        private double min_long = 180;
        private double max_long = -180;
        private double min_lat = 180;
        private double max_lat = -180;
        public List<Coordinates> Vertexes 
          
        { 
            get { return vertexes; } 
        }



        public Polygon()
        {
            
        }
        

        public bool AddVertex(double x, double y)
        {
            try
            {
                Vertexes.Add(new Coordinates(x, y));
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        void SetMaxValues()
        {
            foreach (var vetrex in Vertexes)
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
        public bool IsInside(Tweet Tweet)
        {
            SetMaxValues();
            if (Tweet.Coordinates.Latitude > max_long || Tweet.Coordinates.Latitude < min_long || Tweet.Coordinates.Longtitude > max_lat || Tweet.Coordinates.Longtitude < min_lat)
            {
                return false;
            }

            int count = Vertexes.Count;

            if (count < 3)
            {
                return false;
            }

            bool result = false;

            for (int i = 0, j = count - 1; i < count; i++)
            {
                var p1 = Vertexes[i];
                var p2 = Vertexes[j];

                if (p1.Latitude < Tweet.Coordinates.Longtitude && p2.Latitude >= Tweet.Coordinates.Longtitude || p2.Latitude < Tweet.Coordinates.Longtitude && p1.Latitude >= Tweet.Coordinates.Longtitude)
                {
                    if (p1.Longtitude + (Tweet.Coordinates.Longtitude - p1.Latitude) / (p2.Latitude - p1.Latitude) * (p2.Longtitude - p1.Longtitude) < Tweet.Coordinates.Latitude)
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
