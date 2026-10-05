using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MyGames
{
    public partial class WarPlanes : Form
    {
     
        
    int n = 3, m = 15;

        PictureBox myButton = new PictureBox();
        PictureBox ball = new PictureBox();



        PictureBox[,] Bricks;




        public WarPlanes()
        {
            InitializeComponent();

            CreatBricks();

           

            ball.Image = Image.FromFile("ball.png");
            ball.Size = new Size(20, 20);
            ball.Location = new Point(this.Width / 2, this.Height - 100);
            
            Controls.Add(ball);


          //  myButton.Location = MousePosition;
            Controls.Add(myButton);
            myButton.Image=Image.FromFile("ball3.png");
            myButton.Size = new System.Drawing.Size(77,62);
            
            timer1.Start();
            timer3.Start();
        }


        void CreatBricks()
        {
            Bricks = new PictureBox[n, m];
            int top = 38, width = 52, height = 42;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Bricks[i, j] = new PictureBox();
                    Bricks[i, j].Size = new Size(width, height);
                    Bricks[i, j].Location = new Point(width * j, top * i);
                    Bricks[i, j].Image = Image.FromFile("ball2.png");
                    Bricks[i, j].Enabled = false;
                    this.Controls.Add(Bricks[i, j]);
                }
            }
        }

        int time = 0;
        int i,j,i2,j2;
        int x, y;

        int time2 = 0;
        int x2, y2;



        private void timer1_Tick(object sender, EventArgs e)
        {
            ball.SendToBack();
           

            myButton.Location = new Point( MousePosition.X-125, this.Height - 100);
            if (ball.Location.Y == this.Height - 100)
                ball.Location = new Point(myButton.Left + myButton.Width / 2, this.Height - 100);

            //if (myButton.Right <= this.Width || myButton.Left >=0)
            //{
            //    myButton.Left = MousePosition.X;
            //}

                //if (ball.Location.Y == this.Height - 100)
                //    ball.Location = new Point(myButton.Left + myButton.Width / 2, this.Height - 100);
            

            Random r = new Random();

            if (time == 0)
            {
                i = r.Next(0, n);
                j = r.Next(0, m);
                x = Bricks[i, j].Location.X;
                y = Bricks[i, j].Location.Y;
            }


            time++;
            Bricks[i, j].SendToBack();
            myDispose();

            if (time >= 10)
            {
                if (Bricks[i, j].Top < this.Height - 100)
                {
                    Bricks[i, j].Top += 12;
                    if (Bricks[i, j].Left < myButton.Location.X)
                        Bricks[i, j].Left += 10;
                    if (Bricks[i, j].Left > myButton.Location.X)
                        Bricks[i, j].Left -= 10;
                }
                else
                {
                    Bricks[i, j].Location = new Point(x, y);
                    time = 0;
                }

            }
        }




        int end;
        void myDispose()
        {
            end = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (!Bricks[i, j].IsDisposed && Bricks[i, j].Bounds.IntersectsWith(myButton.Bounds))
                    {
                        timer1.Stop();
                        timer2.Stop();
                        timer3.Stop();
                        MessageBox.Show("Game Over...");
                        this.Close();
                    }
                    if (!Bricks[i, j].IsDisposed && Bricks[i, j].Bounds.IntersectsWith(ball.Bounds))
                    {
                        Bricks[i, j].Dispose();
                        ball.Location = new Point(myButton.Left + myButton.Width / 2, this.Height - 100);
                        timer2.Stop();
                    }
                    if (Bricks[i, j].IsDisposed)
                    {
                        end++;
                    }
                    if (end == n*m-1)
                    {
                        timer1.Stop();
                        MessageBox.Show("Game Over...");
                        this.Close();
                    }
                }
            }
        }









        private void timer2_Tick(object sender, EventArgs e)
        {
            if (ball.Top > 0)
            {
                ball.Top -= 50;
            }
            else
            {
                ball.Location = new Point(myButton.Left + myButton.Width / 2, this.Height - 100);
                timer2.Stop();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Random r = new Random();

            if (time2 == 0)
            {
                i2 = r.Next(0, n);
                j2 = r.Next(0, m);
                x2 = Bricks[i2, j2].Location.X;
                y2 = Bricks[i2, j2].Location.Y;
            }
            Bricks[i2, j2].SendToBack();


            time2++;


            if (time2 >= 10)
            {
                if (Bricks[i2, j2].Top < this.Height - 100)
                {
                    Bricks[i2, j2].Top += 12;
                    if (Bricks[i2, j2].Left < myButton.Location.X)
                        Bricks[i2, j2].Left += 15;
                    if (Bricks[i2, j2].Left > myButton.Location.X)
                        Bricks[i2, j2].Left -= 15;
                }
                else
                {
                    Bricks[i2, j2].Location = new Point(x2, y2);
                    time2 = 0;
                }
            }
        }




        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            timer2.Start();
        }
    }
}