using System;
using System.Collections.Generic;
using System.Linq;
using SQADemicApp.BL;
using SQADemicApp.Players;

namespace SQADemicApp.Players
{
    public enum Role { Dispatcher, Medic, OpExpert, Researcher, Scientist };

    public class Player
    {
        public string Name;
        public List<Cards> Hand { get; set; }
        public City CurrentCity { get; set; }
        private int _turnCount = 0;
        public Player(string name)
        {
            this.Name = name;
            Hand = new List<Cards>();
            CurrentCity = Create.CityDictionary["Atlanta"];
        }

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

        public bool Move(City destination)
        {
            if (DriveOptions().Any(c => c.Name.Equals(destination.Name)))
            {
                //Do Nothing
            }
            else if (CurrentCity.ShuttleFlightOption().Contains(destination.Name))
            {
                //Do Nothing
            }
            else if (DirectFlightOption().Contains(destination.Name))
            {
                Hand.RemoveAll(x => x.CityName.Equals(destination.Name));
            }
            else if (CharterFlightOption())
            {
                Hand.RemoveAll(x => x.CityName.Equals(CurrentCity.Name));
            }
            else
            {
                return false;
            }
            CurrentCity = destination;
            return true;
        }
        /// <summary>
        ///  Builds a Research Station should the conditions be meet
        /// </summary>
        /// <param name="player">Current Player</param>
        /// <returns>Success Flag</returns>
        public virtual bool BuildAResearchStationOption()
        {
            if (CityBl.GetCitiesWithResearchStations().Contains(CurrentCity))
                return false;
            else if (Hand.Any(c => c.CityName.Equals(CurrentCity.Name)))
            {
                Hand.RemoveAll(x => x.CityName.Equals(CurrentCity.Name));
                CurrentCity.ResearchStation = true;
                return true;
            }
            return false;
        }
        public List<Object> HandStringList()
        {
            List<Object> stringHand = new List<Object>();
            if (Hand.Equals(null))
            {
                return stringHand;
            }
            stringHand.AddRange(Hand.Select(card => card.CityName + " (" + card.CityColor.ToString() + ")").Cast<object>());
            return stringHand;
        }
        /// <summary>
        /// Finds the possible cities a player can move to
        /// </summary>
        /// <param name="currentCity"></param>
        /// <returns>List of Cities</returns>
        public HashSet<City> DriveOptions()
        {
            return CurrentCity.GetAdjacentCities();
        }

        /// <summary>
        /// Finds the possible cities a player can fly to by burning a card
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="currentCity"></param>
        /// <returns></returns>
        public List<string> DirectFlightOption()
        {
            var reducedHand = Hand.Where(c => !c.CityName.Equals(CurrentCity.Name) && c.GetType() == typeof(CityCard));

            return reducedHand.Select(card => card.CityName).ToList();
        }

        /// <summary>
        /// Determins if the player can use a Charter Flight
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="currentCity"></param>
        /// <returns></returns>
        public bool CharterFlightOption()
        {
            return (Hand.Count(c => c.CityName == CurrentCity.Name) == 1);
        }

        /// <summary>
        /// Cures the color if possible
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="currentCity"></param>
        /// <param name="role"></param>
        /// <returns>Success Flag</returns>
        public virtual bool Cure(List<string> cardsToSpend, Color color)
        {
            if (!CurrentCity.ResearchStation || GameBoardModels.Curestatus.GetCureStatus(color) != Cures.Curestate.NotCured)
                return false;
            var cards = Hand.Where(x => x.CityColor == color && cardsToSpend.Contains(x.CityName));
            if (cards.Count() != 5)
                return false;
            Hand.RemoveAll(x => cards.Contains(x));
            GameBoardModels.Curestatus.SetCureStatus(color, Cures.Curestate.Cured);
            if (GameBoardModels.Curestatus.BlackCure != Cures.Curestate.NotCured &&
                   GameBoardModels.Curestatus.BlueCure != Cures.Curestate.NotCured &&
                   GameBoardModels.Curestatus.RedCure != Cures.Curestate.NotCured &&
                   GameBoardModels.Curestatus.YellowCure != Cures.Curestate.NotCured)
            {
                throw new InvalidOperationException("Game Over You Win");
            }

            return true;
        }

        /// <summary>
        /// Allows Players to Trade Cards
        /// </summary>
        /// <param name="sender">Player who holds the card</param>
        /// <param name="reciver">Player who will recive the card</param>
        /// <param name="cityname">Name on the card to be traded</param>
        /// <returns>Sucess Flag</returns>
        public virtual bool ShareKnowledgeOption(Player reciver, string cityname)
        {
            if (!Equals(CurrentCity, reciver.CurrentCity) ||
                (!reciver.CurrentCity.Name.Equals(cityname)))
                return false;
            int index = Hand.FindIndex(x => x.CityName.Equals(cityname));
            if (index == -1)
                return false;
            reciver.Hand.Add(Hand[index]);
            Hand.RemoveAt(index);
            return true;
        }

        public List<string> ShuttleFlightOption()
        {
            return CurrentCity.ShuttleFlightOption();
        }
        /// <summary>
        /// Treates the Diesease if possible
        /// </summary>
        /// <param name="player"></param>
        /// <param name="color"></param>
        /// <returns>Success Flag</returns>
        public virtual bool TreatDiseaseOption(Color color)
        {
            int number = CurrentCity.GetDiseaseCubes(color);
            if (number < 1)
                return false;
            return CurrentCity.SetDiseaseCubes(color, (number - 1), number);
        }

    }
}