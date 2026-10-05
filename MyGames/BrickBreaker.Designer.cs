namespace MyGames
{
    partial class BrickBreaker
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
            this.components = new System.ComponentModel.Container();
            this.Paddle = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Ball = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Paddle
            // 
            this.Paddle.BackColor = System.Drawing.Color.Black;
            this.Paddle.Enabled = false;
            this.Paddle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Paddle.Location = new System.Drawing.Point(79, 234);
            this.Paddle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Paddle.Name = "Paddle";
            this.Paddle.Size = new System.Drawing.Size(121, 16);
            this.Paddle.TabIndex = 11;
            this.Paddle.UseVisualStyleBackColor = false;
            this.Paddle.UseWaitCursor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Ball
            // 
            this.Ball.AutoSize = true;
            this.Ball.Location = new System.Drawing.Point(114, 161);
            this.Ball.Name = "Ball";
            this.Ball.Size = new System.Drawing.Size(13, 13);
            this.Ball.TabIndex = 12;
            this.Ball.Text = "  ";
            // 
            // BrickBreaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Paddle);
            this.Controls.Add(this.Ball);
            this.Name = "BrickBreaker";
            this.Text = "Brick Breaker";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BrickBreaker_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Paddle;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Ball;
    }
}