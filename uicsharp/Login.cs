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
            Trace.Listeners.Add(new TextWriterTraceListener("../ErrorLog/errorlog"+DateTime.Now.ToString().Replace(' ','_')+".txt"));
            Trace.AutoFlush = true;
            Trace.Indent();
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
            bool default_valid = File.Exists("C:/Python37/python.exe");
            if (default_valid)
            {
                this.Hide();
                if (File.Exists("C:/Python37/python.exe")) checked_path = "C:/Python37/python.exe";
                new Choose(checked_path, id_from_input).Show();
                return;
            }
            else if (!default_valid && label1.Text== "                                                                                                                          ")
            {
                MessageBox.Show("You have no python installed in the default path. Please choose a new path if you didn't install it in the default path!", "Python Interpretor Unavailable");
                return;
            }
            else if (!default_valid && File.Exists(label1.Text+"/python.exe"))
            {
                MessageBox.Show("The python directory has no python.exe. Please confirm the directory has one.", "Python Interpretor Unavailable");
                return;
            }
            else
            {
                MessageBox.Show("Unknown error. Please check debug log for more infomation or choose a correct path.", "Unknown error.");
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
            if (String.IsNullOrEmpty(label1.Text))label1.Text = "                                                                                                                          ";
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
