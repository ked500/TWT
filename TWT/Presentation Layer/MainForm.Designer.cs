
namespace TWT
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.emotionalPanelShow = new System.Windows.Forms.CheckBox();
            this.emotionalPanel = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tweetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gMapControl
            // 
            this.gMapControl.Bearing = 0F;
            this.gMapControl.CanDragMap = true;
            this.gMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl.GrayScaleMode = false;
            this.gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl.LevelsKeepInMemmory = 5;
            this.gMapControl.Location = new System.Drawing.Point(0, 1);
            this.gMapControl.Margin = new System.Windows.Forms.Padding(4);
            this.gMapControl.MarkersEnabled = true;
            this.gMapControl.MaxZoom = 2;
            this.gMapControl.MinZoom = 2;
            this.gMapControl.MouseWheelZoomEnabled = true;
            this.gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl.Name = "gMapControl";
            this.gMapControl.NegativeMode = false;
            this.gMapControl.PolygonsEnabled = true;
            this.gMapControl.RetryLoadTile = 0;
            this.gMapControl.RoutesEnabled = true;
            this.gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl.ShowTileGridLines = false;
            this.gMapControl.Size = new System.Drawing.Size(1668, 665);
            this.gMapControl.TabIndex = 1;
            this.gMapControl.Zoom = 0D;
            this.gMapControl.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gMapControl_OnMarkerClick);
            this.gMapControl.Load += new System.EventHandler(this.gMapControlLoad);
            // 
            // emotionalPanelShow
            // 
            this.emotionalPanelShow.AutoSize = true;
            this.emotionalPanelShow.Location = new System.Drawing.Point(17, 641);
            this.emotionalPanelShow.Margin = new System.Windows.Forms.Padding(4);
            this.emotionalPanelShow.Name = "emotionalPanelShow";
            this.emotionalPanelShow.Size = new System.Drawing.Size(165, 21);
            this.emotionalPanelShow.TabIndex = 2;
            this.emotionalPanelShow.Text = "Hide Emotional Panel";
            this.emotionalPanelShow.UseVisualStyleBackColor = true;
            this.emotionalPanelShow.CheckedChanged += new System.EventHandler(this.emotionalPanelShow_CheckedChanged);
            // 
            // emotionalPanel
            // 
            this.emotionalPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.emotionalPanel.Location = new System.Drawing.Point(195, 603);
            this.emotionalPanel.Margin = new System.Windows.Forms.Padding(4);
            this.emotionalPanel.Name = "emotionalPanel";
            this.emotionalPanel.Size = new System.Drawing.Size(488, 63);
            this.emotionalPanel.TabIndex = 3;
            this.emotionalPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.emotionalPanelPaint);
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1667, 36);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tweetsToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileToolStripMenuItem.Image = global::TWT.Properties.Resources.cpu_1280x720;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(80, 32);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tweetsToolStripMenuItem
            // 
            this.tweetsToolStripMenuItem.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tweetsToolStripMenuItem.Name = "tweetsToolStripMenuItem";
            this.tweetsToolStripMenuItem.Size = new System.Drawing.Size(215, 28);
            this.tweetsToolStripMenuItem.Text = "Choose tweets";
            this.tweetsToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tweetsToolStripMenuItem_DropDownItemClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1667, 667);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.emotionalPanel);
            this.Controls.Add(this.emotionalPanelShow);
            this.Controls.Add(this.gMapControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Twitter trends";
            this.Load += new System.EventHandler(this.FormLoad);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private System.Windows.Forms.CheckBox emotionalPanelShow;
        private System.Windows.Forms.Panel emotionalPanel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tweetsToolStripMenuItem;
    }
}

