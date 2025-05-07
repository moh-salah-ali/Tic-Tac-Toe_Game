using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Byte TurnsNumber;

        void SwitchTurns(PictureBox pb)
        {

            if (lblTurn.Text == "Game Over")
            {
                return;
            }

            if (pb.Tag.ToString() == "X" || pb.Tag.ToString() == "O")
            {
                MessageBox.Show("Wrong Choice", "Wrong Choice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ++TurnsNumber;

            if (lblTurn.Tag.ToString() == "Player 1")
            {
                pb.Image = Resources.X;
                pb.Tag = "X";
                lblTurn.Tag = "Player 2";
                lblTurn.Text = "Player 2";
            }

            else if (lblTurn.Tag.ToString() == "Player 2")
            {
                pb.Image = Resources.O;
                pb.Tag = "O";
                lblTurn.Tag = "Player 1";
                lblTurn.Text = "Player 1";
            }
        }

        void GameOver(PictureBox pb1, PictureBox pb2, PictureBox pb3)
        {
            
            lblTurn.Tag = "Game Over";
            lblTurn.Text = "Game Over";

            pb1.BackColor = Color.YellowGreen;
            pb2.BackColor = Color.YellowGreen;
            pb3.BackColor = Color.YellowGreen;

            if (pb1.Tag.ToString() == "X")
            {
                lblWinner.Text = "Player 1";
            }
            else
            {
                lblWinner.Text = "Player 2";
            }

            MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        void CheckButtonsMatch(PictureBox PictureBox1, PictureBox PictureBox2, PictureBox PictureBox3)
        {
            if (PictureBox1.Tag.ToString() == PictureBox2.Tag.ToString() && PictureBox2.Tag.ToString() == PictureBox3.Tag.ToString())
            {
                GameOver(PictureBox1, PictureBox2, PictureBox3);
            }
        }

        void CheckWinner()
        {

            if (lblTurn.Text == "Game Over")
            {
                return;
            }

            CheckButtonsMatch(pb1, pb2, pb3);
            CheckButtonsMatch(pb4, pb5, pb6);
            CheckButtonsMatch(pb7, pb8, pb9);
            CheckButtonsMatch(pb1, pb4, pb7);
            CheckButtonsMatch(pb2, pb5, pb8);
            CheckButtonsMatch(pb3, pb6, pb9);
            CheckButtonsMatch(pb1, pb5, pb9);
            CheckButtonsMatch(pb3, pb5, pb7);

        }

        void CheckDraw()
        {
            if (TurnsNumber == 9)
            {
                if (lblTurn.Text == "Game Over")
                {
                    return;
                }

                lblTurn.Tag = "Game Over";
                lblTurn.Text = "Game Over";
                lblWinner.Text = "Draw";

                MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void UpdateStatus(PictureBox Pb)
        {
            SwitchTurns(Pb);
            CheckWinner();
            CheckDraw();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.FromArgb(255, 255, 255, 255);
            Pen pen = new Pen(White);
            pen.Width = 15;

            
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(pen, 400, 270, 850, 270);
            e.Graphics.DrawLine(pen, 400, 390, 850, 390);

            e.Graphics.DrawLine(pen, 550, 150, 550, 510);
            e.Graphics.DrawLine(pen, 700, 150, 700, 510);

        }

        

        private void pb1_Click(object sender, EventArgs e)
        {
            UpdateStatus((PictureBox)sender);
        }

        private void pb2_Click(object sender, EventArgs e)
        {
            UpdateStatus((PictureBox)sender);
        }

        private void pb3_Click(object sender, EventArgs e)
        {
            UpdateStatus((PictureBox)sender);
        }

        private void pb4_Click(object sender, EventArgs e)
        {
            UpdateStatus((PictureBox)sender);
        }

        private void pb5_Click(object sender, EventArgs e)
        {
            UpdateStatus((PictureBox)sender);
        }

        private void pb6_Click(object sender, EventArgs e)
        {
            UpdateStatus((PictureBox)sender);
        }

        private void pb7_Click(object sender, EventArgs e)
        {
            UpdateStatus((PictureBox)sender);
        }

        private void pb8_Click(object sender, EventArgs e)
        {
            UpdateStatus((PictureBox)sender);
        }

        private void pb9_Click(object sender, EventArgs e)
        {
            UpdateStatus((PictureBox)sender);
        }

        private void btnRestartGame_Click(object sender, EventArgs e)
        {

            lblTurn.Text = "Player 1";
            lblTurn.Tag = "Player 1";
            lblWinner.Text = "In Progress";
            TurnsNumber = 0;

            PictureBox[] boxes = { pb1, pb2, pb3, pb4, pb5, pb6, pb7, pb8, pb9 };

            for (byte i = 0; i < boxes.Length; i++)
            {
                boxes[i].Image = Resources.question_mark_96;
                boxes[i].Tag = (i + 1);
                boxes[i].BackColor = Color.Black;
            }
        }
    }
}
