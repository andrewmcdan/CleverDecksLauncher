namespace CleverDecksLauncher
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            helpToolStripMenuItem = new ToolStripMenuItem();
            textBox1 = new TextBox();
            autoScrollCheckBox = new CheckBox();
            qrBox = new PictureBox();
            nextAddrButton = new Button();
            previousAddrButton = new Button();
            urlTextBox = new TextBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem1 = new ToolStripMenuItem();
            minimizeToTrayToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem1 = new ToolStripMenuItem();
            showQRCodeToolStripMenuItem = new ToolStripMenuItem();
            removeLockFileOnRestartToolStripMenuItem = new ToolStripMenuItem();
            aboutCleverDecksLauncherToolStripMenuItem = new ToolStripMenuItem();
            textBox_clickToClose = new TextBox();
            toolStripMenuItem_launchCD = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)qrBox).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "CleverDecks";
            notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(32, 19);
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Cursor = Cursors.IBeam;
            textBox1.HideSelection = false;
            textBox1.Location = new Point(1, 24);
            textBox1.MaxLength = 131071;
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(623, 358);
            textBox1.TabIndex = 1;
            // 
            // autoScrollCheckBox
            // 
            autoScrollCheckBox.AutoSize = true;
            autoScrollCheckBox.Checked = true;
            autoScrollCheckBox.CheckState = CheckState.Checked;
            autoScrollCheckBox.Location = new Point(1, 26);
            autoScrollCheckBox.Name = "autoScrollCheckBox";
            autoScrollCheckBox.Size = new Size(84, 19);
            autoScrollCheckBox.TabIndex = 2;
            autoScrollCheckBox.Text = "Auto Scroll";
            autoScrollCheckBox.UseVisualStyleBackColor = true;
            autoScrollCheckBox.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // qrBox
            // 
            qrBox.Location = new Point(155, 44);
            qrBox.Name = "qrBox";
            qrBox.Size = new Size(300, 300);
            qrBox.TabIndex = 3;
            qrBox.TabStop = false;
            // 
            // nextAddrButton
            // 
            nextAddrButton.Location = new Point(420, 321);
            nextAddrButton.Name = "nextAddrButton";
            nextAddrButton.Size = new Size(35, 23);
            nextAddrButton.TabIndex = 5;
            nextAddrButton.Text = ">";
            nextAddrButton.UseVisualStyleBackColor = true;
            // 
            // previousAddrButton
            // 
            previousAddrButton.Location = new Point(155, 321);
            previousAddrButton.Name = "previousAddrButton";
            previousAddrButton.Size = new Size(35, 23);
            previousAddrButton.TabIndex = 6;
            previousAddrButton.Text = "<";
            previousAddrButton.UseVisualStyleBackColor = true;
            // 
            // urlTextBox
            // 
            urlTextBox.BackColor = SystemColors.HighlightText;
            urlTextBox.Location = new Point(155, 344);
            urlTextBox.Name = "urlTextBox";
            urlTextBox.Size = new Size(300, 23);
            urlTextBox.TabIndex = 7;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(624, 24);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem1, minimizeToTrayToolStripMenuItem, toolStripMenuItem_launchCD });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem1
            // 
            exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            exitToolStripMenuItem1.Size = new Size(238, 22);
            exitToolStripMenuItem1.Text = "Exit";
            // 
            // minimizeToTrayToolStripMenuItem
            // 
            minimizeToTrayToolStripMenuItem.Name = "minimizeToTrayToolStripMenuItem";
            minimizeToTrayToolStripMenuItem.Size = new Size(238, 22);
            minimizeToTrayToolStripMenuItem.Text = "Minimize to Tray";
            // 
            // helpToolStripMenuItem1
            // 
            helpToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { showQRCodeToolStripMenuItem, removeLockFileOnRestartToolStripMenuItem, aboutCleverDecksLauncherToolStripMenuItem });
            helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            helpToolStripMenuItem1.Size = new Size(44, 20);
            helpToolStripMenuItem1.Text = "Help";
            // 
            // showQRCodeToolStripMenuItem
            // 
            showQRCodeToolStripMenuItem.Name = "showQRCodeToolStripMenuItem";
            showQRCodeToolStripMenuItem.Size = new Size(226, 22);
            showQRCodeToolStripMenuItem.Text = "Show QR Code";
            // 
            // removeLockFileOnRestartToolStripMenuItem
            // 
            removeLockFileOnRestartToolStripMenuItem.Name = "removeLockFileOnRestartToolStripMenuItem";
            removeLockFileOnRestartToolStripMenuItem.Size = new Size(226, 22);
            removeLockFileOnRestartToolStripMenuItem.Text = "Remove Lock File on Restart";
            // 
            // aboutCleverDecksLauncherToolStripMenuItem
            // 
            aboutCleverDecksLauncherToolStripMenuItem.Name = "aboutCleverDecksLauncherToolStripMenuItem";
            aboutCleverDecksLauncherToolStripMenuItem.Size = new Size(226, 22);
            aboutCleverDecksLauncherToolStripMenuItem.Text = "About CleverDecks Launcher";
            // 
            // textBox_clickToClose
            // 
            textBox_clickToClose.Location = new Point(155, 24);
            textBox_clickToClose.Name = "textBox_clickToClose";
            textBox_clickToClose.Size = new Size(300, 23);
            textBox_clickToClose.TabIndex = 9;
            textBox_clickToClose.Text = "Click QR to close";
            textBox_clickToClose.TextAlign = HorizontalAlignment.Center;
            // 
            // toolStripMenuItem_launchCD
            // 
            toolStripMenuItem_launchCD.Name = "toolStripMenuItem_launchCD";
            toolStripMenuItem_launchCD.Size = new Size(238, 22);
            toolStripMenuItem_launchCD.Text = "Launch CleverDecks in Browser";
            toolStripMenuItem_launchCD.Click += toolstripMenuItem_launchCD_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 381);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(textBox_clickToClose);
            Controls.Add(menuStrip1);
            Controls.Add(previousAddrButton);
            Controls.Add(nextAddrButton);
            Controls.Add(qrBox);
            Controls.Add(urlTextBox);
            Controls.Add(autoScrollCheckBox);
            Controls.Add(textBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            ShowInTaskbar = false;
            Text = "CleverDecks Launcher";
            WindowState = FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)qrBox).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox textBox1;
        private CheckBox autoScrollCheckBox;
        private PictureBox qrBox;
        private Button nextAddrButton;
        private Button previousAddrButton;
        private TextBox urlTextBox;
        private ToolStripMenuItem helpToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem1;
        private ToolStripMenuItem helpToolStripMenuItem1;
        private ToolStripMenuItem showQRCodeToolStripMenuItem;
        private ToolStripMenuItem removeLockFileOnRestartToolStripMenuItem;
        private ToolStripMenuItem aboutCleverDecksLauncherToolStripMenuItem;
        private TextBox textBox_clickToClose;
        private ToolStripMenuItem minimizeToTrayToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem_launchCD;
    }
}
