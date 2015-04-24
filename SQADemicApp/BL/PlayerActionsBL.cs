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
            var reducedHand = hand.Where(c => !c.CityName.Equals(currentCity.Name) && c.CardType == Card.CARDTYPE.City );

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
        #region not implemented
        /**
        public static bool ShuttleFlightOption(List<Card> hand, City currentCity)
        {
            //need list of cities that have research centers
            return false;
        }

        public static bool BuildAResearchStationOption(List<Card> hand, City currentCity, ROLE role)
        {
            //need list of cities with reaserch centers for:
            //count
            //don't double build

            return false;
        }

        public static bool CureOption(List<Card> hand, City currentCity, ROLE role)
        {
            //need a list of existing cures
            return false;
        }

        public static bool TreatDiseaseOption(City currentCity, ROLE role)
        {
            //need list of cures
            return false;
        }

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
        /// <returns>true if move worked and false it failed</returns>
        public static bool moveplayer(Player player, City city)
        {
            player.currentCity = city;
            return true;
        }



    }
}
