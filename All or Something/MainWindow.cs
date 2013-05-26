using All_or_Something.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace All_or_Something
{
    public partial class MainWindow : Form
    {
        static int []values = {1, 3, 5, 10, 25, 50, 75, 100, 200, 300, 400, 500, 750, 1000, 2500, 5000, 10000, 20000, 30000, 40000, 50000, 100000, 200000, 350000, 500000, 1000000};
        static Label message = new Label();
        static Button messYes = new Button();
        static Button messNo = new Button();
        
        Briefcase[] briefcases;
        PictureBox[] briefImages;
        Label[] sideValues;
        Label[] briefNums;
        Game g;

        public void init()
        {
            g = new Game();
            this.DoubleBuffered = true;
            this.SuspendLayout();

            message.Text = "Одберете ја вашата кутија";
            message.Location = new Point(690, 90);
            message.Size = new Size(160, 50);
            message.TextAlign = ContentAlignment.MiddleCenter;
            message.Visible = true;

            messYes.Text = "Да";
            messYes.Location = new Point(690, 150);
            messYes.Click += messYes_Click;
            messYes.Visible = false;

            messNo.Text = "Не";
            messNo.Location = new Point(780, 150);
            messNo.Click += messNo_Click;
            messNo.Visible = false;

            sideValues = new Label[26];
            briefNums = new Label[26];
            briefcases = new Briefcase[26];
            briefImages = new PictureBox[26];

            Random r = new Random();

            for (int i = 0; i < 26; i++)
            {
                sideValues[i] = new Label();
                sideValues[i].Text = values[i].ToString();
                sideValues[i].Location = new Point(30 + (i / 13) * 550, 20 + (i % 13) * 25);
                sideValues[i].BackColor = Color.FromArgb((i / 13) * 255, 0, ((25 - i) / 13) * 255);
                sideValues[i].TextAlign = ContentAlignment.MiddleCenter;
                sideValues[i].Visible = true;
                this.Controls.Add(sideValues[i]);

                briefcases[i] = new Briefcase(i);

                briefNums[i] = new Label();
                if (i < 24)
                    briefNums[i].Location = new Point(185 + 65 * (i % 6), 48 + 55 * (i / 6));
                else
                    briefNums[i].Location = new Point(315 + 65 * (i % 6), 48 + 55 * (i / 6));
                briefNums[i].Size = new Size(20, 15);
                briefNums[i].Name = (i).ToString();
                briefNums[i].Click += Briefcase_Click;
                briefNums[i].TextAlign = ContentAlignment.MiddleCenter;
                briefNums[i].Text = (i+1).ToString();
                briefNums[i].BackColor = Color.FromArgb(237, 28, 36);
                briefNums[i].Visible = true;
                this.Controls.Add(briefNums[i]);

                briefImages[i] = new PictureBox();
                briefImages[i].Image = Resources.br;
                if (i < 24)
                    briefImages[i].Location = new Point(170 + 65 * (i % 6), 30 + 55 * (i / 6));
                else
                    briefImages[i].Location = new Point(300 + 65 * (i % 6), 30 + 55 * (i / 6));
                briefImages[i].Size = new Size(50, 50);
                briefImages[i].Name = i.ToString();
                briefImages[i].Click += Briefcase_Click;
                briefImages[i].Visible = true;
                this.Controls.Add(briefImages[i]);
            }

            for (int i = 0; i < 1000; i++)
            {
                int index = r.Next(26);
                briefcases[i%26].swap(briefcases[index]);
            }

            this.Controls.Add(message);
            this.Controls.Add(messYes);
            this.Controls.Add(messNo);

            this.ResumeLayout();
        }


        public MainWindow()
        {
            InitializeComponent();
            init();
        }

        private void Briefcase_Click(object sender, EventArgs e)
        {
            if (message.Text.Length < 26)
            {
                int index;
                try
                {
                    Int32.TryParse(((PictureBox)sender).Name, out index);
                }
                catch (Exception ex)
                {
                    Int32.TryParse(((Label)sender).Name, out index);
                }
                if (message.Text.Length == 25)
                {
                    briefImages[index].Location = new Point(750, 300);
                    briefNums[index].Location = new Point(765, 322);
                    message.Text = g.turn(values[briefcases[index].value]);
                }
                else
                {
                    briefImages[index].Visible = false;
                    briefNums[index].Visible = false;
                    sideValues[briefcases[index].value].Visible = false;
                    message.Text = g.turn(values[briefcases[index].value]);
                    if (values[briefcases[index].value] < 50)
                    {
                        new SoundPlayer(Resources.people071).Play();
                    }
                    else if(values[briefcases[index].value]>50000)
                    {
                        new SoundPlayer(Resources.people037).Play();
                    }
                    if (message.Text.Length > 25)
                    {
                        messYes.Visible = true;
                        messNo.Visible = true;
                    }
                }
            }
            if (g.getRound() == 11)
            {
                message.Text = "Честито, освоивте " + g.offer() + " денари!";
                if(messYes.Visible == true)
                new SoundPlayer(Resources.people093).Play();
                messYes.Visible = false;
                messNo.Visible = false;
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void messYes_Click(object sender, EventArgs e)
        {
            message.Text = "Честито, освоивте " + g.offer() + " денари";
            new SoundPlayer(Resources.people093).Play();
            messYes.Visible = false;
            messNo.Visible = false;
        }

        private void messNo_Click(object sender, EventArgs e)
        {
            message.Text = "Отвори кутија";
            messYes.Visible = false;
            messNo.Visible = false;
        }

        private void newGame_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Дали сакате да започнете нова игра?", "НОВА ИГРА", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (MessageBox.Show("Дали сакате да започнете нова игра?", "НОВА ИГРА", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                for (int i = 0; i < 26; i++)
                {
                    briefcases[i] = null;
                    briefImages[i].Dispose();
                    sideValues[i].Dispose();
                    briefNums[i].Dispose();
                }
                init();
            }
            else Close();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Играта Се или Нешто е игра на среќа. Сумите во кутиите се случајно избрани и никој не знае која сума во која кутија се наоѓа. Најпрвин се започнува со тоа што се  клика на една кутија и таа кутија е Ваша кутија. Од тука па натака започнува играта, каде што во првата рунда се отвораат 6 кутии и после нив следи понуда од банкарот со сума со која што сака да ја откупи Вашата кутија, без разлика што тој не знае што се крие во вашата кутија. После понудатата на банкарот одлучувате дали ќе ја прифатите понудатата или ќе продолжите понатаму. Ако одлучите да продолжите влегувате во втората рунда и тука отворате 5 кутии, и исто како и во претходната рунда после 5те кутии отворени се јавува банкарот. Вака се продолжува се до останување на една кутија и Вашата што сте ја избрале. Тогаш ја отварате претпоследната кутија и онаа сума што ќе остане е  вашата добивка.", "ПРАВИЛА НА ИГРАТА");
        }
    }
}