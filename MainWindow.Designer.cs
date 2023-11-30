namespace lab_2
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.NewPlaylistName = new System.Windows.Forms.TextBox();
            this.CreatePlaylistButton = new System.Windows.Forms.Button();
            this.CurrentPlaylist = new System.Windows.Forms.ListBox();
            this.CurrentPlaylistName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NewPlaylistName
            // 
            this.NewPlaylistName.Location = new System.Drawing.Point(359, 522);
            this.NewPlaylistName.Name = "NewPlaylistName";
            this.NewPlaylistName.Size = new System.Drawing.Size(272, 22);
            this.NewPlaylistName.TabIndex = 0;
            // 
            // CreatePlaylistButton
            // 
            this.CreatePlaylistButton.Location = new System.Drawing.Point(359, 550);
            this.CreatePlaylistButton.Name = "CreatePlaylistButton";
            this.CreatePlaylistButton.Size = new System.Drawing.Size(272, 37);
            this.CreatePlaylistButton.TabIndex = 1;
            this.CreatePlaylistButton.Text = "Создать плейлист";
            this.CreatePlaylistButton.UseVisualStyleBackColor = true;
            this.CreatePlaylistButton.Click += new System.EventHandler(this.CreatePlaylistButton_Click);
            // 
            // CurrentPlaylist
            // 
            this.CurrentPlaylist.FormattingEnabled = true;
            this.CurrentPlaylist.ItemHeight = 16;
            this.CurrentPlaylist.Location = new System.Drawing.Point(359, 27);
            this.CurrentPlaylist.Name = "CurrentPlaylist";
            this.CurrentPlaylist.Size = new System.Drawing.Size(272, 484);
            this.CurrentPlaylist.TabIndex = 2;
            // 
            // CurrentPlaylistName
            // 
            this.CurrentPlaylistName.AutoSize = true;
            this.CurrentPlaylistName.Location = new System.Drawing.Point(356, 8);
            this.CurrentPlaylistName.Name = "CurrentPlaylistName";
            this.CurrentPlaylistName.Size = new System.Drawing.Size(35, 16);
            this.CurrentPlaylistName.TabIndex = 3;
            this.CurrentPlaylistName.Text = "Tmp";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 599);
            this.Controls.Add(this.CurrentPlaylistName);
            this.Controls.Add(this.CurrentPlaylist);
            this.Controls.Add(this.CreatePlaylistButton);
            this.Controls.Add(this.NewPlaylistName);
            this.Name = "MainWindow";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NewPlaylistName;
        private System.Windows.Forms.Button CreatePlaylistButton;
        private System.Windows.Forms.ListBox CurrentPlaylist;
        private System.Windows.Forms.Label CurrentPlaylistName;
    }
}

