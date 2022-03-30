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
    public class StateParser
    {
        public static List<State> Parse()
        {

            string jsonString = new StreamReader(FilesManager.GetStatesFullPath()).ReadToEnd();
            JObject jsonStates = JObject.Parse(jsonString);


            List<State> states = new List<State>();
            foreach (var jsonState in jsonStates)
            {

                State state = ReadState(jsonState.Value);
                state.Postcode = jsonState.Key;
                states.Add(state);
                
            }
            return states;
        }

        private static State ReadState(JToken jsonState)
        {
            State state = new State();
            if (jsonState.Children().Children().Children().Children().Any())
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
