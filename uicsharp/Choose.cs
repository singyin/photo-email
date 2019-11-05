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
        static List<Tuple<string, double>> Base = new List<Tuple<string, double>>();
        PictureBox big_box = new PictureBox();

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
        SortedDictionary<string, bool> SLT = new SortedDictionary<string, bool>();
        void GetMatchList()
        {
            string datapath="";
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("./../../../paths/photo_collection_path.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    datapath = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
            }
            string output = "";
            //Provide script path
            string Pyname = "./../../../photo_email/camera.py";
            //string Pyname = @"./../Testing_Python/testing2.py";
            //Create Process Info
            ProcessStartInfo StartInfo = new ProcessStartInfo(Path);
            StartInfo.Arguments = $"\"{Pyname}\" " + datapath;
            //Config
            StartInfo.UseShellExecute = false;
            StartInfo.CreateNoWindow = true;
            StartInfo.RedirectStandardError = true;
            StartInfo.RedirectStandardOutput = true;
            //Execution
            using (Process pro = Process.Start(StartInfo))
            {
                output = pro.StandardOutput.ReadToEnd();
            }
            String[] kk = output.Split('\n');
            for (int i=0;i<kk.Length - 1; i++)
            {
                String[] temp = kk[i].Split(' ');
                Base.Add(new Tuple<string, double>(temp[0], Convert.ToDouble(temp[1].Remove(temp[1].Length - 8))));
            }
            if (output == null) MessageBox.Show("It seems there is no matched photo...\nThere are 2 reasons:\n1. You got no photo in the photo set :(\n2. You took the photo under insufficient lightness, inappropriate angle or strange emotion... :)", "Oops...Seems something went wrong!");
        }
        string ID;
        void SendEmail(string list)
        {
            string Pyname = "\"./../../../photo_email/mail/main.py\"";
            ProcessStartInfo StartInfo = new ProcessStartInfo('\"'+Path+'\"', Pyname + " " + list + " sy"+ID+"@syss.edu.hk");
            //Config
            StartInfo.UseShellExecute = false;
            StartInfo.CreateNoWindow = true;
            StartInfo.RedirectStandardError = false;
            StartInfo.RedirectStandardOutput = true;
            //Execution
            string output = "";
            using (Process pro = Process.Start(StartInfo))
            {
                output = pro.StandardOutput.ReadToEnd();
            }
        }
        void Ini()
        {
            for (int i = 0; i < Base.Count; i++) SLT[Base[i].Item1] = false;
            Base.OrderByDescending(pp => pp.Item2).ToList();
            for (int i = Base.Count-1; i >=0 ; i--)
            {
                SLT[Base[i].Item1] = false;
                if (Base[i].Item2 <= trackBar1.Value/20.0)
                {
                    Arr.Add(Base[i].Item1);
                }
            }
        }
        PhotoPreviewer photo_window =null;
        public Choose(string s, string id)
        {
            Path = s;
            ID = id;
            InitializeComponent();
            GetMatchList();
            Ini();
            //photo_window = new PhotoPreviewer();
        }
        int cur = 0;
        Image ban_image = new Bitmap("./../SourcePic/unavailable.png");
        void Setbrowse()
        {
            checkedListBox1.Items.Clear();
            Console.WriteLine(Arr.Count);
            for (int i = 0; i < Arr.Count; i++)
            {
                Console.WriteLine(Arr[i]);
                checkedListBox1.Items.Add(Arr[i].Substring(Arr[i].LastIndexOf('\\')+1));
                checkedListBox1.SetItemChecked(i,SLT[Arr[i]]);
            }
        }
        private void Choose_Load(object sender, EventArgs e)
        {
            confirm_button.FlatStyle = FlatStyle.Flat;
            confirm_button.FlatAppearance.BorderSize = 0;
            Setbrowse();
        }
        Image tick_image = new Bitmap("../SourcePic/Big_Tick.png");
        private void Prev_Click(object sender, EventArgs e)
        {
        }

        private void Next_Click(object sender, EventArgs e)
        {
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
                if (SLT[Arr[i]]) Arg_Py += Arr[i].Substring(0, Arr[i].Length) + ";";
            }
            if (Arg_Py.Length <= 0)
            {
                MessageBox.Show("No photo is chosen! Please choose at least 1 photo!", "No Photo Error");
                return;
            }
            DialogResult dr = MessageBox.Show(Arg_Py.Count(x => x == ';').ToString()+" photos are being sent.\n\nYou Email:\n********************\nsy" + ID + "@syss.edu.hk\n********************\n\nPlease confirm your email. I don't think you want your photos being seen by other students...", "Email Confirmation",MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
            {
                return;
            }
            Arg_Py = Arg_Py.Substring(0, Arg_Py.Length - 1);
            SendEmail(Arg_Py + " " + "sy" + ID + "@syss.edu.hk");
            MessageBox.Show("Email Sent!\nThanks for using the system!", "Notice");
        }

        private void Next_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Prev_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Choose_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

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
        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            Arr.Clear();
            cur = 0;
            for (int i = Base.Count - 1; i >= 0 ; i--)
            {
                if (Base[i].Item2 <= trackBar1.Value / 20.0)
                {
                    Arr.Add(Base[i].Item1);
                }
            }
            //label1.Text=trackBar1.Value.ToString("F");
            Setbrowse();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            new main().Show();
            this.Dispose();
        }

        private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (checkedListBox1.SelectedIndex!=-1)SLT[Arr[checkedListBox1.SelectedIndex]]^=true;
        }

        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile(Arr[checkedListBox1.SelectedIndex]);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Arr.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
                SLT[Arr[i]] = true;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Arr.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
                SLT[Arr[i]] = false;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Choose photos by Space and Up and Down arrow keys.\n2. Click on the filename to get a preview of the photo.\n3. Adjust the threshold by the scrollbar.\n4. Please confirm the email after choosing the photos.", "How to use the system?");
        }
    }
}