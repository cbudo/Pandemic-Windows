using System;
using System.Collections.Generic;
using System.Linq;

namespace SQADemicApp
{
    public enum ROLE { Dispatcher, Medic, OpExpert, Researcher, Scientist };
    public class Player
    {

        public List<GameBoardModels.Card> hand = new List<GameBoardModels.Card>();
        public City location { get; set; }
        public Player()
        {

        }
        public void move(City destination)
        {

        }
    }

}