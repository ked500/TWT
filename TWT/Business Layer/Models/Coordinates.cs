using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWT.Business_Layer.Models
{
    public class Coordinates
    {

        private double latitude;
        private double longtitude { get; set; }
        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }


        public double Longtitude
        {
            get { return longtitude; }
            set { longtitude = value; } 
        }
        public Coordinates(double x, double y)
        {
            Longtitude = x;
            Latitude = y;
        }
        

    }
}
