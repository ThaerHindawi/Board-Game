using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class Profile
    {
       private string name;
       public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
           
        }

        private string gender;    
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }

        private int age;
       public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        private Image toy_figure;
        public Image Toy_figure
        {
            get
            {
                return toy_figure;
            }
            set
            {
                toy_figure = value;
            }
        }

        public List<Games> Games = new List<Games>();

        
        

    }
}
