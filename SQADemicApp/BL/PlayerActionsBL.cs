using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp.BL
{
    public class PlayerActionsBL
    {

        /// <summary>
        /// Finds the possible cities a player can move to
        /// </summary>
        /// <param name="currentCity"></param>
        /// <returns>List of Cities</returns>
        public static HashSet<City> DriveOptions(City currentCity)
        {
            return currentCity.getAdjacentCities();
        }

        /// <summary>
        /// Finds the possible cities a player can fly to by burning a card
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="currentCity"></param>
        /// <returns></returns>
        public static List<String> DirectFlightOption(List<Card> hand, City currentCity)
        {
            var reducedHand = hand.Where(c => !c.CityName.Equals(currentCity.Name) && c.CardType == Card.CARDTYPE.City);

            var returnlist = new List<String>();
            foreach (Card card in reducedHand)
            {
                returnlist.Add(card.CityName);
            }

            return returnlist;
        }

        /// <summary>
        /// Determins if the player can use a Charter Flight
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="currentCity"></param>
        /// <returns></returns>
        public static bool CharterFlightOption(List<Card> hand, City currentCity)
        {
            return (hand.Where(c => c.CityName == currentCity.Name).Count() == 1);
        }

        /// <summary>
        /// Determines if the player can use a Shuttle Flight and returns list of possibilities
        /// </summary>
        /// <param name="currentCity"></param>
        /// <returns></returns>
        public static List<String> ShuttleFlightOption(City currentCity)
        {
            if (!currentCity.researchStation)
            {
                return new List<String>();
            }
            List<String> options = new List<String>();
            List<City> stations = CityBL.getCitiesWithResearchStations();
            foreach (var city in stations)
            {
                if (city.Name != currentCity.Name)
                {
                    options.Add(city.Name);
                }
            }
            return options;
        }

        #region not implemented
        /**
        public static bool ShareKnowledgeOption(City currentCity, ROLE role)
        {
            //need all of the players
            return false;
        }**/
        #endregion

        /// <summary>
        /// Moves the player to the given city, updating the hand if needed
        /// </summary>
        /// <param name="player">Current Player or if dispatcher, player trying to move</param>
        /// <param name="city">City to move to</param>
        /// <returns>Success Flag/returns>
        public static bool moveplayer(Player player, City city)
        {
            if (DriveOptions(player.currentCity).Any(c => c.Name.Equals(city.Name))){
                //Do Nothing
            }
            else if(ShuttleFlightOption(player.currentCity).Contains(city.Name)){
                //Do Nothing
            }
            else if (DirectFlightOption(player.hand, player.currentCity).Contains(city.Name))
            {
                player.hand.RemoveAll(x => x.CityName.Equals(city.Name));
            }
            else if (CharterFlightOption(player.hand, player.currentCity))
            {
                player.hand.RemoveAll(x => x.CityName.Equals(player.currentCity.Name));
            }
            else
            {
                return false;
            }
            player.currentCity = city;
            return true;
        }

        /// <summary>
        ///  Builds a Research Station should the conditions be meet
        /// </summary>
        /// <param name="player">Current Player</param>
        /// <returns>Success Flag</returns>
        public static bool BuildAResearchStationOption(Player player)
        {
            if (CityBL.getCitiesWithResearchStations().Contains(player.currentCity))
                return false;
            else if (player.role == ROLE.OpExpert)
            {
                player.currentCity.researchStation = true;
                return true;
            }
            else if (player.hand.Any(c => c.CityName.Equals(player.currentCity.Name)))
            {
                player.hand.RemoveAll(x => x.CityName.Equals(player.currentCity.Name));
                player.currentCity.researchStation = true;
                return true;
            }
            return false;

        }


        /// <summary>
        /// Cures the color if possible
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="currentCity"></param>
        /// <param name="role"></param>
        /// <returns>Success Flag</returns>
        public static bool Cure(Player player, List<String> cardsToSpend, COLOR color)
        {
            if (!player.currentCity.researchStation || GameBoardModels.CURESTATUS.getCureStatus(color) != GameBoardModels.Cures.CURESTATE.NotCured)
                return false;
            var cards = player.hand.Where(x => x.CityColor == color && cardsToSpend.Contains(x.CityName));
            if (player.role == ROLE.Scientist)
            {
                if (cards.Count() != 4)
                    return false;
            }
            else if (cards.Count() != 5)
                return false;
            player.hand.RemoveAll(x => cards.Contains(x));
            GameBoardModels.CURESTATUS.setCureStatus(color, GameBoardModels.Cures.CURESTATE.Cured);
            return true;
        }

        /// <summary>
        /// Treates the Diesease if possible
        /// </summary>
        /// <param name="player"></param>
        /// <param name="color"></param>
        /// <returns>Success Flag</returns>
        public static bool TreatDiseaseOption(Player player, COLOR color)
        {
            //need list of cures
            player.currentCity.blueCubes--;
            player.currentCity.redCubes--;
            return true;
        }
    }
}
