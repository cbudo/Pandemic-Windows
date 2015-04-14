using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp.BL
{
    public class InfectorBL
    {
		/// <summary>
		///  Draws the next n cards from the infect deck and updates the pile
		/// </summary>
		/// <param name="deck">infection Deck - LinkedList</param>
        /// <param name="pile">infection Deck - LinkedList</param>
        /// <param name="infectionRate"></param>
		/// <returns>List of new infected cities</returns>
        public static List<String> InfectCities(LinkedList<String> deck, LinkedList<String> pile, int infectionRate)
        {
            List<string> returnList = new List<string>();

            for (int i = 0; i < infectionRate; i++)
            {
                returnList.Add(deck.First.Value);
                pile.AddFirst(deck.First.Value);
                deck.RemoveFirst();
				
            }
                return returnList;
        }
		/// <summary>
		/// handles Epidmeic card actions
        /// Increases the infection rate, draws from the bottom of the deck, shuffles the Infection discard pile back into the infection deck 
		/// </summary>
        /// <param name="deck">infection Deck - LinkedList</param>
        /// <param name="pile">infection Deck - LinkedList</param>
        /// <param name="infectionRate"></param>
		/// <returns></returns>
        public static List<String> Epidemic(LinkedList<String> deck, LinkedList<String> pile, int infectionRate)
        {

            return new List<String> { "city" };

		}

    }
}
