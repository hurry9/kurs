

namespace example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int hp=10;
        string word;
        char[] secret_word;
        bool right = false;
        private void button1_Click(object sender, EventArgs e)
        {
            hp = 10;
            label1.Text = null;
            string str = "јЅ¬√ƒ≈∆«»… ЋћЌќѕ–—“”‘’÷„ЎўЏџ№Ёёя";
            for (int i = 0; i < 32; i++)
            {
                Button button = new Button();                                                
                button.Text = str[i] + "";
                button.Click += ButtonOnClick;
                button.Size = new Size(25, 25);
                button.TabStop = false;
                flowLayoutPanel1.Controls.Add(button);
                
            }
            word = textBox1.Text.ToUpper();
            secret_word = new char[word.Length];
            for (int i = 0; i < secret_word.Length; i++)
            {
                if (i == 0)
                {
                    label1.Text += word[i];
                    secret_word[i] = word[i];
                    continue;
                }
                else if (i == secret_word.Length - 1)
                {
                    label1.Text += word[i];
                    secret_word[i] = word[i];
                    continue;
                }
                label1.Text += '-';
                secret_word[i] = '-';
                label2.Text=hp.ToString();
            }
            pictureBox1.Image = null;
            textBox1.Text = null;
            textBox1.Visible = false;
            button1.Visible = false;
            label3.Visible = true;
            label2.Visible = true;

        }
        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;

            for (int i = 0; i < word.Length; i++)
            {
                if (char.Parse(button.Text) == word[i])
                {
                    right = true;
                    secret_word[i] = word[i];
                    label1.Text = null;
                }
            }

            if (right == true)
            {

                for (int i = 0; i < secret_word.Length; i++)
                {
                    label1.Text += secret_word[i];
                }
                button.Enabled = false;
            }
            if (right == false)
            {
                button.Enabled = false;
                hp = hp - 1;
                losehp(hp);
            }
            if (label1.Text == word)
            {
                MessageBox.Show("¬ы выйграли! —лово " + word);
                label1.Text = "ƒл€ начала игры введите слово!";
                pictureBox1.Image = null;
                flowLayoutPanel1.Controls.Clear();
                button1.Enabled = true;
                button1.Visible = true;
                textBox1.Visible = true;
                label3.Visible = false;
                label2.Visible = false;
            }
            right= false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 3) 
            {
                button1.Enabled= false;
            }
        }

        void losehp(int a) {
            
            label2.Text = a.ToString();
            if (a == 10) pictureBox1.Image = Properties.Resources._1;
            if (a == 9) pictureBox1.Image = Properties.Resources._2;
            if (a == 8) pictureBox1.Image = Properties.Resources._3;
            if (a == 7) pictureBox1.Image = Properties.Resources._4;
            if (a == 6) pictureBox1.Image = Properties.Resources._5;
            if (a == 5) pictureBox1.Image = Properties.Resources._6;
            if (a == 4) pictureBox1.Image = Properties.Resources._7;
            if (a == 3) pictureBox1.Image = Properties.Resources._8;
            if (a == 2) pictureBox1.Image = Properties.Resources._9;
            if (a == 1) {
                pictureBox1.Image = Properties.Resources._10;
                flowLayoutPanel1.Controls.Clear();
                button1.Enabled = true;
                button1.Visible= true;
                textBox1.Visible= true;
                label3.Visible= false;
                label2.Visible= false;
                MessageBox.Show("¬ы выйграли! —лово " + word);
                label1.Text = "ƒл€ начала игры введите слово!";
                pictureBox1.Image = null;
            }
            
        }
       
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {/* место дл€ размежещие букв */}

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letter = e.KeyChar;
            if (!(textBox1.Text.Length < 3))
            {
                button1.Enabled = true;
            }
            // Ѕуквы 
            if ((letter < 'ј' || letter > '€')&& letter!='\b')
            {
                e.Handled = true;
            }
        }

        private void textBox1_Move(object sender, EventArgs e)
        {
            textBox1.SelectionLength = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}