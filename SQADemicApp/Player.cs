using System;
using System.Collections.Generic;
using System.Linq;

namespace SQADemicApp
{
    public enum ROLE { Dispatcher, Medic, OpExpert, Researcher, Scientist };
    public class Player
    {
        public readonly ROLE role;
        public City location { get; set; }
        public Player(ROLE role)
        {
            this.role = role;
        }
        public void move(City destination)
        {

        }
    }

}