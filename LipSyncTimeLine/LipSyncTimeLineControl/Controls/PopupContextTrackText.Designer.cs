namespace LipSyncTimeLineControl.Controls
{
    partial class PopupContextTrackText
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

        private void InitializeComponent()
        {
            this.tbName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(13, 13);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(272, 22);
            this.tbName.TabIndex = 14;
            this.tbName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // PopupContextTrackText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbName);
            this.Name = "PopupContextTrackText";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(299, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
    }
}
