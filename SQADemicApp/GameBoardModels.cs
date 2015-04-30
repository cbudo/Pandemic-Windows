using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace SQADemicApp
{
    public enum COLOR { red, black, blue, yellow }
    public class GameBoardModels
    {
        #region Public Vars
        public static InfectionCubeCount cubeCount;
        public static Cures CURESTATUS;
        public Card[] playerDeck = new Card[58];
        int playerDeckPoint = -1;
        public int CurrentPlayerIndex;
        public static List<String> citiesWithResearchStations;
        public static int outbreakMarker = 0;
        public int InfectionRateCounter = 0;
        public static Player[] players;
        public int currentPlayerTurnCounter = 0;
        #endregion

        public GameBoardModels(string[] playersroles)
        {
            Create c = new Create();
            outbreakMarker = 0;

            players = new Player[playersroles.Length];
            currentPlayerTurnCounter = 1;
            int i = 0;   
            foreach(var role in playersroles)
            {
                switch (role)
                {
                    case "Dispatcher":
                        players[i] = new Player(ROLE.Dispatcher);
                        break;
                    case "Operations Expert":
                        players[i] = new Player(ROLE.OpExpert);
                        break;
                    case "Scientist":
                        players[i] = new Player(ROLE.Scientist);
                        break;
                    case "Medic":
                        players[i] = new Player(ROLE.Medic);
                        break;
                    case "Researcher":
                        players[i] = new Player(ROLE.Researcher);
                        break;
                    default:
                        players[i] = null;
                        break;
                }
                i++;
            }
            CurrentPlayerIndex = 0;
            
            CURESTATUS = new Cures();
            Create createHelper = new Create();
            cubeCount = new InfectionCubeCount();
            
            cubeCount.blackCubes = cubeCount.redCubes = cubeCount.blueCubes = cubeCount.yellowCubes = 24;            
            CURESTATUS.BlackCure = CURESTATUS.BlueCure = CURESTATUS.RedCure = CURESTATUS.YellowCure = Cures.CURESTATE.NotCured;            
            playerDeck = createHelper.makePlayerDeck();

            //build players


        }
        public void incTurnCount()
        {
            if (currentPlayerTurnCounter == 4)
            {
                NextPlayer();
            }
            else
            {
                currentPlayerTurnCounter++;
            }
        }
        public Card drawCard()
        {
            playerDeckPoint++;
            if (playerDeckPoint < 58)
                return playerDeck[playerDeckPoint];
            else  //gameover
                throw new Exception("Game Over");
        }
        
        public void NextPlayer()
        {
            currentPlayerTurnCounter = 1;
            CurrentPlayerIndex++;
        }

        #region Storage Classes
        public class InfectionCubeCount
            {
            public int redCubes { get; set; }
            public int blackCubes { get; set; }
            public int blueCubes { get; set; }
            public int yellowCubes { get; set; }
        }
        public class Cures
        {
            public enum CURESTATE { NotCured, Cured, Sunset }
            public CURESTATE RedCure { get; set; }
            public CURESTATE BlueCure { get; set; }
            public CURESTATE BlackCure { get; set; }
            public CURESTATE YellowCure { get; set; }
        }
        #endregion
    }
}