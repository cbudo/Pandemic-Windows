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
        
        private void MoveButton_Click(object sender, EventArgs e)
        {
            Form1.CurrentState = Form1.STATE.Move;
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

    }
}
