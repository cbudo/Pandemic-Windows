using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp.BL
{
    public class PlayerActionsBL
    {

        static CityBL bl = new CityBL();

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

        //Determines if the player can use a Shuttle Flight and returns list of possibilities
        public static List<String> ShuttleFlightOption(City currentCity)
        {
            if (!currentCity.researchStation)
            {
                return new List<string>();
            }
            List<String> options = new List<String>();
            List<City> stations = bl.getCitiesWithResearchStations();
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
    }
}
