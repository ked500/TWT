using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWT.Business_Layer.Models
{
    public class State
    {


        private List<Polygon> polygons = new List<Polygon>();

        public List<Polygon> Polygons 
        { 
            get { return polygons; } 
        }

        public State()
        {


        }

        public bool AddPolygon(Polygon Polygon)
        {

            try
            {
                Polygons.Add(Polygon);
                return true;
            }
            catch
            {
                return false;
            }
        }




    }
}
