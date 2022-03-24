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
using TWT.Data_Layer.Parsers;

namespace TWT.Data_Layer
{
    internal class DB
    {
        static Dictionary<string, double> wordValues;
        static List<State> states;
        static List<Tweet> tweets;

        static public List<GMapPolygon> GetPolygons()
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

        //TEST ONLY
        private static void ParseStates()
        {
            states = JsonParser.ParseStates();
        }

        private static void ParseSentiments()
        {
            wordValues = SentimentsParser.Parse(@"..\..\Data Layer\Data Files\sentiments.csv");
        }

        private static void ParseTweet(string path)
        {
            ParseSentiments();
            tweets = TxtParser.ParseTweets(path);
            foreach (var item in tweets)
            {
                item.Analyse(wordValues);
            }
        }

        //@"..\..\Data Layer\Data Files\cali_tweets2014.txt"

        static Dictionary<string, State> ConvertStates()
        {
            Dictionary<string, State> statesDic = new Dictionary<string, State>();
            foreach (var item in states)
            {
                statesDic.Add(item.Postcode, item);
            }
            return statesDic;
        }

        static private void countStates()
        {
            ParseStates();
            Dictionary<string, State> newStates = ConvertStates();         
            ParseTweet(@"..\..\Data Layer\Data Files\cali_tweets2014.txt");
            List<State> statesToColor = states;
            foreach (var tweet in tweets)
            {
               
                State state = AnalyseStates(statesToColor, tweet);
                if(!newStates.ContainsKey(state.Postcode))
                {
                    state.AddTweet(tweet);
                    newStates.Add(state.Postcode, state);
                }
                else
                {
                    State newState = newStates[state.Postcode];
                    newStates.Remove(state.Postcode);
                    newState.AddTweet(tweet);
                    newStates.Add(newState.Postcode, newState);
                }
            }
            states = new List<State>(newStates.Values);
        }

        static private State AnalyseStates(List<State> states,Tweet tweet)
        {
            State stateToReturn = new State();
            stateToReturn.Postcode = "UNKNOWN";
            foreach (var state in states)
            {
                foreach (var polygon in state.Polygons)
                {

                    if (state.isInside(tweet.Coordinates, polygon.Vertexes))
                    {
                        return state;
                    }
                }
            }
            return stateToReturn;
        }

        static public List<GMapPolygon> GetPaintedStates()
        {
            countStates();
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
    }
}
