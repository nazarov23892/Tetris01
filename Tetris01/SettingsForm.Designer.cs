
namespace Tetris01
{
    partial class SettingsForm
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
            this.ui_Label_ShowPlane = new System.Windows.Forms.Label();
            this.ui_checkBox_ShowPlane = new System.Windows.Forms.CheckBox();
            this.ui_OkButton = new System.Windows.Forms.Button();
            this.ui_CancelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_Label_ShowPlane
            // 
            this.ui_Label_ShowPlane.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ui_Label_ShowPlane.AutoSize = true;
            this.ui_Label_ShowPlane.Location = new System.Drawing.Point(3, 20);
            this.ui_Label_ShowPlane.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.ui_Label_ShowPlane.Name = "ui_Label_ShowPlane";
            this.ui_Label_ShowPlane.Size = new System.Drawing.Size(95, 13);
            this.ui_Label_ShowPlane.TabIndex = 3;
            this.ui_Label_ShowPlane.Text = "Show figure plane:";
            // 
            // ui_checkBox_ShowPlane
            // 
            this.ui_checkBox_ShowPlane.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ui_checkBox_ShowPlane.AutoSize = true;
            this.ui_checkBox_ShowPlane.Location = new System.Drawing.Point(104, 22);
            this.ui_checkBox_ShowPlane.Name = "ui_checkBox_ShowPlane";
            this.ui_checkBox_ShowPlane.Size = new System.Drawing.Size(15, 14);
            this.ui_checkBox_ShowPlane.TabIndex = 6;
            this.ui_checkBox_ShowPlane.UseVisualStyleBackColor = true;
            // 
            // ui_OkButton
            // 
            this.ui_OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ui_OkButton.Location = new System.Drawing.Point(138, 85);
            this.ui_OkButton.Name = "ui_OkButton";
            this.ui_OkButton.Size = new System.Drawing.Size(60, 23);
            this.ui_OkButton.TabIndex = 0;
            this.ui_OkButton.Text = "OK";
            this.ui_OkButton.UseVisualStyleBackColor = true;
            // 
            // ui_CancelButton
            // 
            this.ui_CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ui_CancelButton.Location = new System.Drawing.Point(138, 114);
            this.ui_CancelButton.Name = "ui_CancelButton";
            this.ui_CancelButton.Size = new System.Drawing.Size(60, 23);
            this.ui_CancelButton.TabIndex = 1;
            this.ui_CancelButton.Text = "Cancel";
            this.ui_CancelButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.ui_Label_ShowPlane, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_checkBox_ShowPlane, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(151, 39);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 149);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ui_CancelButton);
            this.Controls.Add(this.ui_OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings..";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label ui_Label_ShowPlane;
        private System.Windows.Forms.CheckBox ui_checkBox_ShowPlane;
        private System.Windows.Forms.Button ui_OkButton;
        private System.Windows.Forms.Button ui_CancelButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}