using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
{
    public partial class Form1 : Form
    {
        //bool goUp; //boolean to be used to detect player up position
        //bool goDown; //boolean to be used to detect player down position
        int speed = 5; //integer called speed holding value of 5
        int puckX = 5; //horizontal X speed value for the ball object
        int puckY = 5; //vertical Y speed value for the ball object
        int score = 0; //score for the player
        int cpuPoint = 0;// score for the CPU

        public Form1()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(Form1_KeyDown);
            KeyDown += new KeyEventHandler(Player2_KeyDown);
            KeyPreview = true;
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)                    //Start of controls for Player 1
        {
            int x = Player1.Location.X;
            int y = Player1.Location.Y;

            if (e.KeyCode == Keys.Right) x += 10;
            else if (e.KeyCode == Keys.Left) x -= 10;
            else if (e.KeyCode == Keys.Up) y -= 10;
            else if (e.KeyCode == Keys.Down) y += 10;

            Player1.Location = new Point(x, y);
        }                                                                   //End of controls for Player 1

        private void Player2_KeyDown(object sender, KeyEventArgs e)         //Start of controls for Player 2
        {
            int x = Player2.Location.X;
            int y = Player2.Location.Y;

            if (e.KeyCode == Keys.D) x += 10;
            else if (e.KeyCode == Keys.A) x -= 10;
            else if (e.KeyCode == Keys.W) y -= 10;
            else if (e.KeyCode == Keys.S) y += 10;

            Player2.Location = new Point(x, y);
        }                                                                   //End of controls for Player 2

        private void timerTick(object sender, EventArgs e)
        {
            //this is the main timer event, this event will trigger every 20 milliseconds

            Player1Score.Text = "" + score; //show Player 1 score on left label
            Player2Score.Text = "" + cpuPoint; //show Player 2 score on right label

            puck.Top -= puckY; //assign the puck TOP to puck Y integer
            puck.Left -= puckX; //assign the puck TOP to puck Y integer

            //Player2.Top += speed; //assignment of the CPU top speed integer                               //CPU code





            //if the score is less than 5





            /*if (score < 5)                                                                                //start of CPU code
            {
                //if Player 2 has reached the top or gone to the bottom of the screen
                if (Player2.Top < 0 || Player2.Top > 527)
                {
                    //change the speed direction so the paddle moves back up or down
                    speed = -speed;
                }
            }
            else //if score is greater than 5, increase difficulty by enabling tracking on right paddle
            {
                Player2.Top = puck.Top + 30;
            }*/                                                                                             //end of CPU code

            //check the score
            //if the puck has gone past Player 1's paddle through the left
            if (puck.Left < 0)
            {
                puck.Left = 560; //reset the puck to the middle of the screen
                puckX = -puckX; //change the puck's direction
                puckX -= 2; //increase the speed
                cpuPoint++; //add 1 to player 2's score
            }

            //if the puck has gone past player 2's paddle on the right
            if (puck.Left + puck.Width > ClientSize.Width)
            {
                puck.Left = 560; //reset the puck to the middle of the screen
                puckX = -puckX; //change the puck's direction
                puckX -= 2; //increase the speed
                score++; //add 1 to player 1's score
            }





            //controlling the puck





            //if the puck either reaches the top of the screen or the bottom
            if (puck.Top < 0 || puck.Top + puck.Height > ClientSize.Height)
            {
                puckY = -puckY; //reverse the speed of the puck so it stays within the screen
            }


            //if the puck hits either paddle
            if (puck.Bounds.IntersectsWith(Player1.Bounds) || puck.Bounds.IntersectsWith(Player2.Bounds))
            {
                puckX = -puckX; //bounce the puck in the other direction
            }


            


            //final score and ending the game





            //if Player 1's score is more than 9
            //stop the timer and show a winning message box for Player 1
            if (score > 9)
            {
                gameTimer.Stop();
                MessageBox.Show("Congratulations, Player 1, you won this game");
            }
            //if Player 2's score is more than 9
            //stop the timer and show a winning message box for Player 2
            if (cpuPoint > 9)
            {
                gameTimer.Stop();
                MessageBox.Show("Congratulations, Player 2, you won this game");
            }

            
        }
    }
}
