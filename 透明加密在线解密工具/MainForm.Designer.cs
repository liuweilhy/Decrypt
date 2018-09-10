namespace MainFormNamespace
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.radioButtonDecryptFiles = new System.Windows.Forms.RadioButton();
            this.groupBoxSource = new System.Windows.Forms.GroupBox();
            this.checkBoxIncludeChildren = new System.Windows.Forms.CheckBox();
            this.buttonOpenFolder = new System.Windows.Forms.Button();
            this.buttonOpenFiles = new System.Windows.Forms.Button();
            this.textBoxSourceFolder = new System.Windows.Forms.TextBox();
            this.textBoxSourceFiles = new System.Windows.Forms.TextBox();
            this.radioButtonDecryptFolder = new System.Windows.Forms.RadioButton();
            this.groupBoxDestination = new System.Windows.Forms.GroupBox();
            this.buttonSaveDestination = new System.Windows.Forms.Button();
            this.textBoxDestinationFolder = new System.Windows.Forms.TextBox();
            this.checkBoxMakeBakeup = new System.Windows.Forms.CheckBox();
            this.radioButtonSaveNewPosition = new System.Windows.Forms.RadioButton();
            this.radioButtonSaveOriginal = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.linkLabelDisclaimer = new System.Windows.Forms.LinkLabel();
            this.linkLabelAbout = new System.Windows.Forms.LinkLabel();
            this.textProgressBar1 = new SimpleWindowsFormsControlLibrary.TextProgressBar();
            this.groupBoxSource.SuspendLayout();
            this.groupBoxDestination.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonDecryptFiles
            // 
            this.radioButtonDecryptFiles.AutoSize = true;
            this.radioButtonDecryptFiles.Checked = true;
            this.radioButtonDecryptFiles.Location = new System.Drawing.Point(18, 30);
            this.radioButtonDecryptFiles.Name = "radioButtonDecryptFiles";
            this.radioButtonDecryptFiles.Size = new System.Drawing.Size(88, 19);
            this.radioButtonDecryptFiles.TabIndex = 0;
            this.radioButtonDecryptFiles.TabStop = true;
            this.radioButtonDecryptFiles.Text = "解密文件";
            this.radioButtonDecryptFiles.UseVisualStyleBackColor = true;
            this.radioButtonDecryptFiles.CheckedChanged += new System.EventHandler(this.radioButtonDecryptFiles_CheckedChanged);
            // 
            // groupBoxSource
            // 
            this.groupBoxSource.Controls.Add(this.checkBoxIncludeChildren);
            this.groupBoxSource.Controls.Add(this.buttonOpenFolder);
            this.groupBoxSource.Controls.Add(this.buttonOpenFiles);
            this.groupBoxSource.Controls.Add(this.textBoxSourceFolder);
            this.groupBoxSource.Controls.Add(this.textBoxSourceFiles);
            this.groupBoxSource.Controls.Add(this.radioButtonDecryptFolder);
            this.groupBoxSource.Controls.Add(this.radioButtonDecryptFiles);
            this.groupBoxSource.Location = new System.Drawing.Point(15, 38);
            this.groupBoxSource.Name = "groupBoxSource";
            this.groupBoxSource.Size = new System.Drawing.Size(471, 121);
            this.groupBoxSource.TabIndex = 1;
            this.groupBoxSource.TabStop = false;
            this.groupBoxSource.Text = "源文件";
            // 
            // checkBoxIncludeChildren
            // 
            this.checkBoxIncludeChildren.AutoSize = true;
            this.checkBoxIncludeChildren.Checked = true;
            this.checkBoxIncludeChildren.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIncludeChildren.Enabled = false;
            this.checkBoxIncludeChildren.Location = new System.Drawing.Point(124, 94);
            this.checkBoxIncludeChildren.Name = "checkBoxIncludeChildren";
            this.checkBoxIncludeChildren.Size = new System.Drawing.Size(119, 19);
            this.checkBoxIncludeChildren.TabIndex = 6;
            this.checkBoxIncludeChildren.Text = "包含子文件夹";
            this.checkBoxIncludeChildren.UseVisualStyleBackColor = true;
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.Enabled = false;
            this.buttonOpenFolder.Location = new System.Drawing.Point(426, 63);
            this.buttonOpenFolder.Name = "buttonOpenFolder";
            this.buttonOpenFolder.Size = new System.Drawing.Size(39, 25);
            this.buttonOpenFolder.TabIndex = 5;
            this.buttonOpenFolder.Text = "...";
            this.buttonOpenFolder.UseVisualStyleBackColor = true;
            this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
            // 
            // buttonOpenFiles
            // 
            this.buttonOpenFiles.Location = new System.Drawing.Point(426, 24);
            this.buttonOpenFiles.Name = "buttonOpenFiles";
            this.buttonOpenFiles.Size = new System.Drawing.Size(39, 25);
            this.buttonOpenFiles.TabIndex = 2;
            this.buttonOpenFiles.Text = "...";
            this.buttonOpenFiles.UseVisualStyleBackColor = true;
            this.buttonOpenFiles.Click += new System.EventHandler(this.buttonOpenFiles_Click);
            // 
            // textBoxSourceFolder
            // 
            this.textBoxSourceFolder.AllowDrop = true;
            this.textBoxSourceFolder.CausesValidation = false;
            this.textBoxSourceFolder.Enabled = false;
            this.textBoxSourceFolder.Location = new System.Drawing.Point(124, 63);
            this.textBoxSourceFolder.Name = "textBoxSourceFolder";
            this.textBoxSourceFolder.Size = new System.Drawing.Size(296, 25);
            this.textBoxSourceFolder.TabIndex = 4;
            this.textBoxSourceFolder.TextChanged += new System.EventHandler(this.textBoxSourceFiles_TextChanged);
            this.textBoxSourceFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxSourceFolder_DragDrop);
            this.textBoxSourceFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxSourceFiles_DragEnter);
            // 
            // textBoxSourceFiles
            // 
            this.textBoxSourceFiles.AllowDrop = true;
            this.textBoxSourceFiles.CausesValidation = false;
            this.textBoxSourceFiles.Location = new System.Drawing.Point(124, 24);
            this.textBoxSourceFiles.Name = "textBoxSourceFiles";
            this.textBoxSourceFiles.Size = new System.Drawing.Size(296, 25);
            this.textBoxSourceFiles.TabIndex = 1;
            this.textBoxSourceFiles.TextChanged += new System.EventHandler(this.textBoxSourceFiles_TextChanged);
            this.textBoxSourceFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxSourceFiles_DragDrop);
            this.textBoxSourceFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxSourceFiles_DragEnter);
            // 
            // radioButtonDecryptFolder
            // 
            this.radioButtonDecryptFolder.AutoSize = true;
            this.radioButtonDecryptFolder.Location = new System.Drawing.Point(18, 63);
            this.radioButtonDecryptFolder.Name = "radioButtonDecryptFolder";
            this.radioButtonDecryptFolder.Size = new System.Drawing.Size(103, 19);
            this.radioButtonDecryptFolder.TabIndex = 3;
            this.radioButtonDecryptFolder.Text = "解密文件夹";
            this.radioButtonDecryptFolder.UseVisualStyleBackColor = true;
            this.radioButtonDecryptFolder.CheckedChanged += new System.EventHandler(this.radioButtonDecryptFiles_CheckedChanged);
            // 
            // groupBoxDestination
            // 
            this.groupBoxDestination.Controls.Add(this.buttonSaveDestination);
            this.groupBoxDestination.Controls.Add(this.textBoxDestinationFolder);
            this.groupBoxDestination.Controls.Add(this.checkBoxMakeBakeup);
            this.groupBoxDestination.Controls.Add(this.radioButtonSaveNewPosition);
            this.groupBoxDestination.Controls.Add(this.radioButtonSaveOriginal);
            this.groupBoxDestination.Location = new System.Drawing.Point(15, 172);
            this.groupBoxDestination.Name = "groupBoxDestination";
            this.groupBoxDestination.Size = new System.Drawing.Size(471, 90);
            this.groupBoxDestination.TabIndex = 2;
            this.groupBoxDestination.TabStop = false;
            this.groupBoxDestination.Text = "目标文件";
            // 
            // buttonSaveDestination
            // 
            this.buttonSaveDestination.Enabled = false;
            this.buttonSaveDestination.Location = new System.Drawing.Point(426, 48);
            this.buttonSaveDestination.Name = "buttonSaveDestination";
            this.buttonSaveDestination.Size = new System.Drawing.Size(39, 25);
            this.buttonSaveDestination.TabIndex = 4;
            this.buttonSaveDestination.Text = "...";
            this.buttonSaveDestination.UseVisualStyleBackColor = true;
            this.buttonSaveDestination.Click += new System.EventHandler(this.buttonSaveDestination_Click);
            // 
            // textBoxDestinationFolder
            // 
            this.textBoxDestinationFolder.AllowDrop = true;
            this.textBoxDestinationFolder.CausesValidation = false;
            this.textBoxDestinationFolder.Enabled = false;
            this.textBoxDestinationFolder.Location = new System.Drawing.Point(157, 48);
            this.textBoxDestinationFolder.Name = "textBoxDestinationFolder";
            this.textBoxDestinationFolder.Size = new System.Drawing.Size(263, 25);
            this.textBoxDestinationFolder.TabIndex = 3;
            this.textBoxDestinationFolder.TextChanged += new System.EventHandler(this.textBoxSourceFiles_TextChanged);
            this.textBoxDestinationFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxSourceFolder_DragDrop);
            this.textBoxDestinationFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxSourceFiles_DragEnter);
            // 
            // checkBoxMakeBakeup
            // 
            this.checkBoxMakeBakeup.AutoSize = true;
            this.checkBoxMakeBakeup.Checked = true;
            this.checkBoxMakeBakeup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMakeBakeup.Location = new System.Drawing.Point(157, 23);
            this.checkBoxMakeBakeup.Name = "checkBoxMakeBakeup";
            this.checkBoxMakeBakeup.Size = new System.Drawing.Size(152, 19);
            this.checkBoxMakeBakeup.TabIndex = 1;
            this.checkBoxMakeBakeup.Text = "备份源文件(.bak)";
            this.checkBoxMakeBakeup.UseVisualStyleBackColor = true;
            // 
            // radioButtonSaveNewPosition
            // 
            this.radioButtonSaveNewPosition.AutoSize = true;
            this.radioButtonSaveNewPosition.Location = new System.Drawing.Point(18, 54);
            this.radioButtonSaveNewPosition.Name = "radioButtonSaveNewPosition";
            this.radioButtonSaveNewPosition.Size = new System.Drawing.Size(133, 19);
            this.radioButtonSaveNewPosition.TabIndex = 2;
            this.radioButtonSaveNewPosition.Text = "保存到指定位置";
            this.radioButtonSaveNewPosition.UseVisualStyleBackColor = true;
            this.radioButtonSaveNewPosition.CheckedChanged += new System.EventHandler(this.radioButtonSaveOriginal_CheckedChanged);
            // 
            // radioButtonSaveOriginal
            // 
            this.radioButtonSaveOriginal.AutoSize = true;
            this.radioButtonSaveOriginal.Checked = true;
            this.radioButtonSaveOriginal.Location = new System.Drawing.Point(18, 23);
            this.radioButtonSaveOriginal.Name = "radioButtonSaveOriginal";
            this.radioButtonSaveOriginal.Size = new System.Drawing.Size(118, 19);
            this.radioButtonSaveOriginal.TabIndex = 0;
            this.radioButtonSaveOriginal.TabStop = true;
            this.radioButtonSaveOriginal.Text = "保存在原位置";
            this.radioButtonSaveOriginal.UseVisualStyleBackColor = true;
            this.radioButtonSaveOriginal.CheckedChanged += new System.EventHandler(this.radioButtonSaveOriginal_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(413, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "本程序不验证生成文件的正确性,请确保您有打开密文的权限!";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(381, 268);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(105, 29);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "保存明文(&S)";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // linkLabelDisclaimer
            // 
            this.linkLabelDisclaimer.Location = new System.Drawing.Point(43, 308);
            this.linkLabelDisclaimer.Name = "linkLabelDisclaimer";
            this.linkLabelDisclaimer.Size = new System.Drawing.Size(67, 19);
            this.linkLabelDisclaimer.TabIndex = 6;
            this.linkLabelDisclaimer.TabStop = true;
            this.linkLabelDisclaimer.Text = "免责声明";
            this.linkLabelDisclaimer.Click += new System.EventHandler(this.linkLabelDisclaimer_Click);
            // 
            // linkLabelAbout
            // 
            this.linkLabelAbout.Location = new System.Drawing.Point(353, 308);
            this.linkLabelAbout.Name = "linkLabelAbout";
            this.linkLabelAbout.Size = new System.Drawing.Size(82, 19);
            this.linkLabelAbout.TabIndex = 7;
            this.linkLabelAbout.TabStop = true;
            this.linkLabelAbout.Text = "关于本程序...";
            this.linkLabelAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAbout_LinkClicked);
            // 
            // textProgressBar1
            // 
            this.textProgressBar1.Location = new System.Drawing.Point(18, 268);
            this.textProgressBar1.Name = "textProgressBar1";
            this.textProgressBar1.Size = new System.Drawing.Size(355, 28);
            this.textProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.textProgressBar1.TabIndex = 8;
            this.textProgressBar1.TextColor = System.Drawing.Color.Black;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 333);
            this.Controls.Add(this.textProgressBar1);
            this.Controls.Add(this.linkLabelAbout);
            this.Controls.Add(this.linkLabelDisclaimer);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxDestination);
            this.Controls.Add(this.groupBoxSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Decrypt Online Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.groupBoxSource.ResumeLayout(false);
            this.groupBoxSource.PerformLayout();
            this.groupBoxDestination.ResumeLayout(false);
            this.groupBoxDestination.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonDecryptFiles;
        private System.Windows.Forms.GroupBox groupBoxSource;
        private System.Windows.Forms.Button buttonOpenFolder;
        private System.Windows.Forms.Button buttonOpenFiles;
        private System.Windows.Forms.TextBox textBoxSourceFolder;
        private System.Windows.Forms.TextBox textBoxSourceFiles;
        private System.Windows.Forms.RadioButton radioButtonDecryptFolder;
        private System.Windows.Forms.GroupBox groupBoxDestination;
        private System.Windows.Forms.Button buttonSaveDestination;
        private System.Windows.Forms.TextBox textBoxDestinationFolder;
        private System.Windows.Forms.CheckBox checkBoxMakeBakeup;
        private System.Windows.Forms.RadioButton radioButtonSaveNewPosition;
        private System.Windows.Forms.RadioButton radioButtonSaveOriginal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.LinkLabel linkLabelDisclaimer;
        private System.Windows.Forms.LinkLabel linkLabelAbout;
        private System.Windows.Forms.CheckBox checkBoxIncludeChildren;
        private SimpleWindowsFormsControlLibrary.TextProgressBar textProgressBar1;

    }
}

