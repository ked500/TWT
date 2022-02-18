using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
