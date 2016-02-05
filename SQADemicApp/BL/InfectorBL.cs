using System;
using System.Collections.Generic;
using System.Linq;

namespace SQADemicApp.BL
{
    public class InfectorBl
    {
        /// <summary>
        ///  Draws the next n cards from the infect deck and updates the pile
        /// </summary>
        /// <param name="deck">infection Deck - LinkedList</param>
        /// <param name="pile">infection Deck - LinkedList</param>
        /// <param name="infectionRate"></param>
        /// <returns>List of new infected cities</returns>
        public static List<string> InfectCities(LinkedList<string> deck, LinkedList<string> pile, int infectionRate)
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
        /// Handles Epidmeic card actions,
        /// Increases the infection rate, draws from the bottom of the deck, Shuffles the infection discard pile back into the infection deck
        /// </summary>
        /// <param name="deck">infection Deck - LinkedList</param>
        /// <param name="pile">infection Deck - LinkedList</param>
        /// <param name="infectionRateIndex">infectionRateIndex - int current index in the infectionRates</param>
        /// <param name="infectionRate"></param>
        /// <returns></returns>
        public static string Epidemic(LinkedList<string> deck, LinkedList<string> pile, ref int infectionRateIndex, ref int infectionRate)
        {
            //infection rate stuff
            infectionRate = infectionRateIndex > 1 ? (infectionRateIndex > 3 ? 4 : 3) : 2;
            infectionRateIndex += 1;

            //draw Last card
            string epidmicCity = deck.Last.Value;
            deck.RemoveLast();
            pile.AddFirst(epidmicCity);

            //shuffle remains back on to the deck
            string[] pilearray = pile.ToArray<string>();
            pilearray = HelperBl.ShuffleArray(pilearray);
            for (int i = 0; i < pilearray.Length; i++)
            {
                deck.AddFirst(pilearray[i]);
            }
            pile.Clear();
            return epidmicCity;
        }

        public static void InfectCities(List<string> citiesToInfect)
        {
            foreach (string name in citiesToInfect)
            {
                InfectCity(Create.CityDictionary[name], new HashSet<City>(), false, Create.CityDictionary[name].Color);
            }
        }

        /// <summary>
        /// Deals with outbreaks for Infect City
        /// </summary>
        /// <param name="city">city to infect</param>
        /// <param name="alreadyInfected"></param>
        /// <param name="causedByOutbreak"></param>
        /// <param name="outbreakColor"></param>
        /// <returns></returns>

        public static int InfectCity(City city, HashSet<City> alreadyInfected, bool causedByOutbreak, Color outbreakColor)
        {

            Color color;
            if (!causedByOutbreak)
            {
                color = city.Color;
            }
            else
            {
                color = outbreakColor;
            }

            int currentCubes = city.getCityCubes(color);

            if (GameBoardModels.Curestatus.GetColorCureState(color) != Cures.Curestate.Sunset)
            {
                if (currentCubes < 3)
                {
                    GameBoardModels.CubeCount.decrementCubeCount(color);

                    city.incrementCityCubeCount(color);
                    currentCubes = city.getCityCubes(color);
                    if (GameBoardModels.CubeCount.GetColorCubeCount(color) <= 0)
                    {
                        throw new GameLostException();
                    }
                    return currentCubes;
                }
                Outbreak(city, color, city.AdjacentCities, alreadyInfected);
                return currentCubes;
            }
            return currentCubes;

        }

        //returns a list of the cities that have already been infected
        public static HashSet<City> Outbreak(City city, Color color, HashSet<City> adjacentCities, HashSet<City> alreadyInfected)
        {
            new PicForm(true, city.Name).Show();
            alreadyInfected.Add(city);
            foreach (var neighbor in adjacentCities)
            {
                if (!alreadyInfected.Contains(neighbor))
                {
                    //alreadyInfected.Add(neighbor);
                    InfectCity(neighbor, alreadyInfected, true, color);
                }
            }
            GameBoardModels.OutbreakMarker++;
            if (GameBoardModels.OutbreakMarker == 8)
            {
                throw new GameLostException();
            }
            return alreadyInfected;
        }
    }
}