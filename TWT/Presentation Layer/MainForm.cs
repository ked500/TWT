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
using TWT.Data_Layer;

namespace TWT
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            chooseFileList.Visible = false;
        }

        //Choose File Button
        private void choseFileButton_Click(object sender, EventArgs e)
        {
            if (!chooseFileList.Visible)
            {
                chooseFileList.Visible = true;
                chooseFileList.Items.Clear();
                Directory.GetFiles(@"..\..\Data Layer\Data Files", "*.txt").ToList().ForEach(x =>
                chooseFileList.Items.Add(Path.GetFileNameWithoutExtension(x)));
            }
            else
            {
                chooseFileList.Visible = false;
                return;
            }
        }

        //File List
        private void ChooseFileLIstClick(object sender, MouseEventArgs e)
        {
            string path = chooseFileList.SelectedItems[0].Text.ToString() + ".txt";
        }

        private void ChooseFileListChangeIndex(object sender, EventArgs e)
        {

        }

        //Emotional Panel
        private void emotionalPanelPaint(object sender, PaintEventArgs e)
        {
            DrawPanel();
        }

        private void TestForStrings(string path)
        {
            //Delete in release
            Graphics g = emotionalPanel.CreateGraphics();
            g.Clear(Color.Green);
            g.DrawString(path, new Font("HelvLight", 10), Brushes.White, (emotionalPanel.Width + 36) / 4, 0);
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
            if (emotionalPanel.Visible)
                emotionalPanel.Visible = false;
            else
                emotionalPanel.Visible = true;
        }

        //GMap
        private void FormLoad(object sender, EventArgs e)
        {
            gMapControl.ShowCenter = false;
        }

        private void gMapControlLoad(object sender, EventArgs e)
        {
            gMapControl.MapProvider = YandexMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMapControl.Position = new PointLatLng(40.280177245114054, -97.83735244087555);
            gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.ViewCenter;
            gMapControl.MinZoom = 2;
            gMapControl.MaxZoom = 18;
            gMapControl.Zoom = 3;
            gMapControl.CanDragMap = true;
            gMapControl.DragButton = MouseButtons.Left;
            LoadMap();
        }

        private void LoadMap()
        {
            Graphics g = gMapControl.CreateGraphics();
            GMapOverlay polygonOverlay = new GMapOverlay("polygonOverlay");
            gMapControl.PolygonsEnabled = true;
            List<GMapPolygon> polygons = DB.GetPolygons(JsonParser.ParseStates());
            foreach (var polygon in polygons)
            {            
                polygonOverlay.Polygons.Add(polygon);
            }
            gMapControl.Overlays.Add(polygonOverlay);
        }

        private void paintMap()
        {
           
        }

        private void RefreshMap()
        {
            double curZoom = gMapControl.Zoom;
            gMapControl.Zoom += 0.001;
            gMapControl.Zoom -= 0.001;
        }
    }
}

