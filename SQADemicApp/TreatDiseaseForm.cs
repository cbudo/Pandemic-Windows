using SQADemicApp.BL;
using System;
using System.Windows.Forms;

namespace SQADemicApp
{
    public partial class TreatDiseaseForm : Form
    {
        private GameBoard _board;

        public TreatDiseaseForm(GameBoard board)
        {
            this._board = board;
            InitializeComponent();
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            Color colorChoice;
            switch (button.Text)
            {
                case "Blue":
                    colorChoice = Color.Blue;
                    break;

                case "Black":
                    colorChoice = Color.Black;
                    break;

                case "Red":
                    colorChoice = Color.Red;
                    break;

                default:
                    colorChoice = Color.Yellow;
                    break;
            }
            PlayerActionsBl.TreatDiseaseOption(GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex], colorChoice);

            if (GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex].IncrementTurnCount())
                GameBoard.TurnPart = GameBoard.Turnpart.Draw;
            this.Close();
            _board.UpdatePlayerForm();
            _board.UpdateCityButtons(false);
        }
    }
}