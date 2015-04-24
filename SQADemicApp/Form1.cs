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
            form3.listBox1.Items.Add(drawnCard.CityName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Atlanta_Click(object sender, EventArgs e)
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
                    if (PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]))
                    {
                        switch (boardModel.CurrentPlayerIndex)
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

                    }
                    break;
            }
        }

        private void Jakarta_Click(object sender, EventArgs e)
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
                    if (PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]))
                    {
                        switch (boardModel.CurrentPlayerIndex)
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

                    }
                    break;
            }
        }

        private void Sydney_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Manila_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void HoChiMinhCity_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Bangkok_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void HongKong_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Taipei_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Osaka_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Tokyo_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Seoul_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Beijing_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Kolkata_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Delhi_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Chennai_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Mumbai_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Karachi_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Tehran_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Moscow_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Istanbul_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Baghdad_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Riyadh_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Johannesburg_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Khartoum_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Cairo_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void StPetersburg_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Essen_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Milan_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Algiers_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Kinshasi_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Lagos_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Paris_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void London_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Madrid_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void SaoPaulo_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void BuenosAires_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Santiago_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Lima_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Bogota_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Miami_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Washington_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void NewYork_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Montreal_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void MexicoCity_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Chicago_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void LosAngeles_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void SanFrancisco_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

        private void Shanghai_Click(object sender, EventArgs e)
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
                    PlayerActionsBL.moveplayer(GameBoardModels.players[boardModel.CurrentPlayerIndex], Create.cityDictionary[pressed.Text.Substring(1)]);
                    break;
            }
        }

    }
}
