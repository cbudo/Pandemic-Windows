using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using SQADemicApp.BL;

namespace SQADemicApp
{
    public class Create
    {
        public static Dictionary<string, City> cityDictionary = new Dictionary<string, City>();

        public Create()
        {
            createDictionary();
            setAdjacentCities(new StringReader(Properties.Resources.AdjacentNeighbors));
        }

        public void createDictionary()
        {
            #region Createcities
            //create the blues
            City sanFrancisco = new City(COLOR.blue, "San Francisco");
            City chicago = new City(COLOR.blue, "Chicago");
            City montreal = new City(COLOR.blue, "Montreal");
            City newYork = new City(COLOR.blue, "New York");
            City washington = new City(COLOR.blue, "Washington");
            City atlanta = new City(COLOR.blue, "Atlanta");
            City london = new City(COLOR.blue, "London");
            City madrid = new City(COLOR.blue, "Madrid");
            City paris = new City(COLOR.blue, "Paris");
            City milan = new City(COLOR.blue, "Milan");
            City stPetersburg = new City(COLOR.blue, "St Petersburg");
            City essen = new City(COLOR.blue, "Essen");

            //create the yellows
            City losAngeles = new City(COLOR.yellow, "Los Angeles");
            City mexicoCity = new City(COLOR.yellow, "Mexico City");
            City miami = new City(COLOR.yellow, "Miami");
            City bogota = new City(COLOR.yellow, "Bogota");
            City lima = new City(COLOR.yellow, "Lima");
            City saoPaulo = new City(COLOR.yellow, "Sao Paulo");
            City buenosAires = new City(COLOR.yellow, "Buenos Aires");
            City santiago = new City(COLOR.yellow, "Santiago");
            City lagos = new City(COLOR.yellow, "Lagos");
            City khartoum = new City(COLOR.yellow, "Khartoum");
            City kinshasa = new City(COLOR.yellow, "Kinshasa");
            City johannesburg = new City(COLOR.yellow, "Johannesburg");

            //create the blacks
            City algiers = new City(COLOR.black, "Algiers");
            City cairo = new City(COLOR.black, "Cairo");
            City istanbul = new City(COLOR.black, "Istanbul");
            City moscow = new City(COLOR.black, "Moscow");
            City baghdad = new City(COLOR.black, "Baghdad");
            City riyadh = new City(COLOR.black, "Riyadh");
            City tehran = new City(COLOR.black, "Tehran");
            City karachi = new City(COLOR.black, "Karachi");
            City delhi = new City(COLOR.black, "Delhi");
            City mumbai = new City(COLOR.black, "Mumbai");
            City chennai = new City(COLOR.black, "Chennai");
            City kolkata = new City(COLOR.black, "Kolkata");

            //create the reds
            City beijing = new City(COLOR.red, "Beijing");
            City seoul = new City(COLOR.red, "Seoul");
            City shanghai = new City(COLOR.red, "Shanghai");
            City tokyo = new City(COLOR.red, "Tokyo");
            City osaka = new City(COLOR.red, "Osaka");
            City taipei = new City(COLOR.red, "Taipei");
            City hongKong = new City(COLOR.red, "Hong Kong");
            City bangkok = new City(COLOR.red, "Bangkok");
            City manila = new City(COLOR.red, "Manila");
            City hoChiMinhCity = new City(COLOR.red, "Ho Chi Minh City");
            City jakarta = new City(COLOR.red, "Jakarta");
            City sydney = new City(COLOR.red, "Sydney");
            #endregion

            try
            {
                #region loadDictionary
                cityDictionary.Add("San Francisco", sanFrancisco);
                cityDictionary.Add("Chicago", chicago);
                cityDictionary.Add("Montreal", montreal);
                cityDictionary.Add("New York", newYork);
                cityDictionary.Add("Atlanta", atlanta);
                cityDictionary.Add("Washington", washington);
                cityDictionary.Add("London", london);
                cityDictionary.Add("Essen", essen);
                cityDictionary.Add("Saint Petersburg", stPetersburg);
                cityDictionary.Add("Milan", milan);
                cityDictionary.Add("Paris", paris);
                cityDictionary.Add("Madrid", madrid);
                cityDictionary.Add("Los Angeles", losAngeles);
                cityDictionary.Add("Mexico City", mexicoCity);
                cityDictionary.Add("Miami", miami);
                cityDictionary.Add("Bogota", bogota);
                cityDictionary.Add("Lima", lima);
                cityDictionary.Add("Santiago", santiago);
                cityDictionary.Add("Buenos Aires", buenosAires);
                cityDictionary.Add("Sao Paulo", saoPaulo);
                cityDictionary.Add("Lagos", lagos);
                cityDictionary.Add("Kinshasa", kinshasa);
                cityDictionary.Add("Johannesburg", johannesburg);
                cityDictionary.Add("Khartoum", khartoum);
                cityDictionary.Add("Moscow", moscow);
                cityDictionary.Add("Tehran", tehran);
                cityDictionary.Add("Delhi", delhi);
                cityDictionary.Add("Kolkata", kolkata);
                cityDictionary.Add("Istanbul", istanbul);
                cityDictionary.Add("Baghdad", baghdad);
                cityDictionary.Add("Karachi", karachi);
                cityDictionary.Add("Algiers", algiers);
                cityDictionary.Add("Cairo", cairo);
                cityDictionary.Add("Riyadh", riyadh);
                cityDictionary.Add("Mumbai", mumbai);
                cityDictionary.Add("Chennai", chennai);
                cityDictionary.Add("Beijing", beijing);
                cityDictionary.Add("Seoul", seoul);
                cityDictionary.Add("Shanghai", shanghai);
                cityDictionary.Add("Tokyo", tokyo);
                cityDictionary.Add("Osaka", osaka);
                cityDictionary.Add("Taipei", taipei);
                cityDictionary.Add("Hong Kong", hongKong);
                cityDictionary.Add("Bangkok", bangkok);
                cityDictionary.Add("Manila", manila);
                cityDictionary.Add("Ho Chi Minh City", hoChiMinhCity);
                cityDictionary.Add("Jakarta", jakarta);
                cityDictionary.Add("Sydney", sydney);
                #endregion
            }
            catch (Exception e)
            {

            }
        }

