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
    public partial class WT3_Game : Form
    {
        public WT3_Game()
        {
            InitializeComponent();
            games = new Games();
            games.Level = 1;
            games.CountBarrier = 3;
            pictureBoxes.Add(pictureGoal);
            pictureBoxes.Add(pictureBox2);
            pictureBoxes.Add(pictureBox10);
            pictureBoxes.Add(pictureBox8);            
            games.CountBarrier = pictureBoxes.Count;
            try { player.Image = GamesManager.profiles[Current_profile.indexProfile].Toy_figure; }
            catch { player.Image = GamesManager.allImage[0]; }

        }

        private Games games;
        int seconds = 0;
        private List<PictureBox> pictureBoxes = new List<PictureBox>();

        private void WT3_Game_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.W:
                    moveUP();
                    break;

                case Keys.Down:
                case Keys.S:
                    moveDown();
                    break;

                case Keys.Right:
                case Keys.D:
                    moveRight();
                    break;

                case Keys.Left:
                case Keys.A:
                    moveLeft();
                    break;
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void WT3_Game_Load(object sender, EventArgs e)
        {

            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            userName.Text = GamesManager.profiles[Current_profile.indexProfile].Name;


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            moveUP();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            moveDown();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            moveRight();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            moveLeft();
        }

        private void newProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Create_New_Profile create_New_Profile = new Create_New_Profile();
            create_New_Profile.ShowDialog();
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statistics_Form statistics_Form = new Statistics_Form();
            statistics_Form.ShowDialog();
        }

        private void GiveupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure?",
                      "you will lose", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    this.Hide();
                    Form1 form1 = new Form1();
                    form1.ShowDialog();
                    this.Close();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure?",
                      "you will lose", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    Application.Exit();
                    break;
                case DialogResult.No:
                    break;
            }

        }

        private void currentProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Current_profile current_Profile = new Current_profile();
            current_Profile.ShowDialog();
        }

        private void WT3_Game_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'r':
                    RandomGame();
                    break;
                case 'm':
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
                    WindowState = FormWindowState.Maximized;
                    TopMost = true;
                    break;
                case 'M':
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                    TopMost = true;
                    break;
                case 'n':
                    this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                    break;
            }

        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            History history = new History();
            history.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void moveUP()
        {
            int rowUp = tableLayoutPanel1.GetRow(player);//
            int colupostionUp = tableLayoutPanel1.GetColumn(player);//
            if (rowUp - 1 >= 0)
            {
                PictureBox pic = tableLayoutPanel1.GetControlFromPosition(colupostionUp, rowUp - 1) as PictureBox;

                if (pic == null)
                {
                    tableLayoutPanel1.SetRow(player, --rowUp);
                    games.NumMoveUP++;
                    games.dirctionSteps.Add(1);
                }

                else if (pic.Tag != "barrier")
                {
                    tableLayoutPanel1.SetRow(player, --rowUp);
                    pictureGoal.Visible = false;
                    MessageBox.Show("You are winner");
                    games.dirctionSteps.Add(1);
                    games.NumMoveUP++;
                    levelUP();
                }
                else games.FailedMoves++;

            }
            else games.FailedMoves++;
            numTotleMoves.Text = games.TotleMoves + "";
            successMoves.Text = games.successfulMoves + "";
        }

        private void moveDown()
        {
            int rowDown = tableLayoutPanel1.GetRow(player);//
            int colupostionD = tableLayoutPanel1.GetColumn(player);//
            if (rowDown < tableLayoutPanel1.RowCount - 1)
            {
                PictureBox pic = tableLayoutPanel1.GetControlFromPosition(colupostionD, rowDown + 1) as PictureBox;

                if (pic == null)
                {
                    tableLayoutPanel1.SetRow(player, ++rowDown);
                    games.NumMoveDown++;
                    games.dirctionSteps.Add(2);
                }
                else if (pic.Tag != "barrier")
                {
                    tableLayoutPanel1.SetRow(player, ++rowDown);

                    pictureGoal.Visible = false;
                    MessageBox.Show("You are winner");
                    games.dirctionSteps.Add(2);
                    games.NumMoveDown++;


                    levelUP();
                }
                else games.FailedMoves++;
            }
            else games.FailedMoves++;
            numTotleMoves.Text = games.TotleMoves + "";
            successMoves.Text = games.successfulMoves + "";
        }

        private void moveRight()
        {
            int colRight = tableLayoutPanel1.GetColumn(player);//
            int rowpostionR = tableLayoutPanel1.GetRow(player);//
            if (colRight < tableLayoutPanel1.ColumnCount - 1)
            {
                PictureBox pic = tableLayoutPanel1.GetControlFromPosition(colRight + 1, rowpostionR) as PictureBox;

                if (pic == null)
                {
                    tableLayoutPanel1.SetColumn(player, ++colRight);
                    games.NumMoveRight++;
                    games.dirctionSteps.Add(3);
                }

                else if (pic.Tag != "barrier")
                {
                    tableLayoutPanel1.SetColumn(player, ++colRight);

                    pictureGoal.Visible = false;
                    MessageBox.Show("You are winner");
                    games.dirctionSteps.Add(3);
                    games.NumMoveRight++;
                    levelUP();
                }
                else games.FailedMoves++;
            }
            else games.FailedMoves++;
            numTotleMoves.Text = games.TotleMoves + "";
            successMoves.Text = games.successfulMoves + "";
        }

        private void moveLeft()
        {
            int colLeft = tableLayoutPanel1.GetColumn(player);//
            int rowpostionL = tableLayoutPanel1.GetRow(player);//
            if (colLeft - 1 >= 0)
            {
                PictureBox pic = tableLayoutPanel1.GetControlFromPosition(colLeft - 1, rowpostionL) as PictureBox;

                if (pic == null)
                {
                    tableLayoutPanel1.SetColumn(player, --colLeft);
                    games.NumMoveLeft++;
                    games.dirctionSteps.Add(4);
                }

                else if (pic.Tag != "barrier")
                {
                    tableLayoutPanel1.SetColumn(player, --colLeft);

                    pictureGoal.Visible = false;
                    MessageBox.Show("You are winner");
                    games.dirctionSteps.Add(4);
                    games.NumMoveLeft++;
                    levelUP();
                }
                else games.FailedMoves++;
            }
            else games.FailedMoves++;
            numTotleMoves.Text = games.TotleMoves + "";
            successMoves.Text = games.successfulMoves + "";
        }


        private void durationSeconds_Tick(object sender, EventArgs e)
        {
            seconds++;
            durationSeconds.Text = seconds + "";
        }

        private void levelUP()
        {
            int level = games.Level;
            int gamesid = games.gameId + 1;
            complete_game();
            recordGame();
            pictureGoal.Visible = true;
            games = new Games();
            games.Level = level + 1;
            //games.Score = score;
            games.gameId = gamesid;
            RandomGame();
            levelGame.Text = games.Level + "";
        }

        public PictureBox AddPic()
        {
            PictureBox pictureBox = new PictureBox()
            {
                Name = "pictureBox",
                Tag = "barrier",
                Height = pictureBox2.Height,
                Width = pictureBox2.Width,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.None,
                Visible = true,
                Image = pictureBox2.Image
            };

            tableLayoutPanel1.Controls.Add(pictureBox);
            return pictureBox;
        }

        private void RandomGame()
        {

            Random randomGame = new Random();
            int colCount = tableLayoutPanel1.ColumnCount - 1;
            int rowCount = tableLayoutPanel1.RowCount - 1;
            TableLayoutPanelCellPosition tableCell = new TableLayoutPanelCellPosition();
            if (pictureBoxes.Count < 10)
            {
                pictureBoxes.Add(AddPic());
            }

            foreach (var pic in pictureBoxes)
            {
                
                    tableCell.Column = randomGame.Next(colCount);
                    tableCell.Row = randomGame.Next(rowCount);
                    tableLayoutPanel1.SetCellPosition(pic, tableCell);
                
            }

            if (tableLayoutPanel1.GetCellPosition(pictureGoal).Equals(tableLayoutPanel1.GetCellPosition(player)))
                RandomGame();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RandomGame();
        }

        private void complete_game()
        {
            
            games.Duration = seconds;
            games.CountBarrier = pictureBoxes.Count - 1;
            scoreGame.Text = games.Score + ""; 
            GamesManager.numAllGames++;
            try { GamesManager.profiles[Current_profile.indexProfile].Games.Add(games); }
            catch { GamesManager.profiles[0].Games.Add(games); }
            
            seconds = 0;


            //if (GamesManager.numAllGames == 1)
            //{
            //    GamesManager.minDuration = games.Duration;
            //    GamesManager.maxDuration = games.Duration;
            //    GamesManager.highScore = games.Score;
            //    GamesManager.lowScore = games.Score;
            //}
            //else if (GamesManager.minDuration > games.Duration)
            //    GamesManager.minDuration = games.Duration;

            //else if (GamesManager.maxDuration < games.Duration)
            //    GamesManager.maxDuration = games.Duration;

            //GamesManager.totleDuration += games.Duration;

            //if (GamesManager.highScore < games.Score)
            //    GamesManager.highScore = games.Score;
            //else if (GamesManager.lowScore > games.Score)
            //    GamesManager.lowScore = games.Score;
        }

        private void recordGame()
        {            
            for (int i = 0; i < games.dirctionSteps.Count; i++)
            {
                switch (games.dirctionSteps[i])
                {
                    case 1:
                        games.arr.Add("Up");
                        break;
                    case 2:
                        games.arr.Add( "Down");
                        break;
                    case 3:
                        games.arr.Add("Right");
                        break;
                    case 4:
                        games.arr.Add("Left");
                        break;
                }
            }
          
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ues W or arrow up for go UP\nUes S or arrow Down for go Down\n" +
                "Ues D or arrow Right for go Right\n" + "Ues A or arrow left for go Left\n"
                + "Ues R for Random the game");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}


