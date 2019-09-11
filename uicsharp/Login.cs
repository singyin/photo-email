using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Blackhole
{
    public partial class main : Form
    {
        public string id_from_input;
        public main()
        {
            InitializeComponent();
        }
        public string data_path = "";
        public string python_path = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("./../../../var/photo_collection_path.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    data_path = sr.ReadToEnd();
                }
            }
            catch (IOException p)
            {
                data_path = "";
            }
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("./../../../var/default_python_path.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    python_path = sr.ReadToEnd();
                }
            }
            catch (IOException p)
            {
                python_path = "";
            }
            label1.Text = python_path;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            id_from_input = textBox1.Text;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists(data_path))
            {
                MessageBox.Show("You have no face data in the default path ("+data_path+"). Please make sure you have run preloader to calculate the face encodings.", "Face Data Unavailable");
                return;
            }
            bool Valid(string s)
            {
                for (int i = 0; i < s.Length; i++) if ('0' > s[i] || s[i] > '9') return false;
                return true;
            }
            string checked_path="";
            if (!Valid(id_from_input))
            {
                MessageBox.Show("The student ID you entered is invalid, please try again", "Invalid input");
                return;
            }
            bool default_valid = File.Exists(python_path + "/python.exe");
            if (!File.Exists(label1.Text + "/python.exe"))
            {
                MessageBox.Show("The python directory has no python.exe. Please confirm the directory has one.", "Python Interpretor Unavailable");
                return;
            }
            else
            {
                checked_path = python_path + "/python.exe";
                Console.WriteLine(python_path + "/python.exe");
                this.Hide();
                new Choose(checked_path, id_from_input).Show();
                return;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            label1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Label1_TextChanged_1(object sender, EventArgs e)
        {
        }
    }
}
