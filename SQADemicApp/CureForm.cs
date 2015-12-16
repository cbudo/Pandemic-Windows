using SQADemicApp.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SQADemicApp
{
    public partial class CureForm : Form
    {
        private GameBoard board;

        public CureForm(GameBoard board)
        {
            InitializeComponent();
            this.board = board;
            listBox1.Items.Clear();
            listBox1.Items.AddRange(GameBoardModels.players[GameBoardModels.CurrentPlayerIndex].handStringList().ToArray());
        }

        private void Cure_Click(object sender, EventArgs e)
        {
            List<string> selectedCards = new List<string>();
            var citynamesWithColors = listBox2.Items;
            List<string> cityNames = new List<string>();
            foreach (object o in citynamesWithColors)
            {
                int index = o.ToString().IndexOf('(') - 1;
                cityNames.Add(o.ToString().Substring(0, index));
            }

            bool cured = false;
            try
            {
                cured = PlayerActionsBL.Cure(GameBoardModels.players[GameBoardModels.CurrentPlayerIndex], cityNames, Create.cityDictionary[cityNames[0]].color);
            }
            catch (ArgumentException exe)
            {
                MessageBox.Show("You Win");
                return;
            }

            if (!cured)
                MessageBox.Show("Invalid card selection", "Invalid Selection");
            else
            {
                if (this.board.boardModel.incTurnCount())
                    GameBoard.turnpart = GameBoard.TURNPART.Draw;
                this.Close();
                board.UpdatePlayerForm();
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            List<string> selectedCards = new List<string>();
            selectedCards = listBox2.SelectedItems.Cast<String>().ToList();
            listBox1.Items.AddRange(selectedCards.ToArray());
            foreach (var item in selectedCards)
            {
                listBox2.Items.Remove(item);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            List<string> selectedCards = new List<string>();
            selectedCards = listBox1.SelectedItems.Cast<String>().ToList();
            listBox2.Items.AddRange(selectedCards.ToArray());
            foreach (var item in selectedCards)
            {
                listBox1.Items.Remove(item);
            }
        }
    }
}