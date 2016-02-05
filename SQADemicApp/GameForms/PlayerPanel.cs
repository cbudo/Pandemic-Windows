using SQADemicApp.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SQADemicApp
{
    public partial class PlayerPanel : Form
    {
        private GameBoard _board;
        public static bool QuietNight = false;

        public PlayerPanel(GameBoard board)
        {
            this._board = board;
            InitializeComponent();
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            GameBoard.CurrentState = GameBoard.State.Move;
        }

        private void CureCityButton_Click(object sender, EventArgs e)
        {
            TreatDiseaseForm tdForm = new TreatDiseaseForm(_board);
            tdForm.Show();
        }

        private void AAButton_Click(object sender, EventArgs e)
        {
            AdvancedActions aaForm = new AdvancedActions(_board);
            aaForm.Show();
        }

        private void DispatcherMove_Click(object sender, EventArgs e)
        {
            GameBoard.CurrentState = SQADemicApp.GameBoard.State.Dispatcher;
            SQADemicApp.DispatcherMove dispatcherForm = new DispatcherMove(GameBoardModels.Players,GameBoardModels.CurrentPlayerIndex);
            dispatcherForm.Show();
        }

        private void EndSequenceBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (GameBoard.TurnPart == GameBoard.Turnpart.Draw)
                    Drawcards();
                else if (GameBoard.TurnPart == GameBoard.Turnpart.Infect)
                    InfectCities();
                _board.UpdatePlayerForm();
            }
            catch (GameLostException exc)
            {
                //END OF GAME STUFF
                MessageBox.Show("You Lost. That must suck...");
                MessageBox.Show("Have a great rest of your day");
            }
        }

        private void InfectCities()
        {
            if (!QuietNight)
            {
                List<string> infectedcites = InfectorBl.InfectCities(GameBoardModels.InfectionDeck, GameBoardModels.InfectionPile, GameBoardModels.InfectionRate);
                InfectorBl.InfectCities(infectedcites);
            }
            else
                QuietNight = true;
            GameBoard.TurnPart = GameBoard.Turnpart.Action;
            GameBoardModels.CurrentPlayerIndex = (GameBoardModels.CurrentPlayerIndex + 1) % GameBoardModels.Players.Count();
            _board.UpdateCityButtons(false);
        }

        private void Drawcards()
        {
            //Draw Two cards
            //Card drawCard1 = GameBoardModels.DrawCard();
            //Card drawCard2 = GameBoardModels.DrawCard();
            Cards drawCard1 = _board.drawCard();
            Cards drawCard2 = _board.drawCard();

            //Epidemic code
            if (drawCard1.GetType() == typeof(EpidemicCard))
            {
                string infectcityname = InfectorBl.Epidemic(GameBoardModels.InfectionDeck, GameBoardModels.InfectionPile, ref GameBoardModels.InfectionRateIndex, ref GameBoardModels.InfectionRate);
                new PicForm(false, infectcityname).Show();
                for (int i = 0; i < 3; i++)
                {
                    InfectorBl.InfectCities(new List<string> { infectcityname });
                }
            }
            else if (drawCard1.GetType() == typeof(SpecialCard))
                GameBoardModels.EventCards.Add(drawCard1);
            else
                GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex].Hand.Add(drawCard1);

            if (drawCard2.GetType() == typeof(EpidemicCard))
            {
                string infectcityname = InfectorBl.Epidemic(GameBoardModels.InfectionDeck, GameBoardModels.InfectionPile, ref GameBoardModels.InfectionRateIndex, ref GameBoardModels.InfectionRate);
                new PicForm(false, infectcityname).Show();
                for (int i = 0; i < 3; i++)
                {
                    InfectorBl.InfectCities(new List<string> { infectcityname });
                }
            }
            else if (drawCard2.GetType() == typeof(SpecialCard))
                GameBoardModels.EventCards.Add(drawCard2);
            else
                GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex].Hand.Add(drawCard2);

            //Move to infection phase
            if (!QuietNight)
                GameBoard.TurnPart = GameBoard.Turnpart.Infect;
            else
            {
                QuietNight = false;
                GameBoard.TurnPart = GameBoard.Turnpart.Action;
                GameBoardModels.CurrentPlayerIndex = (GameBoardModels.CurrentPlayerIndex + 1) % GameBoardModels.Players.Count();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _board.displayPossibleMoves();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _board.HidePossibleMoves();
        }
    }
}