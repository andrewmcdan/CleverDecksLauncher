using System.Diagnostics;
using System.Windows.Forms;
using System;
using QRCoder;
using System.Net.Http;


namespace CleverDecksLauncher
{
    public partial class Form1 : Form
    {

        private Process nodeProcess;
        private bool isCleverDecksRunning = false;
        private string[] cl_args;
        private List<string> qrCodeText = new List<string> { };
        private int qrCodeIndex = 0;
        public Form1(string[] args)
        {
            cl_args = args;
            InitializeComponent();
            InitializeSystemTrayOptions();
            InitializeReadOnlyTextArea();
            this.FormClosing += MainForm_FormClosing;
            notifyIcon1.DoubleClick += notifyIcon1_DoubleClick;
            this.Load += MainForm_Load;
            qrBox.Visible = false;

            nextAddrButton.Visible = false;
            previousAddrButton.Visible = false;
            urlTextBox.ReadOnly = true;
            urlTextBox.Visible = false;
            textBox_clickToClose.Visible = false;

            nextAddrButton.Click += NextAddrButton_Click;
            previousAddrButton.Click += PreviousAddrButton_Click;

            aboutCleverDecksLauncherToolStripMenuItem.Click += AboutCleverDecksLauncherToolStripMenuItem_Click;
            showQRCodeToolStripMenuItem.Click += ShowQRCodeMenuItem_Click;

            minimizeToTrayToolStripMenuItem.Click += MinimizeToTrayToolStripMenuItem_Click;
            exitToolStripMenuItem1.Click += QuitMenuItem_Click;

            removeLockFileOnRestartToolStripMenuItem.Click += RemoveLockFileOnRestartToolStripMenuItem_Click;

            AboutForm aboutForm = new AboutForm();
            aboutForm.Hide();
        }

        private void RemoveLockFileOnRestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create a file in the current directory to indicate that the lock file should be removed
            System.IO.File.Create("remove_lock_file_on_restart").Close();
        }

        private void MinimizeToTrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void AboutCleverDecksLauncherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void NextAddrButton_Click(object sender, EventArgs e)
        {
            if (qrCodeText.Count == 0)
            {
                ShowErrorNotification("QR Code not available. Please try again in a moment.");
                return;
            }
            if (qrCodeIndex == qrCodeText.Count - 1)
            {
                qrCodeIndex = 0;
            }
            else
            {
                qrCodeIndex++;
            }
            UpdateQrCode(qrCodeText[qrCodeIndex]);
        }

        private void PreviousAddrButton_Click(object sender, EventArgs e)
        {
            if (qrCodeText.Count == 0)
            {
                ShowErrorNotification("QR Code not available. Please try again in a moment.");
                return;
            }
            if (qrCodeIndex == 0)
            {
                qrCodeIndex = qrCodeText.Count - 1;
            }
            else
            {
                qrCodeIndex--;
            }
            UpdateQrCode(qrCodeText[qrCodeIndex]);
        }

