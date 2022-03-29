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
        private Coordinates coordinates;
        private DateTime dateTime = new DateTime();
        private double emotionality = double.NaN;


        public List<string> Words 
        { 
            get { return words; }
            private set { words = value; } 
        }
        public Coordinates Coordinates
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
            this.Coordinates = new Coordinates(Convert.ToDouble(XCord.Trim()), Convert.ToDouble(YCord.Trim()));

        }


        //SETTING EMOTIONALITY
        //MUST BE CALLED FOR EVERY TWEET AFTER PARSING THE FILES (IN THE DB)
        public void Analyse(Dictionary<string, double> sentimentsWords)
        {

            int count = 0;
            for (int index =0; index < Words.Count; index++)
            {
                for (int index1 = 0; index1 != index; index1++)
                {
                    string word = string.Empty;
                    for (int index2 = index1; index2!= index; index2++)
                    {
                        word += Words[index2];
                        if(index2 + 1 != index) word += ' ';
                    }
                    if (sentimentsWords.ContainsKey(word))
                    {
                        if (double.IsNaN(this.Emotionality)) this.Emotionality = 0;
                        this.Emotionality += sentimentsWords[word];
                        count++;
                    }
                   
                }

            }
            if(count != 0)
                this.Emotionality = Math.Round((this.Emotionality / count), 2);

        }

    }
}
