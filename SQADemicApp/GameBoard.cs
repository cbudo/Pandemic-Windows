using SQADemicApp.BL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SQADemicApp
{
    public partial class GameBoard : Form
    {
        public GameBoardModels BoardModel;
        private CharacterPane _form2;
        private PlayerPanel _playerForm;
        private EventCardForm _ecForm;
        ToolTip tip = new ToolTip();

        public enum State { Dispatcher, Initializing, Move, Cure, Default, Airlift, GovGrant }

        public static State CurrentState;

        public enum Turnpart { Action, Draw, Infect };

        public static Turnpart TurnPart;
        public static int DispatcherMoveIndex;

        public GameBoard()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            CurrentState = State.Initializing;
            string[] rolesDefault = { "Dispatcher", "Scientist" };
            BoardModel = new GameBoardModels(rolesDefault);
            _playerForm = new PlayerPanel(this);
            _form2 = new CharacterPane(rolesDefault);
            _ecForm = new EventCardForm();
            InitializeComponent();
            _ecForm.Show();
            _form2.Show();
            _playerForm.Show();
            UpdatePlayerForm();
            UpdateCityButtons(true);
            CurrentState = State.Default;
            TurnPart = Turnpart.Action;
            updateDifficultyDisplay();
        }

        public GameBoard(string[] playerRoles)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BoardModel = new GameBoardModels(playerRoles);
            _playerForm = new PlayerPanel(this);
            _form2 = new CharacterPane(playerRoles);
            _ecForm = new EventCardForm();
            InitializeComponent();
            _ecForm.Show();
            _form2.Show();
            _playerForm.Show();
            UpdatePlayerForm();
            UpdateCityButtons(true);
            CurrentState = State.Default;
            TurnPart = Turnpart.Action;
            updateDifficultyDisplay();
        }

        private void updateDifficultyDisplay()
        {
            String text;
            switch(GameBoardModels.Difficulty)
            {
                case DifficultySetting.Easy:
                    text = "Introductory"; break;
                case DifficultySetting.Medium:
                    text = "Normal"; break;
                case DifficultySetting.Hard:
                    text = "Heroic"; break;
                case DifficultySetting.Legendary:
                    text = "Legendary"; break;
                default:
                    text = "Normal"; break;
            }
            this.difficultyDisplay.Text = text;
        }

        //private void DrawBtn_Click(object sender, EventArgs e)
        //{
        //    Card drawnCard = boardModel.drawCard();
        //    GameBoardModels.players[GameBoardModels.CurrentPlayerIndex].hand.Add(drawnCard);
        //    button49.Text = String.Format("Draw\n{0}", boardModel.playerDeckSize());
        //    UpdatePlayerForm();
        //}

        private void City_Click(object sender, EventArgs e)
        {
            Button pressed = sender as Button;
            var cityName = pressed.Text.Substring(3);
            switch (CurrentState)
            {
                case State.Airlift:
                    SpecialEventCardsBl.Airlift(GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex], Create.CityDictionary[cityName]);
                    break;

                case State.GovGrant:
                    SpecialEventCardsBl.GovernmentGrant(cityName);
                    break;

                case State.Dispatcher:
                    if (PlayerActionsBl.DispatcherMovePlayer(GameBoardModels.Players[DispatcherMoveIndex], new List<Player>(GameBoardModels.Players), Create.CityDictionary[cityName]))
                    {
                        switch (DispatcherMoveIndex)
                        {
                            case 3:
                                _form2.Player4.Text = "Player 4\n" + GameBoardModels.Players[3].Role.ToString() + "\n" + cityName;
                                break;

                            case 2:
                                _form2.Player3.Text = "Player 3\n" + GameBoardModels.Players[2].Role.ToString() + "\n" + cityName;
                                break;

                            case 1:
                                _form2.Player2.Text = "Player 2\n" + GameBoardModels.Players[1].Role.ToString() + "\n" + cityName;
                                break;

                            default:
                                _form2.Player1.Text = "Player 1\n" + GameBoardModels.Players[0].Role.ToString() + "\n" + cityName;
                                break;
                        }
                        if (BoardModel.IncTurnCount())
                            TurnPart = Turnpart.Draw;
                        UpdatePlayerForm();
                        UpdateCityButtons(false);
                    }
                    else
                    {
                        MessageBox.Show("Invalid City", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                case State.Move:
                    if (PlayerActionsBl.Moveplayer(GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex], Create.CityDictionary[cityName]))
                    {
                        switch (GameBoardModels.CurrentPlayerIndex)
                        {
                            case 3:
                                _form2.Player4.Text = "Player 4\n" + GameBoardModels.Players[3].Role.ToString() + "\n" + cityName;
                                break;

                            case 2:
                                _form2.Player3.Text = "Player 3\n" + GameBoardModels.Players[2].Role.ToString() + "\n" + cityName;
                                break;

                            case 1:
                                _form2.Player2.Text = "Player 2\n" + GameBoardModels.Players[1].Role.ToString() + "\n" + cityName;
                                break;

                            default:
                                _form2.Player1.Text = "Player 1\n" + GameBoardModels.Players[0].Role.ToString() + "\n" + cityName;
                                break;
                        }
                        bool endofturn = BoardModel.IncTurnCount();
                        if (endofturn)
                            TurnPart = Turnpart.Draw;
                        UpdatePlayerForm();
                        UpdateCityButtons(false);
                    }
                    else
                    {
                        MessageBox.Show("Invalid City", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                default:
                    CityPageForm cpForm = new CityPageForm(Create.CityDictionary[cityName]);
                    cpForm.Show();
                    break;
            }
            CurrentState = State.Default;
        }

        public void UpdatePlayerForm()
        {
            _playerForm.progressBar1.Value = 100 * (BoardModel.CurrentPlayerTurnCounter) / 4;
            _playerForm.label1.Text = _playerForm.label1.Text.Substring(0, _playerForm.label1.Text.Length - 3) + (Convert.ToInt32(BoardModel.CurrentPlayerTurnCounter)) + "/" + 4;
            _playerForm.listBox1.Items.Clear();
            _playerForm.listBox1.Items.AddRange(GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex].HandStringList().ToArray());
            if (GameBoardModels.Players[GameBoardModels.CurrentPlayerIndex].Role == Role.Dispatcher)
            {
                _playerForm.DispatcherMove.Show();
                _playerForm.AAButton.Location = new System.Drawing.Point(159, 82);
            }
            else
            {
                _playerForm.DispatcherMove.Hide();
                _playerForm.AAButton.Location = new System.Drawing.Point(91, 81);
            }
            if (TurnPart == Turnpart.Draw)
            {
                _playerForm.EndSequenceBtn.Text = "Draw Cards";
                _playerForm.EndSequenceBtn.Show();
            }
            else if (TurnPart == Turnpart.Infect)
            {
                _playerForm.EndSequenceBtn.Text = "Infect";
                _playerForm.EndSequenceBtn.Show();
            }
            else
            {
                _playerForm.EndSequenceBtn.Hide();
            }
            UpdateCharacterForm(GameBoardModels.CurrentPlayerIndex);
            UpdateCubeCounts();
            UpdateCounters();
            UpdateCureStatus();
            _ecForm.UpdateEventCards();
        }

        private void UpdateCharacterForm(int p)
        {
            switch (p)
            {
                case 3:
                    _form2.Player4.UseVisualStyleBackColor = false;
                    _form2.Player3.UseVisualStyleBackColor = true;
                    break;

                case 2:
                    _form2.Player3.UseVisualStyleBackColor = false;
                    _form2.Player2.UseVisualStyleBackColor = true;
                    break;

                case 1:
                    _form2.Player2.UseVisualStyleBackColor = false;
                    _form2.Player1.UseVisualStyleBackColor = true;
                    break;

                default:
                    _form2.Player1.UseVisualStyleBackColor = false;
                    _form2.Player4.UseVisualStyleBackColor = _form2.Player3.UseVisualStyleBackColor = _form2.Player2.UseVisualStyleBackColor = true;
                    break;
            }
            switch (GameBoardModels.Players.Length)
            {
                case 4:
                    _form2.Player4.Text = "Player 4\n" + GameBoardModels.Players[3].Role.ToString() + "\n" + GameBoardModels.Players[3].CurrentCity.Name;
                    goto case 3;
                case 3:
                    _form2.Player3.Text = "Player 3\n" + GameBoardModels.Players[2].Role.ToString() + "\n" + GameBoardModels.Players[2].CurrentCity.Name;
                    goto case 2;
                case 2:
                    _form2.Player1.Text = "Player 1\n" + GameBoardModels.Players[0].Role.ToString() + "\n" + GameBoardModels.Players[0].CurrentCity.Name;
                    _form2.Player2.Text = "Player 2\n" + GameBoardModels.Players[1].Role.ToString() + "\n" + GameBoardModels.Players[1].CurrentCity.Name;
                    break;
            }
        }

        private void UpdateCubeCounts()
        {
            _playerForm.RedCubes.Text = string.Format("Red Cubes Remaining:    {0,-2}/24", GameBoardModels.CubeCount.RedCubes);
            _playerForm.BlueCubes.Text = string.Format("Blue Cubes Remaining:   {0,-2}/24", GameBoardModels.CubeCount.BlueCubes);
            _playerForm.BlackCubes.Text = string.Format("Black Cubes Remaining:  {0,-2}/24", GameBoardModels.CubeCount.BlackCubes);
            _playerForm.YellowCubes.Text = string.Format("Yellow Cubes Remaining: {0,-2}/24", GameBoardModels.CubeCount.YellowCubes);
        }

        private void UpdateCounters()
        {
            _playerForm.InfectionRate.Text = string.Format("Infection Rate: {0}", GameBoardModels.InfectionRate);
            _playerForm.OutbreakCount.Text = string.Format("Outbreak Count: {0}", GameBoardModels.OutbreakMarker);
        }

        private void UpdateCureStatus()
        {
            // set value of cure label to status in game board
            // if status is NotCured, change to No Cure for nicer appearance
            _playerForm.RedCure.Text = string.Format("Red:  {0}", GameBoardModels.Curestatus.RedCure.ToString().Replace("NotCured", "No Cure"));
            _playerForm.BlueCure.Text = string.Format("Blue: {0}", GameBoardModels.Curestatus.BlueCure.ToString().Replace("NotCured", "No Cure"));
            _playerForm.BlackCure.Text = string.Format("Black:  {0}", GameBoardModels.Curestatus.BlackCure.ToString().Replace("NotCured", "No Cure"));
            _playerForm.YellowCure.Text = string.Format("Yellow: {0}", GameBoardModels.Curestatus.YellowCure.ToString().Replace("NotCured", "No Cure"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DiscardPile dp = new DiscardPile(false);
            dp.Show();
        }

        public void UpdateCityButtons(bool firstRun)
        {
            foreach (var control in this.Controls)
            {
                if (control is Button)
                {
                    var button = control as Button;
                    string cityName = button.Text.Substring(3);
                    try
                    {
                        var city = Create.CityDictionary[cityName];
                        button.Text = string.Format("{0,2} " + city.Name, city.AllCubeCount());
                        if (firstRun)
                            button.Font = new System.Drawing.Font(button.Font.FontFamily, 5);
                    }
                    catch (KeyNotFoundException)
                    {
                        // not a button that needs to be updated
                    }
                }
            }
        }

        public void City_Hover(object sender, EventArgs e)
        {
            var city = Create.CityDictionary[((Button)sender).Text.Substring(3)];
            var tipInfo =
                $"{city.Name}\n{city.Color}\n\nBlack: {city.BlackCubes}\nBlue: {city.BlueCubes}\nRed: {city.RedCubes}\nYellow: {city.YellowCubes}\n";
            if (city.ResearchStation) tipInfo += "\nResearch Station";
            tip.Show(tipInfo, (Button)sender);
        }

    }
}