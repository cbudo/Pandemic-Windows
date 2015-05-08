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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            Form1.CurrentState = Form1.STATE.Move;
        }

        private void ResearchButton_Click(object sender, EventArgs e)
        {
            if (PlayerActionsBL.BuildAResearchStationOption(GameBoardModels.players[GameBoardModels.CurrentPlayerIndex]))
            {
                
            }
        }

        private void CreateCureButton_Click(object sender, EventArgs e)
        {
            List<string> selectedCards = new List<string>();
            selectedCards = listBox1.SelectedItems.Cast<string>().ToList<string>();
            PlayerActionsBL.Cure(GameBoardModels.players[GameBoardModels.CurrentPlayerIndex], selectedCards, Create.cityDictionary[listBox1.SelectedItems[0].ToString()].color);
        }
        private void CureCityButton_Click(object sender, EventArgs e)
        {
            TreatDiseaseForm TDForm = new TreatDiseaseForm();
            TDForm.Show();
        }

    }
}
