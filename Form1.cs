using System.Diagnostics;
using System.Windows.Forms;
using System;

namespace CleverDecksLauncher
{
    public partial class Form1 : Form
    {
        private Process nodeProcess;
        private bool isCleverDecksRunning = false;
        private string[] cl_args;
        public Form1(string[] args)
        {
            cl_args = args;
            InitializeComponent();
            InitializeSystemTrayOptions();
            InitializeReadOnlyTextArea();
            this.FormClosing += MainForm_FormClosing;
            notifyIcon1.DoubleClick += notifyIcon1_DoubleClick;
            this.Load += MainForm_Load;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
        }

        private void InitializeSystemTrayOptions()
        {
            var showOutputMenuItem = new ToolStripMenuItem("Show Log Window");
            var launchBrowserMenuItem = new ToolStripMenuItem("Launch in Browser");
            var quitMenuItem = new ToolStripMenuItem("Quit");

            showOutputMenuItem.Click += ShowOutputMenuItem_Click;
            launchBrowserMenuItem.Click += LaunchBrowserMenuItem_Click;
            quitMenuItem.Click += QuitMenuItem_Click;

            contextMenuStrip1.Items.Add(showOutputMenuItem);
            contextMenuStrip1.Items.Add(launchBrowserMenuItem);
            contextMenuStrip1.Items.Add(quitMenuItem);

            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Visible = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            LaunchNodeApp();
        }

        private void LaunchNodeApp()
        {
            var startInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
            };
            
            if (cl_args.Length == 0 && CheckFileExists("CleverDecks.exe"))
            {
                startInfo.FileName = "CleverDecks.exe";
            }
            else if (cl_args.Length == 1 && cl_args[0].EndsWith(".exe") && CheckFileExists(cl_args[0]))
            {
                startInfo.FileName = cl_args[0];
            }
            else if (cl_args.Length == 1 && cl_args[0].EndsWith(".js") && CheckFileExists(cl_args[0]))
            {
                startInfo.FileName = "node";
                startInfo.Arguments = cl_args[0];
                int lastSlash = cl_args[0].LastIndexOf('/');
                if (lastSlash == -1)
                {
                    lastSlash = cl_args[0].LastIndexOf('\\');
                }
                startInfo.WorkingDirectory = cl_args[0].Substring(0, lastSlash);
            }
            else
            {
                bool fileExists = false;
                if(cl_args.Length == 1)
                {
                    fileExists = CheckFileExists(cl_args[0]);
                }
                ShowErrorNotification("Unable to launch CleverDecks." + (fileExists?"":" Specified file does not exist."));
                Application.Exit();
            }
            var startsInfo = new ProcessStartInfo
            {
                FileName = "node",
                Arguments = "index.js",
                WorkingDirectory = "O:/Projects/CleverDecks",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
            };
            try
            {
                nodeProcess = Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                ShowErrorNotification("Unable to launch CleverDecks." + ex.Message.Substring(0,ex.Message.Length>64?64:ex.Message.Length));
                Application.Exit();
            }
            nodeProcess.OutputDataReceived += NodeProcess_OutputDataReceived;
            nodeProcess.BeginOutputReadLine();
            isCleverDecksRunning = true;

        }

        private bool CheckFileExists(string path)
        {
            // checkif path is absolute or relative
            if (System.IO.Path.IsPathRooted(path))
            {
                return System.IO.File.Exists(path);
            }
            else
            {
                // check if the file exists in the current directory
                var currentDir = System.IO.Directory.GetCurrentDirectory();
                path = System.IO.Path.Combine(currentDir, path);
                return System.IO.File.Exists(path);
            }
        }

        private void NodeProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                // Invoke the UI thread to update the TextBox
                this.Invoke(new Action(() =>
                {
                    textBox1.AppendText(e.Data + Environment.NewLine);
                    if(autoScrollCheckBox.Checked)
                    {
                        textBox1.SelectionStart = textBox1.Text.Length;
                        textBox1.ScrollToCaret();
                    }
                }));
            }
        }


        private void ShowOutputMenuItem_Click(object sender, EventArgs e)
        {
            // Implement showing the output of the Node.js app
            if (!isCleverDecksRunning)
            {
                ShowErrorNotification("CleverDecks is not running.");
                textBox1.Text = "CleverDecks is not running. This is unusual and should be fixed by restarting the launcher. If that doesn't fix the problem, try re-installing the application.";
            }
            if (this.ShowInTaskbar)
            {
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
                if (autoScrollCheckBox.Checked)
                {
                    textBox1.SelectionStart = textBox1.Text.Length;
                    textBox1.ScrollToCaret();
                }
                this.Activate();
            }

        }

        private void LaunchBrowserMenuItem_Click(object sender, EventArgs e)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "http://localhost:3000",
                UseShellExecute = true
            };
            try
            {
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                // just eat the exception, om nom nom
            }
        }

        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            nodeProcess?.Kill();
            Application.Exit();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (!isCleverDecksRunning)
            {
                ShowErrorNotification("CleverDecks is not running.");
                textBox1.Text = "CleverDecks is not running. This is unusual and should be fixed by restarting the launcher. If that doesn't fix the problem, try re-installing the application.";
            }
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void ShowErrorNotification(string errorMessage)
        {
            // Parameters are: duration in milliseconds, title, message, and icon
            notifyIcon1.ShowBalloonTip(5000, "Error Occurred", errorMessage, ToolTipIcon.Error);
        }

        private void InitializeReadOnlyTextArea()
        {
            //TextBox readOnlyTextArea = new TextBox();
            textBox1.Multiline = true; // Enable multiline
            textBox1.ReadOnly = true;  // Make it read-only
            textBox1.ScrollBars = ScrollBars.Vertical; // Add a vertical scrollbar
            textBox1.Dock = DockStyle.Fill; // Optional: Fill the parent container

            // Set the initial text (if any)
            textBox1.Text = "";

            // Add the TextBox to the form (or a specific container on the form)
            this.Controls.Add(textBox1);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
