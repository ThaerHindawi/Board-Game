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
    public partial class Current_profile : Form
    {
        int counterImg;
        public Current_profile()
        {
            InitializeComponent();
        }
        public static int indexProfile = GamesManager.countProfile - 1;
       
        private void Current_profile_Load(object sender, EventArgs e)
        {
            
            //Create_New_Profile.profiles.
            int count = GamesManager.countProfile - 1;
            foreach (var profile in GamesManager.profiles)
            {
                listBox1.Items.Add(profile.Name);
            }
            textname.Text = GamesManager.profiles[count].Name;
            if (GamesManager.profiles[count].Gender == "Male")
                radioMale.Checked = true;
            else radioFemale.Checked = true;
            numericAge.Value = GamesManager.profiles[count].Age;
            ToyFigure.Image = GamesManager.profiles[count].Toy_figure;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = listBox1.SelectedIndex;
            if (count >= 0 && count < GamesManager.countProfile)
            { 
                     textname.Text = GamesManager.profiles[count].Name;
                if (GamesManager.profiles[count].Gender == "Male")
                    radioMale.Checked = true;
                else radioFemale.Checked = true;
                numericAge.Value = GamesManager.profiles[count].Age;
                ToyFigure.Image  = GamesManager.profiles[count].Toy_figure;
                indexProfile = count;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (GamesManager.countProfile > 0) { 
            if (textname.Text != "")
            {
                    GamesManager.profiles[indexProfile].Name = textname.Text;
                    listBox1.Items.RemoveAt(indexProfile);
                    listBox1.Items.Insert(indexProfile, GamesManager.profiles[indexProfile].Name);
            }
            
            int age;
            int.TryParse(numericAge.Text, out age);
            GamesManager.profiles[indexProfile].Age = age;
            if (radioMale.Checked)
                GamesManager.profiles[indexProfile].Gender = "Male";
            else if (radioFemale.Checked)
                GamesManager.profiles[indexProfile].Gender = "Female";
          
            GamesManager.profiles[indexProfile].Toy_figure = ToyFigure.Image;
            MessageBox.Show("Info is Saved");
            }
            else MessageBox.Show("Please create profile first");
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (counterImg < GamesManager.allImage.Length - 1)
                ToyFigure.Image = GamesManager.allImage[++counterImg];
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (counterImg > 0)
                ToyFigure.Image = GamesManager.allImage[--counterImg];
        }
    }
}
