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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoundSpeedDialog));
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
            resources.ApplyResources(this.okBtn, "okBtn");
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Name = "okBtn";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            resources.ApplyResources(this.cancelBtn, "cancelBtn");
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // preConfigCbx
            // 
            resources.ApplyResources(this.preConfigCbx, "preConfigCbx");
            this.preConfigCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.preConfigCbx.FormattingEnabled = true;
            this.preConfigCbx.Items.AddRange(new object[] {
            resources.GetString("preConfigCbx.Items"),
            resources.GetString("preConfigCbx.Items1"),
            resources.GetString("preConfigCbx.Items2")});
            this.preConfigCbx.Name = "preConfigCbx";
            this.preConfigCbx.SelectedIndexChanged += new System.EventHandler(this.preConfigCbx_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tempEdit
            // 
            resources.ApplyResources(this.tempEdit, "tempEdit");
            this.tempEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.tempEdit.ValueChanged += new System.EventHandler(this.tempEdit_ValueChanged);
            // 
            // pressureEdit
            // 
            resources.ApplyResources(this.pressureEdit, "pressureEdit");
            this.pressureEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pressureEdit.DecimalPlaces = 1;
            this.pressureEdit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.pressureEdit.Name = "pressureEdit";
            this.pressureEdit.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.pressureEdit.ValueChanged += new System.EventHandler(this.pressureEdit_ValueChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // salinityEdit
            // 
            resources.ApplyResources(this.salinityEdit, "salinityEdit");
            this.salinityEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.salinityEdit.DecimalPlaces = 1;
            this.salinityEdit.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.salinityEdit.Name = "salinityEdit";
            this.salinityEdit.ValueChanged += new System.EventHandler(this.salinityEdit_ValueChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // soundSpeedEdit
            // 
            resources.ApplyResources(this.soundSpeedEdit, "soundSpeedEdit");
            this.soundSpeedEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.soundSpeedEdit.Value = new decimal(new int[] {
            1300,
            0,
            0,
            0});
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // getFromBaseBtn
            // 
            resources.ApplyResources(this.getFromBaseBtn, "getFromBaseBtn");
            this.getFromBaseBtn.Name = "getFromBaseBtn";
            this.getFromBaseBtn.TabStop = true;
            this.getFromBaseBtn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.getFromBaseBtn_LinkClicked);
            // 
            // SoundSpeedDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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