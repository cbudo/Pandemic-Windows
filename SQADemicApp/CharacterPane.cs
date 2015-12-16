using System;
using System.Linq;
using System.Windows.Forms;

namespace SQADemicApp
{
    public partial class CharacterPane : Form
    {
        private string[] playerRoles;

        public CharacterPane()
        {
            InitializeComponent();
        }

        public CharacterPane(string[] playerRoles)
        {
            InitializeComponent();
            this.playerRoles = playerRoles;
            switch (playerRoles.Count())
            {
                case 1:
                    Player2.Hide();
                    goto case 2;
                case 2:
                    Player3.Hide();
                    goto case 3;
                case 3:
                    Player4.Hide();
                    break;
            }
        }

        private void Player_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (GameBoard.CurrentState == GameBoard.STATE.Dispatcher)
            {
                var playernum = btn.Text.Substring(7, 1);
                GameBoard.dispatcherMoveIndex = Convert.ToInt32(playernum) - 1;
            }
        }
    }
}