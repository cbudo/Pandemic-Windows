using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SQADemicApp
{
    public partial class DiscardPile : Form
    {
        public DiscardPile()
        {
            InitializeComponent();
        }

        public DiscardPile(bool resilientPopulation)
        {
            InitializeComponent();
            if (!resilientPopulation)
            {
                Discard.Hide();
            }
            SetCards();
        }

        private void SetCards()
        {
            listBox1.Items.Clear();
            List<string> discarded = GameBoardModels.infectionPile.getCardsAsStrings();
            listBox1.Items.AddRange(discarded.ToArray());
        }

        private void Discard_Click(object sender, EventArgs e)
        {
            try
            {
                var selecteditem = listBox1.SelectedItem.ToString();
                GameBoardModels.infectionPile.removeCardFromPlay(selecteditem);
                this.Close();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No card selected");
            }
        }
    }
}