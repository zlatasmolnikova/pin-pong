using GameProjectUlearn.GameController;
using GameProjectUlearn.GameModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProjectUlearn
{
    public partial class Form1 : Form
    {
        private Controller controller;
        private Model model;
        public Form1()
        {
            InitializeComponent();
            controller = new Controller(this);
            model = new Model();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)    
        {
            controller.KeyDown(this, e);
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            controller.KeyIsUp(this, e);
        }
        public void UpdateScore(int playerScore, int computerScore) 
        {
            this.Text = "Player Score: " + playerScore + "--- Computer Score: " + computerScore;
        }

        public void GameOver(string message) 
        {
            controller.ResetGame(message);
        }

        public void GameTimerEvent(object sender, EventArgs e)
        {
            controller.GameTimerEvent(sender, e);            
        }
    }
}
