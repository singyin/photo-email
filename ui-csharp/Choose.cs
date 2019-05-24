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
        // For testing *** ( // before EXECUTING)
        string Path = "C:/Users/Administrator/AppData/Local/Programs/Python/Python36/python.exe";
        //***
        List<string> Arr = new List<string>();
        bool[] SLT = new bool[1001];
        void GetMatchList()
        {
            //Provide script path
            string Pyname = Directory.GetCurrentDirectory()+"/../../../photo_email/album.py";
            Pyname = Directory.GetCurrentDirectory() + "/../Testing_Python/testing.py";
            //Create Process Info
            ProcessStartInfo StartInfo = new ProcessStartInfo(Path);
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
        void SendEmail(string list)
        {
            //Provide script path
            string Pyname = Directory.GetCurrentDirectory() + "/../../../photo_email/mail/main.py";
            MessageBox.Show(Pyname);
            //Pyname= Directory.GetCurrentDirectory() + "/../../../photo_email/ui-csharp/bin/Testing_Python/testing.py";
            //Create Process Info
            ProcessStartInfo StartInfo = new ProcessStartInfo(Path,Pyname+ " " +list);
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
        void Ini()
        {
            for (int i = 0; i <= 1000; i++) SLT[i] = false;
        }
        public Choose(string s)
        {
            //Path = s;
            InitializeComponent();
            GetMatchList();
            Ini();
        }
        int cur = 0;
        void Setbrowse(int from)
        {
            if (from < Arr.Count) pictureBox1.ImageLocation = Arr[from]; else pictureBox1.ImageLocation = Directory.GetCurrentDirectory()+ "../SourcePic/unavailable.png";
            if (from+1 < Arr.Count) pictureBox2.ImageLocation = Arr[from+1]; else pictureBox2.ImageLocation = Directory.GetCurrentDirectory() + "../SourcePic/unavailable.png";
            if (from+2 < Arr.Count) pictureBox3.ImageLocation = Arr[from+2]; else pictureBox3.ImageLocation = Directory.GetCurrentDirectory() + "../SourcePic/unavailable.png";
            if (from+3 < Arr.Count) pictureBox4.ImageLocation = Arr[from+3]; else pictureBox4.ImageLocation = Directory.GetCurrentDirectory() + "../SourcePic/unavailable.png";
            if (from+4 < Arr.Count) pictureBox5.ImageLocation = Arr[from+4]; else pictureBox5.ImageLocation = Directory.GetCurrentDirectory() + "../SourcePic/unavailable.png";
            if (from+5 < Arr.Count) pictureBox6.ImageLocation = Arr[from+5]; else pictureBox6.ImageLocation = Directory.GetCurrentDirectory() + "../SourcePic/unavailable.png";
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
            if (cur * 6 >= Arr.Count) return;
            SLT[cur * 6] ^= true;
            pictureBox7.Visible = (SLT[cur*6]);
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            if (cur * 6 + 1 >= Arr.Count) return;
            SLT[cur * 6 + 1] ^= true;
            pictureBox8.Visible = (SLT[cur * 6 + 1]);
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            if (cur * 6 + 2 >= Arr.Count) return;
            SLT[cur * 6 + 2] ^= true;
            pictureBox9.Visible = (SLT[cur * 6 + 2]);
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            if (cur * 6 + 3 >= Arr.Count) return;
            SLT[cur * 6 + 3] ^= true;
            pictureBox10.Visible = (SLT[cur * 6 + 3]);
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        { 
            if (cur* 6 + 4 >= Arr.Count) return;
            SLT[cur * 6 + 4] ^= true;
            pictureBox11.Visible = (SLT[cur * 6 + 4]);
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            if (cur * 6 + 5 >= Arr.Count) return;
            SLT[cur * 6 + 5] ^= true;
            pictureBox12.Visible = (SLT[cur * 6 + 5]);
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

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            //ignore
        }

        private void Confirm_button_Click(object sender, EventArgs e)
        {
            string Arg_Py="";
            for (int i = 0; i < Arr.Count; i++)
            {
                if (SLT[i]) Arg_Py += Arr[i] + " ";
            }
            //MessageBox.Show("The chosen files:\n" + Arg_Py, "Comfirmation");
            SendEmail(Arg_Py);
            MessageBox.Show("Email Sent!", "Notice");
            this.Hide();
        }
    }
}