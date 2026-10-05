using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGames
{
    public partial class RapidRoll : Form
    {
     public RapidRoll()
        {
            InitializeComponent();
            Interface();
        }

        const int width = 90;
        const int height = 15;

        int save = 0;
        int count = 0;
        int lives = 3;

        short score = 0;

        bool moveLeft = false;
        bool moveRight = false;

        Random r = new Random();

        private void DrawBall(object sender, PaintEventArgs e)
        {
            Rectangle ball = new Rectangle(0, 0, 30, 30);
            Pen pn = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.Red);
            e.Graphics.DrawEllipse(pn, ball);
            e.Graphics.FillEllipse(brush, ball);
        }
        private void Pressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                moveRight = true;
            }
        }
        private void Released(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
        }
        private void Controlling(object sender, EventArgs e)
        {
            if (moveLeft && Ball.Location.X >= 0)
            {
                Ball.Left -= 6;
            }
            else if (moveRight && Ball.Location.X <= ClientSize.Width - Ball.Width)
            {
                Ball.Left += 6;
            }
        }
        private void SetBall()
        {
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox && c.Name == "Layer")
                {
                    PictureBox layer = (PictureBox)c;
                    Ball.Location = new Point(layer.Location.X, layer.Location.Y - Ball.Height - 5);
                }
            }
        }

        //انشاء واجهة اللعبة
        private void Interface()
        {
            int x, c, y = 0;

            while (y < ClientSize.Height - Ball.Height)
            {
                x = r.Next(0, ClientSize.Width - width);
                c = r.Next(60, 120);
                y += c;
                if (y > ClientSize.Height - Ball.Height) break;
                Bar(x, y);
            }

            SetBall();
        }
        private void Bar(int w, int h)
        {
            PictureBox bar = new PictureBox();
            bar.Location = new Point(w, h);
            bar.Size = new Size(width, height);
           // bar.BackgroundImage = Properties.Resources.brick;
            bar.BackgroundImage = Image.FromFile("brick.gif");
            bar.BackgroundImageLayout = ImageLayout.Stretch;
            bar.AccessibleName = "Field";
            bar.Name = "Bar";
            this.Controls.Add(bar);
            Layer(bar);
        }
        private void Layer(PictureBox b)
        {
            PictureBox layer = new PictureBox();
            layer.Location = new Point(b.Location.X, b.Location.Y - 5);
            layer.Size = new Size(width, 1);
            layer.AccessibleName = "Field";
            layer.Name = "Layer";
            this.Controls.Add(layer);
        }
        private void Spike(int w, int h)
        {
            PictureBox spike = new PictureBox();
            spike.Location = new Point(w, h);
            spike.Size = new Size(width, height);
           // spike.BackgroundImage = Properties.Resources.spikes;
            spike.BackgroundImage = Image.FromFile("brick2.gif"); 

            spike.BackgroundImageLayout = ImageLayout.Stretch;
            spike.AccessibleName = "Field";
            spike.Name = "Spike";
            this.Controls.Add(spike);
        }


        //انشاء سلالم
        private void Generator(object sender, EventArgs e)
        {
            if (save == 0)
            {
                int pick = r.Next(1, 5) + 1;
                save = pick;
            }

            count++;

            if (count == save)
            {
                Spike(r.Next(ClientSize.Width - width), ClientSize.Height);
                count = 0; save = 0;
            }
            else
            {
                Bar(r.Next(ClientSize.Width - width), ClientSize.Height);
            }
        }

        //ارتفاع السلالم
        private void Detector(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox && c.AccessibleName == "Field")
                {
                    PictureBox field = (PictureBox)c;
                    field.Top -= 3;

                    if (field.Bounds.IntersectsWith(Wire.Bounds))
                    {
                        this.Controls.Remove(field);
                    }
                }
            }
        }
        private bool Settled(PictureBox surface)
        {
            return surface.Location.Y - Ball.Location.Y >= Ball.Height - 6;
        }

        //تحريك الكرة مع السلالم
        private void Observer(object sender, EventArgs e)
        {
            int top = 3;

            if (Ball.Bounds.IntersectsWith(Wire.Bounds) || Ball.Location.Y >= ClientSize.Height)
            {
                checkStatus();
                return;
            }
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox && c.Name == "Layer")
                {
                    PictureBox layer = (PictureBox)c;

                    if (Ball.Bounds.IntersectsWith(layer.Bounds) && Settled(layer))
                    {
                        top *= (-1);
                    }
                }
                else if (c is PictureBox && c.Name == "Spike")
                {
                    PictureBox spike = (PictureBox)c;

                    if (Ball.Bounds.IntersectsWith(spike.Bounds))
                    {
                        checkStatus();
                        return;
                    }
                }
            }
            MoveBall(top);
            WriteScore(top);
            CheckForWinner();
        }
        private void MoveBall(int num)
        {
            Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + num);
        }
        private void checkStatus()
        {
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox && c.Name.Contains("Life"))
                {
                    this.Controls.Remove(c);
                    lives--;
                    break;
                }
            }

            if (lives == 0)
            {
                DisposeTimers();
                MessageBox.Show("Game Over!" + "\n"
                              + "Score: " + score.ToString()
                               );
            }
            else
            {
                SetBall();
            }
        }
        private void CheckForWinner()
        {
            if (score == short.MaxValue)
            {
                DisposeTimers();
                MessageBox.Show("Congratulations, you won!");
            }
        }
        private void WriteScore(int value)
        {
            if (value > 0)
            {
                score++;
                label1.Text = "Score: " + score.ToString();
            }
        }
        private void DisposeTimers()
        {
            Controller.Dispose();
            Generate.Dispose();
            Detect.Dispose();
            Observe.Dispose();
        }


    }
}