using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQADemicApp.BL;

namespace SQADemicApp
{
    public partial class ShareCardForm : Form
    {
        public ShareCardForm()
        {
            InitializeComponent();
            switch(GameBoardModels.CurrentPlayerIndex)
            {
                case 0:
                    P1T.Text = "Player 2";
                    P2T.Text = "Player 3";
                    P3T.Text = "Player 4";
                    break;
                case 1:
                    P1T.Text = "Player 1";
                    P2T.Text = "Player 3";
                    P3T.Text = "Player 4";
                    break;
                case 2:
                    P1T.Text = "Player 1";
                    P2T.Text = "Player 2";
                    P3T.Text = "Player 4";
                    break;
                case 3:
                    P1T.Text = "Player 1";
                    P2T.Text = "Player 2";
                    P3T.Text = "Player 3";
                    break;
                default:
                    break;
            } 
            listBox1.Items.Clear();
            listBox1.Items.AddRange(GameBoardModels.players[GameBoardModels.CurrentPlayerIndex].handStringList().ToArray());
        }
        
        private void P1T_Click(object sender, EventArgs e)
        {
            switch (GameBoardModels.CurrentPlayerIndex)
            {
                case 0:
                    PlayerActionsBL.ShareKnowledgeOption(GameBoardModels.players[GameBoardModels.CurrentPlayerIndex], GameBoardModels.players[1], listBox1.SelectedItem.ToString());
                    break;
                default:
                    PlayerActionsBL.ShareKnowledgeOption(GameBoardModels.players[GameBoardModels.CurrentPlayerIndex], GameBoardModels.players[0], listBox1.SelectedItem.ToString());
                    break;
            }
        }

        private void P2T_Click(object sender, EventArgs e)
        {
            switch (GameBoardModels.CurrentPlayerIndex)
            {
                case 0:
                    PlayerActionsBL.ShareKnowledgeOption(GameBoardModels.players[GameBoardModels.CurrentPlayerIndex], GameBoardModels.players[2], listBox1.SelectedItem.ToString());
                    break;
                case 1:
                    PlayerActionsBL.ShareKnowledgeOption(GameBoardModels.players[GameBoardModels.CurrentPlayerIndex], GameBoardModels.players[2], listBox1.SelectedItem.ToString());
                    break;
                default:
                    PlayerActionsBL.ShareKnowledgeOption(GameBoardModels.players[GameBoardModels.CurrentPlayerIndex], GameBoardModels.players[1], listBox1.SelectedItem.ToString());
                    break;
            }
        }

        private void P3T_Click(object sender, EventArgs e)
        {
            switch (GameBoardModels.CurrentPlayerIndex)
            {
                case 3:
                    PlayerActionsBL.ShareKnowledgeOption(GameBoardModels.players[GameBoardModels.CurrentPlayerIndex], GameBoardModels.players[3], listBox1.SelectedItem.ToString());
                    break;
                default:
                    PlayerActionsBL.ShareKnowledgeOption(GameBoardModels.players[GameBoardModels.CurrentPlayerIndex], GameBoardModels.players[2], listBox1.SelectedItem.ToString());
                    break;
            }
        }

        private void StealCardButton_Click(object sender, EventArgs e)
        {

        }
    }
}
