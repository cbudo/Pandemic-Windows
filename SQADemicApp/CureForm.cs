using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQADemicApp.BL;

namespace SQADemicApp
{
    public partial class CureForm : Form
    {
        public CureForm()
        {
            InitializeComponent();

            listBox1.Items.Clear();
            listBox1.Items.AddRange(GameBoardModels.players[GameBoardModels.CurrentPlayerIndex].handStringList().ToArray());
        }

        private void Cure_Click(object sender, EventArgs e)
        {
            List<string> selectedCards = new List<string>();
            selectedCards = listBox2.Items.Cast<String>().ToList();
            if(selectedCards.Count<5)
            {
                MessageBox.Show("Not Enough Cards Selected", "Invalid Selection");
                return;
            }
            if(!PlayerActionsBL.Cure(GameBoardModels.players[GameBoardModels.CurrentPlayerIndex], selectedCards, Create.cityDictionary[listBox1.SelectedItems[0].ToString()].color))
            {
                MessageBox.Show("Invalid card selection", "Invalid Selection");
                return;
            }
            this.Dispose();
            this.Close();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            List<string> selectedCards = new List<string>();
            selectedCards = listBox2.SelectedItems.Cast<String>().ToList();
            listBox1.Items.AddRange(selectedCards.ToArray());
            foreach(var item in selectedCards)
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
