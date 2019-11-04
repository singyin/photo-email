using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Web;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(label1.Text))
            {
                label1.Text = "";
            }
        }
        string path;
        private void Button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            path = folderBrowserDialog1.SelectedPath;
            label1.Text = path;
        }
        private void passArg(string arg)
        {
            string datapath = "";
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("../../../../../paths/default_python_path.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    datapath = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
            }
            ProcessStartInfo StartInfo = new ProcessStartInfo(datapath+"/python.exe", "../../../../../photo_email/preload.py"+" "+arg);
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
            if (err != "")
            {
                MessageBox.Show("Oops... Something's wrong in the preloader.py, please check the validity of your folder!","ERROR");
                Console.WriteLine(err);
                Application.Exit();
            }
        }
        void remove_space(string path)
        {
            string datapath = "";
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("../../../../../paths/default_python_path.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    datapath = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
            }
            ProcessStartInfo StartInfo = new ProcessStartInfo(datapath + "/python.exe", "../../../../../remove_spaces.py" + " " + path);
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
            if (err != "")
            {
                MessageBox.Show("Oops... Something's wrong in the remove_spaces.py, please check the validity of your directory!", "ERROR");
                Console.WriteLine(err);
                Application.Exit();
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(path))
            {
                MessageBox.Show("The path you provide is incorrect","Alert");
                return;
            }
            remove_space(path);
            passArg(path);
            MessageBox.Show("Photos set is compiled! Thanks for using the system!");
            using (FileStream fs = new FileStream("./temp.txt", FileMode.OpenOrCreate))
            {
                using (TextWriter tw = new StreamWriter(fs))
                {
                    tw.WriteLine(path);
                }
            }
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Label1_TextChanged_1(object sender, EventArgs e)
        {
            path = label1.Text;
        }
    }
}
