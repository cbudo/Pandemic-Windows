using System;
using System.Collections.Generic;
using SQADemicApp.Players;

namespace SQADemicApp.BL
{
    public class SpecialEventCardsBl
    {
        /// <summary>
        /// Completes the special actions for the Government Grant Card
        /// Builds a research station in the named city
        /// </summary>
        /// <param name="cityName">City to build a research station</param>
        /// <returns>status flag</returns>
        public static bool GovernmentGrant(string cityName)
        {
            if (Create.CityDictionary[cityName].ResearchStation)
                return false;
            Create.CityDictionary[cityName].ResearchStation = true;
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
            if (player.CurrentCity.Equals(destination))
                return false;
            player.CurrentCity = destination;
            return true;
        }

        /// <summary>
        /// Takes a carcd form the Infection Discard Pile and removes it from the game
        /// </summary>
        /// <param name="infectionPile">Infection Discard Pile</param>
        /// <param name="cityname">Card to be removed</param>
        /// <returns>status flag</returns>
        public static bool ResilientPopulation(InfectionPile infectionPile, string cityname)
        {
            return infectionPile.removeCardFromPlay(cityname);
        }

        /// <summary>
        /// Removes the top 6 cards from the Infection Deck
        /// ~ Call this first
        /// </summary>
        /// <param name="infectionDeck"></param>
        /// <returns>Top 6 cards to be examined</returns>
        public static List<string> GetForcastCards(InfectionDeck infectionDeck)
        {
            List<string> returnList = new List<string>();

            for (int _ = 0; _ < 6; _++)
            {
                Cards drawn = infectionDeck.draw();
                infectionDeck.addCardToBottom(drawn);
                returnList.Add(drawn.CityName);
            }
            return returnList;
        }

        /// <summary>
        /// Replaces the 6 cards on the infection deck
        /// ~ Call this second
        /// </summary>
        /// <param name="infectionDeck"></param>
        /// <param name="orderedCards">6 cards in the order to be replaced</param>
        /// <returns>status flag</returns>
        public static bool CommitForcast(InfectionDeck infectionDeck, List<string> orderedCards)
        {
            if (orderedCards.Count != 6)
                return false;
            List<Cards> ordered = infectionDeck.getAndRemoveCardsWithNames(orderedCards);
            for (int i = 5; i >= 0; i--)
            {
                infectionDeck.addCardToTop(ordered[i]);
            }
            return true;
        }
    }
}