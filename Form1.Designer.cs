namespace FNFCoverManager
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
            button1 = new Button();
            label1 = new Label();
            songsBox = new ListBox();
            coversBox = new ListBox();
            label2 = new Label();
            currentSong = new Label();
            currentCover = new Label();
            setCoverButton = new Button();
            errorBoxLabel = new Label();
            errorBox = new RichTextBox();
            label4 = new Label();
            label5 = new Label();
            linkLabel1 = new LinkLabel();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 415);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Debug";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(448, 10);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 4;
            label1.Text = "Songs";
            // 
            // songsBox
            // 
            songsBox.FormattingEnabled = true;
            songsBox.ItemHeight = 15;
            songsBox.Location = new Point(448, 28);
            songsBox.Name = "songsBox";
            songsBox.Size = new Size(167, 409);
            songsBox.TabIndex = 5;
            songsBox.SelectedIndexChanged += songsBox_SelectedIndexChanged;
            // 
            // coversBox
            // 
            coversBox.FormattingEnabled = true;
            coversBox.ItemHeight = 15;
            coversBox.Location = new Point(621, 28);
            coversBox.Name = "coversBox";
            coversBox.Size = new Size(167, 379);
            coversBox.TabIndex = 6;
            coversBox.SelectedIndexChanged += coversBox_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(621, 10);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 7;
            label2.Text = "Covers";
            // 
            // currentSong
            // 
            currentSong.AutoSize = true;
            currentSong.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            currentSong.Location = new Point(12, 171);
            currentSong.Name = "currentSong";
            currentSong.Size = new Size(78, 21);
            currentSong.TabIndex = 8;
            currentSong.Text = "Song: ???";
            // 
            // currentCover
            // 
            currentCover.AutoSize = true;
            currentCover.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            currentCover.Location = new Point(205, 171);
            currentCover.Name = "currentCover";
            currentCover.Size = new Size(145, 21);
            currentCover.TabIndex = 9;
            currentCover.Text = "Current Cover: ???";
            // 
            // setCoverButton
            // 
            setCoverButton.Location = new Point(669, 415);
            setCoverButton.Name = "setCoverButton";
            setCoverButton.Size = new Size(75, 23);
            setCoverButton.TabIndex = 10;
            setCoverButton.Text = "Set Cover";
            setCoverButton.UseVisualStyleBackColor = true;
            setCoverButton.Click += setCoverButton_Click;
            // 
            // errorBoxLabel
            // 
            errorBoxLabel.AutoSize = true;
            errorBoxLabel.Location = new Point(12, 281);
            errorBoxLabel.Name = "errorBoxLabel";
            errorBoxLabel.Size = new Size(40, 15);
            errorBoxLabel.TabIndex = 11;
            errorBoxLabel.Text = "Errors:";
            // 
            // errorBox
            // 
            errorBox.Enabled = false;
            errorBox.Location = new Point(12, 299);
            errorBox.Name = "errorBox";
            errorBox.Size = new Size(418, 96);
            errorBox.TabIndex = 12;
            errorBox.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(12, 73);
            label4.Name = "label4";
            label4.Size = new Size(338, 42);
            label4.TabIndex = 13;
            label4.Text = "How to use:\nSelect a song, select a cover, then set cover.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 10);
            label5.Name = "label5";
            label5.Size = new Size(183, 15);
            label5.TabIndex = 14;
            label5.Text = "FNF Cover Manager by JohnBDev";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(12, 25);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(122, 15);
            linkLabel1.TabIndex = 15;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "https://johnbdev.net/";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(linkLabel1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(errorBox);
            Controls.Add(errorBoxLabel);
            Controls.Add(setCoverButton);
            Controls.Add(currentCover);
            Controls.Add(currentSong);
            Controls.Add(label2);
            Controls.Add(coversBox);
            Controls.Add(songsBox);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "FNF Cover Manager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private ListBox songsBox;
        private ListBox coversBox;
        private Label label2;
        private Label currentSong;
        private Label currentCover;
        private Button setCoverButton;
        private Label errorBoxLabel;
        private RichTextBox errorBox;
        private Label label4;
        private Label label5;
        private LinkLabel linkLabel1;
    }
}
