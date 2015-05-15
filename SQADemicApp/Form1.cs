using System;
using System.Windows.Forms;
using SQADemicApp.BL;

namespace SQADemicApp
{
    public partial class Form1 : Form
    {
        GameBoardModels boardModel;
        Form2 form2 = new Form2();
        Form3 form3 = new Form3();
        public enum STATE { Dispatcher, Initializing, Move, Draw, Cure, Default }
        public static STATE CurrentState;
        public Form1()
        {
            CurrentState = STATE.Initializing;
            string[] rolesDefault = { "Dispatcher", "Scientist" };
            boardModel = new GameBoardModels(rolesDefault);
            InitializeComponent();
            form2.Show();
            form3.Show();
            UpdateForm3();
            //GameBoardModels.CURESTATUS.RedCure = GameBoardModels.Cures.CURESTATE.Cured;
            //GameBoardModels.cubeCount.blackCubes = 9;
            CurrentState = STATE.Default;
        }
        public Form1(string[] playerRoles)
        {

            boardModel = new GameBoardModels(playerRoles);

            InitializeComponent();
            form2.Show();
            form3.Show();
            CurrentState = STATE.Default;
        }

        private void button49_Click(object sender, EventArgs e)
        {
            Card drawnCard = boardModel.drawCard();
            GameBoardModels.players[GameBoardModels.CurrentPlayerIndex].hand.Add(drawnCard);
            button49.Text = String.Format("Draw\n{0}", boardModel.playerDeckSize());
            UpdateForm3();
        }

        private void City_Click(object sender, EventArgs e)
        {
            Button pressed = sender as Button;
            switch (CurrentState)
            {
                case STATE.Move:
                    if (PlayerActionsBL.moveplayer(GameBoardModels.players[GameBoardModels.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]))
                    {
                        switch (GameBoardModels.CurrentPlayerIndex)
                        {
                            case 3:
                                form2.Player4.Text = "Player 4\n" + pressed.Text.Substring(1);
                                break;
                            case 2:
                                form2.Player3.Text = "Player 3\n" + pressed.Text.Substring(1);
                                break;
                            case 1:
                                form2.Player2.Text = "Player 2\n" + pressed.Text.Substring(1);
                                break;
                            default:
                                form2.Player1.Text = "Player 1\n" + pressed.Text.Substring(1);
                                break;
                        }
                        boardModel.incTurnCount();
                        UpdateForm3();
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
        public void UpdateForm3()
        {
            form3.progressBar1.Value = 100 * (boardModel.currentPlayerTurnCounter) / 4;
            form3.label1.Text = form3.label1.Text.Substring(0, form3.label1.Text.Length - 3) + (Convert.ToInt32(boardModel.currentPlayerTurnCounter)) + "/" + 4;
            form3.listBox1.Items.Clear();
            form3.listBox1.Items.AddRange(GameBoardModels.players[GameBoardModels.CurrentPlayerIndex].handStringList().ToArray());
            updateCubeCounts();
            updateCounters();
            updateCureStatus();
        }
        private void updateCubeCounts()
        {
            form3.RedCubes.Text = String.Format("Red Cubes Remaining:    {0,-2}/24", GameBoardModels.cubeCount.redCubes);
            form3.BlueCubes.Text = String.Format("Blue Cubes Remaining:   {0,-2}/24", GameBoardModels.cubeCount.blueCubes);
            form3.BlackCubes.Text = String.Format("Black Cubes Remaining:  {0,-2}/24", GameBoardModels.cubeCount.blackCubes);
            form3.YellowCubes.Text = String.Format("Yellow Cubes Remaining: {0,-2}/24", GameBoardModels.cubeCount.yellowCubes);
        }
        private void updateCounters()
        {
            form3.InfectionRate.Text = string.Format("Infection Rate: {0}", boardModel.InfectionRateCounter);
            form3.OutbreakCount.Text = string.Format("Outbreak Count: {0}", GameBoardModels.outbreakMarker);
        }
        private void updateCureStatus()
        {
            // set value of cure label to status in game board
            // if status is NotCured, change to No Cure for nicer appearance
            form3.RedCure.Text = String.Format("Red:  {0}", GameBoardModels.CURESTATUS.RedCure.ToString().Replace("NotCured", "No Cure"));
            form3.BlueCure.Text = String.Format("Blue: {0}", GameBoardModels.CURESTATUS.BlueCure.ToString().Replace("NotCured", "No Cure"));
            form3.BlackCure.Text = String.Format("Black:  {0}", GameBoardModels.CURESTATUS.BlackCure.ToString().Replace("NotCured", "No Cure"));
            form3.YellowCure.Text = String.Format("Yellow: {0}", GameBoardModels.CURESTATUS.YellowCure.ToString().Replace("NotCured", "No Cure"));
        }
    }
}
