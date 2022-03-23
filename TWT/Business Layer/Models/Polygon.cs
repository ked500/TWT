using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWT.Business_Layer.Models
{
    public class Polygon
    {
        private List<Coordinates> vertexes  = new List<Coordinates>();
        public List<Coordinates> Vertexes 
          
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
                Vertexes.Add(new Coordinates(x, y));
                return true;
            }
            catch
            {
                return false;
            }
            
        }



    }
}
