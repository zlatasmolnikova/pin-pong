using GameProjectUlearn.GameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProjectUlearn.GameController
{
    internal class Controller
    {
        private Model model;
        private Form1 view;

        public Controller(Form1 view1)
        {
            this.view = view1;
            model = new Model();
        }

        public void GameTimerEvent(object sender, EventArgs e)
        {
            view.ball.Top -= model.ballYspeed;
            view.ball.Left -= model.ballXspeed;
            view.Text = "Player Score: " + model.playerScore + " -- Computer Score: " + model.computerScore;
            if (view.ball.Top < 0 || view.ball.Bottom > view.ClientSize.Height)
            {
                model.ballYspeed = -model.ballYspeed;
            }
            if (view.ball.Left < -5)
            {
                view.ball.Left = 300;
                model.ballXspeed = -model.ballXspeed;
                model.computerScore++;
            }
            if (view.ball.Right > view.ClientSize.Width + 5)
            {
                view.ball.Left = 300;
                model.ballXspeed = -model.ballXspeed;
                model.playerScore++;
            }
            if (view.computer.Top <= 1)
            {
                view.computer.Top = 0;
            }
            else if (view.computer.Bottom >= view.ClientSize.Height)
            {
                view.computer.Top = view.ClientSize.Height - view.computer.Height;
            }
            if (view.ball.Top < view.computer.Top + (view.computer.Height / 2) && view.ball.Left > 300)
            {
                view.computer.Top -= model.speed;
            }
            if (view.ball.Top > view.computer.Top + (view.computer.Height / 2) && view.ball.Left > 300)
            {
                view.computer.Top += model.speed;
            }
            model.computer_speed_change -= 1;
            if (model.computer_speed_change < 0)
            {
                model.speed = model.computerSpeed[model.rand.Next(model.computerSpeed.Length)];
                model.computer_speed_change = 50;
            }
            if (model.goDown && view.player.Top + view.player.Height < view.ClientSize.Height)
            {
                view.player.Top += model.playerSpeed;
            }
            if (model.goUp && view.player.Top > 0)
            {
                view.player.Top -= model.playerSpeed;
            }
            CheckCollision(view.ball, view.player, view.player.Right + 5);
            CheckCollision(view.ball, view.computer, view.computer.Left - 35);
            if (model.goDown && view.player.Top + view.player.Height < view.ClientSize.Height) 
            {
                view.player.Top += model.playerSpeed;
            }
            if (model.goUp && view.player.Top > 0)
            { 
                view.player.Top -= model.playerSpeed;
            }

            if (model.computerScore > 2)
            {
                ResetGame("Sorry you lost the game");
            }
            else if (model.playerScore > 2)
            {
                ResetGame("You Won this game");
            }

        }

        public void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                model.goDown = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                model.goUp = false;
            }
        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                model.goDown = true;
                if (model.goDown && view.player.Top + view.player.Height < view.ClientSize.Height)
                {
                    view.player.Top += model.playerSpeed;
                }
                
            }
            if (e.KeyCode == Keys.Up)
            {
                model.goUp = true;
                if (model.goUp && view.player.Top > 0)
                {
                    view.player.Top -= model.playerSpeed;
                }
            }
        }
        public void CheckCollision(PictureBox PicOne, PictureBox PicTwo, int offset)
        {
            if (PicOne.Bounds.IntersectsWith(PicTwo.Bounds))
            {
                PicOne.Left = offset;
                int x = model.ballSpeed[model.rand.Next(model.ballSpeed.Length)];
                int y = model.ballSpeed[model.rand.Next(model.ballSpeed.Length)];
                if (model.ballXspeed < 0)
                {
                    model.ballXspeed = x;
                }
                else
                {
                    model.ballXspeed = -x;
                }
                if (model.ballYspeed < 0)
                {
                    model.ballYspeed = -y;
                }
                else
                {
                    model.ballYspeed = y;
                }
            }
        }
        public void ResetGame(string message)
        {
            view.GameTimer.Stop();
            MessageBox.Show(message);
            model.computerScore = 0;
            model.playerScore = 0;
            model.ballXspeed = model.ballYspeed = 4;
            model.computer_speed_change = 60;
            view.GameTimer.Start();
        }
    }
}
