namespace UCNLUI.Dialogs
{
    partial class SoundSpeedDialog
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
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.preConfigCbx = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tempEdit = new System.Windows.Forms.NumericUpDown();
            this.pressureEdit = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.salinityEdit = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.soundSpeedEdit = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.getFromBaseBtn = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.tempEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pressureEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salinityEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundSpeedEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okBtn.Location = new System.Drawing.Point(185, 248);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 0;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Location = new System.Drawing.Point(292, 248);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Configurations";
            // 
            // preConfigCbx
            // 
            this.preConfigCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.preConfigCbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.preConfigCbx.FormattingEnabled = true;
            this.preConfigCbx.Items.AddRange(new object[] {
            "Fresh water",
            "Sea water",
            "Direct measurement"});
            this.preConfigCbx.Location = new System.Drawing.Point(103, 20);
            this.preConfigCbx.Name = "preConfigCbx";
            this.preConfigCbx.Size = new System.Drawing.Size(154, 21);
            this.preConfigCbx.TabIndex = 3;
            this.preConfigCbx.SelectedIndexChanged += new System.EventHandler(this.preConfigCbx_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Water temperature, C";
            // 
            // tempEdit
            // 
            this.tempEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tempEdit.Location = new System.Drawing.Point(160, 66);
            this.tempEdit.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.tempEdit.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            -2147483648});
            this.tempEdit.Name = "tempEdit";
            this.tempEdit.Size = new System.Drawing.Size(97, 20);
            this.tempEdit.TabIndex = 5;
            this.tempEdit.ValueChanged += new System.EventHandler(this.tempEdit_ValueChanged);
            // 
            // pressureEdit
            // 
            this.pressureEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pressureEdit.DecimalPlaces = 1;
            this.pressureEdit.Enabled = false;
            this.pressureEdit.Location = new System.Drawing.Point(160, 92);
            this.pressureEdit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.pressureEdit.Name = "pressureEdit";
            this.pressureEdit.Size = new System.Drawing.Size(97, 20);
            this.pressureEdit.TabIndex = 7;
            this.pressureEdit.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.pressureEdit.ValueChanged += new System.EventHandler(this.pressureEdit_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hydrostatic pressure, MPa";
            // 
            // salinityEdit
            // 
            this.salinityEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.salinityEdit.DecimalPlaces = 1;
            this.salinityEdit.Enabled = false;
            this.salinityEdit.Location = new System.Drawing.Point(160, 118);
            this.salinityEdit.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.salinityEdit.Name = "salinityEdit";
            this.salinityEdit.Size = new System.Drawing.Size(97, 20);
            this.salinityEdit.TabIndex = 9;
            this.salinityEdit.ValueChanged += new System.EventHandler(this.salinityEdit_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Salinity, PSU";
            // 
            // soundSpeedEdit
            // 
            this.soundSpeedEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.soundSpeedEdit.Location = new System.Drawing.Point(160, 186);
            this.soundSpeedEdit.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.soundSpeedEdit.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.soundSpeedEdit.Name = "soundSpeedEdit";
            this.soundSpeedEdit.Size = new System.Drawing.Size(97, 20);
            this.soundSpeedEdit.TabIndex = 11;
            this.soundSpeedEdit.Value = new decimal(new int[] {
            1300,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Speed of sound, m/s";
            // 
            // getFromBaseBtn
            // 
            this.getFromBaseBtn.AutoSize = true;
            this.getFromBaseBtn.Enabled = false;
            this.getFromBaseBtn.Location = new System.Drawing.Point(272, 120);
            this.getFromBaseBtn.Name = "getFromBaseBtn";
            this.getFromBaseBtn.Size = new System.Drawing.Size(94, 13);
            this.getFromBaseBtn.TabIndex = 12;
            this.getFromBaseBtn.TabStop = true;
            this.getFromBaseBtn.Text = "Get from database";
            this.getFromBaseBtn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.getFromBaseBtn_LinkClicked);
            // 
            // SoundSpeedDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 283);
            this.Controls.Add(this.getFromBaseBtn);
            this.Controls.Add(this.soundSpeedEdit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.salinityEdit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pressureEdit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tempEdit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.preConfigCbx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SoundSpeedDialog";
            this.Text = "SoundSpeedDialog";
            ((System.ComponentModel.ISupportInitialize)(this.tempEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pressureEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salinityEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundSpeedEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox preConfigCbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown tempEdit;
        private System.Windows.Forms.NumericUpDown pressureEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown salinityEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown soundSpeedEdit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel getFromBaseBtn;
    }
}