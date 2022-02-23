
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
            this.chooseFileList.Location = new System.Drawing.Point(135, 29);
            this.chooseFileList.MultiSelect = false;
            this.chooseFileList.Name = "chooseFileList";
            this.chooseFileList.Size = new System.Drawing.Size(159, 212);
            this.chooseFileList.TabIndex = 1;
            this.chooseFileList.UseCompatibleStateImageBehavior = false;
            this.chooseFileList.View = System.Windows.Forms.View.List;
            this.chooseFileList.SelectedIndexChanged += new System.EventHandler(this.ChooseFileListChangeIndex);
            this.chooseFileList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChooseFileLIstClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chooseFileList);
            this.Controls.Add(this.chooseFileButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button chooseFileButton;
        private System.Windows.Forms.ListView chooseFileList;
    }
}

