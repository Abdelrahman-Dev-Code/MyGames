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
    public partial class ChoseLevel : Form
    {
        public ChoseLevel()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectGame f0 = new SelectGame();
            f0.Focus();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SlowRadio.Checked)
            {
                BrickBreaker.interval = 100;
            }
            else if (MediumRadio.Checked)
            {
                BrickBreaker.interval = 30;
            }
            else
            {
                BrickBreaker.interval = 1;
            }

            BrickBreaker.n = int.Parse(numericUpDown1.Text);
            BrickBreaker.m = int.Parse(numericUpDown2.Text);
            this.Hide();
            BrickBreaker f1 = new BrickBreaker();
            f1.Show();
        }
    }
}
