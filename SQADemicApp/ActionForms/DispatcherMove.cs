using System;
using System.Linq;
using System.Windows.Forms;
using SQADemicApp.Players;

namespace SQADemicApp
{
    public partial class DispatcherMove : Form
    {
        public DispatcherMove()
        {
            InitializeComponent();
        }

        public DispatcherMove(Player[] players, int currentPlayer)
        {
            InitializeComponent();
            switch (currentPlayer)
            {
                case 0:
                    Player1.Text = "Player 2";
                    Player2.Text = "Player 3";
                    Player3.Text = "Player 4";
                    break;

                case 1:
                    Player1.Text = "Player 1";
                    Player2.Text = "Player 3";
                    Player3.Text = "Player 4";
                    break;

                case 2:
                    Player1.Text = "Player 1";
                    Player2.Text = "Player 2";
                    Player3.Text = "Player 4";
                    break;

                case 3:
                    Player1.Text = "Player 1";
                    Player2.Text = "Player 2";
                    Player3.Text = "Player 3";
                    break;

                default:
                    break;
            }
            switch (players.Count())
            {
                case 2:
                    Player2.Hide();
                    goto case 3;
                case 3:
                    Player3.Hide();
                    break;
            }
        }

        private void Player_Click(object sender, System.EventArgs e)
        {
            Button pressed = (Button)sender;
            GameBoard.DispatcherMoveIndex = Convert.ToInt32(pressed.Text.Substring(7)) - 1;
            this.Close();
        }
    }
}