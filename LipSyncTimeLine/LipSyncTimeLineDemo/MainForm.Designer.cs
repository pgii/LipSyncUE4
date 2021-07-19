using LipSyncTimeLineControl.Controls;

namespace LipSyncTimeLineDemo
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("1", "AI");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("2", "AI");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("3", "AI");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("4", "AI");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.expressionListBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.phonemeListView = new System.Windows.Forms.ListView();
            this.imageListPhoneme = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudTrackLength = new System.Windows.Forms.NumericUpDown();
            this.rtbPhraseText = new System.Windows.Forms.RichTextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnAddWordsTrack = new System.Windows.Forms.ToolStripButton();
            this.btnGeneratePhoneme = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddSubtitleTrack = new System.Windows.Forms.ToolStripButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.chbPlayingLoop = new System.Windows.Forms.CheckBox();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNewProject = new System.Windows.Forms.ToolStripButton();
            this.btnOpenProject = new System.Windows.Forms.ToolStripButton();
            this.btnSaveProject = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tbUdpPort = new System.Windows.Forms.ToolStripTextBox();
            this.btnConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPhonemeImage = new System.Windows.Forms.ToolStripButton();
            this.cbDevicesPlayer = new System.Windows.Forms.ToolStripComboBox();
            this.chbOnTop = new System.Windows.Forms.ToolStripButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeline = new LipSyncTimeLineControl.Controls.Timeline();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTrackLength)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(817, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 425);
            this.panel1.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.expressionListBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 250);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 175);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Expression";
            // 
            // expressionListBox
            // 
            this.expressionListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expressionListBox.FormattingEnabled = true;
            this.expressionListBox.Location = new System.Drawing.Point(3, 16);
            this.expressionListBox.Name = "expressionListBox";
            this.expressionListBox.Size = new System.Drawing.Size(225, 156);
            this.expressionListBox.TabIndex = 0;
            this.expressionListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.expressionListBox_MouseDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.phonemeListView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 205);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phoneme";
            // 
            // phonemeListView
            // 
            this.phonemeListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.phonemeListView.AutoArrange = false;
            this.phonemeListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.phonemeListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.phonemeListView.HideSelection = false;
            this.phonemeListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.phonemeListView.LargeImageList = this.imageListPhoneme;
            this.phonemeListView.Location = new System.Drawing.Point(3, 16);
            this.phonemeListView.Margin = new System.Windows.Forms.Padding(0);
            this.phonemeListView.MultiSelect = false;
            this.phonemeListView.Name = "phonemeListView";
            this.phonemeListView.ShowGroups = false;
            this.phonemeListView.Size = new System.Drawing.Size(225, 186);
            this.phonemeListView.SmallImageList = this.imageListPhoneme;
            this.phonemeListView.TabIndex = 21;
            this.phonemeListView.UseCompatibleStateImageBehavior = false;
            this.phonemeListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.phonemeListView_MouseDown);
            // 
            // imageListPhoneme
            // 
            this.imageListPhoneme.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListPhoneme.ImageStream")));
            this.imageListPhoneme.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListPhoneme.Images.SetKeyName(0, "AI");
            this.imageListPhoneme.Images.SetKeyName(1, "O");
            this.imageListPhoneme.Images.SetKeyName(2, "TH");
            this.imageListPhoneme.Images.SetKeyName(3, "E");
            this.imageListPhoneme.Images.SetKeyName(4, "FV");
            this.imageListPhoneme.Images.SetKeyName(5, "L");
            this.imageListPhoneme.Images.SetKeyName(6, "None");
            this.imageListPhoneme.Images.SetKeyName(7, "MBP");
            this.imageListPhoneme.Images.SetKeyName(8, "U");
            this.imageListPhoneme.Images.SetKeyName(9, "WQ");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudTrackLength);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(231, 45);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Track length (Milliseconds)";
            // 
            // nudTrackLength
            // 
            this.nudTrackLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudTrackLength.Location = new System.Drawing.Point(3, 16);
            this.nudTrackLength.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudTrackLength.Name = "nudTrackLength";
            this.nudTrackLength.Size = new System.Drawing.Size(225, 20);
            this.nudTrackLength.TabIndex = 0;
            this.nudTrackLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudTrackLength.ValueChanged += new System.EventHandler(this.nudTrackLength_ValueChanged);
            // 
            // rtbPhraseText
            // 
            this.rtbPhraseText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbPhraseText.Location = new System.Drawing.Point(0, 401);
            this.rtbPhraseText.Margin = new System.Windows.Forms.Padding(2);
            this.rtbPhraseText.Name = "rtbPhraseText";
            this.rtbPhraseText.Size = new System.Drawing.Size(817, 81);
            this.rtbPhraseText.TabIndex = 9;
            this.rtbPhraseText.Text = "Hi. My name is Victoria. This is a lip sync demo for Unreal Engine.";
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddWordsTrack,
            this.btnGeneratePhoneme,
            this.toolStripSeparator3,
            this.btnAddSubtitleTrack});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(817, 52);
            this.toolStrip2.TabIndex = 20;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnAddWordsTrack
            // 
            this.btnAddWordsTrack.AutoSize = false;
            this.btnAddWordsTrack.Image = ((System.Drawing.Image)(resources.GetObject("btnAddWordsTrack.Image")));
            this.btnAddWordsTrack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddWordsTrack.Name = "btnAddWordsTrack";
            this.btnAddWordsTrack.Size = new System.Drawing.Size(60, 40);
            this.btnAddWordsTrack.Text = "Words";
            this.btnAddWordsTrack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddWordsTrack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddWordsTrack.Click += new System.EventHandler(this.btnAddWordsTrack_Click);
            // 
            // btnGeneratePhoneme
            // 
            this.btnGeneratePhoneme.AutoSize = false;
            this.btnGeneratePhoneme.Image = ((System.Drawing.Image)(resources.GetObject("btnGeneratePhoneme.Image")));
            this.btnGeneratePhoneme.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGeneratePhoneme.Name = "btnGeneratePhoneme";
            this.btnGeneratePhoneme.Size = new System.Drawing.Size(60, 40);
            this.btnGeneratePhoneme.Text = "Phoneme";
            this.btnGeneratePhoneme.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGeneratePhoneme.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGeneratePhoneme.Click += new System.EventHandler(this.btnGeneratePhoneme_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 52);
            // 
            // btnAddSubtitleTrack
            // 
            this.btnAddSubtitleTrack.AutoSize = false;
            this.btnAddSubtitleTrack.Image = ((System.Drawing.Image)(resources.GetObject("btnAddSubtitleTrack.Image")));
            this.btnAddSubtitleTrack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddSubtitleTrack.Name = "btnAddSubtitleTrack";
            this.btnAddSubtitleTrack.Size = new System.Drawing.Size(60, 40);
            this.btnAddSubtitleTrack.Text = "Subtitle";
            this.btnAddSubtitleTrack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddSubtitleTrack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddSubtitleTrack.Click += new System.EventHandler(this.btnAddSubtitleTrack_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 311);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(817, 38);
            this.panel3.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnStart, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPlay, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.chbPlayingLoop, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEnd, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPause, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(817, 38);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.BackgroundImage = global::LipSyncTimeLineDemo.Properties.Resources.step_backward;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.Location = new System.Drawing.Point(316, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(32, 32);
            this.btnStart.TabIndex = 14;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.Transparent;
            this.btnPlay.BackgroundImage = global::LipSyncTimeLineDemo.Properties.Resources.play_circle;
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlay.Location = new System.Drawing.Point(354, 3);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(32, 32);
            this.btnPlay.TabIndex = 13;
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // chbPlayingLoop
            // 
            this.chbPlayingLoop.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbPlayingLoop.BackColor = System.Drawing.Color.Transparent;
            this.chbPlayingLoop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chbPlayingLoop.BackgroundImage")));
            this.chbPlayingLoop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chbPlayingLoop.Location = new System.Drawing.Point(468, 3);
            this.chbPlayingLoop.Name = "chbPlayingLoop";
            this.chbPlayingLoop.Size = new System.Drawing.Size(32, 32);
            this.chbPlayingLoop.TabIndex = 16;
            this.chbPlayingLoop.UseVisualStyleBackColor = false;
            this.chbPlayingLoop.CheckedChanged += new System.EventHandler(this.chbPlayingLoop_CheckedChanged);
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.Color.Transparent;
            this.btnEnd.BackgroundImage = global::LipSyncTimeLineDemo.Properties.Resources.step_forward;
            this.btnEnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEnd.Location = new System.Drawing.Point(430, 3);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(32, 32);
            this.btnEnd.TabIndex = 0;
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.Transparent;
            this.btnPause.BackgroundImage = global::LipSyncTimeLineDemo.Properties.Resources.pause_symbol;
            this.btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPause.Location = new System.Drawing.Point(392, 3);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(32, 32);
            this.btnPause.TabIndex = 17;
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewProject,
            this.btnOpenProject,
            this.btnSaveProject,
            this.toolStripSeparator4,
            this.btnExport,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tbUdpPort,
            this.btnConnect,
            this.toolStripSeparator2,
            this.btnPhonemeImage,
            this.cbDevicesPlayer,
            this.chbOnTop});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1048, 57);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNewProject
            // 
            this.btnNewProject.AutoSize = false;
            this.btnNewProject.Image = ((System.Drawing.Image)(resources.GetObject("btnNewProject.Image")));
            this.btnNewProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewProject.Name = "btnNewProject";
            this.btnNewProject.Size = new System.Drawing.Size(60, 57);
            this.btnNewProject.Text = "New";
            this.btnNewProject.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNewProject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNewProject.Click += new System.EventHandler(this.btnNewProject_Click);
            // 
            // btnOpenProject
            // 
            this.btnOpenProject.AutoSize = false;
            this.btnOpenProject.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenProject.Image")));
            this.btnOpenProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenProject.Name = "btnOpenProject";
            this.btnOpenProject.Size = new System.Drawing.Size(60, 57);
            this.btnOpenProject.Text = "Open";
            this.btnOpenProject.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOpenProject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOpenProject.Click += new System.EventHandler(this.btnOpenProject_Click);
            // 
            // btnSaveProject
            // 
            this.btnSaveProject.AutoSize = false;
            this.btnSaveProject.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveProject.Image")));
            this.btnSaveProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveProject.Name = "btnSaveProject";
            this.btnSaveProject.Size = new System.Drawing.Size(60, 57);
            this.btnSaveProject.Text = "Save";
            this.btnSaveProject.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveProject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveProject.Click += new System.EventHandler(this.btnSaveProject_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 57);
            // 
            // btnExport
            // 
            this.btnExport.AutoSize = false;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(60, 57);
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 57);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(32, 54);
            this.toolStripLabel1.Text = "Port:";
            // 
            // tbUdpPort
            // 
            this.tbUdpPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbUdpPort.Margin = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.tbUdpPort.Name = "tbUdpPort";
            this.tbUdpPort.Size = new System.Drawing.Size(50, 57);
            this.tbUdpPort.Text = "5678";
            this.tbUdpPort.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnConnect
            // 
            this.btnConnect.AutoSize = false;
            this.btnConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.Image")));
            this.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(60, 57);
            this.btnConnect.Text = "Connect";
            this.btnConnect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConnect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 57);
            // 
            // btnPhonemeImage
            // 
            this.btnPhonemeImage.AutoSize = false;
            this.btnPhonemeImage.BackColor = System.Drawing.Color.Transparent;
            this.btnPhonemeImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPhonemeImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPhonemeImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPhonemeImage.Name = "btnPhonemeImage";
            this.btnPhonemeImage.Size = new System.Drawing.Size(57, 57);
            this.btnPhonemeImage.Text = "toolStripButton1";
            // 
            // cbDevicesPlayer
            // 
            this.cbDevicesPlayer.Enabled = false;
            this.cbDevicesPlayer.Name = "cbDevicesPlayer";
            this.cbDevicesPlayer.Size = new System.Drawing.Size(300, 57);
            this.cbDevicesPlayer.SelectedIndexChanged += new System.EventHandler(this.cbDevicesPlayer_SelectedIndexChanged);
            // 
            // chbOnTop
            // 
            this.chbOnTop.AutoSize = false;
            this.chbOnTop.Image = ((System.Drawing.Image)(resources.GetObject("chbOnTop.Image")));
            this.chbOnTop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chbOnTop.Name = "chbOnTop";
            this.chbOnTop.Size = new System.Drawing.Size(60, 57);
            this.chbOnTop.Text = "On Top";
            this.chbOnTop.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chbOnTop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.chbOnTop.Click += new System.EventHandler(this.chbOnTop_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.toolStrip2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 349);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(817, 52);
            this.panel4.TabIndex = 20;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 460);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(817, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(49, 17);
            this.toolStripStatusLabel1.Text = "00:00:00";
            // 
            // timeline
            // 
            this.timeline.AllowDrop = true;
            this.timeline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.timeline.BackgroundColor = System.Drawing.Color.Black;
            this.timeline.Dock = System.Windows.Forms.DockStyle.Top;
            this.timeline.GridAlpha = 40;
            this.timeline.Location = new System.Drawing.Point(0, 57);
            this.timeline.Name = "timeline";
            this.timeline.PlayingLoop = false;
            this.timeline.Size = new System.Drawing.Size(817, 254);
            this.timeline.TabIndex = 0;
            this.timeline.TrackBorderSize = 1;
            this.timeline.TrackHeight = 30;
            this.timeline.TrackSpacing = 1;
            this.timeline.TimeChanged += new System.EventHandler<LipSyncTimeLineControl.Events.TimeChangeEventsArgs>(this.timeline_TimeChanged);
            this.timeline.AudioTrackChanged += new System.EventHandler<LipSyncTimeLineControl.Events.AudioTrackChangedEventsArgs>(this.timeline_AudioTrackChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 482);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.rtbPhraseText);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.timeline);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LipSyncTimeLineDemo";
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTrackLength)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Timeline timeline;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtbPhraseText;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox chbPlayingLoop;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripButton btnOpenProject;
        private System.Windows.Forms.ToolStripButton btnSaveProject;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox tbUdpPort;
        private System.Windows.Forms.ToolStripButton btnConnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnAddSubtitleTrack;
        private System.Windows.Forms.ToolStripButton btnGeneratePhoneme;
        private System.Windows.Forms.ListView phonemeListView;
        private System.Windows.Forms.ImageList imageListPhoneme;
        private System.Windows.Forms.ToolStripButton btnAddWordsTrack;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripButton btnPhonemeImage;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripButton btnNewProject;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nudTrackLength;
        private System.Windows.Forms.ToolStripComboBox cbDevicesPlayer;
        private System.Windows.Forms.ListBox expressionListBox;
        private System.Windows.Forms.ToolStripButton chbOnTop;
    }
}

