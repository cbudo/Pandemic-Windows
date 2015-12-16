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
            if (!PlayerActionsBl.BuildAResearchStationOption(GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex]))
            {
                MessageBox.Show("Research Station unable to be built");
            }
            else
            {
                if (this._board.BoardModel.IncTurnCount())
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