
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
            this.chooseFileButton = new System.Windows.Forms.Button();
            this.chooseFileList = new System.Windows.Forms.ListView();
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.emotionalPanelShow = new System.Windows.Forms.CheckBox();
            this.emotionalPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // chooseFileButton
            // 
            this.chooseFileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chooseFileButton.Location = new System.Drawing.Point(13, 29);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(116, 33);
            this.chooseFileButton.TabIndex = 0;
            this.chooseFileButton.Text = "Choose File";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            this.chooseFileButton.Click += new System.EventHandler(this.choseFileButton_Click);
            // 
            // chooseFileList
            // 
            this.chooseFileList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chooseFileList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chooseFileList.HideSelection = false;
            this.chooseFileList.Location = new System.Drawing.Point(2, 68);
            this.chooseFileList.MultiSelect = false;
            this.chooseFileList.Name = "chooseFileList";
            this.chooseFileList.Size = new System.Drawing.Size(138, 212);
            this.chooseFileList.TabIndex = 1;
            this.chooseFileList.UseCompatibleStateImageBehavior = false;
            this.chooseFileList.View = System.Windows.Forms.View.List;
            this.chooseFileList.SelectedIndexChanged += new System.EventHandler(this.ChooseFileListChangeIndex);
            this.chooseFileList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChooseFileLIstClick);
            // 
            // gMapControl
            // 
            this.gMapControl.Bearing = 0F;
            this.gMapControl.CanDragMap = true;
            this.gMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl.GrayScaleMode = false;
            this.gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl.LevelsKeepInMemmory = 5;
            this.gMapControl.Location = new System.Drawing.Point(146, 1);
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
            this.gMapControl.Size = new System.Drawing.Size(1105, 540);
            this.gMapControl.TabIndex = 1;
            this.gMapControl.Zoom = 0D;
            this.gMapControl.Load += new System.EventHandler(this.gMapControlLoad);
            // 
            // emotionalPanelShow
            // 
            this.emotionalPanelShow.AutoSize = true;
            this.emotionalPanelShow.Location = new System.Drawing.Point(13, 521);
            this.emotionalPanelShow.Name = "emotionalPanelShow";
            this.emotionalPanelShow.Size = new System.Drawing.Size(127, 17);
            this.emotionalPanelShow.TabIndex = 2;
            this.emotionalPanelShow.Text = "Hide Emotional Panel";
            this.emotionalPanelShow.UseVisualStyleBackColor = true;
            this.emotionalPanelShow.CheckedChanged += new System.EventHandler(this.emotionalPanelShow_CheckedChanged);
            // 
            // emotionalPanel
            // 
            this.emotionalPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.emotionalPanel.Location = new System.Drawing.Point(146, 490);
            this.emotionalPanel.Name = "emotionalPanel";
            this.emotionalPanel.Size = new System.Drawing.Size(366, 51);
            this.emotionalPanel.TabIndex = 3;
            this.emotionalPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.emotionalPanelPaint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 542);
            this.Controls.Add(this.emotionalPanel);
            this.Controls.Add(this.emotionalPanelShow);
            this.Controls.Add(this.gMapControl);
            this.Controls.Add(this.chooseFileList);
            this.Controls.Add(this.chooseFileButton);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chooseFileButton;
        private System.Windows.Forms.ListView chooseFileList;
        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private System.Windows.Forms.CheckBox emotionalPanelShow;
        private System.Windows.Forms.Panel emotionalPanel;
    }
}

