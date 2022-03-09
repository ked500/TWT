using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TWT.Business_Layer.Models
{
    public class Tweet
    {
        private List<string> words = new List<string>();
        private Tuple<double, double> coordinates;
        private DateTime dateTime = new DateTime();
        private double emotionality = double.NaN;


        public List<string> Words 
        { 
            get { return words; }
            private set { words = value; } 
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

        

        public Tweet(string XCord, string YCord, string DateTime, string Message)
        {
            Message = Regex.Replace(Message, @"(http:\/\/\S+\/\w+)|([@#]\w+)", "");
                
            string[] phrases = Message.Split(',', '.', '?', '!', ':', ';', '"', '=', '+', '(', ')');
            foreach (var phrase in phrases)
            {
                string[] words = phrase.Split(' ');
                foreach (var word in words)
                {
                    if(word!= "")this.Words.Add(word.Trim().ToLower());
                }
            }
            this.DateTime = Convert.ToDateTime(DateTime);
            Coordinates = new Tuple<double, double>(Convert.ToDouble(XCord.Trim()), Convert.ToDouble(YCord.Trim()));

        }


        //SETTING EMOTIONALITY
        public void Analyse(Dictionary<string, double> words)
        {
            this.Emotionality = 0;
            
            foreach (var word in words)
            {
                if (this.Words.Contains(word.Key))
                {
                    this.Emotionality += word.Value;
                }

            }

        }

    }
}
