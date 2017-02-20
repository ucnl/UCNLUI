namespace UCNLUI.Controls
{
    partial class SerialPortSettingsEdit
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
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.stopbitsCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.databitsCombo = new System.Windows.Forms.ComboBox();
            this.baudrateCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.portNameCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.parityCombo = new System.Windows.Forms.ComboBox();
            this.handshakeCombo = new System.Windows.Forms.ComboBox();
            this.tableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 2;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.Controls.Add(this.label6, 0, 5);
            this.tableLayout.Controls.Add(this.stopbitsCombo, 1, 3);
            this.tableLayout.Controls.Add(this.label4, 0, 3);
            this.tableLayout.Controls.Add(this.databitsCombo, 1, 2);
            this.tableLayout.Controls.Add(this.baudrateCombo, 1, 1);
            this.tableLayout.Controls.Add(this.label1, 0, 0);
            this.tableLayout.Controls.Add(this.portNameCombo, 1, 0);
            this.tableLayout.Controls.Add(this.label2, 0, 1);
            this.tableLayout.Controls.Add(this.label3, 0, 2);
            this.tableLayout.Controls.Add(this.label5, 0, 4);
            this.tableLayout.Controls.Add(this.parityCombo, 1, 4);
            this.tableLayout.Controls.Add(this.handshakeCombo, 1, 5);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 6;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.Size = new System.Drawing.Size(209, 163);
            this.tableLayout.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 28);
            this.label6.TabIndex = 10;
            this.label6.Text = "Handshake";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stopbitsCombo
            // 
            this.stopbitsCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stopbitsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stopbitsCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopbitsCombo.FormattingEnabled = true;
            this.stopbitsCombo.Location = new System.Drawing.Point(71, 84);
            this.stopbitsCombo.Name = "stopbitsCombo";
            this.stopbitsCombo.Size = new System.Drawing.Size(135, 21);
            this.stopbitsCombo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 27);
            this.label4.TabIndex = 6;
            this.label4.Text = "Stop bit";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // databitsCombo
            // 
            this.databitsCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databitsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.databitsCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.databitsCombo.FormattingEnabled = true;
            this.databitsCombo.Location = new System.Drawing.Point(71, 57);
            this.databitsCombo.Name = "databitsCombo";
            this.databitsCombo.Size = new System.Drawing.Size(135, 21);
            this.databitsCombo.TabIndex = 5;
            // 
            // baudrateCombo
            // 
            this.baudrateCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baudrateCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baudrateCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.baudrateCombo.FormattingEnabled = true;
            this.baudrateCombo.Location = new System.Drawing.Point(71, 30);
            this.baudrateCombo.Name = "baudrateCombo";
            this.baudrateCombo.Size = new System.Drawing.Size(135, 21);
            this.baudrateCombo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // portNameCombo
            // 
            this.portNameCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.portNameCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portNameCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.portNameCombo.FormattingEnabled = true;
            this.portNameCombo.Location = new System.Drawing.Point(71, 3);
            this.portNameCombo.Name = "portNameCombo";
            this.portNameCombo.Size = new System.Drawing.Size(135, 21);
            this.portNameCombo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Baudrate";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "Data bits";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 27);
            this.label5.TabIndex = 8;
            this.label5.Text = "Parity";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // parityCombo
            // 
            this.parityCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parityCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.parityCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.parityCombo.FormattingEnabled = true;
            this.parityCombo.Location = new System.Drawing.Point(71, 111);
            this.parityCombo.Name = "parityCombo";
            this.parityCombo.Size = new System.Drawing.Size(135, 21);
            this.parityCombo.TabIndex = 9;
            // 
            // handshakeCombo
            // 
            this.handshakeCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.handshakeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.handshakeCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.handshakeCombo.FormattingEnabled = true;
            this.handshakeCombo.Location = new System.Drawing.Point(71, 138);
            this.handshakeCombo.Name = "handshakeCombo";
            this.handshakeCombo.Size = new System.Drawing.Size(135, 21);
            this.handshakeCombo.TabIndex = 11;
            // 
            // RS232SettingsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayout);
            this.MaximumSize = new System.Drawing.Size(209, 163);
            this.MinimumSize = new System.Drawing.Size(209, 163);
            this.Name = "RS232SettingsEditor";
            this.Size = new System.Drawing.Size(209, 163);
            this.tableLayout.ResumeLayout(false);
            this.tableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.ComboBox baudrateCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox portNameCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox stopbitsCombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox databitsCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox parityCombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox handshakeCombo;
    }
}
