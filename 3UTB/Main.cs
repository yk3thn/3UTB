using _3UTB;
using System.Diagnostics;
using System.Drawing.Text;
using System.Net;
using System.Runtime.InteropServices;

namespace ColorTriggerBot
{
    public partial class Main : Form
    {
        bool mouseDown;
        private Point offset;

        #region Imports
        [DllImport("user32.dll")]

        static extern short GetAsyncKeyState(Keys vKey);

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int x, int y, uint dwData, IntPtr dwExtraInfo);

        #endregion

        #region Class variables

        const uint LEFTDOWN = 0x02;
        const uint LEFTUP = 0x04;

        Keys hotkey = Keys.F;

        #endregion

        public Main()
        {
            InitializeComponent();
        }

        #region Application logic 


        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = ColorTranslator.FromHtml(enemyColorInput.Text);
            fov = fovSlider.Value;
            CalculateCoordinates(fov);

        }

        int enemyColor;
        int xloc1;
        int yloc1;
        int xloc2;
        int yloc2;
        void BackgroundLogic()
        {

            while (true)
            {
                if (KeyPressed(hotkey))
                {
                    if (ColorSearch(ConvertIntToColor(enemyColor), xloc1, yloc1, xloc2, yloc2))
                    {
                        Thread.Sleep(delayInt);
                        MessageBox.Show("detected at " + xloc1.ToString() + ", " + yloc1.ToString() + ", " + xloc2.ToString() + ", " + yloc2.ToString());
                        //PerformClick(960, 540);
                    }
                }
                Thread.Sleep(10);
            }

        }

        #endregion

        #region Color methods 
        Color ConvertIntToColor(int intColor)
        {
            int red = (intColor >> 16) & 0xFF;
            int green = (intColor >> 8) & 0xFF;
            int blue = intColor & 0xFF;
            return Color.FromArgb(red, green, blue);
        }

        bool ColorSearch(Color wantedColor, int x1, int y1, int x2, int y2)
        {
            using (Bitmap screenshot = new Bitmap(x2 - x1, y2 - y1))
            {
                using (Graphics g = Graphics.FromImage(screenshot))
                {
                    g.CopyFromScreen(new Point(x1, y1), Point.Empty, screenshot.Size);

                    for (int x = 0; x < screenshot.Width; x++)
                    {
                        for (int y = 0; y < screenshot.Height; y++)
                        {
                            Color pixelColor = screenshot.GetPixel(x, y);

                            if (AreColorsClose(wantedColor, pixelColor, strength))
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
            }
        }
        bool AreColorsClose(Color color1, Color color2, int maxColorDifference)
        {
            int redDiff = Math.Abs(color1.R - color2.R);
            int greenDiff = Math.Abs(color1.G - color2.G);
            int blueDiff = Math.Abs(color1.B - color2.B);
            return redDiff <= maxColorDifference && greenDiff <= maxColorDifference && blueDiff <= maxColorDifference;
        }
        #endregion

        #region Import methods 
        int delayInt;
        void PerformClick(int x, int y)
        {
            Int32.TryParse(delayInput.Text, out delayInt);
            Thread.Sleep(delayInt);
            mouse_event(LEFTDOWN, x, y, 0, IntPtr.Zero);
            Thread.Sleep(2);
            mouse_event(LEFTUP, x, y, 0, IntPtr.Zero);
        }

        bool KeyPressed(Keys vKey)
        {
            return GetAsyncKeyState(vKey) < 0;
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            updateSettings();
            Thread th = new Thread(BackgroundLogic) { IsBackground = true };
            th.Start();

        }

        private void updateSettings()
        {
            WebClient version = new WebClient();
            string ver = version.DownloadString("https://pastebin.com/raw/ucn25gfm");
            int strengthInt;
            Int32.TryParse(strengthInput.Text, out strengthInt);
            strength = strengthInt;
            fov = fovSlider.Value;
            settings.Text =
                  "-Settings-" +
                "\nHotkey: " + hotkey +
                "\nEnemy Color: " + enemyColorInput.Text +
                "\nDelay: " + delayInput.Text +
                "\nFOV: " + fov +
                "\nStrength: " + strength.ToString() +
                "\n3UTB Version: " + ver;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            clearButtons();
            buttonq.BackColor = ColorTranslator.FromHtml("#0078D7");
            hotkey = Keys.Q;
            updateSettings();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            clearButtons();
            buttont.BackColor = ColorTranslator.FromHtml("#0078D7");
            hotkey = Keys.T;
            updateSettings();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clearButtons();
            buttonz.BackColor = ColorTranslator.FromHtml("#0078D7");
            hotkey = Keys.Z;
            updateSettings();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            clearButtons();
            buttonx.BackColor = ColorTranslator.FromHtml("#0078D7");
            hotkey = Keys.X;
            updateSettings();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            clearButtons();
            buttonc.BackColor = ColorTranslator.FromHtml("#0078D7");
            hotkey = Keys.C;
            updateSettings();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            clearButtons();
            buttonv.BackColor = ColorTranslator.FromHtml("#0078D7");
            hotkey = Keys.V;
            updateSettings();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            clearButtons();
            buttonf.BackColor = ColorTranslator.FromHtml("#0078D7");
            hotkey = Keys.F;
            updateSettings();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clearButtons();
            buttonrmb.BackColor = ColorTranslator.FromHtml("#0078D7");
            hotkey = Keys.RButton;
            updateSettings();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clearButtons();
            buttonshift.BackColor = ColorTranslator.FromHtml("#0078D7");
            hotkey = Keys.LShiftKey;
            updateSettings();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            clearButtons();
            buttoncapslock.BackColor = ColorTranslator.FromHtml("#0078D7");
            hotkey = Keys.CapsLock;
            updateSettings();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            clearButtons();
            buttonspace.BackColor = ColorTranslator.FromHtml("#0078D7");
            hotkey = Keys.Space;
            updateSettings();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            clearButtons();
            buttonmb4.BackColor = ColorTranslator.FromHtml("#0078D7");
            hotkey = Keys.XButton1;
            updateSettings();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            clearButtons();
            buttonmb5.BackColor = ColorTranslator.FromHtml("#0078D7");
            hotkey = Keys.XButton2;
            updateSettings();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            clearButtons();
            buttonlctrl.BackColor = ColorTranslator.FromHtml("#0078D7");
            hotkey = Keys.LControlKey;
            updateSettings();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            clearButtons();
            buttonalt.BackColor = ColorTranslator.FromHtml("#0078D7");
            hotkey = Keys.Alt;
            updateSettings();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            clearButtons();
            buttontab.BackColor = ColorTranslator.FromHtml("#0078D7");
            hotkey = Keys.Tab;
            updateSettings();
        }
        int convertedInteger;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                panel1.BackColor = ColorTranslator.FromHtml(enemyColorInput.Text);
                Int32.TryParse(convert(enemyColorInput.Text), out convertedInteger);
                enemyColor = convertedInteger;
                updateSettings();
            }
            catch (Exception ex)
            {

            }

        }


        public static string convert(string enemyColor)
        {
            return "0x" + enemyColor.Substring(1);
        }
        public static string deconvert(string enemyColor)
        {
            return "#" + enemyColor.Substring(2);
        }
        int fov;

        private void button18_Click(object sender, EventArgs e)
        {
            xloc1 = 950;
            yloc1 = 530;
            xloc2 = 970;
            yloc2 = 540;
            //fov = "10";
            updateSettings();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            xloc1 = 930;
            yloc1 = 510;
            xloc2 = 990;
            yloc2 = 570;
            //fov = "30";
            updateSettings();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            xloc1 = 900;
            yloc1 = 480;
            xloc2 = 1020;
            yloc2 = 600;
            //fov = "60";
            updateSettings();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            xloc1 = 870;
            yloc1 = 450;
            xloc2 = 1050;
            yloc2 = 630;
            //fov = "90";
            updateSettings();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
                Thread.Sleep(7);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button15_MouseHover(object sender, EventArgs e)
        {
            //this.BackColor = Color.White;
            //this.ForeColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            //this.BackColor = Color.Black;
            //this.ForeColor = Color.White;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Blue;
            button1.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.White;
        }

        private void delayInput_TextChanged(object sender, EventArgs e)
        {
            updateSettings();
        }

        int strength;

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                int fovInt;
                Int32.TryParse(strengthInput.Text, out fovInt);
                strengthSlider.Value = fovInt;
                updateSettings();
            }
            catch (Exception ex)
            {

            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            strengthInput.Text = strengthSlider.Value.ToString();
            updateSettings();
        }

        private void fovSlider_Scroll(object sender, EventArgs e)
        {
            fovDisplay.Text = fovSlider.Value.ToString();

            CalculateCoordinates(fov);
            updateSettings();

        }
        private void CalculateCoordinates(int fov)
        {
            int screenCenterX = 960;
            int screenCenterY = 540;

            xloc1 = screenCenterX - fov;
            yloc1 = screenCenterY - fov;

            xloc2 = screenCenterX + fov;
            yloc2 = screenCenterY + fov;
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                Color chosenColor = colorDialog1.Color;
                string hexColor = $"#{chosenColor.R:X2}{chosenColor.G:X2}{chosenColor.B:X2}";

                enemyColorInput.Text = hexColor;
                updateSettings();
            }
        }

        private void clearButtons()
        {
            buttonq.BackColor = Color.Black;
            buttont.BackColor = Color.Black;
            buttonz.BackColor = Color.Black;
            buttonx.BackColor = Color.Black;
            buttonc.BackColor = Color.Black;
            buttonv.BackColor = Color.Black;
            buttonf.BackColor = Color.Black;
            buttonlctrl.BackColor = Color.Black;
            buttonrmb.BackColor = Color.Black;
            buttonshift.BackColor = Color.Black;
            buttoncapslock.BackColor = Color.Black;
            buttonalt.BackColor = Color.Black;
            buttonspace.BackColor = Color.Black;
            buttonmb4.BackColor = Color.Black;
            buttonmb5.BackColor = Color.Black;
            buttontab.BackColor = Color.Black;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string cdir = Environment.CurrentDirectory;
            Process.Start(cdir + @"\run.bat");
            Application.Exit();
        }
    }
}