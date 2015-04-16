using System;
using System.Windows.Forms;

namespace SQADemicApp
{
    public partial class Form1 : Form
    {
        GameBoardModels boardModel;
        public Form1()
        {
            boardModel = new GameBoardModels();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Atlanta_Click(object sender, EventArgs e)
        {

        }

        private void button49_Click(object sender, EventArgs e)
        {
            GameBoardModels.Card drawnCard = boardModel.drawCard();
            boardModel.CurrentPlayer.hand.Add(drawnCard);
        }

    }
}
