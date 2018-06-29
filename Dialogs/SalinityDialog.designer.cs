namespace UCNLUI.Dialogs
{
    partial class SalinityDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalinityDialog));
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.latCaptionLbl = new System.Windows.Forms.Label();
            this.LonCaptionLbl = new System.Windows.Forms.Label();
            this.latEdit = new System.Windows.Forms.NumericUpDown();
            this.lonEdit = new System.Windows.Forms.NumericUpDown();
            this.latLbl = new System.Windows.Forms.Label();
            this.lonLbl = new System.Windows.Forms.Label();
            this.salinityCaptionLbl = new System.Windows.Forms.Label();
            this.searchBtn = new System.Windows.Forms.Button();
            this.salinityLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.latEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lonEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            resources.ApplyResources(this.cancelBtn, "cancelBtn");
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            resources.ApplyResources(this.okBtn, "okBtn");
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Name = "okBtn";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // latCaptionLbl
            // 
            resources.ApplyResources(this.latCaptionLbl, "latCaptionLbl");
            this.latCaptionLbl.Name = "latCaptionLbl";
            this.latCaptionLbl.Click += new System.EventHandler(this.latCaptionLbl_Click);
            // 
            // LonCaptionLbl
            // 
            resources.ApplyResources(this.LonCaptionLbl, "LonCaptionLbl");
            this.LonCaptionLbl.Name = "LonCaptionLbl";
            this.LonCaptionLbl.Click += new System.EventHandler(this.LonCaptionLbl_Click);
            // 
            // latEdit
            // 
            resources.ApplyResources(this.latEdit, "latEdit");
            this.latEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.latEdit.DecimalPlaces = 1;
            this.latEdit.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.latEdit.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.latEdit.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.latEdit.Name = "latEdit";
            this.latEdit.Value = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.latEdit.ValueChanged += new System.EventHandler(this.latEdit_ValueChanged);
            // 
            // lonEdit
            // 
            resources.ApplyResources(this.lonEdit, "lonEdit");
            this.lonEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lonEdit.DecimalPlaces = 1;
            this.lonEdit.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.lonEdit.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.lonEdit.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.lonEdit.Name = "lonEdit";
            this.lonEdit.Value = new decimal(new int[] {
            44,
            0,
            0,
            0});
            this.lonEdit.ValueChanged += new System.EventHandler(this.lonEdit_ValueChanged);
            // 
            // latLbl
            // 
            resources.ApplyResources(this.latLbl, "latLbl");
            this.latLbl.Name = "latLbl";
            this.latLbl.Click += new System.EventHandler(this.latLbl_Click);
            // 
            // lonLbl
            // 
            resources.ApplyResources(this.lonLbl, "lonLbl");
            this.lonLbl.Name = "lonLbl";
            this.lonLbl.Click += new System.EventHandler(this.lonLbl_Click);
            // 
            // salinityCaptionLbl
            // 
            resources.ApplyResources(this.salinityCaptionLbl, "salinityCaptionLbl");
            this.salinityCaptionLbl.Name = "salinityCaptionLbl";
            this.salinityCaptionLbl.Click += new System.EventHandler(this.salinityCaptionLbl_Click);
            // 
            // searchBtn
            // 
            resources.ApplyResources(this.searchBtn, "searchBtn");
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // salinityLabel
            // 
            resources.ApplyResources(this.salinityLabel, "salinityLabel");
            this.salinityLabel.Name = "salinityLabel";
            this.salinityLabel.Click += new System.EventHandler(this.salinityLabel_Click);
            // 
            // SalinityDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.salinityLabel);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.salinityCaptionLbl);
            this.Controls.Add(this.lonLbl);
            this.Controls.Add(this.latLbl);
            this.Controls.Add(this.lonEdit);
            this.Controls.Add(this.latEdit);
            this.Controls.Add(this.LonCaptionLbl);
            this.Controls.Add(this.latCaptionLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SalinityDialog";
            this.Load += new System.EventHandler(this.SalinityDialog_Load);
            this.Shown += new System.EventHandler(this.SalinityDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.latEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lonEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label latCaptionLbl;
        private System.Windows.Forms.Label LonCaptionLbl;
        private System.Windows.Forms.NumericUpDown latEdit;
        private System.Windows.Forms.NumericUpDown lonEdit;
        private System.Windows.Forms.Label latLbl;
        private System.Windows.Forms.Label lonLbl;
        private System.Windows.Forms.Label salinityCaptionLbl;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Label salinityLabel;
    }
}