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
    public partial class PlayerPanel : Form
    {
        public PlayerPanel()
        {
            InitializeComponent();
        }
        
        private void MoveButton_Click(object sender, EventArgs e)
        {
            GameBoard.CurrentState = GameBoard.STATE.Move;
        }

        private void CureCityButton_Click(object sender, EventArgs e)
        {
            TreatDiseaseForm TDForm = new TreatDiseaseForm();
            TDForm.Show();
        }

        private void AAButton_Click(object sender, EventArgs e)
        {
            AdvancedActions AAForm = new AdvancedActions();
            AAForm.Show();
        }

        private void DispatcherMove_Click(object sender, EventArgs e)
        {

        }

        private void EndSequenceBtn_Click(object sender, EventArgs e)
        {

        }

    }
}
