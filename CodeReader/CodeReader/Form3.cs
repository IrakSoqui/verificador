using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeReader
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            timer1.Start();
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form v1 = new Form1();
            v1.Show();

            this.Hide();
        }
    }
}
