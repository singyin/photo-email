using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Blackhole
{
    public partial class Choose : Form
    {
        // For testing ***
        const string st = "C:/Users/Administrator/source/repos/Project Blackhole/Project Blackhole/bin/Source Pic/";
        public static string Path = "C:/Users/Administrator/AppData/Local/Programs/Python/Python36/python.exe";
        //***
        List<string> Arr = new List<string>();
        void Run()
        {
            //Provide script path
            string Pyname = "C:/Users/Administrator/source/repos/Project Blackhole/Project Blackhole/bin/Testing Python/testing.py";
            //Create Process Info
            ProcessStartInfo StartInfo = new ProcessStartInfo(Path);
            StartInfo.FileName = Path;
            StartInfo.Arguments = $"\"{Pyname}\"";
            //Config
            StartInfo.UseShellExecute = false;
            StartInfo.CreateNoWindow = true;
            StartInfo.RedirectStandardError = true;
            StartInfo.RedirectStandardOutput = true;
            //Execution
            string output = "";
            string err = "";
            using (Process pro = Process.Start(StartInfo))
            {
                err = pro.StandardError.ReadToEnd();
                output = pro.StandardOutput.ReadToEnd();
            }
            string Buffer = "";
            for (int i = 0; i < output.Length; i++)
            {
                if (output[i] == '\n')
                {
                    Arr.Add(Buffer);
                    Buffer = "";
                }
                else Buffer += output[i];
            }
        }
        public Choose(string s)
        {
            InitializeComponent();
            Run();
        }
        int cur = 0;
        void Setbrowse(int from)
        {
            if (from < Arr.Count) pictureBox1.ImageLocation = Arr[from]; else pictureBox1.ImageLocation = st + "unavailable.png";
            if (from+1 < Arr.Count) pictureBox2.ImageLocation = Arr[from+1]; else pictureBox2.ImageLocation = st + "unavailable.png";
            if (from+2 < Arr.Count) pictureBox3.ImageLocation = Arr[from+2]; else pictureBox3.ImageLocation = st + "unavailable.png";
            if (from+3 < Arr.Count) pictureBox4.ImageLocation = Arr[from+3]; else pictureBox4.ImageLocation = st + "unavailable.png";
            if (from+4 < Arr.Count) pictureBox5.ImageLocation = Arr[from+4]; else pictureBox5.ImageLocation = st + "unavailable.png";
            if (from+5 < Arr.Count) pictureBox6.ImageLocation = Arr[from+5]; else pictureBox6.ImageLocation = st + "unavailable.png";
        }
        private void Choose_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = pictureBox2.SizeMode = pictureBox3.SizeMode = pictureBox4.SizeMode = pictureBox5.SizeMode = pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            Setbrowse(0);
            prev.Hide();
            if (Arr.Count <= 6) next.Hide();
        }

        

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void Prev_Click(object sender, EventArgs e)
        {
            next.Show();
            if (--cur == 0) prev.Hide();
            Setbrowse(cur * 6);
        }

        private void Next_Click(object sender, EventArgs e)
        {
            prev.Show();
            if ((++cur+1)*6 >= Arr.Count) next.Hide();
            Setbrowse(cur * 6);
        }
    }
}
