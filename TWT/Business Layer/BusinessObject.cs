using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TWT.Data_Layer.DAO;

namespace TWT.Business_Layer
{
    public abstract class BusinessObject
    {
        protected TweetDAO tweetDAO = new TweetDAO();
        protected StateDAO stateDAO = new StateDAO();
        protected SentimentsDAO sentimentsDAO = new SentimentsDAO();

    }
}
