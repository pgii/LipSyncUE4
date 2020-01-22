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
            this.btnAddTextTrack = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbPhonemeImage = new System.Windows.Forms.PictureBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.timeline1 = new LipSyncTimeLineControl.Timeline();
            this.morphListBoxPhoneme = new LipSyncTimeLineControl.MorphListBox();
            this.morphListBoxExpression = new LipSyncTimeLineControl.MorphListBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhonemeImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveProject
            // 
            this.btnSaveProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveProject.Location = new System.Drawing.Point(179, 457);
            this.btnSaveProject.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveProject.Name = "btnSaveProject";
            this.btnSaveProject.Size = new System.Drawing.Size(150, 49);
            this.btnSaveProject.TabIndex = 4;
            this.btnSaveProject.Text = "SaveProject";
            this.btnSaveProject.UseVisualStyleBackColor = true;
            this.btnSaveProject.Click += new System.EventHandler(this.btnSaveProject_Click);
            // 
            // btnLoadProject
            // 
            this.btnLoadProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadProject.Location = new System.Drawing.Point(22, 457);
            this.btnLoadProject.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLoadProject.Name = "btnLoadProject";
            this.btnLoadProject.Size = new System.Drawing.Size(150, 49);
            this.btnLoadProject.TabIndex = 5;
            this.btnLoadProject.Text = "LoadProject";
            this.btnLoadProject.UseVisualStyleBackColor = true;
            this.btnLoadProject.Click += new System.EventHandler(this.btnLoadProject_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnAddTextTrack);
            this.panel1.Controls.Add(this.morphListBoxPhoneme);
            this.panel1.Controls.Add(this.btnLoadProject);
            this.panel1.Controls.Add(this.morphListBoxExpression);
            this.panel1.Controls.Add(this.btnSaveProject);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1526, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 576);
            this.panel1.TabIndex = 6;
            // 
            // btnAddTextTrack
            // 
            this.btnAddTextTrack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTextTrack.Location = new System.Drawing.Point(21, 398);
            this.btnAddTextTrack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddTextTrack.Name = "btnAddTextTrack";
            this.btnAddTextTrack.Size = new System.Drawing.Size(308, 49);
            this.btnAddTextTrack.TabIndex = 6;
            this.btnAddTextTrack.Text = "Add Text Track";
            this.btnAddTextTrack.UseVisualStyleBackColor = true;
            this.btnAddTextTrack.Click += new System.EventHandler(this.btnAddTextTrack_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pbPhonemeImage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 576);
            this.panel2.TabIndex = 7;
            // 
            // pbPhonemeImage
            // 
            this.pbPhonemeImage.Location = new System.Drawing.Point(18, 18);
            this.pbPhonemeImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbPhonemeImage.Name = "pbPhonemeImage";
            this.pbPhonemeImage.Size = new System.Drawing.Size(225, 231);
            this.pbPhonemeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPhonemeImage.TabIndex = 0;
            this.pbPhonemeImage.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(22, 513);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(308, 49);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // timeline1
            // 
            this.timeline1.AllowDrop = true;
            this.timeline1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.timeline1.BackgroundColor = System.Drawing.Color.Black;
            this.timeline1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeline1.GridAlpha = 40;
            this.timeline1.Location = new System.Drawing.Point(261, 0);
            this.timeline1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.timeline1.Name = "timeline1";
            this.timeline1.Size = new System.Drawing.Size(1265, 576);
            this.timeline1.TabIndex = 0;
            this.timeline1.TrackBorderSize = 2;
            this.timeline1.TrackHeight = 50;
            this.timeline1.TrackSpacing = 1;
            // 
            // morphListBoxPhoneme
            // 
            this.morphListBoxPhoneme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.morphListBoxPhoneme.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.morphListBoxPhoneme.FormattingEnabled = true;
            this.morphListBoxPhoneme.ItemHeight = 18;
            this.morphListBoxPhoneme.Location = new System.Drawing.Point(21, 18);
            this.morphListBoxPhoneme.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.morphListBoxPhoneme.Name = "morphListBoxPhoneme";
            this.morphListBoxPhoneme.Size = new System.Drawing.Size(306, 166);
            this.morphListBoxPhoneme.TabIndex = 1;
            this.morphListBoxPhoneme.MouseDown += new System.Windows.Forms.MouseEventHandler(this.morphListBoxPhoneme_MouseDown);
            // 
            // morphListBoxExpression
            // 
            this.morphListBoxExpression.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.morphListBoxExpression.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.morphListBoxExpression.FormattingEnabled = true;
            this.morphListBoxExpression.ItemHeight = 18;
            this.morphListBoxExpression.Location = new System.Drawing.Point(21, 217);
            this.morphListBoxExpression.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.morphListBoxExpression.Name = "morphListBoxExpression";
            this.morphListBoxExpression.Size = new System.Drawing.Size(306, 166);
            this.morphListBoxExpression.TabIndex = 2;
            this.morphListBoxExpression.MouseDown += new System.Windows.Forms.MouseEventHandler(this.morphListBoxExpression_MouseDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1876, 576);
            this.Controls.Add(this.timeline1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "LipSyncTimeLineDemo";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPhonemeImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LipSyncTimeLineControl.Timeline timeline1;
        private LipSyncTimeLineControl.MorphListBox morphListBoxPhoneme;
        private LipSyncTimeLineControl.MorphListBox morphListBoxExpression;
        private System.Windows.Forms.Button btnSaveProject;
        private System.Windows.Forms.Button btnLoadProject;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbPhonemeImage;
        private System.Windows.Forms.Button btnAddTextTrack;
        private System.Windows.Forms.Button btnExport;
    }
}

