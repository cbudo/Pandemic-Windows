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
    public partial class EventCardForm : Form
    {
        public EventCardForm()
        {
            InitializeComponent();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(eventCardNames().ToArray());
        }
        private List<object> eventCardNames()
        {
            List<object> eventCards = new List<object>();
            foreach (var eventCard in GameBoardModels.eventCards)
            {
                eventCards.Add(eventCard.CityName);
            }
            return eventCards;
        }
        public void UpdateEventCards()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(eventCardNames().ToArray());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedCard = listBox1.SelectedItem;
            }
            catch (NullReferenceException)
            {

            }
        }
    }
}
