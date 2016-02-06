using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp
{
    public class InfectionPile : Deck
    {
        public InfectionPile()
        {
            init();
        }

        public override void init()
        {
            
        }

        public List<Cards> getAndClearCardList() 
        {
            Cards[] old = new Cards[_cards.Count()];
            _cards.CopyTo(old, 0);
            List<Cards> oldList = new List<Cards>(old);
            _cards.Clear();
            return oldList;
        }

        public bool removeCardFromPlay(string cityname)
        {
            Cards cardToRemove = null;
            foreach (Cards cardInPile in _cards) 
            {
                if (cardInPile.CityName.Equals(cityname)) {
                    cardToRemove = cardInPile;
                    break;
                }
            }
            if (cardToRemove != null) {
                _cards.Remove(cardToRemove);
                return true;
            }
            return false;
        }

        public List<string> getCardsAsStrings() {
            List<string> cardNames = new List<string>();
            foreach (Cards card in _cards) {
                cardNames.Insert(0, card.CityName);
            }
            return cardNames;
        }
    }
}
