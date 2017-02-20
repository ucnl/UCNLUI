namespace UCNLUI.Controls
{
    partial class LatitudeEditor
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
            this.degreeNumericEdit = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.minutesNumericEdit = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.secondsNumericEdit = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.resultString = new System.Windows.Forms.Label();
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.degreeNumericEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutesNumericEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsNumericEdit)).BeginInit();
            this.tableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // degreeNumericEdit
            // 
            this.degreeNumericEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.degreeNumericEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.degreeNumericEdit.Location = new System.Drawing.Point(1, 1);
            this.degreeNumericEdit.Margin = new System.Windows.Forms.Padding(1);
            this.degreeNumericEdit.Maximum = new decimal(new int[] {
            89,
            0,
            0,
            0});
            this.degreeNumericEdit.Minimum = new decimal(new int[] {
            89,
            0,
            0,
            -2147483648});
            this.degreeNumericEdit.Name = "degreeNumericEdit";
            this.degreeNumericEdit.Size = new System.Drawing.Size(45, 20);
            this.degreeNumericEdit.TabIndex = 0;
            this.degreeNumericEdit.Value = new decimal(new int[] {
            89,
            0,
            0,
            -2147483648});
            this.degreeNumericEdit.ValueChanged += new System.EventHandler(this.degreeNumericEdit_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(47, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "°";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // minutesNumericEdit
            // 
            this.minutesNumericEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.minutesNumericEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minutesNumericEdit.Location = new System.Drawing.Point(62, 1);
            this.minutesNumericEdit.Margin = new System.Windows.Forms.Padding(1);
            this.minutesNumericEdit.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.minutesNumericEdit.Name = "minutesNumericEdit";
            this.minutesNumericEdit.Size = new System.Drawing.Size(40, 20);
            this.minutesNumericEdit.TabIndex = 2;
            this.minutesNumericEdit.Value = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.minutesNumericEdit.ValueChanged += new System.EventHandler(this.minutesNumericEdit_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(103, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "\'";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // secondsNumericEdit
            // 
            this.secondsNumericEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secondsNumericEdit.DecimalPlaces = 2;
            this.secondsNumericEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondsNumericEdit.Location = new System.Drawing.Point(116, 1);
            this.secondsNumericEdit.Margin = new System.Windows.Forms.Padding(1);
            this.secondsNumericEdit.Maximum = new decimal(new int[] {
            5999,
            0,
            0,
            131072});
            this.secondsNumericEdit.Name = "secondsNumericEdit";
            this.secondsNumericEdit.Size = new System.Drawing.Size(50, 20);
            this.secondsNumericEdit.TabIndex = 4;
            this.secondsNumericEdit.Value = new decimal(new int[] {
            5999,
            0,
            0,
            131072});
            this.secondsNumericEdit.ValueChanged += new System.EventHandler(this.secondsNumericEdit_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(167, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "\"";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // resultString
            // 
            this.resultString.AutoSize = true;
            this.resultString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultString.Location = new System.Drawing.Point(183, 1);
            this.resultString.Margin = new System.Windows.Forms.Padding(1);
            this.resultString.Name = "resultString";
            this.resultString.Size = new System.Drawing.Size(105, 21);
            this.resultString.TabIndex = 6;
            this.resultString.Text = "/ 90° 59\' 59.99\"  S";
            this.resultString.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 7;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayout.Controls.Add(this.degreeNumericEdit, 0, 0);
            this.tableLayout.Controls.Add(this.resultString, 6, 0);
            this.tableLayout.Controls.Add(this.label1, 1, 0);
            this.tableLayout.Controls.Add(this.label3, 5, 0);
            this.tableLayout.Controls.Add(this.minutesNumericEdit, 2, 0);
            this.tableLayout.Controls.Add(this.secondsNumericEdit, 4, 0);
            this.tableLayout.Controls.Add(this.label2, 3, 0);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 1;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.Size = new System.Drawing.Size(289, 23);
            this.tableLayout.TabIndex = 7;
            // 
            // LatitudeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayout);
            this.Name = "LatitudeEditor";
            this.Size = new System.Drawing.Size(289, 23);
            ((System.ComponentModel.ISupportInitialize)(this.degreeNumericEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutesNumericEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsNumericEdit)).EndInit();
            this.tableLayout.ResumeLayout(false);
            this.tableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown degreeNumericEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown minutesNumericEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown secondsNumericEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label resultString;
        private System.Windows.Forms.TableLayoutPanel tableLayout;
    }
}
