using System;
using System.Windows.Forms;

namespace SQADemicApp
{
    public partial class CityPageForm : Form
    {
        public CityPageForm(City city)
        {
            InitializeComponent();
            CityName.Text = city.Name;
            CityColor.Text = city.Color.ToString();
            RedCubeCount.Text = city.RedCubes.ToString();
            BlueCubeCount.Text = city.BlueCubes.ToString();
            BlackCubeCount.Text = city.BlackCubes.ToString();
            YellowCubeCount.Text = city.YellowCubes.ToString();
            HasResearchStation.Checked = city.ResearchStation;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}