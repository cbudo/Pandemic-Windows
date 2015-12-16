using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SQADemicApp
{
    public partial class EventCardForm : Form
    {
        public EventCardForm()
        {
            InitializeComponent();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(EventCardNames().ToArray());
        }

        private List<object> EventCardNames()
        {
            List<object> eventCards = new List<object>();
            foreach (var eventCard in GameBoardModels.EventCards)
            {
                eventCards.Add(eventCard.CityName);
            }
            return eventCards;
        }

        public void UpdateEventCards()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(EventCardNames().ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedCard = listBox1.SelectedItem.ToString();
                switch (selectedCard)
                {
                    case "Airlift":
                        GameBoard.CurrentState = GameBoard.State.Airlift;
                        break;

                    case "One Quiet Night":
                        PlayerPanel.QuietNight = true;
                        break;

                    case "Resilient Population":
                        DiscardPile dp = new DiscardPile(true);
                        dp.Show();
                        break;

                    case "Government Grant":
                        GameBoard.CurrentState = GameBoard.State.GovGrant;
                        break;

                    case "Forecast":
                        Forecast forecast = new Forecast();
                        forecast.Show();
                        break;
                }
                GameBoardModels.EventCards.RemoveAll(x => x.CityName == selectedCard);
                UpdateEventCards();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You must select an event card");
            }
        }
    }
}