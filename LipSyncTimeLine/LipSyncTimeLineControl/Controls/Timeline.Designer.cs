using System.Windows.Forms;

namespace LipSyncTimeLineControl.Controls
{
    partial class Timeline
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ScrollbarV = new VerticalScrollbar();
            this.ScrollbarH = new HorizontalScrollbar();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScrollbarV
            // 
            this.ScrollbarV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScrollbarV.BackgroundColor = System.Drawing.Color.Black;
            this.ScrollbarV.ForegroundColor = System.Drawing.Color.Gray;
            this.ScrollbarV.Location = new System.Drawing.Point(791, 0);
            this.ScrollbarV.Max = 100;
            this.ScrollbarV.Min = 0;
            this.ScrollbarV.Name = "ScrollbarV";
            this.ScrollbarV.Size = new System.Drawing.Size(10, 180);
            this.ScrollbarV.TabIndex = 1;
            this.ScrollbarV.Value = 0;
            this.ScrollbarV.Scroll += new System.EventHandler<System.Windows.Forms.ScrollEventArgs>(this.ScrollbarVScroll);
            // 
            // ScrollbarH
            // 
            this.ScrollbarH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScrollbarH.BackgroundColor = System.Drawing.Color.Black;
            this.ScrollbarH.ForegroundColor = System.Drawing.Color.Gray;
            this.ScrollbarH.Location = new System.Drawing.Point(0, 190);
            this.ScrollbarH.Max = 100;
            this.ScrollbarH.Min = 0;
            this.ScrollbarH.Name = "ScrollbarH";
            this.ScrollbarH.Size = new System.Drawing.Size(780, 10);
            this.ScrollbarH.TabIndex = 0;
            this.ScrollbarH.Value = 0;
            this.ScrollbarH.Scroll += new System.EventHandler<System.Windows.Forms.ScrollEventArgs>(this.ScrollbarHScroll);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Tag = "Open";
            this.openToolStripMenuItem.Text = "Open";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.clearToolStripMenuItem.Tag = "Clear";
            this.clearToolStripMenuItem.Text = "Clear";
            // 
            // Timeline
            // 
            this.AllowDrop = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.ScrollbarV);
            this.Controls.Add(this.ScrollbarH);
            this.Size = new System.Drawing.Size(800, 200);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HorizontalScrollbar ScrollbarH;
        private VerticalScrollbar ScrollbarV;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
    }
}
