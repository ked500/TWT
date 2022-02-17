using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWT.Business_Layer.Models
{
    public class Polygon
    {

        private List<Tuple<double, double>> vertexes  = new List<Tuple<double, double>>();
        public List<Tuple<double, double>> Vertexes 
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
                this.Vertexes.Add(new Tuple<double, double>(x, y));
                return true;
            }
            catch
            {
                return false;
            }
            
        }



    }
}
