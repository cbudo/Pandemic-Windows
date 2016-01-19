using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SQADemicApp
{
    class PlayerDeck : Deck
    {
        private const string resourcePath = SQADemicApp.Properties.Resources.CityList;

        private override void init()
        {
            makeCardList();
            shuffle();
            int epidemicCount;
            if (this._difficulty == DifficultySetting.Easy)
            {
                epidemicCount = EASY_EPIDEMIC_COUNT;
            }
            else if (this._difficulty == DifficultySetting.Medium)
            {
                epidemicCount = MEDIUM_EPIDEMIC_COUNT;
            }
            else
            {
                epidemicCount = HARD_EPIDEMIC_COUNT;
            }
            int subDeckSize = _cards.Count / epidemicCount;
            List<Card>[] subDecks = new List<Card>[epidemicCount];
            List<Card> newInitDeck = new List<Card>();
            for (int i = 0; i < subDecks.Length; i++)
            {
                subDecks[i] = _cards.GetRange(subDeckSize * i, subDeckSize);
                //TODO: Fix this to be integrated with the new Card types
                subDecks[i].Add(new Card("EPIDEMIC", Card.Cardtype.Epidemic));
                subDecks[i] = shuffle(subDecks[i]);
                newInitDeck.AddRange(subDecks[i]);
            }
            _cards = newInitDeck;
        }

        private void makeCardList()
        {
            StringReader stringReader = new StringReader(resourcePath);
            string line;
            while ((line = stringReader.ReadLine()) != null)
            {
                string cardName = line.Substring(0, line.IndexOf(";"));
                string cardColor = line.Substring(line.IndexOf(";") + 2);
                Color color = getColor(cardColor);
                //TODO: Fix this to be integrated with the new Card types
                addCard(new Card(cardName, Card.Cardtype.City, color));
            }
            addSpecialCards();
        }

        private void addSpecialCards()
        {
            //TODO: Fix this to be integrated with the new Card types
            addCard(new Card("Airlift", Card.Cardtype.Special));
            addCard(new Card("One Quiet Night", Card.Cardtype.Special));
            addCard(new Card("Resilient Population", Card.Cardtype.Special));
            addCard(new Card("Government Grant", Card.Cardtype.Special));
            addCard(new Card("Forecast", Card.Cardtype.Special));
        }
        
    }
}
