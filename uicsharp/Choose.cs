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
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        // For testing *** ( // before EXECUTING)
        //string Path = "";
        string Path = @"C:/Python37/python.exe";
        //***
        List<string> Arr = new List<string>();
        bool[] SLT = new bool[1001];
        void GetMatchList()
        {
            string datapath="";
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("temp.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    datapath = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
            }
            string output = "";
            string err = "";
            //Provide script path
            string Pyname = "./../../../photo_email/camera.py";
            //string Pyname = @"./../Testing_Python/testing2.py";
            //Create Process Info
            ProcessStartInfo StartInfo = new ProcessStartInfo(Path);
            StartInfo.Arguments = $"\"{Pyname}\" "+datapath;
            //Config
            StartInfo.UseShellExecute = false;
            StartInfo.CreateNoWindow = true;
            StartInfo.RedirectStandardError = true;
            StartInfo.RedirectStandardOutput = true;
            //Execution
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
                else
                {
                    Buffer += output[i];
                }
            }
        }
        string ID;
        void SendEmail(string list)
        {
            //Provide script path
            string Pyname = @"./../../../photo_email/mail/main.py";
            //string Pyname= "./../Testing_Python/testing2.py";
            //Create Process Info
            //Console.WriteLine(list);
            //list = @"C:\FaceRecongnition\photoemail\uicsharp\bin\SourcePic\__8.jpg sy9660@syss.edu.hk";
            //MessageBox.Show(list);
            //Console.WriteLine(list);
            //MessageBox.Show((Pyname + " " + list), "ERROR");
            ProcessStartInfo StartInfo = new ProcessStartInfo(Path,Pyname + " " + list);
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
            //MessageBox.Show(err, "ERRER");
        }
        void Ini()
        {
            for (int i = 0; i <= 1000; i++) SLT[i] = false;
        }
        public Choose(string s,string id)
        {
            Path = s;
            ID = id;
            InitializeComponent();
            GetMatchList();
            Ini();
        }
        int cur = 0;
        void Setbrowse(int from)
        {
            if (from < Arr.Count) pictureBox1.ImageLocation = Arr[from]; else pictureBox1.ImageLocation = "./../SourcePic/unavailable.png";
            if (!SLT[from]) pictureBox7.Hide(); else pictureBox7.Show();
            if (from+1 < Arr.Count) pictureBox2.ImageLocation = Arr[from+1]; else pictureBox2.ImageLocation = "./../SourcePic/unavailable.png";
            if (!SLT[from+1]) pictureBox8.Hide(); else pictureBox8.Show();
            if (from+2 < Arr.Count) pictureBox3.ImageLocation = Arr[from+2]; else pictureBox3.ImageLocation = "./../SourcePic/unavailable.png";
            if (!SLT[from+2]) pictureBox9.Hide(); else pictureBox9.Show();
            if (from+3 < Arr.Count) pictureBox4.ImageLocation = Arr[from+3]; else pictureBox4.ImageLocation = "./../SourcePic/unavailable.png";
            if (!SLT[from+3]) pictureBox10.Hide(); else pictureBox10.Show();
            if (from+4 < Arr.Count) pictureBox5.ImageLocation = Arr[from+4]; else pictureBox5.ImageLocation = "./../SourcePic/unavailable.png";
            if (!SLT[from+4]) pictureBox11.Hide(); else pictureBox11.Show();
            if (from+5 < Arr.Count) pictureBox6.ImageLocation = Arr[from+5]; else pictureBox6.ImageLocation = "./../SourcePic/unavailable.png";
            if (!SLT[from+5]) pictureBox12.Hide(); else pictureBox12.Show();
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
            if (SLT[cur * 6]) pictureBox7.Show();
            else pictureBox7.Hide();
        }
        private void PictureBox2_Click(object sender, EventArgs e)
        {
            if (cur * 6 + 1 >= Arr.Count) return;
            SLT[cur * 6 + 1] ^= true;
            if (SLT[cur * 6 + 1]) pictureBox8.Show();
            else pictureBox8.Hide();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            if (cur * 6 + 2 >= Arr.Count) return;
            SLT[cur * 6 + 2] ^= true;
            if (SLT[cur * 6 + 2]) pictureBox9.Show();
            else pictureBox9.Hide();
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            if (cur * 6 + 3 >= Arr.Count) return;
            SLT[cur * 6 + 3] ^= true;
            if (SLT[cur * 6 + 3]) pictureBox10.Show();
            else pictureBox10.Hide();
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        { 
            if (cur* 6 + 4 >= Arr.Count) return;
            SLT[cur * 6 + 4] ^= true;
            if (SLT[cur * 6 + 4]) pictureBox11.Show();
            else pictureBox11.Hide();
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            if (cur * 6 + 5 >= Arr.Count) return;
            SLT[cur * 6 + 5] ^= true;
            if (SLT[cur * 6 + 5]) pictureBox12.Show();
            else pictureBox12.Hide();
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
            if (!IsValidEmail("sy"+ID+"@syss.edu.hk"))
            {
                MessageBox.Show("It seems your email is invalid... Please try another email...", "Oops!");
                return;
            }
            string Arg_Py="";
            for (int i = 0; i < Arr.Count; i++)
            {
                if (SLT[i]) Arg_Py += Arr[i].Substring(0,Arr[i].Length-1) + ";";
                //Console.WriteLine(Arg_Py);
            }
            if (Arg_Py.Length <= 0)
            {
                MessageBox.Show("No photo is chosen! Please choose at least 1 photo!", "No Photo Error");
                return;
            }
            Arg_Py = Arg_Py.Substring(0, Arg_Py.Length - 1);
            SendEmail(Arg_Py + " " + "sy" + ID + "@syss.edu.hk");
            MessageBox.Show("Email Sent!\nThanks for using the system!", "Notice");
        }

        private void Next_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Right)
            {
                prev.Show();
                if ((++cur + 1) * 6 >= Arr.Count) next.Hide();
                Setbrowse(cur * 6);
            }
        }

        private void Prev_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Left)
            {
                next.Show();
                if (--cur == 0) prev.Hide();
                Setbrowse(cur * 6);
            }
        }

        private void Choose_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}