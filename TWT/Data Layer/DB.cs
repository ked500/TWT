using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using TWT.Business_Layer.Models;

namespace TWT.Data_Layer
{
    internal class DB
    {
        static public List<GMapPolygon> GetStates(List<State> states)
        {
            List<GMapPolygon> polygons = new List<GMapPolygon>();
            foreach (var state in states)
            {
                foreach (var polygon in state.Polygons)
                {
                        List<PointLatLng> vertexes = new List<PointLatLng>();
                        foreach (var vertex in polygon.Vertexes)
                        {
                            PointLatLng vert = new PointLatLng(vertex.Item2, vertex.Item1);
                            vertexes.Add(vert);
                        }
                       // GMapPolygon pol = new GMapPolygon(vertexes, state.Postcode);
                   // polygons.Add(pol);
                }
            }
            return polygons;
        }
    }
}