        public void setAdjacentCities(StringReader reader)
        {
            String line;
            while ((line = reader.ReadLine()) != null)
            {
                string cityname = line.Substring(0, line.IndexOf(";"));
                string adjcities = line.Substring(line.IndexOf(";") + 1);
                string[] adjCityList = adjcities.Split(',');

                foreach (var city in adjCityList)
                {
                    cityDictionary[cityname].adjacentCities.Add(cityDictionary[city]);
                }
            }

        }

        public Card[] makePlayerDeck()
        {
            Card[] deck = new Card[58];
            Random rand = new Random();
            deck[rand.Next(0, 9)] = new Card("EPIDEMIC", Card.CARDTYPE.Special);
            deck[rand.Next(10, 19)] = new Card("EPIDEMIC", Card.CARDTYPE.Special);
            deck[rand.Next(20, 29)] = new Card("EPIDEMIC", Card.CARDTYPE.Special);
            deck[rand.Next(30, 39)] = new Card("EPIDEMIC", Card.CARDTYPE.Special);
            deck[rand.Next(40, 58)] = new Card("EPIDEMIC", Card.CARDTYPE.Special);
            List<Card> cardList = makeCardList(new StringReader(SQADemicApp.Properties.Resources.CityList));
            cardList = HelperBL.shuffleArray(cardList);
            int j = 0;
            for (int i = 0; i < 58; i++)
            {
                if (deck[i] == null)
                {
                    deck[i] = cardList[j];
                    j++;
                }
            }

            return deck;
        }
        public List<Card> makeCardList(StringReader stringReader)
        {
            List<Card> cardList = new List<Card>();
            string line;
            while ((line = stringReader.ReadLine()) != null)
            {
                string cardName = line.Substring(0, line.IndexOf(";"));
                string cardColor = line.Substring(line.IndexOf(";") + 2);
                COLOR color = getColor(cardColor);
                cardList.Add(new Card(cardName, Card.CARDTYPE.City, color));
            }
            cardList.Add(new Card("Airlift", Card.CARDTYPE.Special));
            cardList.Add(new Card("One Quiet Night", Card.CARDTYPE.Special));
            cardList.Add(new Card("Resilient Population", Card.CARDTYPE.Special));
            cardList.Add(new Card("Government Grant", Card.CARDTYPE.Special));
            cardList.Add(new Card("Forecast", Card.CARDTYPE.Special));
            return cardList;
        }
        public COLOR getColor(string color)
        {
            switch (color.ToLower())
            {
                case "red":
                    return COLOR.red;
                case "black":
                    return COLOR.black;
                case "yellow":
                    return COLOR.yellow;
                default:
                    return COLOR.blue;
            }

        }

    }

}