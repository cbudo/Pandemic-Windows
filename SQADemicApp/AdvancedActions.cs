using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQADemicApp
{
    public partial class AdvancedActions : Form
    {
        public AdvancedActions()
        {
            InitializeComponent();
        }

        private void AdvancedActions_Load(object sender, EventArgs e)
        {

        }

        private void ShareKnowledge_Click(object sender, EventArgs e)
        {
            SQADemicApp.ShareCardForm SCForm = new ShareCardForm();
            SCForm.Show();
            this.Close();
        }

        private void BuildResearchStation_Click(object sender, EventArgs e)
        {

        }

        private void CreateCure_Click(object sender, EventArgs e)
        {
            SQADemicApp.CureForm cureForm = new CureForm();
            cureForm.Show();
            this.Close();
        }
    }
}
