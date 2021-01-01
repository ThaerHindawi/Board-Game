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
    public partial class Create_New_Profile : Form
    {
        

        int counterImg;
        public Create_New_Profile()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Bitmap bitmap;
            //if (counterImg < imageList1.Images.Count - 1)
            //    switch (counterImg)
            //    {
            //        case 0:
            //            bitmap = new Bitmap(HW2.Properties.Resources._5c8954160c96b047950052);
            //            ToyFigure.Image = bitmap;
            //            ToyFigure.Show();

            //            ++counterImg;
            //            break;
            //        case 1:
            //            //   bitmap = new Bitmap(HW2.Properties.Resources._5c895373ba5e5773675130);
            //            // ToyFigure.Image = bitmap;
            //            ToyFigure.Load(@"E:\تعليم\VISUAL C#\Home work 2\HW2\HW2\Resources\5c895373ba5e5773675130.gif");
            //            ++counterImg;
            //            break;
            //        case 2:
            //            //bitmap = new Bitmap(HW2.Properties.Resources.donald_1);
            //            //ToyFigure.Image = bitmap;
            //            ToyFigure.Load(@"E:\تعليم\VISUAL C#\Home work 2\HW2\HW2\Resources\200w_d.gif");
            //            ++counterImg;
            //            break;
            //        case 3:
            //            //bitmap = new Bitmap(HW2.Properties.Resources._200w_d);
            //            //ToyFigure.Image = bitmap;
            //            ToyFigure.Load(@"E:\تعليم\VISUAL C#\Home work 2\HW2\HW2\Resources\donald 1.gif");
            //            ++counterImg;
            //            break;
        //}
               
            if (counterImg < GamesManager.allImage.Length - 1)
                ToyFigure.Image = GamesManager.allImage[++counterImg];
            


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (counterImg > 0)
                ToyFigure.Image = GamesManager.allImage[--counterImg];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            bool vaildProfile = false;
            if (textname.Text != "") { 
                profile.Name = textname.Text;
                vaildProfile = true;
            }
            if (radioMale.Checked)
                profile.Gender = "Male";
            else if (radioFemale.Checked)
                profile.Gender = "Female";
            else vaildProfile = false;
                int age;
                int.TryParse(numericAge.Text, out age);
                profile.Age = age;
                profile.Toy_figure = ToyFigure.Image;
            if (vaildProfile) {
                GamesManager.profiles.Add(profile);
                MessageBox.Show("Info saved");
                GamesManager.countProfile++;
            }
            else MessageBox.Show("please enter all your information");
        }

        private void Create_New_Profile_Load(object sender, EventArgs e)
        {
            //Bitmap bitmap = new Bitmap(HW2.Properties.Resources.donald_1);
            //ToyFigure. = bitmap;
            //++counterImg;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
