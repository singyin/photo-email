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
        string Path = "";
        List<string> Arr = new List<string>();
        List<double> Val = new List<double>();
        bool[] SLT = new bool[1001];
        void GetMatchList()
        {
            string datapath="";
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("./../../../var/photo_collection_path.txt"))
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
            //Console.WriteLine(output);
            //string output = "../SourcePic/__1.jpg\n../SourcePic/__2.jpg\n../SourcePic/__3.jpg\n../SourcePic/__4.jpg\n../SourcePic/__5.jpg\n../SourcePic/__6.jpg\n../SourcePic/__7.jpg\n../SourcePic/__8.jpg\n";
            string Buffer = "";
            for (int i = 0; i < output.Length; i++)
            {
                if (output[i] == ' ')
                {
                    Arr.Add(Buffer);
                    Buffer = "";
                }
                else if (output[i] == '\n')
                {
                    Val.Add(Double.Parse(Buffer));
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
            string Pyname = @"./../../../photo_email/mail/main.py";
            ProcessStartInfo StartInfo = new ProcessStartInfo(Path, Pyname + " " + list);
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
        public Choose(string s, string id)
        {
            Path = s;
            ID = id;
            InitializeComponent();
            pictureBox1.Controls.Add(pictureBox7);
            pictureBox7.BackColor = Color.Transparent;
            pictureBox7.Location = new Point(0, 0);
            pictureBox2.Controls.Add(pictureBox8);
            pictureBox8.BackColor = Color.Transparent;
            pictureBox8.Location = new Point(0, 0);
            pictureBox3.Controls.Add(pictureBox9);
            pictureBox9.BackColor = Color.Transparent;
            pictureBox9.Location = new Point(0, 0);
            pictureBox4.Controls.Add(pictureBox10);
            pictureBox10.BackColor = Color.Transparent;
            pictureBox10.Location = new Point(0, 0);
            pictureBox5.Controls.Add(pictureBox11);
            pictureBox11.BackColor = Color.Transparent;
            pictureBox11.Location = new Point(0, 0);
            pictureBox6.Controls.Add(pictureBox12);
            pictureBox12.BackColor = Color.Transparent;
            pictureBox12.Location = new Point(0, 0);
            GetMatchList();
            Ini();
        }
        int cur = 0;
        Image ban_image = new Bitmap("./../SourcePic/unavailable.png");
        void Setbrowse(int from)
        {
            if (from < Arr.Count) pictureBox1.ImageLocation = Arr[from];
            else
            {
                pictureBox1.BackgroundImage = ban_image;
                pictureBox1.ImageLocation = null;
            }
            if (!SLT[from]) pictureBox7.Hide(); else pictureBox7.Show();
            if (from + 1 < Arr.Count) pictureBox2.ImageLocation = Arr[from + 1];
            else
            {
                pictureBox2.BackgroundImage = ban_image;
                pictureBox2.ImageLocation = null;
            }
            if (!SLT[from + 1]) pictureBox8.Hide(); else pictureBox8.Show();
            if (from + 2 < Arr.Count) pictureBox3.ImageLocation = Arr[from + 2];
            else
            {
                pictureBox3.BackgroundImage = ban_image;
                pictureBox3.ImageLocation = null;
            }
            if (!SLT[from + 2]) pictureBox9.Hide(); else pictureBox9.Show();
            if (from + 3 < Arr.Count) pictureBox4.ImageLocation = Arr[from + 3];
            else
            {
                pictureBox4.BackgroundImage = ban_image;
                pictureBox4.ImageLocation = null;
            }
            if (!SLT[from + 3]) pictureBox10.Hide(); else pictureBox10.Show();
            if (from + 4 < Arr.Count) pictureBox5.ImageLocation = Arr[from + 4];
            else
            {
                pictureBox5.BackgroundImage = ban_image;
                pictureBox5.ImageLocation = null;
            }
            if (!SLT[from + 4]) pictureBox11.Hide(); else pictureBox11.Show();
            if (from + 5 < Arr.Count) pictureBox6.ImageLocation = Arr[from + 5];
            else
            {
                pictureBox6.BackgroundImage = ban_image;
                pictureBox6.ImageLocation = null;
            }
            if (!SLT[from + 5]) pictureBox12.Hide(); else pictureBox12.Show();
        }
        private void Choose_Load(object sender, EventArgs e)
        {
            confirm_button.FlatStyle = FlatStyle.Flat;
            confirm_button.FlatAppearance.BorderSize = 0;
            pictureBox1.SizeMode = pictureBox2.SizeMode = pictureBox3.SizeMode = pictureBox4.SizeMode = pictureBox5.SizeMode = pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            Setbrowse(0);
            prev.Hide();
            if (Arr.Count <= 6) next.Hide();
        }
        Image tick_image = new Bitmap("../SourcePic/Big_Tick.png");
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
            if (cur * 6 + 4 >= Arr.Count) return;
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
            if ((++cur + 1) * 6 >= Arr.Count) next.Hide();
            Setbrowse(cur * 6);
        }

        private void Confirm_button_Click(object sender, EventArgs e)
        {
            if (!IsValidEmail("sy" + ID + "@syss.edu.hk"))
            {
                MessageBox.Show("It seems your email is invalid... Please try another email...", "Oops!");
                return;
            }
            string Arg_Py = "";
            for (int i = 0; i < Arr.Count; i++)
            {
                if (SLT[i]) Arg_Py += Arr[i].Substring(0, Arr[i].Length - 1) + ";";
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

        private void PictureBox7_Click(object sender, EventArgs e)
        {

            if (cur * 6 >= Arr.Count) return;
            SLT[cur * 6] ^= true;
            if (SLT[cur * 6]) pictureBox7.Show();
            else pictureBox7.Hide();
        }
        private void PictureBox8_Click(object sender, EventArgs e)
        {
            if (cur * 6 + 1 >= Arr.Count) return;
            SLT[cur * 6 + 1] ^= true;
            if (SLT[cur * 6 + 1]) pictureBox8.Show();
            else pictureBox8.Hide();
        }
        private void PictureBox9_Click(object sender, EventArgs e)
        {
            if (cur * 6 + 2 >= Arr.Count) return;
            SLT[cur * 6 + 2] ^= true;
            if (SLT[cur * 6 + 2]) pictureBox9.Show();
            else pictureBox9.Hide();
        }
        private void PictureBox10_Click(object sender, EventArgs e)
        {
            if (cur * 6 + 3 >= Arr.Count) return;
            SLT[cur * 6 + 3] ^= true;
            if (SLT[cur * 6 + 3]) pictureBox10.Show();
            else pictureBox10.Hide();
        }
        private void PictureBox11_Click(object sender, EventArgs e)
        {
            if (cur * 6 + 4 >= Arr.Count) return;
            SLT[cur * 6 + 4] ^= true;
            if (SLT[cur * 6 + 4]) pictureBox11.Show();
            else pictureBox11.Hide();
        }

        private void PictureBox12_Click(object sender, EventArgs e)
        {
            if (cur * 6 + 5 >= Arr.Count) return;
            SLT[cur * 6 + 5] ^= true;
            if (SLT[cur * 6 + 5]) pictureBox12.Show();
            else pictureBox12.Hide();
        }

        private void PictureBox7_Click_1(object sender, EventArgs e){PictureBox7_Click(sender, e);}
        private void PictureBox8_Click_1(object sender, EventArgs e){PictureBox8_Click(sender, e);}
        private void PictureBox9_Click_1(object sender, EventArgs e){PictureBox9_Click(sender, e);}
        private void PictureBox10_Click_1(object sender, EventArgs e){PictureBox10_Click(sender, e);}
        private void PictureBox11_Click_1(object sender, EventArgs e){PictureBox11_Click(sender, e);}
        private void PictureBox12_Click_1(object sender, EventArgs e){PictureBox12_Click(sender, e);}

        private void PictureBox7_MouseUp(object sender, MouseEventArgs e)
        {

        }


        private void PictureBox7_MouseEnter(object sender, EventArgs e)
        {

        }

        private void PictureBox8_MouseEnter(object sender, EventArgs e)
        {

        }

        private void PictureBox9_MouseEnter(object sender, EventArgs e)
        {

        }

        private void PictureBox10_MouseEnter(object sender, EventArgs e)
        {

        }

        private void PictureBox11_MouseEnter(object sender, EventArgs e)
        {

        }

        private void PictureBox12_MouseEnter(object sender, EventArgs e)
        {

        }

        private void PictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (cur * 6 + 0 >= Arr.Count) return;
        }

        private void PictureBox1_MouseLeave(object sender, EventArgs e)
        {
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {

        }
    }
}