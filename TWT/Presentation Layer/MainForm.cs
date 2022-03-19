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
                chooseFileList.Items.Add(Path.GetFileName(x)));
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

        //GMap
        private void FormLoad(object sender, EventArgs e)
        {
            gMapControl.ShowCenter = false;
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
            g.DrawString("Емоциональный вес", new Font("HelvLight", 10), Brushes.White, (emotionalPanel.Width + 36) / 4, 0);
            for(int i = 0; i < grids; i++)
            {
                rect[i] = new Rectangle(widthofRec * i, 30, widthofRec, 20);
                brush[i] = new LinearGradientBrush(rect[i], 
                    Coloring.SetColors(currentValue + 0.0001f),
                    Coloring.SetColors(currentValue + step - 0.0001f), 0f);
                currentValue += step;
                g.FillRectangle(brush[i], rect[i]);
                g.DrawRectangle(pen, rect[i]);
                g.DrawString(Convert.ToString(currentValue - step), new Font("Arial", 8), Brushes.White, (widthofRec - 2) * i, 18);
            }
            //String for last grid
            g.DrawString(Convert.ToString(currentValue) + "+", new Font("Arial", 8), Brushes.White, (widthofRec - 3) * grids, 18);
        }

        private void emotionalPanelShow_CheckedChanged(object sender, EventArgs e)
        {
            //Hiding Emotional Panel
            if(emotionalPanel.Visible)
              emotionalPanel.Visible = false;
            else
              emotionalPanel.Visible = true;
        }
    }
}
