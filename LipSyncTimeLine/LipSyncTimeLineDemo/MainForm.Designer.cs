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
            this.btnSaveProject = new System.Windows.Forms.Button();
            this.btnLoadProject = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGeneratePhoneme = new System.Windows.Forms.Button();
            this.rtbPhraseText = new System.Windows.Forms.RichTextBox();
            this.btnAddWordsTrack = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnAddSubtitleTrack = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbPhonemeImage = new System.Windows.Forms.PictureBox();
            this.timeline = new LipSyncTimeLineControl.Timeline();
            this.phonemeListBoxPhoneme = new LipSyncTimeLineControl.MorphListBox();
            this.expressionListBoxExpression = new LipSyncTimeLineControl.MorphListBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhonemeImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveProject
            // 
            this.btnSaveProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveProject.Location = new System.Drawing.Point(120, 390);
            this.btnSaveProject.Name = "btnSaveProject";
            this.btnSaveProject.Size = new System.Drawing.Size(98, 32);
            this.btnSaveProject.TabIndex = 4;
            this.btnSaveProject.Text = "SaveProject";
            this.btnSaveProject.UseVisualStyleBackColor = true;
            this.btnSaveProject.Click += new System.EventHandler(this.btnSaveProject_Click);
            // 
            // btnLoadProject
            // 
            this.btnLoadProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadProject.Location = new System.Drawing.Point(14, 390);
            this.btnLoadProject.Name = "btnLoadProject";
            this.btnLoadProject.Size = new System.Drawing.Size(98, 32);
            this.btnLoadProject.TabIndex = 5;
            this.btnLoadProject.Text = "LoadProject";
            this.btnLoadProject.UseVisualStyleBackColor = true;
            this.btnLoadProject.Click += new System.EventHandler(this.btnLoadProject_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGeneratePhoneme);
            this.panel1.Controls.Add(this.rtbPhraseText);
            this.panel1.Controls.Add(this.btnAddWordsTrack);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnAddSubtitleTrack);
            this.panel1.Controls.Add(this.phonemeListBoxPhoneme);
            this.panel1.Controls.Add(this.btnLoadProject);
            this.panel1.Controls.Add(this.expressionListBoxExpression);
            this.panel1.Controls.Add(this.btnSaveProject);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1018, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 467);
            this.panel1.TabIndex = 6;
            // 
            // btnGeneratePhoneme
            // 
            this.btnGeneratePhoneme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeneratePhoneme.Location = new System.Drawing.Point(14, 315);
            this.btnGeneratePhoneme.Name = "btnGeneratePhoneme";
            this.btnGeneratePhoneme.Size = new System.Drawing.Size(204, 32);
            this.btnGeneratePhoneme.TabIndex = 10;
            this.btnGeneratePhoneme.Text = "Generate Phoneme";
            this.btnGeneratePhoneme.UseVisualStyleBackColor = true;
            this.btnGeneratePhoneme.Click += new System.EventHandler(this.btnGeneratePhoneme_Click);
            // 
            // rtbPhraseText
            // 
            this.rtbPhraseText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbPhraseText.Location = new System.Drawing.Point(14, 231);
            this.rtbPhraseText.Margin = new System.Windows.Forms.Padding(2);
            this.rtbPhraseText.Name = "rtbPhraseText";
            this.rtbPhraseText.Size = new System.Drawing.Size(205, 42);
            this.rtbPhraseText.TabIndex = 9;
            this.rtbPhraseText.Text = "Hi. My name is Victoria. This is a lip sync demo for Unreal Engine.";
            // 
            // btnAddWordsTrack
            // 
            this.btnAddWordsTrack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddWordsTrack.Location = new System.Drawing.Point(14, 277);
            this.btnAddWordsTrack.Name = "btnAddWordsTrack";
            this.btnAddWordsTrack.Size = new System.Drawing.Size(204, 32);
            this.btnAddWordsTrack.TabIndex = 8;
            this.btnAddWordsTrack.Text = "Add Words Track";
            this.btnAddWordsTrack.UseVisualStyleBackColor = true;
            this.btnAddWordsTrack.Click += new System.EventHandler(this.btnAddWordsTrack_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(14, 426);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(204, 32);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnAddSubtitleTrack
            // 
            this.btnAddSubtitleTrack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSubtitleTrack.Location = new System.Drawing.Point(14, 194);
            this.btnAddSubtitleTrack.Name = "btnAddSubtitleTrack";
            this.btnAddSubtitleTrack.Size = new System.Drawing.Size(204, 32);
            this.btnAddSubtitleTrack.TabIndex = 6;
            this.btnAddSubtitleTrack.Text = "Add Subtitle Track";
            this.btnAddSubtitleTrack.UseVisualStyleBackColor = true;
            this.btnAddSubtitleTrack.Click += new System.EventHandler(this.btnAddSubtitleTrack_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pbPhonemeImage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(174, 467);
            this.panel2.TabIndex = 7;
            // 
            // pbPhonemeImage
            // 
            this.pbPhonemeImage.Location = new System.Drawing.Point(12, 12);
            this.pbPhonemeImage.Name = "pbPhonemeImage";
            this.pbPhonemeImage.Size = new System.Drawing.Size(150, 150);
            this.pbPhonemeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPhonemeImage.TabIndex = 0;
            this.pbPhonemeImage.TabStop = false;
            // 
            // timeline
            // 
            this.timeline.AllowDrop = true;
            this.timeline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.timeline.BackgroundColor = System.Drawing.Color.Black;
            this.timeline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeline.GridAlpha = 40;
            this.timeline.Location = new System.Drawing.Point(174, 0);
            this.timeline.Name = "timeline";
            this.timeline.Size = new System.Drawing.Size(844, 467);
            this.timeline.TabIndex = 0;
            this.timeline.TrackHeight = 50;
            this.timeline.TrackSpacing = 1;
            // 
            // phonemeListBoxPhoneme
            // 
            this.phonemeListBoxPhoneme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.phonemeListBoxPhoneme.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.phonemeListBoxPhoneme.FormattingEnabled = true;
            this.phonemeListBoxPhoneme.ItemHeight = 18;
            this.phonemeListBoxPhoneme.Location = new System.Drawing.Point(14, 12);
            this.phonemeListBoxPhoneme.Name = "phonemeListBoxPhoneme";
            this.phonemeListBoxPhoneme.Size = new System.Drawing.Size(205, 76);
            this.phonemeListBoxPhoneme.TabIndex = 1;
            this.phonemeListBoxPhoneme.MouseDown += new System.Windows.Forms.MouseEventHandler(this.morphListBoxPhoneme_MouseDown);
            // 
            // expressionListBoxExpression
            // 
            this.expressionListBoxExpression.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.expressionListBoxExpression.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.expressionListBoxExpression.FormattingEnabled = true;
            this.expressionListBoxExpression.ItemHeight = 18;
            this.expressionListBoxExpression.Location = new System.Drawing.Point(14, 103);
            this.expressionListBoxExpression.Name = "expressionListBoxExpression";
            this.expressionListBoxExpression.Size = new System.Drawing.Size(205, 76);
            this.expressionListBoxExpression.TabIndex = 2;
            this.expressionListBoxExpression.MouseDown += new System.Windows.Forms.MouseEventHandler(this.morphListBoxExpression_MouseDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 467);
            this.Controls.Add(this.timeline);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "LipSyncTimeLineDemo";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPhonemeImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LipSyncTimeLineControl.Timeline timeline;
        private LipSyncTimeLineControl.MorphListBox phonemeListBoxPhoneme;
        private LipSyncTimeLineControl.MorphListBox expressionListBoxExpression;
        private System.Windows.Forms.Button btnSaveProject;
        private System.Windows.Forms.Button btnLoadProject;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbPhonemeImage;
        private System.Windows.Forms.Button btnAddSubtitleTrack;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnAddWordsTrack;
        private System.Windows.Forms.RichTextBox rtbPhraseText;
        private System.Windows.Forms.Button btnGeneratePhoneme;
    }
}

