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
        public enum STATE { Initializing, Move, Draw, Cure }
        public static STATE CurrentState;
        public Form1()
        {
            CurrentState = STATE.Initializing;
            SetupGameForm setupForm = new SetupGameForm();
            setupForm.Show();
            string[] rolesDefault = { "Dispatcher", "Scientist" };
            boardModel = new GameBoardModels(rolesDefault);
            InitializeComponent();
            form2.Show();
            form3.Show();
        }
        public Form1(string[] playerRoles)
        {
            SetupGameForm setupForm = new SetupGameForm();
            setupForm.Show();

            boardModel = new GameBoardModels(playerRoles);

            InitializeComponent();
            form2.Show();
            form3.Show();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            Card drawnCard = boardModel.drawCard();
            GameBoardModels.players[GameBoardModels.CurrentPlayerIndex].hand.Add(drawnCard);
            UpdateForm3();
        }

        private void City_Click(object sender, EventArgs e)
        {
            Button pressed = sender as Button;
            switch (CurrentState)
            {
                case STATE.Initializing:
                    break;
                case STATE.Draw:
                    break;
                case STATE.Cure:
                    break;
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
                    break;
            }
        }
        public void UpdateForm3()
        {
            form3.progressBar1.Value = 100 * (boardModel.currentPlayerTurnCounter - 1) / 4;
            form3.label1.Text = form3.label1.Text.Substring(0, form3.label1.Text.Length - 3) + (Convert.ToInt32(boardModel.currentPlayerTurnCounter) - 1) + "/" + 4;
            form3.listBox1.Items.Clear();
            form3.listBox1.Items.AddRange(GameBoardModels.players[GameBoardModels.CurrentPlayerIndex].handStringList().ToArray());
        }

    }
}
