using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW2
{
    public partial class Statistics_Form : Form
    {
        public Statistics_Form()
        {
            InitializeComponent();
        }

        private void Statistics_Form_Load(object sender, EventArgs e)
        {
            GamesManager.calcStatiistcs();
            numOfGame.Text = GamesManager.numAllGames + "";
            numOfProfiles.Text = GamesManager.countProfile + "";
            minDur.Text = GamesManager.minDuration + "";
            maxDur.Text = GamesManager.maxDuration + "";
            totalDur.Text = GamesManager.totleDuration + "";
            highScore.Text = GamesManager.highScore + "";
            lowScore.Text = GamesManager.lowScore + "";
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            //GamesManager.calcStatiistcs();
        }
    }
}
