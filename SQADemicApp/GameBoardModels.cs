using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace SQADemicApp
{
    public class GameBoardModels
    {
        infectionCubeCount cubeCount;
        Cures CURESTATUS;
        public Card[] playerDeck = new Card[58];
        int playerDeckPoint = -1;
        public PlayerModels.Player CurrentPlayer;
        public static List<String> citiesWithResearchStations;
        public GameBoardModels()
        {

            cubeCount = new infectionCubeCount();
            cubeCount.blackCubes = cubeCount.redCubes = cubeCount.blueCubes = cubeCount.yellowCubes = 24;
            CURESTATUS = new Cures();
            CURESTATUS.BlackCure = CURESTATUS.BlueCure = CURESTATUS.RedCure = CURESTATUS.YellowCure = CURESTATE.NotCured;
            Create createHelper = new Create();
            playerDeck = createHelper.makePlayerDeck();
        }
        public int[] getCubes()
        {
            int[] cubes = { cubeCount.blackCubes, cubeCount.redCubes, cubeCount.blueCubes, cubeCount.yellowCubes };
            return cubes;
        }

        public enum COLOR { red, black, blue, yellow }
        public enum CARDTYPE { Infection, City, Special }
        public enum CURESTATE { NotCured, Cured, Sunset }

        public int InfectionRateCounter = 0;


        public CURESTATE[] getCures()
        {
            CURESTATE[] cures = { CURESTATUS.BlackCure, CURESTATUS.BlueCure, CURESTATUS.RedCure, CURESTATUS.YellowCure };
            return cures;
        }

        public class onBoard
        {
            //stacks for infection and player deck
            Stack<Card> infectionDeck = new Stack<Card>();
            Stack<Card> PlayerDeck = new Stack<Card>();
            // discard Piles
            Card[] playerDiscardPile = new Card[60];
            Card[] infectionDiscardPile = new Card[48];
        }
        public class Card
        {
            public Card(string CityName, CARDTYPE type, COLOR color)
            {
                this.CityName = CityName;
                this.CardType = type;
                this.CityColor = color;
            }
            public Card(string CityName, CARDTYPE type)
            {
                this.CityName = CityName;
                this.CardType = type;
            }
            public string CityName;
            public  CARDTYPE CardType { get; set; }
            public COLOR CityColor { get; set; }

            public override bool Equals(Object obj)
            {
                Card objects = (Card)obj;
                return (this.CityName == objects.CityName) && (this.CardType == objects.CardType) && (this.CityColor == objects.CityColor);
            }
        }
        public class infectionCubeCount
        {
            public int redCubes { get; set; }
            public int blackCubes { get; set; }
            public int blueCubes { get; set; }
            public int yellowCubes { get; set; }
        }
        public class Cures
        {
            public CURESTATE RedCure { get; set; }
            public CURESTATE BlueCure { get; set; }
            public CURESTATE BlackCure { get; set; }
            public CURESTATE YellowCure { get; set; }
        }
        public Card drawCard()
        {
            playerDeckPoint++;
            if (playerDeckPoint < 58)
            {
                return playerDeck[playerDeckPoint];
            }
            else
            {
                //gameover
                throw new Exception("Game Over");
            }
        }
    }
}