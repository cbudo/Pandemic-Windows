using System;
using System.Collections.Generic;

namespace SQADemicApp
{
    public enum Role { Dispatcher, Medic, OpExpert, Researcher, Scientist };

    public class Player
    {
        public readonly Role Role;
        public List<Card> Hand { get; set; }
        public City CurrentCity { get; set; }
        private int _turnCount = 0;

        public bool IncrementTurnCount()
        {
            if (_turnCount == 3)
            {
                _turnCount = 0;
                return true;
            }
            _turnCount++;
            return false;
        }

        public int GetTurnCount()
        {
            return _turnCount;
        }
        public Player(Role role)
        {
            this.Role = role;
            Hand = new List<Card>();
            CurrentCity = Create.CityDictionary["Atlanta"];
        }

        public void Move(City destination)
        {
        }

        public List<Object> HandStringList()
        {
            List<Object> stringHand = new List<Object>();
            if (Hand.Equals(null))
            {
                return stringHand;
            }
            foreach (var card in Hand)
            {
                stringHand.Add(card.CityName + " (" + card.CityColor.ToString() + ")");
            }
            return stringHand;
        }
    }
}