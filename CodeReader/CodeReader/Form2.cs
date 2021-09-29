using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeReader
{
    public partial class Form2 : Form
    {
        
        public Form2(String info, String img)
        {
            InitializeComponent();

            this.info = info;
            this.img = img;
            showInfo(info, img);

            timer1.Start();
        }
        
        String info, img;

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        public void showInfo(String info, String img)
        {

            label2.Text = info;

            //Image imgx = new Image();

            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(img);

            MemoryStream ms = new MemoryStream(bytes);
            Image im = Image.FromStream(ms);

            pictureBox1.Image = im;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form v1 = new Form1();
            v1.Show();

            this.Hide();

            //timer1.Dispose();
        }
    }
}
