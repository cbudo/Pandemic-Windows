using SQADemicApp.BL;
using System;
using System.Windows.Forms;

namespace SQADemicApp
{
    public partial class AdvancedActions : Form
    {
        private GameBoard _board;

        public AdvancedActions(GameBoard board)
        {
            InitializeComponent();
            this._board = board;
        }

        private void ShareKnowledge_Click(object sender, EventArgs e)
        {
            SQADemicApp.ShareCardForm scForm = new ShareCardForm(_board);
            scForm.Show();
            this.Close();
        }

        private void BuildResearchStation_Click(object sender, EventArgs e)
        {
            if (!GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex].BuildAResearchStationOption())
            {
                MessageBox.Show("Research Station unable to be built");
            }
            else
            {
                if (GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex].IncrementTurnCount())
                    GameBoard.TurnPart = GameBoard.Turnpart.Draw;
                _board.UpdatePlayerForm();
                this.Close();
            }
        }

        private void CreateCure_Click(object sender, EventArgs e)
        {
            CureForm cureForm = new CureForm(_board);
            cureForm.Show();
            this.Close();
        }
    }
}