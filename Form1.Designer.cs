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
            textBox1 = new TextBox();
            autoScrollCheckBox = new CheckBox();
            qrBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)qrBox).BeginInit();
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
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Cursor = Cursors.IBeam;
            textBox1.HideSelection = false;
            textBox1.Location = new Point(1, 0);
            textBox1.MaxLength = 131071;
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(623, 314);
            textBox1.TabIndex = 1;
            // 
            // autoScrollCheckBox
            // 
            autoScrollCheckBox.AutoSize = true;
            autoScrollCheckBox.Checked = true;
            autoScrollCheckBox.CheckState = CheckState.Checked;
            autoScrollCheckBox.Location = new Point(520, -1);
            autoScrollCheckBox.Name = "autoScrollCheckBox";
            autoScrollCheckBox.Size = new Size(84, 19);
            autoScrollCheckBox.TabIndex = 2;
            autoScrollCheckBox.Text = "Auto Scroll";
            autoScrollCheckBox.UseVisualStyleBackColor = true;
            autoScrollCheckBox.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // qrBox
            // 
            qrBox.Location = new Point(155, 7);
            qrBox.Name = "qrBox";
            qrBox.Size = new Size(300, 300);
            qrBox.TabIndex = 3;
            qrBox.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 314);
            Controls.Add(qrBox);
            Controls.Add(autoScrollCheckBox);
            Controls.Add(textBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            ShowInTaskbar = false;
            Text = "CleverDecks Launcher";
            WindowState = FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)qrBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox textBox1;
        private CheckBox autoScrollCheckBox;
        private PictureBox qrBox;
    }
}
