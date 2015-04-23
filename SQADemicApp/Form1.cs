﻿using System;
using System.Windows.Forms;

namespace SQADemicApp
{
    public partial class Form1 : Form
    {
        GameBoardModels boardModel;
        Form2 form2 = new Form2();
        Form3 form3 = new Form3();
        public Form1()
        {
            SetupGameForm setupForm = new SetupGameForm();
            setupForm.Show();
            string[] rolesDefault = { "Dispatcher", "Scientist" };
            boardModel = new GameBoardModels(rolesDefault);
            InitializeComponent();
            form2.Show();
            form3.Show();
        }
        public Form1(string[] playerRoles)
        {
            SetupGameForm setupForm = new SetupGameForm();
            setupForm.Show();

            boardModel = new GameBoardModels(playerRoles);
            
            InitializeComponent();
            form2.Show();
            form3.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Atlanta_Click(object sender, EventArgs e)
        {

        }

        private void button49_Click(object sender, EventArgs e)
        {
            Card drawnCard = boardModel.drawCard();
            form3.listBox1.Items.Add(drawnCard.CityName);
        }

    }
}
