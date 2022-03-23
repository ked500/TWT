using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System.Drawing;
using TWT.Business_Layer.Models;

namespace TWT.Data_Layer
{
    internal class DB
    {
        static public List<GMapPolygon> GetPolygons(List<State> states)
        {
            List<GMapPolygon> polygons = new List<GMapPolygon>();
            foreach (var state in states)
            {
                foreach (var polygon in state.Polygons)
                {
                        List<PointLatLng> vertexes = new List<PointLatLng>();
                        foreach (var vertex in polygon.Vertexes)
                        {
                            PointLatLng vert = new PointLatLng(vertex.Latitude, vertex.Longtitude);
                            vertexes.Add(vert);
                        }
                     GMapPolygon pol = new GMapPolygon(vertexes, state.Postcode);
                    if (!double.IsNaN(state.Emotionality))
                        pol.Fill = new SolidBrush(Coloring.SetColors(state.Emotionality));
                    else
                        pol.Fill = new SolidBrush(Color.Gray);
                   pol.Stroke = new Pen(Color.Black, 0.005f);
                   polygons.Add(pol);
                }
            }
            return polygons;
        }

        static public List<State> GetStates(string path)
        {
            //for coloring states
            List<State> states = new List<State>();
            return states;
        }
    }
}
