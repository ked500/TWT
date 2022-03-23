using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TWT.Business_Layer.Models
{
    //ALL PROPERTIES MUST BE FILLED
    public class Tweet
    {
        private List<string> words = new List<string>();
        private Tuple<double, double> coordinates;
        private DateTime dateTime = new DateTime();
        private double emotionality = 0;


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
            Message = Regex.Replace(Message, @"(http:\/\/\S+\/?\w*)|([@#]\w+)", "");
                
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
        //MUST BE CALLED FOR EVERY TWEET AFTER PARSING THE FILES (IN THE DB)
        public void Analyse(Dictionary<string, double> sentimentsWords)
        {

            foreach (var word in Words)
            {

                    if (sentimentsWords.ContainsKey(word))
                        this.Emotionality += sentimentsWords[word];
               
            }

            //foreach (var word in words)
            //{
            //    if (this.Words.Contains(word.Key))
            //    {
            //        if (!Emotionality.HasValue) Emotionality = 0;
                    
            //        Emotionality += word.Value;
            //    }

            //}

        }

    }
}
