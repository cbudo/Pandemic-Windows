using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SQADemicApp
{
    public class PlayerDeck : Deck
    {
        #region Constansts
        private const int TWO_PLAYER_HAND = 4;
        private const int THREE_PLAYER_HAND = 3;
        private const int FOUR_PLAYER_HAND = 2;
        #endregion Constants

        private string resource = SQADemicApp.Properties.Resources.CityList;
        protected DifficultySetting _difficulty;
        protected int _numOfPlayers;
        protected int _epidemicCount;

        public PlayerDeck(DifficultySetting difficulty, int numOfPlayers)
        {
            this._difficulty = difficulty;
            this._numOfPlayers = numOfPlayers;
            init();
        }

        public override void init()
        {
            makeCardList();
            shuffle();
            drawHands();
            if (this._difficulty == DifficultySetting.Easy)
            {
                _epidemicCount = EASY_EPIDEMIC_COUNT;
            }
            else if (this._difficulty == DifficultySetting.Medium)
            {
                _epidemicCount = MEDIUM_EPIDEMIC_COUNT;
            }
            else
            {
                _epidemicCount = HARD_EPIDEMIC_COUNT;
            }
            int subDeckSize = _cards.Count / _epidemicCount;
            List<Cards>[] subDecks = new List<Cards>[_epidemicCount];
            List<Cards> newInitDeck = new List<Cards>();
            for (int i = 0; i < subDecks.Length; i++)
            {
                subDecks[i] = _cards.GetRange(subDeckSize * i, subDeckSize);
                //TODO: Fix this to be integrated with the new Card types
                subDecks[i].Add(new EpidemicCard());
                subDecks[i] = shuffle(subDecks[i]);
                newInitDeck.AddRange(subDecks[i]);
            }
            _cards = newInitDeck;
        }

        private void drawHands()
        {
            int totalHandCount = _numOfPlayers == 4 ? _numOfPlayers * FOUR_PLAYER_HAND : _numOfPlayers == 3 ? _numOfPlayers * THREE_PLAYER_HAND : _numOfPlayers * TWO_PLAYER_HAND;
            for (int i = 0; i < totalHandCount; i++)
            {
                _initialDeal.Add(draw());
            }
        }

        public List<Cards> getInitialDeal()
        {
            return _initialDeal;
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
                addCard(new CityCard(cardName, color));
            }
            addSpecialCards();
        }

        private void addSpecialCards()
        {
            //TODO: Fix this to be integrated with the new Card types
            addCard(new SpecialCard("Airlift"));
            addCard(new SpecialCard("One Quiet Night"));
            addCard(new SpecialCard("Resilient Population"));
            addCard(new SpecialCard("Government Grant"));
            addCard(new SpecialCard("Forecast"));
        }

        public int getEpidemicCount()
        {
            return _epidemicCount;
        }

    }
}