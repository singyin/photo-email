using System;
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
    public partial class PhotoPreviewer : Form
    {
        public PhotoPreviewer()
        {
            InitializeComponent();
        }

        private void PhotoPreviewer_Load(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.BackgroundImage = null;
        }

        public void change_photo(string path)
        {
            if (path == null) return;
            pictureBox1.BackgroundImage = new Bitmap(path);
        }
        public void clear_photo()
        {
            pictureBox1.BackgroundImage = null;
        }
        private void PhotoPreviewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
