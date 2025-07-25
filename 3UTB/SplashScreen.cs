using ColorTriggerBot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3UTB
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)

        {
            timer2.Stop();
            timer3.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
                timer3.Start();
            }
            this.Opacity += .05;

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Opacity == 0)
            {
                this.Hide();
                Main main = new Main();
                main.Show();

                timer2.Stop();
            }
            this.Opacity -= .05;
        }
        int wait = 20;
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (wait == 0)
            {
                timer3.Stop();
                timer2.Start();
            }
            else
            {
                wait -= 1;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string cdir = Environment.CurrentDirectory;
            var ssbp = File.Create(cdir + @"\SSBP");
            ssbp.Close();
        }
    }
}
