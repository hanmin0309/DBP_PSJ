namespace Login
{
    partial class MultiProfileForm
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
            TB_DisplayName = new TextBox();
            label1 = new Label();
            PB_Override = new PictureBox();
            label2 = new Label();
            btnSelectImage = new Button();
            btnSave = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)PB_Override).BeginInit();
            SuspendLayout();
            // 
            // TB_DisplayName
            // 
            TB_DisplayName.Location = new Point(86, 331);
            TB_DisplayName.Name = "TB_DisplayName";
            TB_DisplayName.Size = new Size(222, 23);
            TB_DisplayName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(86, 313);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 1;
            label1.Text = "멀티프로필 이름";
            // 
            // PB_Override
            // 
            PB_Override.BackColor = Color.DarkGray;
            PB_Override.Location = new Point(86, 52);
            PB_Override.Name = "PB_Override";
            PB_Override.Size = new Size(222, 188);
            PB_Override.SizeMode = PictureBoxSizeMode.StretchImage;
            PB_Override.TabIndex = 2;
            PB_Override.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(86, 34);
            label2.Name = "label2";
            label2.Size = new Size(95, 15);
            label2.TabIndex = 3;
            label2.Text = "멀티프로필 사진";
            // 
            // btnSelectImage
            // 
            btnSelectImage.BackColor = Color.FromArgb(88, 101, 242);
            btnSelectImage.FlatStyle = FlatStyle.Popup;
            btnSelectImage.ForeColor = SystemColors.ButtonFace;
            btnSelectImage.Location = new Point(233, 246);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.Size = new Size(75, 23);
            btnSelectImage.TabIndex = 4;
            btnSelectImage.Text = "사진 선택";
            btnSelectImage.UseVisualStyleBackColor = false;
            btnSelectImage.Click += btnSelectImage_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(88, 101, 242);
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.ForeColor = SystemColors.ButtonFace;
            btnSave.Location = new Point(233, 415);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 5;
            btnSave.Text = "저장";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(88, 101, 242);
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.ForeColor = SystemColors.ButtonFace;
            btnClose.Location = new Point(314, 415);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 6;
            btnClose.Text = "닫기";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // MultiProfileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(57, 58, 65);
            ClientSize = new Size(401, 450);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(btnSelectImage);
            Controls.Add(label2);
            Controls.Add(PB_Override);
            Controls.Add(label1);
            Controls.Add(TB_DisplayName);
            Name = "MultiProfileForm";
            Text = "MultiProfileForm";
            Load += MultiProfileForm_Load;
            ((System.ComponentModel.ISupportInitialize)PB_Override).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TB_DisplayName;
        private Label label1;
        private PictureBox PB_Override;
        private Label label2;
        private Button btnSelectImage;
        private Button btnSave;
        private Button btnClose;
    }
}