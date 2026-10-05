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
    public partial class SelectGame : Form
    {
        public SelectGame()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ChoseLevel f2 = new ChoseLevel();
            f2.Show();
            f2.Focus();
        }



        private void pictureBox3_Click(object sender, EventArgs e)
        {
            RapidRoll f3 = new RapidRoll();
            f3.Show();
            f3.Focus();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            ChoseLevel2 f4 = new ChoseLevel2();
            f4.Show();
            f4.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WarPlanes f1 = new WarPlanes();
            f1.Show();
            f1.Focus();
        }

    }
}