        private void UpdateQrCode(string qrData)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q))
            using (QRCode qrCode = new QRCode(qrCodeData))
            {
                Bitmap qrCodeImage = qrCode.GetGraphic(8);
                qrBox.Image = qrCodeImage;
                qrBox.Visible = true;
                urlTextBox.Visible = true;
                urlTextBox.Text = qrData;
            }
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
            var showQRCodeMenuItem = new ToolStripMenuItem("Show QR Code");
            var quitMenuItem = new ToolStripMenuItem("Quit");

            showOutputMenuItem.Click += ShowOutputMenuItem_Click;
            launchBrowserMenuItem.Click += LaunchBrowserMenuItem_Click;
            showQRCodeMenuItem.Click += ShowQRCodeMenuItem_Click;
            quitMenuItem.Click += QuitMenuItem_Click;

            contextMenuStrip1.Items.Add(showOutputMenuItem);
            contextMenuStrip1.Items.Add(launchBrowserMenuItem);
            contextMenuStrip1.Items.Add(showQRCodeMenuItem);
            contextMenuStrip1.Items.Add(quitMenuItem);

            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Visible = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            qrBox.Click += qrBox_Click;
            LaunchNodeApp();
        }

        private void qrBox_Click(object sender, EventArgs e)
        {
            qrBox.Visible = false;
            previousAddrButton.Visible = false;
            nextAddrButton.Visible = false;
            urlTextBox.Visible = false;
            textBox_clickToClose.Visible = false;
        }

        private void LaunchNodeApp()
        {
            // check to see if the remove_lock_file_on_restart file exists
            bool removeLockFile = false;
            if (System.IO.File.Exists("remove_lock_file_on_restart"))
            {
                System.IO.File.Delete("remove_lock_file_on_restart");
                System.IO.File.Delete("lock");
                removeLockFile = true;
            }
            var startInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                RedirectStandardError = true,
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
                startInfo.ArgumentList.Add(cl_args[0]);
                if (removeLockFile)
                {
                    startInfo.ArgumentList.Add("--remove_lock");
                }
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
                if (cl_args.Length == 1)
                {
                    fileExists = CheckFileExists(cl_args[0]);
                }
                ShowErrorNotification("Unable to launch CleverDecks." + (fileExists ? "" : " Specified file does not exist."));
                Application.Exit();
            }

            try
            {
                nodeProcess = Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                ShowErrorNotification("Unable to launch CleverDecks." + ex.Message.Substring(0, ex.Message.Length > 64 ? 64 : ex.Message.Length));
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
                    if (e.Data.Contains("http://"))
                    {
                        // extract the http address from the log
                        int start = e.Data.IndexOf("http://");
                        qrCodeText.Add(e.Data.Substring(start));
                    }
                    textBox1.AppendText(e.Data + Environment.NewLine);
                    if (autoScrollCheckBox.Checked)
                    {
                        textBox1.SelectionStart = textBox1.Text.Length;
                        textBox1.ScrollToCaret();
                    }
                    if (e.Data.Contains("GET /exit") || e.Data.Contains("Goodbye!"))
                    {
                        nodeProcess.WaitForExit(10000);
                        nodeProcess?.Kill();
                        Application.Exit();
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
            if (qrCodeText.Count == 0)
            {
                ShowErrorNotification("Browser launch not available. Try again in a moment.");
                return;
            }

            var startInfo = new ProcessStartInfo
            {
                FileName = qrCodeText[qrCodeIndex],
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

        private async void QuitMenuItem_Click(object sender, EventArgs e)
        {
            if (!nodeProcess.HasExited)
            {
                nodeProcess.StandardInput.AutoFlush = true;
                nodeProcess.StandardInput.WriteLine("terminate");
                var exitUrl = qrCodeText + "/exit";
                // extract the port number from qrCodeText (http://localhost:3000/)
                string url = qrCodeText.ElementAt(qrCodeIndex);
                string port = url.Substring(url.LastIndexOf(":") + 1);
                if (port.Contains("/"))
                {
                    port = port.Substring(0, port.IndexOf('/'));
                }
                ShowErrorNotification("Exit URL: " + exitUrl);
                exitUrl = "http://localhost:" + port + "/exit";
                // create http request to exit
                try
                {
                    await new HttpClient().GetAsync(exitUrl);
                }
                catch (Exception ex)
                {
                    ShowErrorNotification("Failed to send exit request to CleverDecks.");
                }
                nodeProcess.WaitForExit(5000);
            }
            if (!nodeProcess.HasExited)
            {
                nodeProcess?.Kill();
            }
            nodeProcess.WaitForExit(5000);
            Application.Exit();
        }

        private void ShowQRCodeMenuItem_Click(object sender, EventArgs e)
        {
            if (qrCodeText.Count == 0)
            {
                ShowErrorNotification("QR Code not available. Please try again in a moment.");
            }
            else
            {
                this.ShowInTaskbar = true;
                previousAddrButton.Visible = true;
                nextAddrButton.Visible = true;
                textBox_clickToClose.Visible = true;
                qrBox.Visible = true;
                qrBox.BringToFront();
                urlTextBox.Visible = true;
                urlTextBox.BringToFront();
                nextAddrButton.BringToFront();
                previousAddrButton.BringToFront();
                this.WindowState = FormWindowState.Normal;
                UpdateQrCode(qrCodeText[qrCodeIndex]);
            }
        }

        private void ShowQRCodeButton_Click(object sender, EventArgs e)
        {
            if (qrCodeText.Count == 0)
            {
                ShowErrorNotification("QR Code not available. Please try again in a moment.");
            }
            else
            {
                if (qrBox.Visible == true)
                {
                    qrBox.Visible = false;
                    previousAddrButton.Visible = false;
                    nextAddrButton.Visible = false;
                    urlTextBox.Visible = false;
                    return;
                }
                previousAddrButton.Visible = true;
                nextAddrButton.Visible = true;
                urlTextBox.Visible = true;
                qrBox.Visible = true;
                UpdateQrCode(qrCodeText[qrCodeIndex]);
            }
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

        private void toolstripMenuItem_launchCD_Click(object sender, EventArgs e)
        {
            LaunchBrowserMenuItem_Click(sender, e);
        }
    }
}
