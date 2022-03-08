using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWT.Data_Layer.Parsers
{
    public class SentimentsParser
    {
        public static Dictionary<string, double> Parse(string path)
        {
            Dictionary<string, double> words = new Dictionary<string, double>();

            StreamReader reader = new StreamReader(path);
            string[] lines = reader.ReadToEnd().Split('\n');

            foreach (var line in lines)
            {
                string[] keyValue = line.Split(',');
                words.Add(keyValue[0], Convert.ToDouble(keyValue[1]));
             
            }


            return words;

        }


    }
}
