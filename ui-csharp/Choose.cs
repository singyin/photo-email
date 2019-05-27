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
        string Path = "";
        //***
        List<string> Arr = new List<string>();
        bool[] SLT = new bool[1001];
        void GetMatchList()
        {
            //Provide script path
            string Pyname = "./../../../photo_email/album.py";
            //Pyname = "./../Testing_Python/testing.py";
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
                else
                {
                    Buffer += output[i];
                }
            }
        }
        void SendEmail(string list)
        {
            //Provide script path
            string Pyname = "./../../../photo_email/mail/main.py";
            //Pyname= "./../../../ui-csharp/bin/Testing_Python/testing2.py";
            //Create Process Info
            ProcessStartInfo StartInfo = new ProcessStartInfo(Path,Pyname+ " " +list+" "+Email.Text);
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
        }
        void Ini()
        {
            for (int i = 0; i <= 1000; i++) SLT[i] = false;
        }
        public Choose(string s)
        {
            Path = s;
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
            if (!IsValidEmail(Email.Text))
            {
                MessageBox.Show("It seems your email is invalid... Please try another email...", "Oops!");
                return;
            }
            string Arg_Py="";
            for (int i = 0; i < Arr.Count; i++)
            {
                if (SLT[i]) Arg_Py += Arr[i] + ";";
                //Console.WriteLine(Arg_Py);
            }
            if (Arg_Py.Length <= 0)
            {
                MessageBox.Show("No photo is chosen! Please choose at least 1 photo!", "No Photo Error");
                return;
            }
            Arg_Py = Arg_Py.Substring(0, Arg_Py.Length - 1);
            //MessageBox.Show("The chosen files:\n" + Arg_Py, "Comfirmation");
            SendEmail(Arg_Py);
            MessageBox.Show("Email Sent!\nThanks for using the system!", "Notice");
            this.Hide();
        }

        private void Email_TextChanged(object sender, EventArgs e)
        {

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
    }
}