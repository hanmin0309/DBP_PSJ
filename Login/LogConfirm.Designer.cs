namespace EG
{
    partial class LogConfirm
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
            this.UserLogView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.UserBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.UserLogView)).BeginInit();
            this.SuspendLayout();
            // 
            // UserLogView
            // 
            this.UserLogView.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UserLogView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UserLogView.Location = new System.Drawing.Point(12, 84);
            this.UserLogView.Name = "UserLogView";
            this.UserLogView.RowTemplate.Height = 23;
            this.UserLogView.Size = new System.Drawing.Size(464, 255);
            this.UserLogView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "확인할 유저";
            // 
            // UserBox
            // 
            this.UserBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UserBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserBox.ForeColor = System.Drawing.Color.Yellow;
            this.UserBox.FormattingEnabled = true;
            this.UserBox.Location = new System.Drawing.Point(12, 41);
            this.UserBox.Name = "UserBox";
            this.UserBox.Size = new System.Drawing.Size(121, 20);
            this.UserBox.TabIndex = 2;
            this.UserBox.SelectedIndexChanged += new System.EventHandler(this.UserBox_SelectedIndexChanged);
            // 
            // LogConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(488, 386);
            this.Controls.Add(this.UserBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserLogView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LogConfirm";
            this.Text = "로그 확인";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UserLogView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView UserLogView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox UserBox;
    }
}