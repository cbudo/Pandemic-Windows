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
        private static bool _alreadySetUp = false;

        /// <summary>
        /// Sets up all of the dictionaries
        /// </summary>
        /// <param name="playerdeck"></param>
        /// <returns>status flag</returns>
        public static bool SetUpCreate(string[] playerRoles, out Cards[] playerdeck, out List<string> infectionDeck)
        {
            //Keep from making duplicates
            //if (alreadySetUp)
            //  return false;
            CreateDictionary();
            SetAdjacentCities(new StringReader(Properties.Resources.AdjacentNeighbors));
            playerdeck = MakePlayerDeck(GameBoardModels.Difficulty, playerRoles);
            infectionDeck = MakeInfectionDeck(new StringReader(Properties.Resources.InfectionDeck));
            CityDictionary["Atlanta"].ResearchStation = true;
            return true;
        }

        /// <summary>
        /// PUBLIC FOR TESTING ONLY
        /// </summary>
        public static void CreateDictionary()
        {
            #region Createcities

            //create the blues
            City sanFrancisco = new City(Color.Blue, "San Francisco");
            City chicago = new City(Color.Blue, "Chicago");
            City montreal = new City(Color.Blue, "Montreal");
            City newYork = new City(Color.Blue, "New York");
            City washington = new City(Color.Blue, "Washington");
            City atlanta = new City(Color.Blue, "Atlanta");
            City london = new City(Color.Blue, "London");
            City madrid = new City(Color.Blue, "Madrid");
            City paris = new City(Color.Blue, "Paris");
            City milan = new City(Color.Blue, "Milan");
            City stPetersburg = new City(Color.Blue, "Saint Petersburg");
            City essen = new City(Color.Blue, "Essen");

            //create the yellows
            City losAngeles = new City(Color.Yellow, "Los Angeles");
            City mexicoCity = new City(Color.Yellow, "Mexico City");
            City miami = new City(Color.Yellow, "Miami");
            City bogota = new City(Color.Yellow, "Bogota");
            City lima = new City(Color.Yellow, "Lima");
            City saoPaulo = new City(Color.Yellow, "Sao Paulo");
            City buenosAires = new City(Color.Yellow, "Buenos Aires");
            City santiago = new City(Color.Yellow, "Santiago");
            City lagos = new City(Color.Yellow, "Lagos");
            City khartoum = new City(Color.Yellow, "Khartoum");
            City kinshasa = new City(Color.Yellow, "Kinshasa");
            City johannesburg = new City(Color.Yellow, "Johannesburg");

            //create the blacks
            City algiers = new City(Color.Black, "Algiers");
            City cairo = new City(Color.Black, "Cairo");
            City istanbul = new City(Color.Black, "Istanbul");
            City moscow = new City(Color.Black, "Moscow");
            City baghdad = new City(Color.Black, "Baghdad");
            City riyadh = new City(Color.Black, "Riyadh");
            City tehran = new City(Color.Black, "Tehran");
            City karachi = new City(Color.Black, "Karachi");
            City delhi = new City(Color.Black, "Delhi");
            City mumbai = new City(Color.Black, "Mumbai");
            City chennai = new City(Color.Black, "Chennai");
            City kolkata = new City(Color.Black, "Kolkata");

            //create the reds
            City beijing = new City(Color.Red, "Beijing");
            City seoul = new City(Color.Red, "Seoul");
            City shanghai = new City(Color.Red, "Shanghai");
            City tokyo = new City(Color.Red, "Tokyo");
            City osaka = new City(Color.Red, "Osaka");
            City taipei = new City(Color.Red, "Taipei");
            City hongKong = new City(Color.Red, "Hong Kong");
            City bangkok = new City(Color.Red, "Bangkok");
            City manila = new City(Color.Red, "Manila");
            City hoChiMinhCity = new City(Color.Red, "Ho Chi Minh City");
            City jakarta = new City(Color.Red, "Jakarta");
            City sydney = new City(Color.Red, "Sydney");

            #endregion Createcities

            try
            {
                #region loadDictionary

                CityDictionary.Add("San Francisco", sanFrancisco);
                CityDictionary.Add("Chicago", chicago);
                CityDictionary.Add("Montreal", montreal);
                CityDictionary.Add("New York", newYork);
                CityDictionary.Add("Atlanta", atlanta);
                CityDictionary.Add("Washington", washington);
                CityDictionary.Add("London", london);
                CityDictionary.Add("Essen", essen);
                CityDictionary.Add("Saint Petersburg", stPetersburg);
                CityDictionary.Add("Milan", milan);
                CityDictionary.Add("Paris", paris);
                CityDictionary.Add("Madrid", madrid);
                CityDictionary.Add("Los Angeles", losAngeles);
                CityDictionary.Add("Mexico City", mexicoCity);
                CityDictionary.Add("Miami", miami);
                CityDictionary.Add("Bogota", bogota);
                CityDictionary.Add("Lima", lima);
                CityDictionary.Add("Santiago", santiago);
                CityDictionary.Add("Buenos Aires", buenosAires);
                CityDictionary.Add("Sao Paulo", saoPaulo);
                CityDictionary.Add("Lagos", lagos);
                CityDictionary.Add("Kinshasa", kinshasa);
                CityDictionary.Add("Johannesburg", johannesburg);
                CityDictionary.Add("Khartoum", khartoum);
                CityDictionary.Add("Moscow", moscow);
                CityDictionary.Add("Tehran", tehran);
                CityDictionary.Add("Delhi", delhi);
                CityDictionary.Add("Kolkata", kolkata);
                CityDictionary.Add("Istanbul", istanbul);
                CityDictionary.Add("Baghdad", baghdad);
                CityDictionary.Add("Karachi", karachi);
                CityDictionary.Add("Algiers", algiers);
                CityDictionary.Add("Cairo", cairo);
                CityDictionary.Add("Riyadh", riyadh);
                CityDictionary.Add("Mumbai", mumbai);
                CityDictionary.Add("Chennai", chennai);
                CityDictionary.Add("Beijing", beijing);
                CityDictionary.Add("Seoul", seoul);
                CityDictionary.Add("Shanghai", shanghai);
                CityDictionary.Add("Tokyo", tokyo);
                CityDictionary.Add("Osaka", osaka);
                CityDictionary.Add("Taipei", taipei);
                CityDictionary.Add("Hong Kong", hongKong);
                CityDictionary.Add("Bangkok", bangkok);
                CityDictionary.Add("Manila", manila);
                CityDictionary.Add("Ho Chi Minh City", hoChiMinhCity);
                CityDictionary.Add("Jakarta", jakarta);
                CityDictionary.Add("Sydney", sydney);

                #endregion loadDictionary
            }
            catch (Exception e)
            {
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
                    deck[rand.Next(0, 11)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(12, 23)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(24, 35)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(36, 48)] = new EpidemicCard("EPIDEMIC");
                } else if (difficulty == DifficultySetting.Medium) {
                    //deck[rand.Next(0, 8)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(9, 17)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(18, 26)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(27, 35)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(36, 48)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    deck[rand.Next(0, 8)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(9, 17)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(18, 26)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(27, 35)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(36, 48)] = new EpidemicCard("EPIDEMIC");
                } else if (difficulty == DifficultySetting.Hard) {
                    //deck[rand.Next(0, 7)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(8, 15)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(16, 23)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(24, 31)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(32, 39)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(40, 48)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    deck[rand.Next(0, 7)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(8, 15)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(16, 23)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(24, 31)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(32, 39)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(40, 48)] = new EpidemicCard("EPIDEMIC");
                }
            }
            else {
                if (difficulty == DifficultySetting.Easy)
                {
                    //deck[rand.Next(0, 11)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(12, 23)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(24, 35)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(36, 47)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    deck[rand.Next(0, 11)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(12, 23)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(24, 35)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(36, 47)] = new EpidemicCard("EPIDEMIC");
                }
                else if (difficulty == DifficultySetting.Medium)
                {
                    //deck[rand.Next(0, 8)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(9, 17)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(18, 26)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(27, 35)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(36, 47)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    deck[rand.Next(0, 8)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(9, 17)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(18, 26)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(27, 35)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(36, 47)] = new EpidemicCard("EPIDEMIC");
                }
                else if (difficulty == DifficultySetting.Hard)
                {
                    //deck[rand.Next(0, 7)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(8, 15)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(16, 23)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(24, 31)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(32, 39)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    //deck[rand.Next(40, 47)] = new Card("EPIDEMIC", Card.Cardtype.Epidemic);
                    deck[rand.Next(0, 7)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(8, 15)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(16, 23)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(24, 31)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(32, 39)] = new EpidemicCard("EPIDEMIC");
                    deck[rand.Next(40, 47)] = new EpidemicCard("EPIDEMIC");
                }
            }
            //List<Card> cardList = MakeCardList(new StringReader(SQADemicApp.Properties.Resources.CityList));
            List<Cards> cardList = MakeCardList(new StringReader(SQADemicApp.Properties.Resources.CityList));
            cardList = HelperBl.ShuffleArray(cardList);
            int j = 0;
            for (int i = 0; i < 57; i++)
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
        /// <param name="r"></param>
        /// <returns></returns>
        public static List<string> MakeInfectionDeck(StringReader r)
        {
            string line;
            string[] infectionDeckArray = null;
            while ((line = r.ReadLine()) != null)
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
                string cardColor = line.Substring(line.IndexOf(";") + 2);
                Color color = GetColor(cardColor);
                //cardList.Add(new Card(cardName, Card.Cardtype.City, color));
                cardList.Add(new CityCard(cardName, color));
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

        private static Color GetColor(string color)
        {
            switch (color.ToLower())
            {
                case "red":
                    return Color.Red;

                case "black":
                    return Color.Black;

                case "yellow":
                    return Color.Yellow;

                default:
                    return Color.Blue;
            }
        }
    }
}