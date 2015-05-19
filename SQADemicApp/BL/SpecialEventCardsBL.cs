using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp.BL
{
    public class SpecialEventCardsBL
    {
        /// <summary>
        /// Completes the special actions for the Government Grant Card
        /// Builds a research station in the named city
        /// </summary>
        /// <param name="cityName">City to build a research station</param>
        /// <returns>status flag</returns>
        public static bool GovernmentGrant(string cityName)
        {
            if (Create.cityDictionary[cityName].researchStation == true)
                return false;
            Create.cityDictionary[cityName].researchStation = true;
            return true;
        }

        /// <summary>
        /// Completes the special actions for the AirLift card
        /// Moves a pawn to any city.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="destination"></param>
        /// <returns>status flag</returns>
        public static bool Airlift(Player player, City destination)
        {
            if (player.currentCity.Equals(destination))
                return false;
            player.currentCity = destination;
            return true;
        }

        /// <summary>
        /// Takes a carcd form the Infection Discard Pile and removes it from the game
        /// </summary>
        /// <param name="infectionPile">Infection Discard Pile</param>
        /// <param name="cityname">Card to be removed</param>
        /// <returns>status flag</returns>
        public static bool ResilientPopulation(LinkedList<String> infectionPile, string cityname)
        {
            return false;
        }
    }
}
