namespace UCNLUI.Controls
{
    partial class uOSMGeoPlot
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
            this.SuspendLayout();
            // 
            // uOSMGeoPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.Name = "uOSMGeoPlot";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.uOSMGeoPlot_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.uOSMGeoPlot_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.uOSMGeoPlot_MouseMove);
            this.Resize += new System.EventHandler(this.uOSMGeoPlot_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
