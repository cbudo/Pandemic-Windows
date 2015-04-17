using System;
using System.Windows.Forms;

namespace SQADemicApp
{
    public partial class Form1 : Form
    {
        GameBoardModels boardModel;
        Form2 form2 = new Form2();
        Form3 form3 = new Form3();
        public Form1()
        {
            boardModel = new GameBoardModels();
            InitializeComponent();
            form2.Show();
            form3.Show();
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
            form3.listBox1.Items.Add(drawnCard.CityName);
        }

    }
}
