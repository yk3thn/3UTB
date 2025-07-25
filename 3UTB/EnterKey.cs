using _3UTB.Properties;
using ColorTriggerBot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3UTB
{
    public partial class EnterKey : Form
    {
        public EnterKey()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            string correctKey = wc.DownloadString("https://pastebin.com/raw/EjpXJpCF");
            if (keyInput.Text == correctKey)
            {
                Settings.Default.key = correctKey;
                Settings.Default.Save();
                this.Hide();
                SplashScreen ss = new SplashScreen();
                ss.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Key");
            }
        }

        private void EnterKey_Load(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            string correctKey = wc.DownloadString("https://pastebin.com/raw/EjpXJpCF");
            if (Settings.Default.key == correctKey)
            {
                string cdir = Environment.CurrentDirectory;
                if(File.Exists(cdir + @"\SSBP"))
                {
                    Main form = new Main();
                    form.Show();

                    this.Shown += new EventHandler(Form1_Shown);
                }
                else
                {
                    SplashScreen ss = new SplashScreen();
                    ss.Show();

                    this.Shown += new EventHandler(Form1_Shown);
                }
            }
            else
            {

            }
        }
        private void Form1_Shown(Object sender, EventArgs e)
        {
            this.Hide();
            
        }
    }
}
