namespace _3UTB
{
    partial class EnterKey
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox2 = new PictureBox();
            keyInput = new TextBox();
            label2 = new Label();
            button17 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = Properties.Resources._3utbx;
            pictureBox2.Location = new Point(151, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 30);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 35;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // keyInput
            // 
            keyInput.BackColor = Color.Black;
            keyInput.Font = new Font("Consolas", 20F);
            keyInput.ForeColor = Color.White;
            keyInput.Location = new Point(12, 56);
            keyInput.Name = "keyInput";
            keyInput.PlaceholderText = "Type Here";
            keyInput.Size = new Size(169, 39);
            keyInput.TabIndex = 36;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Consolas", 15F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 15);
            label2.Name = "label2";
            label2.Size = new Size(120, 23);
            label2.TabIndex = 37;
            label2.Text = "Enter Key:";
            // 
            // button17
            // 
            button17.Cursor = Cursors.Hand;
            button17.FlatStyle = FlatStyle.Flat;
            button17.Font = new Font("Consolas", 12F);
            button17.ForeColor = Color.White;
            button17.Location = new Point(12, 101);
            button17.Name = "button17";
            button17.RightToLeft = RightToLeft.Yes;
            button17.Size = new Size(169, 31);
            button17.TabIndex = 38;
            button17.Text = "ENTER";
            button17.UseVisualStyleBackColor = true;
            button17.Click += button17_Click;
            // 
            // EnterKey
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(193, 144);
            Controls.Add(button17);
            Controls.Add(label2);
            Controls.Add(keyInput);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EnterKey";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EnterKey";
            Load += EnterKey_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private TextBox keyInput;
        private Label label2;
        private Button button17;
    }
}