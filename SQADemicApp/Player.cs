﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SQADemicApp
{
    public enum ROLE { Dispatcher, Medic, OpExpert, Researcher, Scientist };
    public class Player
    {
        public readonly ROLE role;
        public List<Card> hand {get; set;}
        public City location { get; set; }
        public Player(ROLE role)
        {
            this.role = role;
            List<Card> hand = new List<Card>();
        }
        public void move(City destination)
        {

        }
    }

}