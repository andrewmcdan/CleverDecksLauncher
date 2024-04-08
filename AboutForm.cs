using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CleverDecksLauncher
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            linkLabel_CD_launcher_on_gh.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel_CD_launcher_on_gh_LinkClicked);
            linkLabel_CD_on_gh.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel_CD_on_gh_LinkClicked);
            linkLabel_qrcoder.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel_qrcoder_LinkClicked);
            textBox1.DeselectAll();
        }

        public void DeselecAll()
        {
            textBox1.DeselectAll();
        }

        private void linkLabel_qrcoder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "https://github.com/codebude/QRCoder/",
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

        private void linkLabel_CD_launcher_on_gh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "https://github.com/andrewmcdan/CleverDecksLauncher",
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

        private void linkLabel_CD_on_gh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "https://github.com/andrewmcdan/CleverDecks",
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
    }
}
