﻿using System;
using System.Collections.Generic;
using System.Linq;

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
		/// Handles Epidmeic card actions,
        /// Increases the infection rate, draws from the bottom of the deck, Shuffles the infection discard pile back into the infection deck 
		/// </summary>
        /// <param name="deck">infection Deck - LinkedList</param>
        /// <param name="pile">infection Deck - LinkedList</param>
        /// <param name="infectionRateIndex">infectionRateIndex - int current index in teh infectionRates</param>
       	/// <returns></returns>
        public static string Epidemic(LinkedList<String> deck, LinkedList<String> pile, ref int infectionRateIndex, ref int infectionRate)
        {
            //infection rate stuff
            infectionRate = infectionRateIndex > 1 ? (infectionRateIndex > 3 ? 4 :3) : 2;
            infectionRateIndex += 1;

            //draw Last card
            string epidmicCity = deck.Last.Value;
            deck.RemoveLast();
            pile.AddFirst(epidmicCity);

            //shuffle remains back on to the deck
            string[] pilearray = pile.ToArray<string>();
            pilearray = HelperBL.shuffleArray(pilearray);
            for (int i = 0; i < pilearray.Length; i++)
            {
                deck.AddFirst(pilearray[i]);
            }
            pile.Clear();
            return epidmicCity;
		}

        /// <summary>
        /// Deals with outbreaks for Infect City
        /// </summary>
        /// <param name="city"></param>
        /// <param name="color"></param>
        /// <returns></returns> number of blocks of that color
        //get cities from infectcities, infect each individually
        //place 1 disease cube matching color onto city
        //if city has 3 already, then outbreak (do not place 4th cube_
        //for outbreaks, move outbreak marker up one position
        //place one cube of disease color on every neighboring city
        //if already has 3, then outbreak that city too
        //don't infect same city twice
        public static int InfectCity(SQADemicApp.City city)
        {

            return 1;
        }
    }
}
