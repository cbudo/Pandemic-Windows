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
        /// Completes the special actios for the AirLift card
        /// Moves the player to the destiation city if it is a diffrent city
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
    }
}
