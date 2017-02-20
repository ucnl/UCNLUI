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
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Location = new System.Drawing.Point(381, 234);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(100, 28);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Enabled = false;
            this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okBtn.Location = new System.Drawing.Point(239, 234);
            this.okBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(100, 28);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // latCaptionLbl
            // 
            this.latCaptionLbl.AutoSize = true;
            this.latCaptionLbl.Location = new System.Drawing.Point(31, 29);
            this.latCaptionLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.latCaptionLbl.Name = "latCaptionLbl";
            this.latCaptionLbl.Size = new System.Drawing.Size(59, 17);
            this.latCaptionLbl.TabIndex = 4;
            this.latCaptionLbl.Text = "Latitude";
            // 
            // LonCaptionLbl
            // 
            this.LonCaptionLbl.AutoSize = true;
            this.LonCaptionLbl.Location = new System.Drawing.Point(31, 74);
            this.LonCaptionLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LonCaptionLbl.Name = "LonCaptionLbl";
            this.LonCaptionLbl.Size = new System.Drawing.Size(71, 17);
            this.LonCaptionLbl.TabIndex = 5;
            this.LonCaptionLbl.Text = "Longitude";
            // 
            // latEdit
            // 
            this.latEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.latEdit.DecimalPlaces = 1;
            this.latEdit.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.latEdit.Location = new System.Drawing.Point(111, 27);
            this.latEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.latEdit.Size = new System.Drawing.Size(108, 22);
            this.latEdit.TabIndex = 6;
            this.latEdit.Value = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.latEdit.ValueChanged += new System.EventHandler(this.latEdit_ValueChanged);
            // 
            // lonEdit
            // 
            this.lonEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lonEdit.DecimalPlaces = 1;
            this.lonEdit.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.lonEdit.Location = new System.Drawing.Point(111, 71);
            this.lonEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.lonEdit.Size = new System.Drawing.Size(108, 22);
            this.lonEdit.TabIndex = 7;
            this.lonEdit.Value = new decimal(new int[] {
            44,
            0,
            0,
            0});
            this.lonEdit.ValueChanged += new System.EventHandler(this.lonEdit_ValueChanged);
            // 
            // latLbl
            // 
            this.latLbl.AutoSize = true;
            this.latLbl.Location = new System.Drawing.Point(245, 30);
            this.latLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.latLbl.Name = "latLbl";
            this.latLbl.Size = new System.Drawing.Size(50, 17);
            this.latLbl.TabIndex = 8;
            this.latLbl.Text = "48.0 N";
            // 
            // lonLbl
            // 
            this.lonLbl.AutoSize = true;
            this.lonLbl.Location = new System.Drawing.Point(245, 74);
            this.lonLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lonLbl.Name = "lonLbl";
            this.lonLbl.Size = new System.Drawing.Size(49, 17);
            this.lonLbl.TabIndex = 9;
            this.lonLbl.Text = "44.0 S";
            // 
            // salinityCaptionLbl
            // 
            this.salinityCaptionLbl.AutoSize = true;
            this.salinityCaptionLbl.Location = new System.Drawing.Point(31, 186);
            this.salinityCaptionLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.salinityCaptionLbl.Name = "salinityCaptionLbl";
            this.salinityCaptionLbl.Size = new System.Drawing.Size(89, 17);
            this.salinityCaptionLbl.TabIndex = 10;
            this.salinityCaptionLbl.Text = "Salinity, PSU";
            // 
            // searchBtn
            // 
            this.searchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchBtn.Location = new System.Drawing.Point(119, 133);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(100, 28);
            this.searchBtn.TabIndex = 11;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // salinityLabel
            // 
            this.salinityLabel.AutoSize = true;
            this.salinityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salinityLabel.Location = new System.Drawing.Point(129, 186);
            this.salinityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.salinityLabel.Name = "salinityLabel";
            this.salinityLabel.Size = new System.Drawing.Size(63, 17);
            this.salinityLabel.TabIndex = 12;
            this.salinityLabel.Text = "no data";
            // 
            // SalinityDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 277);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SalinityDialog";
            this.Text = "SalinityDialog";
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