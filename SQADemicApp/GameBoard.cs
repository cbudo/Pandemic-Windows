using System;
using System.Windows.Forms;
using SQADemicApp.BL;
using System.Collections.Generic;

namespace SQADemicApp
{
    public partial class GameBoard : Form
    {
        public GameBoardModels boardModel;
        CharacterPane form2;
        PlayerPanel playerForm;
        public enum STATE { Dispatcher, Initializing, Move, Cure, Default }
        public static STATE CurrentState;
        public enum TURNPART { Action, Draw, Infect };
        public static TURNPART turnpart;
        public static int dispatcherMoveIndex;

        public GameBoard()
        {
            CurrentState = STATE.Initializing;
            string[] rolesDefault = { "Dispatcher", "Scientist" };
            boardModel = new GameBoardModels(rolesDefault);
            playerForm = new PlayerPanel(this);
            form2 = new CharacterPane(rolesDefault);
            InitializeComponent();
            form2.Show();
            playerForm.Show();
            UpdatePlayerForm();
            //GameBoardModels.CURESTATUS.RedCure = GameBoardModels.Cures.CURESTATE.Cured;
            //GameBoardModels.cubeCount.blackCubes = 9;

            CurrentState = STATE.Default;
            turnpart = TURNPART.Action;
        }
        public GameBoard(string[] playerRoles)
        {

            boardModel = new GameBoardModels(playerRoles);
            playerForm = new PlayerPanel(this);
            form2 = new CharacterPane(playerRoles);

            InitializeComponent();
            form2.Show();
            playerForm.Show();
            UpdatePlayerForm();
            CurrentState = STATE.Default;
            turnpart = TURNPART.Action;
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
            switch (CurrentState)
            {
                case STATE.Dispatcher:
                    if (PlayerActionsBL.DispatcherMovePlayer(GameBoardModels.players[dispatcherMoveIndex],new List<Player>(GameBoardModels.players), Create.cityDictionary[pressed.Text.Substring(1)]))
                    {
                        switch (dispatcherMoveIndex)
                        {
                            case 3:
                                form2.Player4.Text = "Player 4\n" + GameBoardModels.players[3].role.ToString() + "\n" + pressed.Text.Substring(1);
                                break;
                            case 2:
                                form2.Player3.Text = "Player 3\n" + GameBoardModels.players[2].role.ToString() + "\n" + pressed.Text.Substring(1);
                                break;
                            case 1:
                                form2.Player2.Text = "Player 2\n" + GameBoardModels.players[1].role.ToString() + "\n" + pressed.Text.Substring(1);
                                break;
                            default:
                                form2.Player1.Text = "Player 1\n" + GameBoardModels.players[0].role.ToString() + "\n" + pressed.Text.Substring(1);
                                break;
                        }
                        bool endofturn = boardModel.incTurnCount();
                        if (endofturn)
                            turnpart = TURNPART.Draw;
                        UpdatePlayerForm();
                    }
                    else
                    {
                        MessageBox.Show("Invalid City", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;
                case STATE.Move:
                    if (PlayerActionsBL.moveplayer(GameBoardModels.players[GameBoardModels.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]))
                    {
                        switch (GameBoardModels.CurrentPlayerIndex)
                        {
                            case 3:
                                form2.Player4.Text = "Player 4\n" + GameBoardModels.players[3].role.ToString() + "\n" + pressed.Text.Substring(1);
                                break;
                            case 2:
                                form2.Player3.Text = "Player 3\n" + GameBoardModels.players[2].role.ToString() + "\n" + pressed.Text.Substring(1);
                                break;
                            case 1:
                                form2.Player2.Text = "Player 2\n" + GameBoardModels.players[1].role.ToString() + "\n" + pressed.Text.Substring(1);
                                break;
                            default:
                                form2.Player1.Text = "Player 1\n" + GameBoardModels.players[0].role.ToString() + "\n" + pressed.Text.Substring(1);
                                break;
                        }
                        bool endofturn = boardModel.incTurnCount();
                        if (endofturn)
                            turnpart = TURNPART.Draw;
                        UpdatePlayerForm();
                    }
                    else
                    {
                        MessageBox.Show("Invalid City", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;
                default:
                    CityPageForm CPForm = new CityPageForm(Create.cityDictionary[pressed.Text.Substring(1)]);
                    CPForm.Show();
                    break;
            }
            CurrentState = STATE.Default;
        }
        public void UpdatePlayerForm()
        {
            playerForm.progressBar1.Value = 100 * (boardModel.currentPlayerTurnCounter) / 4;
            playerForm.label1.Text = playerForm.label1.Text.Substring(0, playerForm.label1.Text.Length - 3) + (Convert.ToInt32(boardModel.currentPlayerTurnCounter)) + "/" + 4;
            playerForm.listBox1.Items.Clear();
            playerForm.listBox1.Items.AddRange(GameBoardModels.players[GameBoardModels.CurrentPlayerIndex].handStringList().ToArray());
            if (GameBoardModels.players[GameBoardModels.CurrentPlayerIndex].role == ROLE.Dispatcher)
            {
                playerForm.DispatcherMove.Show();
                playerForm.AAButton.Location = new System.Drawing.Point(159, 82);
            }
            else
            {
                playerForm.DispatcherMove.Hide();
                playerForm.AAButton.Location = new System.Drawing.Point(91, 81);
            }
            if (turnpart == TURNPART.Draw)
            {
                playerForm.EndSequenceBtn.Text = "Draw Cards";
                playerForm.EndSequenceBtn.Show();
            }
            else if (turnpart == TURNPART.Infect)
            {
                playerForm.EndSequenceBtn.Text = "Infect";
                playerForm.EndSequenceBtn.Show();
            }
            else
            {
                playerForm.EndSequenceBtn.Hide();
            }
            updateCharacterForm(GameBoardModels.CurrentPlayerIndex);
            updateCubeCounts();
            updateCounters();
            updateCureStatus();
        }

        private void updateCharacterForm(int p)
        {
            switch (p)
            {
                case 3:
                    form2.Player4.UseVisualStyleBackColor = false;
                    form2.Player3.UseVisualStyleBackColor = true;
                    break;
                case 2:
                    form2.Player3.UseVisualStyleBackColor = false;
                    form2.Player2.UseVisualStyleBackColor = true;
                    break;
                case 1:
                    form2.Player2.UseVisualStyleBackColor = false;
                    form2.Player1.UseVisualStyleBackColor = true;
                    break;
                default:
                    form2.Player1.UseVisualStyleBackColor = false;
                    form2.Player4.UseVisualStyleBackColor = form2.Player3.UseVisualStyleBackColor = form2.Player2.UseVisualStyleBackColor = true;
                    break;
            }
            switch(GameBoardModels.players.Length)
            {
                case 4:
                    form2.Player4.Text = "Player 4\n" + GameBoardModels.players[3].role.ToString() + "\n" + GameBoardModels.players[3].currentCity.Name;
                    goto case 3;
                case 3:
                    form2.Player3.Text = "Player 3\n" + GameBoardModels.players[2].role.ToString() + "\n" + GameBoardModels.players[2].currentCity.Name;
                    goto case 2;
                case 2:
                    form2.Player1.Text = "Player 1\n" + GameBoardModels.players[0].role.ToString() + "\n" + GameBoardModels.players[0].currentCity.Name;
                    form2.Player2.Text = "Player 2\n" + GameBoardModels.players[1].role.ToString() + "\n" + GameBoardModels.players[1].currentCity.Name;
                    break;       
            }
        }
        private void updateCubeCounts()
        {
            playerForm.RedCubes.Text = String.Format("Red Cubes Remaining:    {0,-2}/24", GameBoardModels.cubeCount.redCubes);
            playerForm.BlueCubes.Text = String.Format("Blue Cubes Remaining:   {0,-2}/24", GameBoardModels.cubeCount.blueCubes);
            playerForm.BlackCubes.Text = String.Format("Black Cubes Remaining:  {0,-2}/24", GameBoardModels.cubeCount.blackCubes);
            playerForm.YellowCubes.Text = String.Format("Yellow Cubes Remaining: {0,-2}/24", GameBoardModels.cubeCount.yellowCubes);
        }
        private void updateCounters()
        {
            playerForm.InfectionRate.Text = string.Format("Infection Rate: {0}", GameBoardModels.InfectionRate);
            playerForm.OutbreakCount.Text = string.Format("Outbreak Count: {0}", GameBoardModels.outbreakMarker);
        }
        private void updateCureStatus()
        {
            // set value of cure label to status in game board
            // if status is NotCured, change to No Cure for nicer appearance
            playerForm.RedCure.Text = String.Format("Red:  {0}", GameBoardModels.CURESTATUS.RedCure.ToString().Replace("NotCured", "No Cure"));
            playerForm.BlueCure.Text = String.Format("Blue: {0}", GameBoardModels.CURESTATUS.BlueCure.ToString().Replace("NotCured", "No Cure"));
            playerForm.BlackCure.Text = String.Format("Black:  {0}", GameBoardModels.CURESTATUS.BlackCure.ToString().Replace("NotCured", "No Cure"));
            playerForm.YellowCure.Text = String.Format("Yellow: {0}", GameBoardModels.CURESTATUS.YellowCure.ToString().Replace("NotCured", "No Cure"));
        }
    }
}
