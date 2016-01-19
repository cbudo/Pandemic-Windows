using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp.Players
{
    public class Dispatcher : Player
    {
        public Dispatcher() : base("Dispatcher")
        {
        }

       
        /// <summary>
        /// Moves the player to the destination city
        /// </summary>
        /// <param name="player">Player to be moved</param>
        /// <param name="players">List of Players</param>
        /// <param name="destination">Name of the City to be moved to</param>
        /// <returns>Status Flag</returns>
        public bool DispatcherMovePlayer(Player player, List<Player> players, City destination)
        {
            if (player.DriveOptions().Any(p => p.Name.Equals(destination.Name)))
            {
                //Do nothing
            }
            else if (players.Any(p => p.CurrentCity.Name.Equals(destination.Name)))
            {
                //Do nothing
            }
            else if (player.ShuttleFlightOption().Contains(destination.Name))
            {
                //Do Nothing
            }
            else
            {
                return false;
            }
            player.CurrentCity = destination;
            return true;
        }

    }
}
