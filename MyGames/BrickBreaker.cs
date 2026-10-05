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
    public partial class BrickBreaker : Form
    {
   //=============================================================
        static public int n; //عدد الصفوف
        static public int m; //عدد الأعمدة

        bool BallUp = true; //ارتفاع او انخفاض الكرة
        bool BallRight = false; //تحريك الكرة لليمين او لليسار

        PictureBox[,] Bricks; //مجموعة الطوب
        static public int interval; //السرعة
        
        int formWidth; //للاحتفاظ بحجم الفورم الابتدائي
   //=============================================================



        



   //========================== عند فتح الفورم =========================================
        public BrickBreaker()
        {
            InitializeComponent();

            Paddle.BackgroundImage = Image.FromFile("paddle.gif");
            timer1.Interval = interval;

            Ball.SendToBack();
            CreatBricks();

            Ball.Image = Image.FromFile("ball.gif");
            Paddle.Top = this.Height + 170;
            Ball.Top = Paddle.Top - 10;
            Paddle.Left = (this.Width / 2) - (Paddle.Width / 2);
            Ball.Left = (this.Width / 2) - (Ball.Width / 2);

            this.Focus();

            // this.Size = new Size(n*70,m*70+300);
            // this.Size=
            // MessageBox.Show(Convert.ToInt64(System.Math.Pow(n, 2)).ToString());
            //  this.Height += (1000/m);
        }
   //=====================================================================================








   //======================== انشاء مجموعة الطوب ========================================
        void CreatBricks()
        {            
            Bricks = new PictureBox[n, m];
            int top = 25, width = 68, height = 23;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Bricks[i, j] = new PictureBox();
                    Bricks[i, j].Size = new Size(width, height);
                    Bricks[i, j].Location = new Point(width * j, top * i);
                    Bricks[i, j].Image = Image.FromFile("brick.gif");
                    Bricks[i, j].Enabled = false;
                    this.Controls.Add(Bricks[i, j]);
                }
            }
        }
   //=====================================================================================








   //=================== عند الضغط من لوحة المفاتيح ====================================
        private void BrickBreaker_KeyDown(object sender, KeyEventArgs e)
        {
            string result = e.KeyData.ToString();

            if (result == "Right")
                if (Paddle.Right <= formWidth - 20)
                {
                    Paddle.Left += 20;
                }

            else if (result == "Left")
                if (Paddle.Left >= 0)
                {
                    Paddle.Left -= 20;
                }

            if (result == "Space")
                timer1.Start();

            else if (result == "Return")
                timer1.Stop();
        }
   //=====================================================================================





        



        bool f = true;
   //======================= عند تشغيل التايمر ==========================================
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (f)
            {
                formWidth = this.Width;
                f = false;
            }
            BallMove();
            DisposePaddle();
            if (Ball.Top >= Paddle.Bottom)
            {
                timer1.Stop();
                MessageBox.Show("Game Over \n try again..");
                Ball.Left = Paddle.Left + Paddle.Width / 2;
                Ball.Top = Paddle.Top - Ball.Height;
                CreatBricks();
            }
        }
   //=====================================================================================








   //========================== تحريك الكرة =============================================
        void BallMove()
        {

            // -------------- Paddleعند ضرب الكرة بالـ --------------------------
            if (Ball.Bottom >= Paddle.Top)
                if (Ball.Left >= Paddle.Left && Ball.Right <= Paddle.Right)
                    BallUp = true;
            //---------------------------------------------------------------------


            //-------------- عند ضرب الكرة بأعلى الحائط -------------------------
            if (Ball.Top <= 0)
                BallUp = false;
            //---------------------------------------------------------------------


            //--------------- عند ضرب الكرة بيمين الحائط ------------------------
            if (Ball.Right >= this.Width - 20)
                BallRight = false;
            //---------------------------------------------------------------------


            //--------------- عند ضرب الكرة بيسار الحائط ------------------------
            if (Ball.Left <= 0)
                BallRight = true;
            //---------------------------------------------------------------------


            //-------------------- تحريك الكرة -----------------------------------
            Ball.Top += (BallUp) ? -5 : 5;  // ارتفاع الكرة عند الاصطدام بالمضرب أو انخفاضها عند الاصطدام بأعلى الحائط
            Ball.Left += (BallRight) ? 5 : -5; //تحريك الكرة لليمين عند الاصطدام بيسار الحائط والعكس
            //---------------------------------------------------------------------
        }
   //=====================================================================================











   //========================== تدمير طوب ==============================================
        void DisposePaddle()
        {
            foreach (Control myPaddle in this.Controls)
            {
                if (myPaddle is PictureBox)
                {
                    if (Ball.Top <= myPaddle.Bottom && Ball.Bottom >= myPaddle.Bottom - 3)
                        if (Ball.Right <= myPaddle.Right && Ball.Left >= myPaddle.Left)
                        {
                            myPaddle.Dispose();
                            BallUp = false;        
                        }

                    else if (Ball.Right >= myPaddle.Left && Ball.Left > myPaddle.Left - 3)
                        if (Ball.Bottom <= myPaddle.Bottom && Ball.Top >= myPaddle.Top)
                        {
                            myPaddle.Dispose();
                            BallRight = false;
                        }

                    else if (Ball.Left <= myPaddle.Right && Ball.Right > myPaddle.Right - 3)
                        if (Ball.Bottom <= myPaddle.Bottom && Ball.Top >= myPaddle.Top)
                        {
                            myPaddle.Dispose();
                            BallRight = true;
                        }

                    else if (Ball.Bottom >= myPaddle.Top && Ball.Top < myPaddle.Top - 3)
                        if (Ball.Right <= myPaddle.Right && Ball.Left >= myPaddle.Left)
                        {
                            myPaddle.Dispose();
                            BallUp = true;
                        }
                }
            }
        }
    //=====================================================================================
    }
}
