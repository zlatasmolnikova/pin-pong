using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectUlearn.GameModel
{
    internal class Model
    {
        public int ballXspeed { get; set; }
        public int ballYspeed { get; set; }
        public int playerScore { get; set; }
        public int computerScore { get; set; }
        public int[] computerSpeed { get; set; }
        public int[] ballSpeed { get; set; }
        public int playerSpeed { get; set; }
        public int computer_speed_change { get; set; }
        public int speed { get; set; }
        public Random rand;
        public bool goDown, goUp;



        public Model()
        {
            ballXspeed = 4;
            ballYspeed = 4;
            playerScore = 0;
            computerScore = 0;
            computerSpeed = new int[] { 7, 8, 9, 10 };
            ballSpeed = new int[] { 11, 8, 9, 12, 13 };
            playerSpeed = 8;
            computer_speed_change = 50;
            speed = 2;
            rand = new Random();
        }
    }
}
