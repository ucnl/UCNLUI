﻿namespace UCNLUI.Dialogs
{
    partial class AboutBox
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
            this.components = new System.ComponentModel.Container();
            this.okBtn = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.titleLbl = new System.Windows.Forms.Label();
            this.versionLbl = new System.Windows.Forms.Label();
            this.copyrightLbl = new System.Windows.Forms.Label();
            this.weblinkLbl = new System.Windows.Forms.LinkLabel();
            this.descriptionTxb = new System.Windows.Forms.RichTextBox();
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.logoList = new System.Windows.Forms.ImageList(this.components);
            this.mainPanel.SuspendLayout();
            this.tableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okBtn.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.okBtn.Location = new System.Drawing.Point(647, 514);
            this.okBtn.Margin = new System.Windows.Forms.Padding(5);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(101, 35);
            this.okBtn.TabIndex = 0;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.Controls.Add(this.tableLayout);
            this.mainPanel.Controls.Add(this.logoBox);
            this.mainPanel.Location = new System.Drawing.Point(16, 19);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(5);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(739, 486);
            this.mainPanel.TabIndex = 1;
            // 
            // tableLayout
            // 
            this.tableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayout.ColumnCount = 1;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.Controls.Add(this.titleLbl, 0, 0);
            this.tableLayout.Controls.Add(this.versionLbl, 0, 1);
            this.tableLayout.Controls.Add(this.copyrightLbl, 0, 2);
            this.tableLayout.Controls.Add(this.weblinkLbl, 0, 3);
            this.tableLayout.Controls.Add(this.descriptionTxb, 0, 4);
            this.tableLayout.Location = new System.Drawing.Point(296, 5);
            this.tableLayout.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 5;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tableLayout.Size = new System.Drawing.Size(439, 478);
            this.tableLayout.TabIndex = 1;
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLbl.Location = new System.Drawing.Point(5, 7);
            this.titleLbl.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(429, 15);
            this.titleLbl.TabIndex = 1;
            this.titleLbl.Text = "Title";
            this.titleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.titleLbl.UseMnemonic = false;
            // 
            // versionLbl
            // 
            this.versionLbl.AutoSize = true;
            this.versionLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionLbl.Location = new System.Drawing.Point(5, 36);
            this.versionLbl.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.versionLbl.Name = "versionLbl";
            this.versionLbl.Size = new System.Drawing.Size(429, 15);
            this.versionLbl.TabIndex = 2;
            this.versionLbl.Text = "version";
            this.versionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.versionLbl.UseMnemonic = false;
            // 
            // copyrightLbl
            // 
            this.copyrightLbl.AutoSize = true;
            this.copyrightLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.copyrightLbl.Location = new System.Drawing.Point(5, 65);
            this.copyrightLbl.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.copyrightLbl.Name = "copyrightLbl";
            this.copyrightLbl.Size = new System.Drawing.Size(429, 15);
            this.copyrightLbl.TabIndex = 3;
            this.copyrightLbl.Text = "Copyrights";
            this.copyrightLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.copyrightLbl.UseMnemonic = false;
            // 
            // weblinkLbl
            // 
            this.weblinkLbl.AutoSize = true;
            this.weblinkLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weblinkLbl.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.weblinkLbl.Location = new System.Drawing.Point(5, 94);
            this.weblinkLbl.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.weblinkLbl.Name = "weblinkLbl";
            this.weblinkLbl.Size = new System.Drawing.Size(429, 15);
            this.weblinkLbl.TabIndex = 4;
            this.weblinkLbl.TabStop = true;
            this.weblinkLbl.Text = "Weblink";
            this.weblinkLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.weblinkLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.weblinkLbl_LinkClicked);
            // 
            // descriptionTxb
            // 
            this.descriptionTxb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionTxb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionTxb.Location = new System.Drawing.Point(5, 121);
            this.descriptionTxb.Margin = new System.Windows.Forms.Padding(5);
            this.descriptionTxb.Name = "descriptionTxb";
            this.descriptionTxb.ReadOnly = true;
            this.descriptionTxb.Size = new System.Drawing.Size(429, 352);
            this.descriptionTxb.TabIndex = 5;
            this.descriptionTxb.Text = "";
            this.descriptionTxb.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.descriptionTxb_LinkClicked);
            // 
            // logoBox
            // 

            this.logoBox.Image = global::UCNLUI.Properties.Resources.UCNLLogo;
            this.logoBox.Location = new System.Drawing.Point(5, 5);
            this.logoBox.Margin = new System.Windows.Forms.Padding(5);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(283, 478);
            this.logoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoBox.TabIndex = 0;
            this.logoBox.TabStop = false;
            // 
            // logoList
            // 
            this.logoList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.logoList.ImageSize = new System.Drawing.Size(16, 16);
            this.logoList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(771, 567);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.okBtn);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.mainPanel.ResumeLayout(false);
            this.tableLayout.ResumeLayout(false);
            this.tableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Label versionLbl;
        private System.Windows.Forms.Label copyrightLbl;
        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.LinkLabel weblinkLbl;
        private System.Windows.Forms.RichTextBox descriptionTxb;
        private System.Windows.Forms.ImageList logoList;

    }
}