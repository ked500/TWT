using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWT.Business_Layer.Models
{
    public class Tweet
    {
        private string message;
        private Tuple<double, double> coordinates;
        private DateTime dateTime = new DateTime();
        private double emotionality = double.NaN;


        public string Message 
        { 
            get { return message; }
            private set { message = value; } 
        }
        public Tuple<double, double> Coordinates
        {
            get { return coordinates; }
            private set { coordinates = value; }
        }

        public DateTime DateTime
        {
            get { return dateTime; }
            private set { dateTime = value; }
        }

        public double Emotionality
        {
            get { return emotionality; }
            private set { emotionality = value; }
        }

        public Tweet()
        {


        }

        public Tweet(string XCord, string YCord, string DateTime, string Message)
        {
            this.Message = Message;
            this.DateTime = Convert.ToDateTime(DateTime);
            Coordinates = new Tuple<double, double>(Convert.ToDouble(XCord.Trim()), Convert.ToDouble(YCord.Trim()));

        }


        //SETTING EMOTIONALITY
        public void Analyse(Dictionary<string, double> words)
        {
            this.Emotionality = 0;

            foreach (var word in words)
            {
                if (this.Message.Contains(word.Key))
                {
                    this.Emotionality += word.Value;
                }

            }

        }

    }
}
