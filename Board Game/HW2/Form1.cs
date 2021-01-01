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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
     
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            Statistics_Form statistics_Form = new Statistics_Form();
            statistics_Form.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Create_New_Profile create_New_Profile = new Create_New_Profile();
            create_New_Profile.ShowDialog();

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GamesManager.countProfile >= 1)
            {
                
                this.Hide();
                WT3_Game wT3_Game = new WT3_Game();
                wT3_Game.ShowDialog();
                // wT3_Game.MaximumSize.Height = ;
                this.Close();
            }
            else MessageBox.Show("please create profile first");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Current_profile current_Profile = new Current_profile();
            current_Profile.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            History history = new History();
            history.ShowDialog();
        }
    }
}
