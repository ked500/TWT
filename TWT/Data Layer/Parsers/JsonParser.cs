using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TWT.Business_Layer.Models;


namespace TWT.Data_Layer.Parsers
{
    public class JsonParser
    {


        public static List<State> ParseStates(string path)
        {

            string jsonString = new StreamReader(path).ReadToEnd();
            JObject jsonStates = JObject.Parse(jsonString);


            List<State> states = new List<State>();
            foreach (var jsonState in jsonStates)
            {

                State state = ReadState(jsonState.Value);
                states.Add(state);
                
            }
            return states;
        }

        private static State ReadState(JToken jsonState)
        {
            State state = new State();
            if (jsonState.Values().Values().Values().Values().Any())
            {
                foreach (var jsonPolygons in jsonState)
                {
                    foreach (var jsonPolygon in jsonPolygons)
                    {
                        Polygon polygon = ReadPolygon(jsonPolygon);

                        state.AddPolygon(polygon);
                    }
                }
            }
            else
            {
                foreach (var jsonPolygon in jsonState)
                {
                    Polygon polygon = ReadPolygon(jsonPolygon);

                    state.AddPolygon(polygon);
                }
            }

            return state;
        }
        private static Polygon ReadPolygon(JToken jsonPolygon)
        {
            Polygon polygon = new Polygon();
            //

                foreach (var pair in jsonPolygon)
                {
                    double x = Double.Parse(pair.First.ToString());
                    double y = Double.Parse(pair.Last.ToString());

                    polygon.AddVertex(x, y);

                }


            
            return polygon;
        }
    }
}
