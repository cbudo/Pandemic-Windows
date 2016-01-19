using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp
{
    class Deck
    {   
        private const int EASY_DECK_SIZE = 57;
        private const int EASY_EPIDEMIC_COUNT = 4;
        private const int MEDIUM_DECK_SIZE = 58;
        private const int MEDIUM_EPIDEMIC_COUNT = 5;
        private const int HARD_DECK_SIZE = 59;
        private const int HARD_EPIDEMIC_COUNT = 6;

        private const int TWO_PLAYER_HAND_TOTAL = 8;
        private const int THREE_PLAYER_HAND_TOTAL = 9;
        private const int FOUR_PLAYER_HAND_TOTAL = 8;

        private List<Card> _cards = new List<Card>();
        private List<Card> _initialDeal = new List<Card>();
        private DifficultySetting _difficulty;
        private int _numOfPlayers;
        private Random _rand = new Random();

        public Deck(DifficultySetting difficulty, int numOfPlayers)
        {
            this._difficulty = difficulty;
            this._numOfPlayers = numOfPlayers;
        }

        private void init() 
        {
            // TODO: initialize based on difficulty setting and player count
            if (this._difficulty == DifficultySetting.Easy) {
                initEasy();
            }
        }

        private void initEasy()
        {

            //for () {
                
            //}
        }

        private void addCard(Card c)
        {
            _cards.Add(c);
        }

        public void shuffleDeck()
        {

        }

        private void shuffle(List<Card> cards)
        {

        }

        public Card draw()
        {
            Card c = this._cards.ElementAt(0);
            this._cards.RemoveAt(0);
            return c;
        }

        public int getDeckSize() 
        {
            return this._cards.Count;
        }
    }
}
