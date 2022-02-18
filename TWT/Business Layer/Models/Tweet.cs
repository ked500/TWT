using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWT.Business_Layer
{
    public class Tweet
    {
        private string message;
        private Tuple<double, double> coordinates;
        private DateTime dateTime = new DateTime();
        private double emotionality;


        public string Message 
        { 
            get { return message; }
            set { message = value; } 
        }
        public Tuple<double, double> Coordinates
        {
            get { return coordinates; }
            set { coordinates = value; }
        }

        public DateTime DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }

        public double Emotionality
        {
            get { return emotionality; }
            set { emotionality = value; }
        }

        public Tweet()
        {


        }

        public Tweet(string Message, DateTime DateTime, double XCord, double YCord)
        {
            this.Message = Message;
            this.DateTime = DateTime;
            Coordinates = new Tuple<double, double>(XCord, YCord);

        }


    }
}
