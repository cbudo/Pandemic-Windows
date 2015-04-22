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
        infectionCubeCount cubeCount;
        Cures CURESTATUS;
        public Card[] playerDeck = new Card[58];
        int playerDeckPoint = -1;
        public Player CurrentPlayer;
        public static List<String> citiesWithResearchStations;
        public static int outbreakMarker = 0;
        public int InfectionRateCounter = 0;
        #endregion
        public GameBoardModels()
        {
             
            cubeCount = new infectionCubeCount();
            cubeCount.blackCubes = cubeCount.redCubes = cubeCount.blueCubes = cubeCount.yellowCubes = 24;
            CURESTATUS = new Cures();
            CURESTATUS.BlackCure = CURESTATUS.BlueCure = CURESTATUS.RedCure = CURESTATUS.YellowCure = Cures.CURESTATE.NotCured;
            Create createHelper = new Create();
            playerDeck = createHelper.makePlayerDeck();
        }
 
        
        

        public Card drawCard()
        {
            playerDeckPoint++;
            if (playerDeckPoint < 58)
                return playerDeck[playerDeckPoint];
            else  //gameover
                throw new Exception("Game Over");
        }

        #region Storage Classes
        public class infectionCubeCount
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