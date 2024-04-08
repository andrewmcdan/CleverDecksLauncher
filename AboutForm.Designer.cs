namespace CleverDecksLauncher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            textBox1 = new TextBox();
            linkLabel_CD_launcher_on_gh = new LinkLabel();
            linkLabel_CD_on_gh = new LinkLabel();
            pictureBox1 = new PictureBox();
            linkLabel_qrcoder = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Control;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(1, -3);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(385, 293);
            textBox1.TabIndex = 0;
            textBox1.Text = "CleverDecks Launcher\r\nCreated by Andrew McDaniel\r\n\r\nLicense: AGPL 3.0\r\n\r\nThis software makes us of QRCoder\r\nby Rafael Herrmann";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // linkLabel_CD_launcher_on_gh
            // 
            linkLabel_CD_launcher_on_gh.AutoSize = true;
            linkLabel_CD_launcher_on_gh.Location = new Point(90, 174);
            linkLabel_CD_launcher_on_gh.Name = "linkLabel_CD_launcher_on_gh";
            linkLabel_CD_launcher_on_gh.Size = new Size(206, 15);
            linkLabel_CD_launcher_on_gh.TabIndex = 1;
            linkLabel_CD_launcher_on_gh.TabStop = true;
            linkLabel_CD_launcher_on_gh.Text = "CleverDecks Launcher on Github.com";
            // 
            // linkLabel_CD_on_gh
            // 
            linkLabel_CD_on_gh.AutoSize = true;
            linkLabel_CD_on_gh.Location = new Point(116, 189);
            linkLabel_CD_on_gh.Name = "linkLabel_CD_on_gh";
            linkLabel_CD_on_gh.Size = new Size(154, 15);
            linkLabel_CD_on_gh.TabIndex = 2;
            linkLabel_CD_on_gh.TabStop = true;
            linkLabel_CD_on_gh.Text = "CleverDecks on Github.com";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(56, 207);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(274, 153);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // linkLabel_qrcoder
            // 
            linkLabel_qrcoder.AutoSize = true;
            linkLabel_qrcoder.Location = new Point(138, 145);
            linkLabel_qrcoder.Name = "linkLabel_qrcoder";
            linkLabel_qrcoder.Size = new Size(111, 15);
            linkLabel_qrcoder.TabIndex = 4;
            linkLabel_qrcoder.TabStop = true;
            linkLabel_qrcoder.Text = "QRCoder on Github";
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            Controls.Add(linkLabel_qrcoder);
            Controls.Add(pictureBox1);
            Controls.Add(linkLabel_CD_on_gh);
            Controls.Add(linkLabel_CD_launcher_on_gh);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AboutForm";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "About CleverDecks Launcher";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private LinkLabel linkLabel_CD_launcher_on_gh;
        private LinkLabel linkLabel_CD_on_gh;
        private PictureBox pictureBox1;
        private LinkLabel linkLabel_qrcoder;
    }
}