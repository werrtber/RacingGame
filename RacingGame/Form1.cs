using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacingGame
{
    public partial class Form1: Form
    {
        private int coinCount = 0;
        public Form1()
        {
            InitializeComponent();
            loseText.Visible = false;
            buttonRestart.Visible = false;
            this.KeyPreview = true; 
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Escape)
                this.Close();
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            int speed = 10;
            bg1.Top += speed;
            pictureBox1.Top += speed;

            int Carspeed = 12;
            enemy1.Top += Carspeed;
            enemy2.Top += Carspeed;

            coin.Top += speed;

            if (bg1.Top >= 650)
            {
                bg1.Top = 0;
                pictureBox1.Top = -650;
            }
            int[] possiblePositionsCar = { 180, 300, 430, 560 };
            Random rand = new Random();
            Random rand2 = new Random();

            if (enemy1.Top >= 650)
            {
                enemy1.Top = -130;
                enemy1.Left = possiblePositionsCar[rand.Next(0, possiblePositionsCar.Length)];
            }

            if (enemy2.Top >= 650)
            {
                enemy2.Top = -250;
                enemy2.Left = possiblePositionsCar[rand.Next(0, possiblePositionsCar.Length)];
            }

            if(enemy1.Bounds.IntersectsWith(player.Bounds) || enemy2.Bounds.IntersectsWith(player.Bounds))
            {
                timer.Enabled = false;
                loseText.Visible = true;
                buttonRestart.Visible = true;
            }

            if (coin.Top >= 650)
            {
                coin.Top = -100;
                int[] possiblePositionsCoins = { 200, 320, 450, 580 };
                coin.Left = possiblePositionsCoins[rand2.Next(0, possiblePositionsCoins.Length)];
            }

            if(player.Bounds.IntersectsWith(coin.Bounds))
            {
                coinCount++;
                labelCoins.Text = "Монети: " + coinCount.ToString();
                coin.Top = -100;
                int[] possiblePositionsCoins = { 200, 320, 450, 580 };
                coin.Left = possiblePositionsCoins[rand2.Next(0, possiblePositionsCoins.Length)];
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int speed = 10;
            if((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && player.Left>180)
            {
                player.Left -= speed;
            }
            else if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.D) && player.Right<660)
            {
                player.Left += speed;
            }
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            enemy1.Top = -130;
            enemy2.Top = -130;
            loseText.Visible = false;
            buttonRestart.Visible = false;
            timer.Enabled = true;
            coinCount = 0;
            labelCoins.Text = "Монети: 0" ;
            coin.Top = -100;
        }

        
    }
}
