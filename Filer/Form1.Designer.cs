
namespace Filer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnScan = new System.Windows.Forms.Button();
            this.chkIncludeMd5 = new System.Windows.Forms.CheckBox();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.lblFolder = new System.Windows.Forms.Label();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnScan
            // 
            this.btnScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScan.Location = new System.Drawing.Point(722, 13);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 3;
            this.btnScan.Text = "&Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // chkIncludeMd5
            // 
            this.chkIncludeMd5.AutoSize = true;
            this.chkIncludeMd5.Location = new System.Drawing.Point(58, 42);
            this.chkIncludeMd5.Name = "chkIncludeMd5";
            this.chkIncludeMd5.Size = new System.Drawing.Size(155, 19);
            this.chkIncludeMd5.TabIndex = 2;
            this.chkIncludeMd5.Text = "Include &MD5 checksums";
            this.chkIncludeMd5.UseVisualStyleBackColor = true;
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.Location = new System.Drawing.Point(58, 13);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(658, 23);
            this.txtFolder.TabIndex = 1;
            this.txtFolder.Text = "C:\\";
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(12, 17);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(40, 15);
            this.lblFolder.TabIndex = 0;
            this.lblFolder.Text = "&Folder";
            // 
            // rtbOutput
            // 
            this.rtbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbOutput.CausesValidation = false;
            this.rtbOutput.Location = new System.Drawing.Point(13, 67);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.ReadOnly = true;
            this.rtbOutput.Size = new System.Drawing.Size(784, 342);
            this.rtbOutput.TabIndex = 4;
            this.rtbOutput.Text = "";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConnectionString.Location = new System.Drawing.Point(13, 415);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(784, 23);
            this.txtConnectionString.TabIndex = 5;
            this.txtConnectionString.Text = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Filer";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 450);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.lblFolder);
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.chkIncludeMd5);
            this.Controls.Add(this.btnScan);
            this.Name = "Form1";
            this.Text = "Filer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.CheckBox chkIncludeMd5;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.TextBox txtConnectionString;
    }
}

