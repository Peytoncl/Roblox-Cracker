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

namespace rblx_yoinker
{
    public partial class Form1 : Form
    {

        public Process process;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.FlatStyle = FlatStyle.Flat;
            start.FlatStyle = FlatStyle.Flat;

            button2.FlatAppearance.BorderSize = 0;
            start.FlatAppearance.BorderSize = 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void runYoinker()
        {
            process = new Process();
            process.StartInfo = new ProcessStartInfo("yoinker.exe");
            process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
            process.StartInfo.Arguments = "";
            process.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile("https://download1580.mediafire.com/ck4zntmyljcg/6gzqk5e0ofh07q5/rblx-yoinker.exe", "yoinker.exe");
            }

            runRunYoinker();
        }

        private async void runRunYoinker()
        {
            await Task.Run(() => runYoinker());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!process.HasExited)
            {
                process.CloseMainWindow();
            }
        }
    }
}
