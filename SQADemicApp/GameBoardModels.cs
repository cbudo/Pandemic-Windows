using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace SQAdemicApp
{
    public class GameBoardModels
    {
        infectionCubeCount cubeCount;
        Cures CURESTATUS;
        public Card[] playerDeck = new Card[58];
        int playerDeckPoint = -1;
        public GameBoardModels()
        {
            List<GameBoardModels.Card> cities = new List<GameBoardModels.Card>();
            try
            {
                using(StreamReader reader = new StreamReader("D:\\Documents\\GitHub\\SQAdemic\\SQAdemic\\App_Data\\CityList.txt"))
                {
                    string line;
                    while((line = reader.ReadLine()) !=null)
                    {
                        COLOR color = COLOR.black;
                        switch(line.Substring(line.IndexOf(";")+1).Replace(" ",""))
                        {
                            case "Blue":
                                color = COLOR.blue;
                                break;
                            case "Black":
                                color = COLOR.black;
                                break;
                            case "Yellow":
                                color = COLOR.yellow;
                                break;
                            case "Red":
                                color = COLOR.red;
                                break;
                            default:
                                break;

                        }
                        cities.Add(new Card(line.Substring(0, line.IndexOf(";")), CARDTYPE.Player, color));
                    }
                }
            }
            catch(Exception ex)
            {

            }
            cubeCount = new infectionCubeCount();
            cubeCount.blackCubes = cubeCount.redCubes = cubeCount.blueCubes = cubeCount.yellowCubes = 24;
            CURESTATUS = new Cures();
            CURESTATUS.BlackCure = CURESTATUS.BlueCure = CURESTATUS.RedCure = CURESTATUS.YellowCure = CURESTATE.NotCured;
//            createDeck createDeck = new createDeck(this,cities);
//            createDeck.makePlayerDeck();
        }
        public int[] getCubes()
        {
            int[] cubes = { cubeCount.blackCubes, cubeCount.redCubes, cubeCount.blueCubes, cubeCount.yellowCubes };
            return cubes;
        }

        public enum COLOR{ red, black, blue, yellow }
        public enum CARDTYPE { Infection, Player, Special }
        public enum CURESTATE { NotCured, Cured, Sunset }

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
            CARDTYPE CardType {get;set;}
            COLOR CityColor { get; set; }

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
            public CURESTATE RedCure{get;set;}
            public CURESTATE BlueCure { get; set; }
            public CURESTATE BlackCure { get; set; }
            public CURESTATE YellowCure { get; set; }
        }
        public Card drawCard()
        {
            playerDeckPoint++;
            return playerDeck[playerDeckPoint];
        }
    }
}