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
    public partial class SetupGameForm : Form
    {
        public SetupGameForm()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if(Player1CheckBox.Checked)
            {
                sb.Append(Player1ComboBox.SelectedItem + ",");
            }
            if (Player2CheckBox.Checked)
            {
                sb.Append(Player2ComboBox.SelectedItem + ",");
            }
            if (Player3CheckBox.Checked)
            {
                sb.Append(Player3ComboBox.SelectedItem + ",");
            }
            if (Player4CheckBox.Checked)
            {
                sb.Append(Player4ComboBox.SelectedItem+",");
            }
            sb.Remove(sb.ToString().LastIndexOf(','),1);
            this.Hide();
            Form1 form1 = new Form1(sb.ToString().Split(','));
            form1.Show();
        }
    }
}
