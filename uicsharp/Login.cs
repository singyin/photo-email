using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            if (label1.Text == "                                                                                                    ")
            {
                MessageBox.Show("The Python interpretor path is empty! Please choose a valid path!", "Invalid input");
            }
            else if (!File.Exists(label1.Text + "/python.exe"))
            {
                MessageBox.Show("The Python interpretor path is invalid! Please choose a valid path!", "Invalid input");
            }
            else if (textBox1.Text == "")return;
            else if (!Valid(id_from_input))
            {
                MessageBox.Show("The student ID you entered is invalid, please try again", "Invalid input");
            }
            else 
            {
                this.Hide();
                new Choose(label1.Text+"/python.exe",id_from_input).Show();
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
