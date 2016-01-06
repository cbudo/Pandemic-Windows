using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
            if (Player1CheckBox.Checked)
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
                sb.Append(Player4ComboBox.SelectedItem + ",");
            }
            sb.Remove(sb.ToString().LastIndexOf(','), 1);
            string[] rolesArray = sb.ToString().Split(',');
            var duplicates = rolesArray.GroupBy(z => z).Where(g => g.Count() > 1).Select(g => g.Key);
            var enumerable = duplicates as IList<string> ?? duplicates.ToList();
            if (enumerable.Any())
            {
                string duplicateWords = enumerable.Aggregate("", (current, dup) => current + (dup + ", "));

                MessageBox.Show("You cannot have more than one: " + duplicateWords.Substring(0, duplicateWords.Length - 2));
                return;
            }
            Program.RolesArray = rolesArray;
            this.Close();
        }

        private void DifficultyChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (introductoryDifficulty.Checked)
            {
                GameBoardModels.Difficulty = DifficultySetting.Easy;
            } else if (normalDifficulty.Checked)
            {
                GameBoardModels.Difficulty = DifficultySetting.Medium;
            } else if (heroicDifficulty.Checked)
            {
                GameBoardModels.Difficulty = DifficultySetting.Hard;
            }
        }
    }
}