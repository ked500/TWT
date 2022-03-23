using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using TWT.Business_Layer.Models;
using TWT.Data_Layer.Parsers;


namespace TWT.Data_Layer
{
    internal class DB
    {
        private List<State> states = new List<State>();
        private Dictionary<string, List<Tweet>> tweets = new Dictionary<string, List<Tweet>>();
        private Dictionary<string, double> sentiments = new Dictionary<string, double>();
        public List<State> States
        {
            get
            {
                return states;
            }
            set
            {
                states = value;
            }
        }
        public Dictionary<string, List <Tweet>> Tweets
        {
            get
            {
                return tweets;
            }
            set
            {
                tweets= value;
            }
        }
        public Dictionary<string, double> Sentiments
        {
            get
            {
                return sentiments;
            }
            set
            {
                sentiments = value;
            }
        }
        DB()
        {
            Sentiments = SentimentsParser.Parse("");
            States = JsonParser.ParseStates();
        }


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
                            PointLatLng vert = new PointLatLng(vertex.Latitude, vertex.Longtitude);
                            vertexes.Add(vert);
                        }
                     GMapPolygon pol = new GMapPolygon(vertexes, state.Postcode);
                   polygons.Add(pol);
                }
            }
            return polygons;
        }

    }
}
