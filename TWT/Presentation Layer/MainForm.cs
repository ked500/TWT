using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.ToolTips;
using GMap.NET.WindowsForms.Markers;

using TWT.Data_Layer.Parsers;
using TWT.Business_Layer.Models;
using TWT.Business_Layer;
using TWT.Data_Layer;

namespace TWT
{
    public partial class MainForm : Form
    {

        //OVERLAYS
        private GMapOverlay stateOverlay = new GMapOverlay("stateOverlay");



        private Painter painter = new Painter();
        private string currentTweetFileName = string.Empty;
        public MainForm()
        {
            InitializeComponent();
        }
        private void FormLoad(object sender, EventArgs e)
        {
            gMapControl.ShowCenter = false;
            foreach (var item in FilesManager.GetTweetFiles())
            {
                tweetsToolStripMenuItem.DropDownItems.Add(item);
            }


        }

        //Emotional Panel
        private void emotionalPanelPaint(object sender, PaintEventArgs e)
        {
            DrawPanel();
        }

        private void DrawPanel()
        {
            //Pen
            
            Pen pen = new Pen(Color.Black, 0.002f);
            //Amount of grids
            int grids = 6;
            int widthofRec = (emotionalPanel.Width - 1) / grids;

            Graphics g = emotionalPanel.CreateGraphics();
            Rectangle[] rect = new Rectangle[grids];
            Brush[] brush = new LinearGradientBrush[grids];
            float min = -1.5f, step = 0.5f;
            float currentValue = min;
            //String Above panel
            g.DrawString("Эмоциональный вес", new Font("HelvLight", 10), Brushes.Black, (emotionalPanel.Width + 36) / 4, 0);
            for (int i = 0; i < grids; i++)
            {
                rect[i] = new Rectangle(widthofRec * i, 30, widthofRec, 20);
                brush[i] = new LinearGradientBrush(rect[i],
                Coloring.SetColors(currentValue + 0.0001f),
                Coloring.SetColors(currentValue + step - 0.0001f), 0f);
                currentValue += step;
                g.FillRectangle(brush[i], rect[i]);
                g.DrawRectangle(pen, rect[i]);
                g.DrawString(Convert.ToString(currentValue - step), new Font("Arial", 8), Brushes.Black, (widthofRec - 2) * i, 18);
            }
            //String for last grid
            g.DrawString(Convert.ToString(currentValue) + "+", new Font("Arial", 8), Brushes.Black, (widthofRec - 3) * grids, 18);
        }

        private void emotionalPanelShow_CheckedChanged(object sender, EventArgs e)
        {
            //Hiding Emotional Panel
            emotionalPanel.Visible = !emotionalPanel.Visible;
        }

        //GMap
       

        private void gMapControlLoad(object sender, EventArgs e)
        {
            //gMapControl.MapProvider = YandexMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMapControl.Position = new PointLatLng(40.280177245114054, -97.83735244087555);
            gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.ViewCenter;
            gMapControl.MinZoom = 3;
            gMapControl.MaxZoom = 18;
            gMapControl.PolygonsEnabled = true;
            gMapControl.Zoom = 3;
            gMapControl.CanDragMap = true;
            gMapControl.DragButton = MouseButtons.Left;
            gMapControl.Overlays.Add(stateOverlay);

        }


        

        private void LoadMap()
        {
            this.stateOverlay.Polygons.Clear();
            this.stateOverlay.Markers.Clear();

            foreach (var polygon in painter.GetPolygons())
            {
                stateOverlay.Polygons.Add(polygon);
            }
            foreach (var tweet in painter.GetTweets())
            {
                stateOverlay.Markers.Add(tweet);
            }

            RefreshMap();
           
        }


        private void RefreshMap()
        {
            double curZoom = gMapControl.Zoom;
            gMapControl.Zoom += 0.001;
            gMapControl.Zoom -= 0.001;
        }



        private void gMapControl_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            toolTip.SetToolTip(gMapControl, item.ToolTipText);
        }

        private void tweetsToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.currentTweetFileName = e.ClickedItem.Text;
            DB.GetInstance().Update(this.currentTweetFileName);
            LoadMap();
        }
    }
}

