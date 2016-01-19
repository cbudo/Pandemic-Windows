using System;
using System.Collections.Generic;
using System.Linq;

namespace SQADemicApp.BL
{
    public class PlayerActionsBl
    {
        private const int Maxcubecount = 24;

        /// <summary>
        /// Finds the possible cities a player can move to
        /// </summary>
        /// <param name="currentCity"></param>
        /// <returns>List of Cities</returns>
        public static HashSet<City> DriveOptions(City currentCity)
        {
            return currentCity.GetAdjacentCities();
        }

        /// <summary>
        /// Finds the possible cities a player can fly to by burning a card
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="currentCity"></param>
        /// <returns></returns>
        public static List<string> DirectFlightOption(List<Cards> hand, City currentCity)
        {
            var reducedHand = hand.Where(c => !c.CityName.Equals(currentCity.Name) && c.GetType() == typeof(CityCard));

            var returnlist = new List<string>();
            foreach (Cards card in reducedHand)
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
        public static bool CharterFlightOption(List<Cards> hand, City currentCity)
        {
            return (hand.Count(c => c.CityName == currentCity.Name) == 1);
        }

        /// <summary>
        /// Determines if the player can use a Shuttle Flight and returns list of possibilities
        /// </summary>
        /// <param name="currentCity"></param>
        /// <returns></returns>
        public static List<string> ShuttleFlightOption(City currentCity)
        {
            if (!currentCity.ResearchStation)
            {
                return new List<string>();
            }
            List<string> options = new List<string>();
            List<City> stations = CityBl.GetCitiesWithResearchStations();
            foreach (var city in stations)
            {
                if (city.Name != currentCity.Name)
                {
                    options.Add(city.Name);
                }
            }
            return options;
        }

        /// <summary>
        /// Moves the player to the given city, updating the hand if needed
        /// </summary>
        /// <param name="player">Current Player or if dispatcher, player trying to move</param>
        /// <param name="city">City to move to</param>
        /// <returns>Success Flag/returns>
        public static bool Moveplayer(Player player, City city)
        {
            if (DriveOptions(player.CurrentCity).Any(c => c.Name.Equals(city.Name)))
            {
                //Do Nothing
            }
            else if (ShuttleFlightOption(player.CurrentCity).Contains(city.Name))
            {
                //Do Nothing
            }
            else if (DirectFlightOption(player.Hand, player.CurrentCity).Contains(city.Name))
            {
                player.Hand.RemoveAll(x => x.CityName.Equals(city.Name));
            }
            else if (CharterFlightOption(player.Hand, player.CurrentCity))
            {
                player.Hand.RemoveAll(x => x.CityName.Equals(player.CurrentCity.Name));
            }
            else
            {
                return false;
            }
            player.CurrentCity = city;
            return true;
        }

        /// <summary>
        /// Moves the player to the destination city
        /// </summary>
        /// <param name="player">Player to be moved</param>
        /// <param name="players">List of Players</param>
        /// <param name="destination">Name of the City to be moved to</param>
        /// <returns>Status Flag</returns>
        public static bool DispatcherMovePlayer(Player player, List<Player> players, City destination)
        {
            if (DriveOptions(player.CurrentCity).Any(p => p.Name.Equals(destination.Name)))
            {
                //Do nothing
            }
            else if (players.Any(p => p.CurrentCity.Name.Equals(destination.Name)))
            {
                //Do nothing
            }
            else if (ShuttleFlightOption(player.CurrentCity).Contains(destination.Name))
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

        /// <summary>
        ///  Builds a Research Station should the conditions be meet
        /// </summary>
        /// <param name="player">Current Player</param>
        /// <returns>Success Flag</returns>
        public static bool BuildAResearchStationOption(Player player)
        {
            if (CityBl.GetCitiesWithResearchStations().Contains(player.CurrentCity))
                return false;
            else if (player.Role == Role.OpExpert)
            {
                player.CurrentCity.ResearchStation = true;
                return true;
            }
            else if (player.Hand.Any(c => c.CityName.Equals(player.CurrentCity.Name)))
            {
                player.Hand.RemoveAll(x => x.CityName.Equals(player.CurrentCity.Name));
                player.CurrentCity.ResearchStation = true;
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
        public static bool Cure(Player player, List<string> cardsToSpend, Color color)
        {
            if (!player.CurrentCity.ResearchStation || GameBoardModels.Curestatus.GetCureStatus(color) != GameBoardModels.Cures.Curestate.NotCured)
                return false;
            var cards = player.Hand.Where(x => x.CityColor == color && cardsToSpend.Contains(x.CityName));
            if (player.Role == Role.Scientist)
            {
                if (cards.Count() != 4)
                    return false;
            }
            else if (cards.Count() != 5)
                return false;
            player.Hand.RemoveAll(x => cards.Contains(x));
            GameBoardModels.Curestatus.SetCureStatus(color, GameBoardModels.Cures.Curestate.Cured);
            if (GameBoardModels.Curestatus.BlackCure != GameBoardModels.Cures.Curestate.NotCured &&
                   GameBoardModels.Curestatus.BlueCure != GameBoardModels.Cures.Curestate.NotCured &&
                   GameBoardModels.Curestatus.RedCure != GameBoardModels.Cures.Curestate.NotCured &&
                   GameBoardModels.Curestatus.YellowCure != GameBoardModels.Cures.Curestate.NotCured)
            {
                throw new InvalidOperationException("Game Over You Win");
            }

            return true;
        }

        /// <summary>
        /// Treates the Diesease if possible
        /// </summary>
        /// <param name="player"></param>
        /// <param name="color"></param>
        /// <returns>Success Flag</returns>
        public static bool TreatDiseaseOption(Player player, Color color)
        {
            int number = GetDiseaseCubes(player.CurrentCity, color);
            if (number < 1)
                return false;
            return SetDiseaseCubes(player.CurrentCity, color, player.Role == Role.Medic ? 0 : (number - 1), number);
        }

        /// <summary>
        /// Helper method for Treat Disease Option
        /// </summary>
        /// <param name="city"></param>
        /// <param name="color"></param>
        /// <returns>number of disease cubes in the city</returns>
        private static int GetDiseaseCubes(City city, Color color)
        {
            switch (color)
            {
                case Color.Red:
                    return city.RedCubes;

                case Color.Blue:
                    return city.BlueCubes;

                case Color.Yellow:
                    return city.YellowCubes;

                case Color.Black:
                    return city.BlackCubes;

                default:
                    throw new ArgumentException("invalid color");
            }
        }

        /// <summary>
        /// Helper method for Treat Disease Option
        /// </summary>
        /// <param name="city"></param>
        /// <param name="color"></param>
        /// <param name="number"></param>
        private static bool SetDiseaseCubes(City city, Color color, int numberaftercure, int numberBeforeCure)
        {
            switch (color)
            {
                case Color.Red:
                    numberaftercure = GameBoardModels.Curestatus.RedCure == GameBoardModels.Cures.Curestate.Cured ? 0 : numberaftercure;
                    GameBoardModels.CubeCount.RedCubes += (numberBeforeCure - numberaftercure);
                    city.RedCubes = numberaftercure;
                    if (GameBoardModels.CubeCount.RedCubes == Maxcubecount && GameBoardModels.Curestatus.RedCure == GameBoardModels.Cures.Curestate.Cured)
                        GameBoardModels.Curestatus.RedCure = GameBoardModels.Cures.Curestate.Sunset;
                    break;

                case Color.Blue:
                    numberaftercure = GameBoardModels.Curestatus.BlueCure == GameBoardModels.Cures.Curestate.Cured ? 0 : numberaftercure;
                    GameBoardModels.CubeCount.BlueCubes += (numberBeforeCure - numberaftercure);
                    city.BlueCubes = numberaftercure;
                    if (GameBoardModels.CubeCount.BlueCubes == Maxcubecount && GameBoardModels.Curestatus.BlueCure == GameBoardModels.Cures.Curestate.Cured)
                        GameBoardModels.Curestatus.BlueCure = GameBoardModels.Cures.Curestate.Sunset;
                    break;

                case Color.Yellow:
                    numberaftercure = GameBoardModels.Curestatus.YellowCure == GameBoardModels.Cures.Curestate.Cured ? 0 : numberaftercure;
                    GameBoardModels.CubeCount.YellowCubes += (numberBeforeCure - numberaftercure);
                    city.YellowCubes = numberaftercure;
                    if (GameBoardModels.CubeCount.YellowCubes == Maxcubecount && GameBoardModels.Curestatus.YellowCure == GameBoardModels.Cures.Curestate.Cured)
                        GameBoardModels.Curestatus.YellowCure = GameBoardModels.Cures.Curestate.Sunset;
                    break;

                case Color.Black:
                    numberaftercure = GameBoardModels.Curestatus.BlackCure == GameBoardModels.Cures.Curestate.Cured ? 0 : numberaftercure;
                    GameBoardModels.CubeCount.BlackCubes += (numberBeforeCure - numberaftercure);
                    city.BlackCubes = numberaftercure;
                    if (GameBoardModels.CubeCount.BlackCubes == Maxcubecount && GameBoardModels.Curestatus.BlackCure == GameBoardModels.Cures.Curestate.Cured)
                        GameBoardModels.Curestatus.BlackCure = GameBoardModels.Cures.Curestate.Sunset;
                    break;

                default:
                    throw new ArgumentException("invalid color");
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
        public static bool ShareKnowledgeOption(Player sender, Player reciver, string cityname)
        {
            if (sender.CurrentCity != reciver.CurrentCity ||
                (!reciver.CurrentCity.Name.Equals(cityname) && sender.Role != Role.Researcher))
                return false;
            int index = sender.Hand.FindIndex(x => x.CityName.Equals(cityname));
            if (index == -1)
                return false;
            reciver.Hand.Add(sender.Hand[index]);
            sender.Hand.RemoveAt(index);
            return true;
        }
    }
}