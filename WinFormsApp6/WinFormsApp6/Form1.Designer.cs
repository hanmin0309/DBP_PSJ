namespace WinFormsApp6
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
            txtSearch = new TextBox();
            tvEmployees = new TreeView();
            btnSearch = new Button();
            btnAddFav = new Button();
            btnRemoveFav = new Button();
            lstFavorites = new ListBox();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(39, 38);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(338, 39);
            txtSearch.TabIndex = 0;
            // 
            // tvEmployees
            // 
            tvEmployees.Location = new Point(12, 148);
            tvEmployees.Name = "tvEmployees";
            tvEmployees.Size = new Size(776, 644);
            tvEmployees.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(404, 39);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(150, 46);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnAddFav
            // 
            btnAddFav.Location = new Point(901, 632);
            btnAddFav.Name = "btnAddFav";
            btnAddFav.Size = new Size(250, 46);
            btnAddFav.TabIndex = 3;
            btnAddFav.Text = "AddFav";
            btnAddFav.UseVisualStyleBackColor = true;
            btnAddFav.Click += btnAddFav_Click;
            // 
            // btnRemoveFav
            // 
            btnRemoveFav.Location = new Point(902, 707);
            btnRemoveFav.Name = "btnRemoveFav";
            btnRemoveFav.Size = new Size(249, 46);
            btnRemoveFav.TabIndex = 4;
            btnRemoveFav.Text = "RemoveFav";
            btnRemoveFav.UseVisualStyleBackColor = true;
            btnRemoveFav.Click += btnRemoveFav_Click;
            // 
            // lstFavorites
            // 
            lstFavorites.FormattingEnabled = true;
            lstFavorites.Location = new Point(818, 38);
            lstFavorites.Name = "lstFavorites";
            lstFavorites.Size = new Size(341, 548);
            lstFavorites.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1199, 804);
            Controls.Add(lstFavorites);
            Controls.Add(btnRemoveFav);
            Controls.Add(btnAddFav);
            Controls.Add(btnSearch);
            Controls.Add(tvEmployees);
            Controls.Add(txtSearch);
            Name = "Form1";
            Text = "FormContactManager";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private TreeView tvEmployees;
        private Button btnSearch;
        private Button btnAddFav;
        private Button btnRemoveFav;
        private ListBox lstFavorites;
    }
}
