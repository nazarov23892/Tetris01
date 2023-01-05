
namespace Tetris01
{
    partial class AboutForm
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
            this.ui_button_OK = new System.Windows.Forms.Button();
            this.ui_label_02 = new System.Windows.Forms.Label();
            this.ui_label_01 = new System.Windows.Forms.Label();
            this.ui_label_03 = new System.Windows.Forms.Label();
            this.ui_linkLabel_Mail = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // ui_button_OK
            // 
            this.ui_button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ui_button_OK.Location = new System.Drawing.Point(252, 145);
            this.ui_button_OK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ui_button_OK.Name = "ui_button_OK";
            this.ui_button_OK.Size = new System.Drawing.Size(90, 35);
            this.ui_button_OK.TabIndex = 0;
            this.ui_button_OK.Text = "OK";
            this.ui_button_OK.UseVisualStyleBackColor = true;
            // 
            // ui_label_02
            // 
            this.ui_label_02.AutoSize = true;
            this.ui_label_02.Location = new System.Drawing.Point(18, 62);
            this.ui_label_02.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ui_label_02.Name = "ui_label_02";
            this.ui_label_02.Size = new System.Drawing.Size(119, 20);
            this.ui_label_02.TabIndex = 1;
            this.ui_label_02.Text = "Nazarov Mikhail";
            // 
            // ui_label_01
            // 
            this.ui_label_01.AutoSize = true;
            this.ui_label_01.Location = new System.Drawing.Point(18, 14);
            this.ui_label_01.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ui_label_01.Name = "ui_label_01";
            this.ui_label_01.Size = new System.Drawing.Size(114, 20);
            this.ui_label_01.TabIndex = 2;
            this.ui_label_01.Text = "TETRIS Game";
            // 
            // ui_label_03
            // 
            this.ui_label_03.AutoSize = true;
            this.ui_label_03.Location = new System.Drawing.Point(18, 82);
            this.ui_label_03.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ui_label_03.Name = "ui_label_03";
            this.ui_label_03.Size = new System.Drawing.Size(45, 20);
            this.ui_label_03.TabIndex = 3;
            this.ui_label_03.Text = "2023";
            // 
            // ui_linkLabel_Mail
            // 
            this.ui_linkLabel_Mail.AutoSize = true;
            this.ui_linkLabel_Mail.Location = new System.Drawing.Point(18, 123);
            this.ui_linkLabel_Mail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ui_linkLabel_Mail.Name = "ui_linkLabel_Mail";
            this.ui_linkLabel_Mail.Size = new System.Drawing.Size(197, 20);
            this.ui_linkLabel_Mail.TabIndex = 4;
            this.ui_linkLabel_Mail.TabStop = true;
            this.ui_linkLabel_Mail.Text = "nazarov23892@gmail.com";
            this.toolTip1.SetToolTip(this.ui_linkLabel_Mail, "copy to clipboard");
            this.ui_linkLabel_Mail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ui_linkLabel_Mail_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 198);
            this.Controls.Add(this.ui_linkLabel_Mail);
            this.Controls.Add(this.ui_label_03);
            this.Controls.Add(this.ui_label_01);
            this.Controls.Add(this.ui_label_02);
            this.Controls.Add(this.ui_button_OK);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About..";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ui_button_OK;
        private System.Windows.Forms.Label ui_label_02;
        private System.Windows.Forms.Label ui_label_01;
        private System.Windows.Forms.Label ui_label_03;
        private System.Windows.Forms.LinkLabel ui_linkLabel_Mail;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}