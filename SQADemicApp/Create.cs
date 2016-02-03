using SQADemicApp.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SQADemicApp
{
    public class Create
    {
        public static Dictionary<string, City> CityDictionary = new Dictionary<string, City>();

        public static bool SetUpCreate(string[] playerRoles, out Cards[] playerdeck, out List<string> infectionDeck)
        {
            CreateDictionary();
            SetAdjacentCities(new StringReader(Properties.Resources.AdjacentNeighbors));
            playerdeck = MakePlayerDeck(GameBoardModels.Difficulty, playerRoles);
            infectionDeck = MakeInfectionDeck(new StringReader(Properties.Resources.InfectionDeck));
            CityDictionary["Atlanta"].ResearchStation = true;
            return true;
        }

        public static void CreateDictionary()
        {
            CreateDictionary(new StringReader(Properties.Resources.CityList));
        }

        /// <summary>
        /// PUBLIC FOR TESTING ONLY
        /// </summary>
        public static void CreateDictionary(StringReader reader)
        {
            CityDictionary = new Dictionary<string, City>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string cityname = line.Substring(0, line.IndexOf(";"));
                string colorstring = (line.Substring(line.IndexOf(";") + 1)).Trim();
                Color color = GetColorForString(colorstring);
                City city = new City(color, cityname);
                CityDictionary.Add(cityname, city);
            }

        }

        /// <summary>
        /// Protected for testing.
        /// </summary>
        /// <param name="colorString"></param>
        /// <returns>The color associated with the given string. Blue if the string does not match a color.</returns>
        protected static Color GetColorForString(string colorString)
            {
            switch (colorString)
            {
                case "Yellow": return Color.Yellow;
                case "Red": return Color.Red;
                case "Black": return Color.Black;
                default: return Color.Blue;
            }
        }

        /// <summary>
        /// PUBLIC FOR TESTING ONLY
        /// </summary>
        /// <param name="reader"></param>
        public static void SetAdjacentCities(StringReader reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string cityname = line.Substring(0, line.IndexOf(";"));
                string adjcities = line.Substring(line.IndexOf(";") + 1);
                string[] adjCityList = adjcities.Split(',');

                foreach (var city in adjCityList)
                {
                    CityDictionary[cityname].AdjacentCities.Add(CityDictionary[city]);
                }
            }
        }

        /// <summary> 
        /// PUBLIC FOR TESTING ONLY
        /// </summary>
        /// <returns></returns>
        //public static Card[] MakePlayerDeck(DifficultySetting difficulty, string[] playerRoles)
        public static Cards[] MakePlayerDeck(DifficultySetting difficulty, string[] playerRoles)
        {
            //Card[] deck = new Card[57];
            Cards[] deck = new Cards[57];
            Random rand = new Random();
            if (playerRoles.Length == 2 || playerRoles.Length == 4) {
                if (difficulty == DifficultySetting.Easy) {
                    //deck[rand.Next(0, 11)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(12, 23)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(24, 35)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(36, 48)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    deck[rand.Next(0, 11)] = new EpidemicCard();
                    deck[rand.Next(12, 23)] = new EpidemicCard();
                    deck[rand.Next(24, 35)] = new EpidemicCard();
                    deck[rand.Next(36, 48)] = new EpidemicCard();
                } else if (difficulty == DifficultySetting.Medium) {
                    //deck[rand.Next(0, 8)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(9, 17)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(18, 26)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(27, 35)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(36, 48)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    deck[rand.Next(0, 8)] = new EpidemicCard();
                    deck[rand.Next(9, 17)] = new EpidemicCard();
                    deck[rand.Next(18, 26)] = new EpidemicCard();
                    deck[rand.Next(27, 35)] = new EpidemicCard();
                    deck[rand.Next(36, 48)] = new EpidemicCard();
                } else if (difficulty == DifficultySetting.Hard) {
                    //deck[rand.Next(0, 7)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(8, 15)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(16, 23)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(24, 31)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(32, 39)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(40, 48)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    deck[rand.Next(0, 7)] = new EpidemicCard();
                    deck[rand.Next(8, 15)] = new EpidemicCard();
                    deck[rand.Next(16, 23)] = new EpidemicCard();
                    deck[rand.Next(24, 31)] = new EpidemicCard();
                    deck[rand.Next(32, 39)] = new EpidemicCard();
                    deck[rand.Next(40, 48)] = new EpidemicCard();
                }
            }
            else {
                if (difficulty == DifficultySetting.Easy)
                {
                    //deck[rand.Next(0, 11)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(12, 23)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(24, 35)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(36, 47)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    deck[rand.Next(0, 11)] = new EpidemicCard();
                    deck[rand.Next(12, 23)] = new EpidemicCard();
                    deck[rand.Next(24, 35)] = new EpidemicCard();
                    deck[rand.Next(36, 47)] = new EpidemicCard();
                }
                else if (difficulty == DifficultySetting.Medium)
                {
                    //deck[rand.Next(0, 8)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(9, 17)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(18, 26)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(27, 35)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(36, 47)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    deck[rand.Next(0, 8)] = new EpidemicCard();
                    deck[rand.Next(9, 17)] = new EpidemicCard();
                    deck[rand.Next(18, 26)] = new EpidemicCard();
                    deck[rand.Next(27, 35)] = new EpidemicCard();
                    deck[rand.Next(36, 47)] = new EpidemicCard();
                }
                else if (difficulty == DifficultySetting.Hard)
                {
                    //deck[rand.Next(0, 7)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(8, 15)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(16, 23)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(24, 31)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(32, 39)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(40, 47)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    deck[rand.Next(0, 7)] = new EpidemicCard();
                    deck[rand.Next(8, 15)] = new EpidemicCard();
                    deck[rand.Next(16, 23)] = new EpidemicCard();
                    deck[rand.Next(24, 31)] = new EpidemicCard();
                    deck[rand.Next(32, 39)] = new EpidemicCard();
                    deck[rand.Next(40, 47)] = new EpidemicCard();
                }
            }
            //List<Card> cardList = MakeCardList(new StringReader(SQADemicApp.Properties.Resources.CityList));
            List<Cards> cardList = MakeCardList(new StringReader(SQADemicApp.Properties.Resources.CityList));
            cardList = HelperBl.ShuffleArray(cardList);
            int j = 0;
            for (int i = 0; i < deck.Length; i++)
            {
                if (deck[i] == null)
                {
                    deck[i] = cardList[j];
                    j++;
                }
            }

            return deck;
        }

        /// <summary>
        /// PUBLIC FOR TESTING ONLY
        /// </summary>
        /// <param name="stringReader"></param>
        /// <returns></returns>
        public static List<string> MakeInfectionDeck(StringReader stringReader)
        {
            string line;
            string[] infectionDeckArray = null;
            while ((line = stringReader.ReadLine()) != null)
            {
                infectionDeckArray = line.Split(',');
            }
            string[] shuffledDeck = HelperBl.ShuffleArray(infectionDeckArray);
            return shuffledDeck.ToList();
        }

        /// <summary>
        /// PUBLIC FOR TESTING ONLY
        /// </summary>
        /// <param name="stringReader"></param>
        /// <returns></returns>
        //public static List<Card> MakeCardList(StringReader stringReader)
        public static List<Cards> MakeCardList(StringReader stringReader)
        {
            //List<Card> cardList = new List<Card>();
            List<Cards> cardList = new List<Cards>();
            string line;
            while ((line = stringReader.ReadLine()) != null)
            {
                string cardName = line.Substring(0, line.IndexOf(";"));
                System.Globalization.TextInfo textInfo = new System.Globalization.CultureInfo("en-US", false).TextInfo;
                string cardColor = textInfo.ToTitleCase(line.Substring(line.IndexOf(";") + 2));
                Color color = new Color();
                try
                {
                    color = (Color)Enum.Parse(typeof(Color), cardColor);
                }
                catch(ArgumentException)
                {
                }
                
                //cardList.Add(new Card(cardName, Card.Cardtype.City, color));
                cardList.Add(new CityCard(cardName,  color));
            }
            //cardList.Add(new Card("Airlift", Card.Cardtype.Special));
            //cardList.Add(new Card("One Quiet Night", Card.Cardtype.Special));
            //cardList.Add(new Card("Resilient Population", Card.Cardtype.Special));
            //cardList.Add(new Card("Government Grant", Card.Cardtype.Special));
            //cardList.Add(new Card("Forecast", Card.Cardtype.Special));
            cardList.Add(new SpecialCard("Airlift"));
            cardList.Add(new SpecialCard("One Quiet Night"));
            cardList.Add(new SpecialCard("Resilient Population"));
            cardList.Add(new SpecialCard("Government Grant"));
            cardList.Add(new SpecialCard("Forecast"));
            return cardList;
        }
    }
}