using System;
using System.Collections.Generic;

namespace SQADemicApp
{
    public enum Role { Dispatcher, Medic, OpExpert, Researcher, Scientist };

    public class Player
    {
        public readonly Role Role;
        public List<Cards> Hand { get; set; }
        public City CurrentCity { get; set; }

        public Player(Role role)
        {
            this.Role = role;
            Hand = new List<Cards>();
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