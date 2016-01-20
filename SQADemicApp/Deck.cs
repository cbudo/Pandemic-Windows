using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SQADemicApp
{
    abstract class Deck
    {
        protected const int TOTAL_PLAYER_CARDS = 59;
        protected const int EASY_DECK_SIZE = 57;
        protected const int EASY_EPIDEMIC_COUNT = 4;
        protected const int MEDIUM_DECK_SIZE = 58;
        protected const int MEDIUM_EPIDEMIC_COUNT = 5;
        protected const int HARD_DECK_SIZE = 59;
        protected const int HARD_EPIDEMIC_COUNT = 6;

        protected const int TWO_PLAYER_HAND = 4;
        protected const int THREE_PLAYER_HAND = 3;
        protected const int FOUR_PLAYER_HAND = 2;

        protected List<Card> _cards = new List<Card>();
        protected List<Card> _initialDeal = new List<Card>();
        protected Random _rand = new Random();
        
        public abstract void init();

        protected void addCard(Card c)
        {
            _cards.Add(c);
        }

        public void shuffle()
        {
            shuffle(this._cards);
        }

        protected List<Card> shuffle(List<SQADemicApp.Card> unshuffledArray)
        {
            RNGCryptoServiceProvider rnd = new RNGCryptoServiceProvider();
            List<SQADemicApp.Card> shuffledArray = unshuffledArray.OrderBy(x => GetNextInt32(rnd)).ToList<Card>();
            return shuffledArray;
        }

        private int GetNextInt32(RNGCryptoServiceProvider rnd)
        {
            byte[] randomInt = new byte[4];
            rnd.GetBytes(randomInt);
            return Convert.ToInt32(randomInt[0]);
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

        protected Color getColor(string color)
        {
            switch (color.ToLower())
            {
                case "red":
                    return Color.Red;

                case "black":
                    return Color.Black;

                case "yellow":
                    return Color.Yellow;

                default:
                    return Color.Blue;
            }
        }
    }
}
