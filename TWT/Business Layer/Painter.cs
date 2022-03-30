using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWT.Business_Layer.Models;
using TWT.Data_Layer;

namespace TWT.Business_Layer
{
    public class Painter
    {
        public List<GMapPolygon> GetPolygons()
        {
            List<GMapPolygon> polygons = new List<GMapPolygon>();
            foreach (var state in DB.GetInstance().States)
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
        public List<GMapMarker> GetTweets()
        {

            List<GMapMarker> tweets = new List<GMapMarker>();
            foreach (var state in DB.GetInstance().States)
            {
                
                foreach (var tweet in state.Tweets)
                {

                    if (DB.GetInstance().IsUnknown(tweet))
                        continue;

                    string emotionality = string.Empty;
                    if (double.IsNaN(tweet.Emotionality))
                        emotionality = "Cannot set";
                    else
                        emotionality = tweet.Emotionality.ToString();

                    Bitmap tweetPoint = new Bitmap(20, 20);

                    using (Graphics g = Graphics.FromImage(tweetPoint))
                    {
                        Pen pen = new Pen(Color.Black, 2f);
                        g.DrawEllipse(pen, 0, 0, 7f, 7f);
                        //g.DrawString(tweet.Emotionality.ToString(),new Font("Tahoma", 10, FontStyle.Regular) , new SolidBrush(Color.Black), 0,0);
                        g.FillEllipse(new SolidBrush(Coloring.SetColors(tweet.Emotionality)), 0, 0, 7f, 7f);
                    }
                    Coordinates c = tweet.Coordinates;
                    PointLatLng point = new PointLatLng(tweet.Coordinates.Longtitude, tweet.Coordinates.Latitude);
                    GMapMarker GPoint = new GMarkerGoogle(point, tweetPoint);
                    GPoint.ToolTip = new GMapRoundedToolTip(GPoint);
                    
                    GPoint.ToolTipText = $"Message: {tweet.Message}\nDate: {tweet.DateTime}\nEmotionality: {emotionality}";
                    GPoint.ToolTipMode = MarkerTooltipMode.Never;
                    tweets.Add(GPoint);

                }
            }
            return tweets;
        }



    }
}
