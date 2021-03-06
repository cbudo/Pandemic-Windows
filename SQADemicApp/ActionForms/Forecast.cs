﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SQADemicApp
{
    public partial class Forecast : Form
    {
        public Forecast()
        {
            InitializeComponent();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(SQADemicApp.BL.SpecialEventCardsBl.GetForcastCards(GameBoardModels.infectionDeck).ToArray());
        }

        private void Reorder_Click(object sender, EventArgs e)
        {
            List<string> selectedCards = new List<string>();
            foreach (var select in listBox2.SelectedItems)
            {
                selectedCards.Add(select.ToString());
            }
            SQADemicApp.BL.SpecialEventCardsBl.CommitForcast(GameBoardModels.infectionDeck, selectedCards);
            this.Close();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            List<string> selectedCards = new List<string>();
            selectedCards = listBox2.SelectedItems.Cast<string>().ToList();
            listBox1.Items.AddRange(selectedCards.ToArray());
            foreach (var item in selectedCards)
            {
                listBox2.Items.Remove(item);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            List<string> selectedCards = new List<string>();
            selectedCards = listBox1.SelectedItems.Cast<string>().ToList();
            listBox2.Items.AddRange(selectedCards.ToArray());
            foreach (var item in selectedCards)
            {
                listBox1.Items.Remove(item);
            }
        }
    }
}