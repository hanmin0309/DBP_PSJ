namespace EG
{
    partial class SearchComment
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
            this.SenderBox = new System.Windows.Forms.ComboBox();
            this.ReceiverBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.MessageList = new System.Windows.Forms.ListBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label3 = new System.Windows.Forms.Label();
            this.KeyWord = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SenderBox
            // 
            this.SenderBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SenderBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SenderBox.ForeColor = System.Drawing.Color.Yellow;
            this.SenderBox.FormattingEnabled = true;
            this.SenderBox.Location = new System.Drawing.Point(28, 58);
            this.SenderBox.Name = "SenderBox";
            this.SenderBox.Size = new System.Drawing.Size(121, 20);
            this.SenderBox.TabIndex = 0;
            this.SenderBox.SelectedIndexChanged += new System.EventHandler(this.SenderBox_SelectedIndexChanged);
            // 
            // ReceiverBox
            // 
            this.ReceiverBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ReceiverBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReceiverBox.ForeColor = System.Drawing.Color.Yellow;
            this.ReceiverBox.FormattingEnabled = true;
            this.ReceiverBox.Location = new System.Drawing.Point(185, 58);
            this.ReceiverBox.Name = "ReceiverBox";
            this.ReceiverBox.Size = new System.Drawing.Size(121, 20);
            this.ReceiverBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(26, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "보낸사람";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(183, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "받는사람";
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchButton.ForeColor = System.Drawing.Color.Yellow;
            this.SearchButton.Location = new System.Drawing.Point(379, 339);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(100, 114);
            this.SearchButton.TabIndex = 4;
            this.SearchButton.Text = "검색";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // MessageList
            // 
            this.MessageList.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MessageList.ForeColor = System.Drawing.Color.Yellow;
            this.MessageList.FormattingEnabled = true;
            this.MessageList.ItemHeight = 12;
            this.MessageList.Location = new System.Drawing.Point(28, 97);
            this.MessageList.Name = "MessageList";
            this.MessageList.Size = new System.Drawing.Size(278, 388);
            this.MessageList.TabIndex = 5;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.monthCalendar1.ForeColor = System.Drawing.Color.Yellow;
            this.monthCalendar1.Location = new System.Drawing.Point(333, 55);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 6;
            this.monthCalendar1.TitleBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.monthCalendar1.TitleForeColor = System.Drawing.Color.Yellow;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(331, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "날짜 선택";
            // 
            // KeyWord
            // 
            this.KeyWord.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.KeyWord.ForeColor = System.Drawing.Color.Yellow;
            this.KeyWord.Location = new System.Drawing.Point(333, 278);
            this.KeyWord.Name = "KeyWord";
            this.KeyWord.Size = new System.Drawing.Size(227, 21);
            this.KeyWord.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(331, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "키워드";
            // 
            // Date
            // 
            this.Date.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Date.ForeColor = System.Drawing.Color.Yellow;
            this.Date.Location = new System.Drawing.Point(333, 225);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(227, 21);
            this.Date.TabIndex = 10;
            // 
            // SearchComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(587, 521);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.KeyWord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.MessageList);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReceiverBox);
            this.Controls.Add(this.SenderBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SearchComment";
            this.Text = "대화 검색";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SenderBox;
        private System.Windows.Forms.ComboBox ReceiverBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.ListBox MessageList;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox KeyWord;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Date;
    }
}