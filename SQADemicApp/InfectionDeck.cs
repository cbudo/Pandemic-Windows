using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp
{
    public class InfectionDeck : Deck
    {
        private string resource = Properties.Resources.CityList;

        public InfectionDeck()
        {
            init();
        }

        public Cards drawFromBottom()
        {
            Cards drawn = _cards.ElementAt(_cards.Count() - 1);
            _cards.RemoveAt(_cards.Count() - 1);
            return drawn;
        }

        public void addCardListToTop(List<Cards> newList)
        {
            foreach (Cards c in newList) {
                addCardToTop(c);
            }
        }

        public override void init()
        {
            makeCardList();
            shuffle();
        }

        private void makeCardList()
        {
            StringReader stringReader = new StringReader(resource);
            string line;
            while ((line = stringReader.ReadLine()) != null)
            {
                string cardName = line.Substring(0, line.IndexOf(";"));
                string cardColor = line.Substring(line.IndexOf(";") + 2);
                Color color = getColor(cardColor);
                addCardToBottom(new CityCard(cardName, color));
            }
            
        }

        public List<Cards> getAndRemoveCardsWithNames(List<string> names) 
        {
            List<Cards> cardsToReturn = new List<Cards>();
            foreach (string name in names) {
                foreach (Cards card in _cards) {
                    if (card.CityName.Equals(name)) {
                        cardsToReturn.Add(card);
                    }
                }
            }
            foreach (Cards card in cardsToReturn) {
                _cards.Remove(card);
            }
            return cardsToReturn;
        }

    }
}
