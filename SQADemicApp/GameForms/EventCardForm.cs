using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SQADemicApp
{
    public partial class EventCardForm : Form
    {
        private Dictionary<string, string> descDict = new Dictionary<string, string>();
        public EventCardForm()
        {
            descDict.Add("Airlift", "Move a pawn (yours or another player's) to any city. You must have a player's permission to move their pawn.");
            descDict.Add("One Quiet Night", "Skip the next infect cities step.");
            descDict.Add("Resilient Population", "Take a card from the Infection Discard Pile and remove it from the game.");
            descDict.Add("Government Grant", "Add a Research Station to any city for free.");
            descDict.Add("Forecast", "Examine the top 6 cards of the Infection Draw Pile, rearrange them in the order of your choice, then place them back on the pile.");

            InitializeComponent();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(EventCardNames().ToArray());
            listBox1.MouseDoubleClick += new MouseEventHandler(Card_Description);
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

        public void Card_Description(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("click");
            int index = listBox1.IndexFromPoint(e.Location);
            if(index != System.Windows.Forms.ListBox.NoMatches)
            {
                MessageBox.Show(descDict[listBox1.SelectedItem.ToString()]);
            }
        }
    }
}