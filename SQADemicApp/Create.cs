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
        public Create()
        {
        }

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
        City stPetersburg = new City(COLOR.blue, "Saint Petersburg");
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

        public static Dictionary<string, City> dictOfNeighbors = new Dictionary<string, City>();

        public void createDictionary()
        {
            try
            {
                dictOfNeighbors.Add("San Francisco", sanFrancisco);
                dictOfNeighbors.Add("Chicago", chicago);
                dictOfNeighbors.Add("Montreal", montreal);
                dictOfNeighbors.Add("New York", newYork);
                dictOfNeighbors.Add("Atlanta", atlanta);
                dictOfNeighbors.Add("Washington", washington);
                dictOfNeighbors.Add("London", london);
                dictOfNeighbors.Add("Essen", essen);
                dictOfNeighbors.Add("Saint Petersburg", stPetersburg);
                dictOfNeighbors.Add("Milan", milan);
                dictOfNeighbors.Add("Paris", paris);
                dictOfNeighbors.Add("Madrid", madrid);
                dictOfNeighbors.Add("Los Angeles", losAngeles);
                dictOfNeighbors.Add("Mexico City", mexicoCity);
                dictOfNeighbors.Add("Miami", miami);
                dictOfNeighbors.Add("Bogota", bogota);
                dictOfNeighbors.Add("Lima", lima);
                dictOfNeighbors.Add("Santiago", santiago);
                dictOfNeighbors.Add("Buenos Aires", buenosAires);
                dictOfNeighbors.Add("Sao Paulo", saoPaulo);
                dictOfNeighbors.Add("Lagos", lagos);
                dictOfNeighbors.Add("Kinshasa", kinshasa);
                dictOfNeighbors.Add("Johannesburg", johannesburg);
                dictOfNeighbors.Add("Khartoum", khartoum);
                dictOfNeighbors.Add("Moscow", moscow);
                dictOfNeighbors.Add("Tehran", tehran);
                dictOfNeighbors.Add("Delhi", delhi);
                dictOfNeighbors.Add("Kolkata", kolkata);
                dictOfNeighbors.Add("Istanbul", istanbul);
                dictOfNeighbors.Add("Baghdad", baghdad);
                dictOfNeighbors.Add("Karachi", karachi);
                dictOfNeighbors.Add("Algiers", algiers);
                dictOfNeighbors.Add("Cairo", cairo);
                dictOfNeighbors.Add("Riyadh", riyadh);
                dictOfNeighbors.Add("Mumbai", mumbai);
                dictOfNeighbors.Add("Chennai", chennai);
                dictOfNeighbors.Add("Beijing", beijing);
                dictOfNeighbors.Add("Seoul", seoul);
                dictOfNeighbors.Add("Shanghai", shanghai);
                dictOfNeighbors.Add("Tokyo", tokyo);
                dictOfNeighbors.Add("Osaka", osaka);
                dictOfNeighbors.Add("Taipei", taipei);
                dictOfNeighbors.Add("Hong Kong", hongKong);
                dictOfNeighbors.Add("Bangkok", bangkok);
                dictOfNeighbors.Add("Manila", manila);
                dictOfNeighbors.Add("Ho Chi Minh City", hoChiMinhCity);
                dictOfNeighbors.Add("Jakarta", jakarta);
                dictOfNeighbors.Add("Sydney", sydney);
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
                    dictOfNeighbors[cityname].adjacentCities.Add(dictOfNeighbors[city]);
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