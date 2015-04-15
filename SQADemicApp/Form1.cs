using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQADemicApp;
using SQAdemicApp;

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
