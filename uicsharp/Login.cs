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
        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            string defpath="";
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("default_python_path.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    defpath = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
            }
            label1.Text = defpath;
            */
            label1.Text = @"C:/Python37";
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
            bool default_valid = File.Exists(@"C:/Python37/python.exe");
            if (label1.Text == "                                                                                                                          ")
            {
                if (!default_valid)
                {
                    MessageBox.Show("You have no python installed in the default path. Please choose a new path if you didn't install it in the default path!", "Python Interpretor Unavailable");
                    return;
                }
                else
                {
                    checked_path = "C:/Python37/python.exe";
                    this.Hide();
                    new Choose(checked_path, id_from_input).Show();
                    return;
                }
            }
            else
            {
                if (!File.Exists(label1.Text + "/python.exe"))
                {
                    MessageBox.Show("The python directory has no python.exe. Please confirm the directory has one.", "Python Interpretor Unavailable");
                    return;
                }
                else
                {
                    checked_path = "C:/Python37/python.exe";
                    this.Hide();
                    new Choose(checked_path, id_from_input).Show();
                    return;
                }
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
