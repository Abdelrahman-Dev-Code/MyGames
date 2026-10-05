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
    public partial class PingPong : Form
    {
        int xspeed;
        int yspeed;
        int lastx; 
        int lastx_cpu;
        int score_player;
        int score_cpu;
        int topBounds;
        int bottomBounds;
        int leftBounds;
        int rightBounds;

        static public string ChoosePlayer;






   //=============================================================
        bool BallUp = true; //ارتفاع او انخفاض الكرة
        bool BallRight = false; //تحريك الكرة لليمين او لليسار

        static public int interval; //السرعة
   //=============================================================







   //========================== عند فتح الفورم =========================================
        public PingPong()
        {
            InitializeComponent();




            //اعطاء قيم ابتدائية للسرعة
            xspeed = 2;
            yspeed = 2;

            //لعدم تنقل المؤشر بين الازرار
            Ball.Enabled = false;
            paddle.Enabled = false;
            paddle2.Enabled = false;

            lastx = MousePosition.X;
            lastx_cpu = paddle2.Location.X;

            paddle.BackgroundImage = Image.FromFile("paddle.gif");
            Ball.SendToBack();
            Ball.Image = Image.FromFile("ball.gif");

            timer1.Interval = interval;
            Ball.Top = paddle.Top - 10;
            paddle.Left = (this.Width / 2) - (paddle.Width / 2);
            Ball.Left = (this.Width / 2) - (Ball.Width / 2);

            this.Focus();
        }
   //=====================================================================================







   //=================== عند الضغط من لوحة المفاتيح ====================================
        private void PingPong_KeyDown(object sender, KeyEventArgs e)
        {
            string result = e.KeyData.ToString();
            if (result == "Space")
                timer1.Start();
            else if (result == "Return")
                timer1.Stop();


            if (result == "D")
                if (paddle2.Right <= this.Width - 20)
                    paddle2.Left += 20;

            if (result == "A")
                if (paddle2.Left >= panel1.Width)
                    paddle2.Left -= 20;
        }

        private void PingPong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)';')
                if (paddle.Right <= this.Width - 20)
                    paddle.Left += 20;

            else if (e.KeyChar == (char)'l')
                if (paddle.Left >= panel1.Width)
                    paddle.Left -= 20;
        }
   //=====================================================================================





        




   //======================= عند تشغيل التايمر ==========================================
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ChoosePlayer == "Tow Players")
                PlayTowPlayer();
            else
                playWithComputer();
        }
   //=====================================================================================







        int point1 = 0, point2 = 0;
   //========================== Tow Players =============================================
        void PlayTowPlayer()
        {

            //-------------- Paddle1 تحريك الـ -----------------------------------
            if (paddle.Right <= this.Width || paddle.Left >= panel1.Width)
            {
                paddle.Left = MousePosition.X;
            }
            //---------------------------------------------------------------------


            //-------------- عند ضرب الكرة بأعلى الحائط -------------------------
            if (Ball.Top <=paddle2.Top)
            {
                point1++;
                label1.Text = "Player1: ("+ point1+")" ;
                BallUp = false;
            }
            //---------------------------------------------------------------------


            //-------------- عند ضرب الكرة بأسفل الحائط -------------------------
            if (Ball.Top >= paddle.Bottom)
            {
                point2++;
                label2.Text = "Player2: (" + point2+")";
                BallUp = true;
                Ball.Visible = false;
            }
            else
                Ball.Visible = true;
            //---------------------------------------------------------------------


            // -------------- Paddleعند ضرب الكرة بالـ --------------------------
            if (Ball.Bottom >= paddle.Top)
            {
                if (Ball.Left >= paddle.Left && Ball.Right <= paddle.Right)
                {
                    BallUp = true;
                }
            }
            //---------------------------------------------------------------------


            // -------------- Paddle2عند ضرب الكرة بالـ --------------------------
            if (Ball.Top <= paddle2.Bottom)
            {
                if (Ball.Left >= paddle2.Left && Ball.Right <= paddle2.Right)
                {
                    BallUp = false;
                }
            }
            //---------------------------------------------------------------------


            //--------------- عند ضرب الكرة بيمين الحائط ------------------------
            if (Ball.Right >= this.Width - 20)
            {
                BallRight = false;
            }
            //---------------------------------------------------------------------


            //--------------- عند ضرب الكرة بيسار الحائط ------------------------
            if (Ball.Left <= panel1.Width)
            {
                BallRight = true;
            }
            //---------------------------------------------------------------------


            //-------------------- تحريك الكرة -----------------------------------
            Ball.Top += (BallUp) ? -5 : 5;  // ارتفاع الكرة عند الاصطدام بالمضرب أو انخفاضها عند الاصطدام بأعلى الحائط
            Ball.Left += (BallRight) ? 5 : -5; //تحريك الكرة لليمين عند الاصطدام بيسار الحائط والعكس
            //---------------------------------------------------------------------
        }
   //=====================================================================================









    //===================== playWithComputer =============================================
        void playWithComputer()
        {
            topBounds = 0;
            bottomBounds = this.Height - 23;
            leftBounds = panel1.Width;
            rightBounds = this.Width-30;

            //---------------- Player 1 تحريك --------------------------        
            paddle.Location = new Point((int)(MousePosition.X - paddle.Width), paddle.Location.Y);
            Ball.Location = new Point(Ball.Location.X + xspeed, Ball.Location.Y + yspeed);

            //----------------- Computer تحريك --------------------------  
            if (Ball.Location.X > paddle2.Location.X && paddle2.Right <= this.Width - 20)
                paddle2.Location = new Point(paddle2.Location.X + 3, paddle2.Location.Y);
            else
                if (paddle2.Left >= panel1.Width)
                paddle2.Location = new Point(paddle2.Location.X - 3, paddle2.Location.Y);

            //---- عند اصطدام الكرة بيسار الحائط مع حساب السرعة ------
            if (Ball.Location.X < leftBounds)
            {
                xspeed *= -1;
                while (Ball.Location.X - 1 < leftBounds)
                    Ball.Location = new Point(Ball.Location.X + 1, Ball.Location.Y);
            }

            //---- عند اصطدام الكرة بيمين الحائط مع حساب السرعة ------
            if (Ball.Location.X + Ball.Width > rightBounds)
            {
                xspeed *= -1;
                while (Ball.Location.X + 1 > rightBounds)
                    Ball.Location = new Point(Ball.Location.X - 1, Ball.Location.Y);
            }

            //-- عند اصطدام الكرة باللاعب الاول مع حساب قوة الضربة ------
            if (Ball.Location.Y + Ball.Height > paddle.Location.Y && Ball.Location.X > (int)(paddle.Location.X - Ball.Width / 2) && Ball.Location.X + Ball.Width < (int)(paddle.Location.X + paddle.Width + Ball.Width / 2) && Ball.Location.Y < (int)(paddle.Location.Y + paddle.Height / 2))
            {
                yspeed *= -1;
                xspeed = Math.Abs(MousePosition.X - lastx);
                if (xspeed > 10)
                    xspeed = 10;
                else if (xspeed < -10)
                    xspeed = -10;
                else if (xspeed == 0)
                {
                    Random a = new Random();
                    if (a.NextDouble() > .5)
                        xspeed = 2;
                    else
                        xspeed = -2;
                }
                while (Ball.Location.Y + 1 + Ball.Height > paddle.Location.Y)
                    Ball.Location = new Point(Ball.Location.X, Ball.Location.Y - 1);
            }

            //-- عند اصطدام الكرة بلاعب الكمبيوتر مع حساب قوة الضربة ------
            if (Ball.Location.Y < paddle2.Location.Y + paddle2.Height && Ball.Location.X > (int)(paddle2.Location.X - Ball.Width / 2) && Ball.Location.X + Ball.Width < (int)(paddle2.Location.X + paddle.Width + Ball.Width / 2) && Ball.Location.Y > (int)(paddle2.Location.Y + paddle2.Height / 2))
            {
                yspeed *= -1;
                xspeed = Math.Abs(paddle.Location.X - lastx_cpu);
                if (xspeed > 4)
                    xspeed = 4;
                else if (xspeed < -4)
                    xspeed = -4;
                else if (xspeed == 0)
                {
                    Random a = new Random();
                    if (a.NextDouble() > .5)
                        xspeed = 5;
                    else
                        xspeed = -5;
                }
                while (Ball.Location.Y - 1 < paddle2.Location.Y + paddle2.Height)
                    Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 1);
            }

            //------------ حساب نقاط الـComputer ----------------
            if (Ball.Location.Y > bottomBounds)
            {
                Ball.Location = new Point(120, 100);
                Random b = new Random();
                if (b.NextDouble() > .5)
                    xspeed = 2;
                else
                    xspeed = -2;
                yspeed = -2;
                point1++;
                label2.Text = "Computer: " + point1;
            } 
                
            //--------------- حساب نقاط Player -----------------
            else if (Ball.Location.Y < topBounds)
            {
                Ball.Location = new Point(120, 100);
                Random b = new Random();
                if (b.NextDouble() > .5)
                    xspeed = 2;
                else
                    xspeed = -2;
                yspeed = 2;
                point2 ++;
                label1.Text = "Player: " + point2 ;
            }
            lastx = MousePosition.X;
            lastx_cpu = paddle2.Location.X;
        }
    //=====================================================================================
    }
}
