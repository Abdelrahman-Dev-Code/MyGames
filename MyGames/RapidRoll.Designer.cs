namespace MyGames
{
    partial class RapidRoll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RapidRoll));
            this.Ball = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Life3 = new System.Windows.Forms.PictureBox();
            this.Life2 = new System.Windows.Forms.PictureBox();
            this.Life1 = new System.Windows.Forms.PictureBox();
            this.Wire = new System.Windows.Forms.PictureBox();
            this.Controller = new System.Windows.Forms.Timer(this.components);
            this.Generate = new System.Windows.Forms.Timer(this.components);
            this.Detect = new System.Windows.Forms.Timer(this.components);
            this.Observe = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Life3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Life2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Life1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wire)).BeginInit();
            this.SuspendLayout();
            // 
            // Ball
            // 
            this.Ball.Image = ((System.Drawing.Image)(resources.GetObject("Ball.Image")));
            this.Ball.Location = new System.Drawing.Point(169, 175);
            this.Ball.Name = "Ball";
            this.Ball.Size = new System.Drawing.Size(32, 32);
            this.Ball.TabIndex = 11;
            this.Ball.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(277, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Score: 0";
            // 
            // Life3
            // 
            this.Life3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Life3.BackgroundImage")));
            this.Life3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Life3.Location = new System.Drawing.Point(74, 25);
            this.Life3.Name = "Life3";
            this.Life3.Size = new System.Drawing.Size(25, 25);
            this.Life3.TabIndex = 9;
            this.Life3.TabStop = false;
            // 
            // Life2
            // 
            this.Life2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Life2.BackgroundImage")));
            this.Life2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Life2.Location = new System.Drawing.Point(43, 25);
            this.Life2.Name = "Life2";
            this.Life2.Size = new System.Drawing.Size(25, 25);
            this.Life2.TabIndex = 8;
            this.Life2.TabStop = false;
            // 
            // Life1
            // 
            this.Life1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Life1.BackgroundImage")));
            this.Life1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Life1.Location = new System.Drawing.Point(12, 25);
            this.Life1.Name = "Life1";
            this.Life1.Size = new System.Drawing.Size(25, 25);
            this.Life1.TabIndex = 7;
            this.Life1.TabStop = false;
            // 
            // Wire
            // 
            this.Wire.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Wire.Image = ((System.Drawing.Image)(resources.GetObject("Wire.Image")));
            this.Wire.Location = new System.Drawing.Point(0, -1);
            this.Wire.Name = "Wire";
            this.Wire.Size = new System.Drawing.Size(385, 15);
            this.Wire.TabIndex = 6;
            this.Wire.TabStop = false;
            // 
            // Controller
            // 
            this.Controller.Enabled = true;
            this.Controller.Interval = 1;
            this.Controller.Tick += new System.EventHandler(this.Controlling);
            // 
            // Generate
            // 
            this.Generate.Enabled = true;
            this.Generate.Interval = 350;
            this.Generate.Tick += new System.EventHandler(this.Generator);
            // 
            // Detect
            // 
            this.Detect.Enabled = true;
            this.Detect.Interval = 1;
            this.Detect.Tick += new System.EventHandler(this.Detector);
            // 
            // Observe
            // 
            this.Observe.Enabled = true;
            this.Observe.Interval = 1;
            this.Observe.Tick += new System.EventHandler(this.Observer);
            // 
            // RapidRoll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.Ball);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Life3);
            this.Controls.Add(this.Life2);
            this.Controls.Add(this.Life1);
            this.Controls.Add(this.Wire);
            this.Name = "RapidRoll";
            this.Text = "RapidRoll";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pressed);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Released);
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Life3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Life2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Life1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wire)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Ball;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Life3;
        private System.Windows.Forms.PictureBox Life2;
        private System.Windows.Forms.PictureBox Life1;
        private System.Windows.Forms.PictureBox Wire;
        private System.Windows.Forms.Timer Controller;
        private System.Windows.Forms.Timer Generate;
        private System.Windows.Forms.Timer Detect;
        private System.Windows.Forms.Timer Observe;

    }
}