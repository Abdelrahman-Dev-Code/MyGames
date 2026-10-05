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
    public partial class ChoseLevel2 : Form
    {
        public ChoseLevel2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SlowRadio.Checked)
            {
                PingPong.interval = 100;
            }
            else if (MediumRadio.Checked)
            {
                PingPong.interval = 50;
            }
            else
            {
                PingPong.interval = 10;
            }

            if (radioButton1.Checked)
            {
                PingPong.ChoosePlayer = "Tow Players";
            }
            else
            {
                PingPong.ChoosePlayer = "With Computer";
            }

            this.Close();
            PingPong f3 = new PingPong();
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectGame f0 = new SelectGame();
            f0.Focus();
            this.Close();
        }
    }
}
