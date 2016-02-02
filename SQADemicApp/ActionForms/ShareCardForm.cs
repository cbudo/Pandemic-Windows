using SQADemicApp.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SQADemicApp.Players;

namespace SQADemicApp
{
    public partial class ShareCardForm : Form
    {
        private GameBoard _board;

        public ShareCardForm(GameBoard board)
        {
            this._board = board;
            InitializeComponent();
            switch (GameBoardModels.CurrentPlayerIndex)
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
            switch (GameBoardModels.Players.Count())
            {
                case 2:
                    P2T.Hide();
                    goto case 3;
                case 3:
                    P3T.Hide();
                    break;
            }
            listBox1.Items.Clear();
            listBox1.Items.AddRange(GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex].HandStringList().ToArray());
            List<object> allHands = new List<object>();
            foreach (var player in GameBoardModels.Players)
            {
                if (player != GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex])
                {
                    allHands.AddRange(player.HandStringList());
                }
            }
            listBox2.Items.Clear();
            listBox2.Items.AddRange(allHands.ToArray());
        }

        /// <summary>
        /// Click for give card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P1T_Click(object sender, EventArgs e)
        {
            var selectedItem = listBox1.SelectedItem.ToString();
            var selectedCard = selectedItem.Substring(0, selectedItem.IndexOf('(') - 1);
            bool success = false;
            switch (GameBoardModels.CurrentPlayerIndex)
            {
                case 0:
                    success = GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex].ShareKnowledgeOption(GameBoardModels.Players[1], selectedCard);
                    break;

                default:
                    success = GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex].ShareKnowledgeOption(GameBoardModels.Players[0], selectedCard);
                    break;
            }
            if (success)
            {
                if (GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex].IncrementTurnCount())
                    GameBoard.TurnPart = GameBoard.Turnpart.Draw;
            }
            this.Close();
            _board.UpdatePlayerForm();
        }

        /// <summary>
        /// Click give card to the next player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P2T_Click(object sender, EventArgs e)
        {
            var selectedItem = listBox1.SelectedItem.ToString();
            var selectedCard = selectedItem.Substring(0, selectedItem.IndexOf('(') - 1);
            bool success = false;
            switch (GameBoardModels.CurrentPlayerIndex)
            {
                case 0:
                    success = GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex].ShareKnowledgeOption(GameBoardModels.Players[2], selectedCard);
                    break;

                case 1:
                    success = GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex].ShareKnowledgeOption(GameBoardModels.Players[2], selectedCard);
                    break;

                default:
                    success = GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex].ShareKnowledgeOption(GameBoardModels.Players[1], selectedCard);
                    break;
            }
            if (success)
            {
                if (GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex].IncrementTurnCount())
                    GameBoard.TurnPart = GameBoard.Turnpart.Draw;
            }
            this.Close();
            _board.UpdatePlayerForm();
        }

        /// <summary>
        /// Click give card to the third player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P3T_Click(object sender, EventArgs e)
        {
            var selectedItem = listBox1.SelectedItem.ToString();
            var selectedCard = selectedItem.Substring(0, selectedItem.IndexOf('(') - 1);
            bool success = false;
            switch (GameBoardModels.CurrentPlayerIndex)
            {
                case 3:
                    success = GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex].ShareKnowledgeOption(GameBoardModels.Players[3], selectedCard);
                    break;

                default:
                    success = GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex].ShareKnowledgeOption(GameBoardModels.Players[2], selectedCard);
                    break;
            }
            if (success)
            {
                if (GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex].IncrementTurnCount())
                    GameBoard.TurnPart = GameBoard.Turnpart.Draw;
            }
            this.Close();
            _board.UpdatePlayerForm();
        }

        private void StealCardButton_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = listBox2.SelectedItem.ToString();
                var selectedCard = selectedItem.Substring(0, selectedItem.IndexOf('(') - 1);
                Player selectedCardHolder = GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex];
                foreach (var player in GameBoardModels.Players)
                {
                    if (player.Hand.Any(c => c.CityName == selectedCard))
                    {
                        selectedCardHolder = player;
                        break;
                    }
                }
                if (selectedCardHolder.ShareKnowledgeOption(GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex], selectedCard))
                {
                    MessageBox.Show("Card Traded");
                    this.Close();
                    _board.UpdatePlayerForm();
                }
                else
                {
                    MessageBox.Show("Card unable to be traded");
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You must select a card to take");
            }
        }

        private void ShareCardForm_Load(object sender, EventArgs e)
        {

        }
    }
}