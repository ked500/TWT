using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWT.Data_Layer.DAO
{
    public class SentimentsDAO
    {
        public Dictionary<string, double> GetSentiments()
        {
            return DB.GetInstance().Sentiments;
        }


    }
}
