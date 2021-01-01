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
    public partial class History : Form
    {
        
        public History()
        {
            InitializeComponent();
           
        }  

        private void History_Load(object sender, EventArgs e)
        {
            foreach (var profile in GamesManager.profiles)
            {
                listBox1.Items.Add(profile.Name);
            }
        }

        

        private void performclick()
        {
            foreach (Games games in GamesManager.profiles[listBox1.SelectedIndex].Games)
            {
                string[] arr = new string[5];
                ListViewItem itm;

                arr[0] = GamesManager.profiles[listBox1.SelectedIndex].Name;
                arr[1] = games.Date;
                arr[2] = games.Duration + "";
                arr[3] = games.successfulMoves + "";
                arr[4] = games.CountBarrier + "";

                itm = new ListViewItem(arr);
                itm.Name = GamesManager.profiles[listBox1.SelectedIndex].Name;
                listView1.Items.Add(itm);
            }

        }

        private void History_Click(object sender, EventArgs e)
        {
            listView2.Visible = false;
            listView2.Items.Clear();
        }
        int preindex = 0;
        int co = 0;
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            preindex = e.ItemIndex;
            if (co == 0)
            {
                if (e.IsSelected)
                {
                    try
                    {
                        if (GamesManager.profiles[listBox1.SelectedIndex].Name == listView1.Items[e.ItemIndex].Name)
                        {
                            int i = 0;
                            foreach (var item in GamesManager.profiles[listBox1.SelectedIndex].Games[e.ItemIndex].arr)
                            {

                                string[] arr1 = new string[2];
                                arr1[0] = ++i + "";
                                arr1[1] = item;
                                ListViewItem listViewItem = new ListViewItem(arr1);
                                listView2.Items.Add(listViewItem);

                            }
                        }
                        listView2.Visible = true;
                        co = 1;
                    }
                    catch { MessageBox.Show(e.ItemIndex + ""); }
                }
            }
            else
            {
                listView2.Items.Clear();
                co = 0;
                listView2.Visible = false;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Visible = false;
            performclick();
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }





        //public void createTable()
        //{

        //    TableLayoutPanel tableLayout = new TableLayoutPanel();
        //    tableLayout.Size = tableLayoutPanel1.Size;
        //    tableLayout.Visible = true;
        //    tableLayout.Enabled = true;
        //    tableLayout.Left = x; // x 
        //    tableLayout.Top = y + 50; // y
        //    tableLayout.ColumnCount = 6;


        //    PictureBox pictureBox = new PictureBox();
        //    pictureBox.Image = Properties.Resources.Down_Arrow_PNG_PicRigth;
        //    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        //    pictureBox.Width = 42;
        //    pictureBox.Height = 39;
        //    pictureBox.Click += (s, e) => {

        //    };
        //    tableLayout.Controls.Add(pictureBox);


        //    for (int i = 1; i < 6; i++)
        //    {
        //        Label label = new Label();
        //        label.Text = "hhhh";
        //        label.Font = label2.Font;
        //        label.Anchor = AnchorStyles.Left;
        //        tableLayout.Controls.Add(label);

        //    }

        //    tableLayout.AutoSizeMode = tableLayoutPanel1.AutoSizeMode;
        //    tableLayout.RowCount = 1;
        //    tableLayout.ColumnStyles.Add(new ColumnStyle() { Width = 7.68F, SizeType = SizeType.Percent });
        //    for (int i = 1; i < 6; i++)
        //    {
        //        tableLayout.ColumnStyles.Add(new ColumnStyle() { Width = 33, SizeType = SizeType.Percent });
        //    }
        //    //  tableLayout.ColumnStyles.Add(tableLayoutPanel2.ColumnStyles.);
        //    tableLayout.BackColor = SystemColors.ScrollBar;

        //    this.Controls.Add(tableLayout);
        //}

        //private void hideTable()
        //{
        //    tableLayoutPanel3.Visible = false;
        //    plaupack.Visible = false;
        //    y = tableLayoutPanel4.Bounds.Y - tableLayoutPanel3.Bounds.Y;
        //    tableLayoutPanel4.Location = new Point(x, y);
        //    counter = 1;
        //}

        //private void showTable()
        //{
        //    y = tableLayoutPanel4.Bounds.Y + tableLayoutPanel3.Bounds.Y;
        //    tableLayoutPanel4.Location = new Point(x, y);
        //    tableLayoutPanel3.Visible  = true;
        //    plaupack.Visible = true;
        //    counter = 0;
        //}

    }
}
