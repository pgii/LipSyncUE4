namespace LipSyncTimeLineControl.Popup
{
    partial class PopupContextTrackValue
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
            this.tbTrackValue = new System.Windows.Forms.TrackBar();
            this.lblValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.tbTrackValue)).BeginInit();
            this.SuspendLayout();
            // 
            // tbTrackValue
            // 
            this.tbTrackValue.Location = new System.Drawing.Point(-1, 27);
            this.tbTrackValue.Minimum = -10;
            this.tbTrackValue.Name = "tbTrackValue";
            this.tbTrackValue.Size = new System.Drawing.Size(150, 45);
            this.tbTrackValue.TabIndex = 12;
            this.tbTrackValue.Scroll += new System.EventHandler(this.tbTrackValue_Scroll);
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(13, 10);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(37, 14);
            this.lblValue.TabIndex = 13;
            this.lblValue.Text = "Value";
            // 
            // PopupContextTrackValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.tbTrackValue);
            this.Name = "PopupContextTrackValue";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(150, 79);
            ((System.ComponentModel.ISupportInitialize) (this.tbTrackValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TrackBar tbTrackValue;
    }
}
