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
        City sanFrancisco = new City(GameBoardModels.COLOR.blue, "San Francisco");
        City chicago = new City(GameBoardModels.COLOR.blue, "Chicago");
        City montreal = new City(GameBoardModels.COLOR.blue, "Montreal");
        City newYork = new City(GameBoardModels.COLOR.blue, "New York");
        City washington = new City(GameBoardModels.COLOR.blue, "Washington");
        City atlanta = new City(GameBoardModels.COLOR.blue, "Atlanta");
        City london = new City(GameBoardModels.COLOR.blue, "London");
        City madrid = new City(GameBoardModels.COLOR.blue, "Madrid");
        City paris = new City(GameBoardModels.COLOR.blue, "Paris");
        City milan = new City(GameBoardModels.COLOR.blue, "Milan");
        City stPetersburg = new City(GameBoardModels.COLOR.blue, "Saint Petersburg");
        City essen = new City(GameBoardModels.COLOR.blue, "Essen");

        //create the yellows
        City losAngeles = new City(GameBoardModels.COLOR.yellow, "Los Angeles");
        City mexicoCity = new City(GameBoardModels.COLOR.yellow, "Mexico City");
        City miami = new City(GameBoardModels.COLOR.yellow, "Miami");
        City bogota = new City(GameBoardModels.COLOR.yellow, "Bogota");
        City lima = new City(GameBoardModels.COLOR.yellow, "Lima");
        City saoPaulo = new City(GameBoardModels.COLOR.yellow, "Sao Paulo");
        City buenosAires = new City(GameBoardModels.COLOR.yellow, "Buenos Aires");
        City santiago = new City(GameBoardModels.COLOR.yellow, "Santiago");
        City lagos = new City(GameBoardModels.COLOR.yellow, "Lagos");
        City khartoum = new City(GameBoardModels.COLOR.yellow, "Khartoum");
        City kinshasa = new City(GameBoardModels.COLOR.yellow, "Kinshasa");
        City johannesburg = new City(GameBoardModels.COLOR.yellow, "Johannesburg");

        //create the blacks
        City algiers = new City(GameBoardModels.COLOR.black, "Algiers");
        City cairo = new City(GameBoardModels.COLOR.black, "Cairo");
        City istanbul = new City(GameBoardModels.COLOR.black, "Istanbul");
        City moscow = new City(GameBoardModels.COLOR.black, "Moscow");
        City baghdad = new City(GameBoardModels.COLOR.black, "Baghdad");
        City riyadh = new City(GameBoardModels.COLOR.black, "Riyadh");
        City tehran = new City(GameBoardModels.COLOR.black, "Tehran");
        City karachi = new City(GameBoardModels.COLOR.black, "Karachi");
        City delhi = new City(GameBoardModels.COLOR.black, "Delhi");
        City mumbai = new City(GameBoardModels.COLOR.black, "Mumbai");
        City chennai = new City(GameBoardModels.COLOR.black, "Chennai");
        City kolkata = new City(GameBoardModels.COLOR.black, "Kolkata");

        //create the reds
        City beijing = new City(GameBoardModels.COLOR.red, "Beijing");
        City seoul = new City(GameBoardModels.COLOR.red, "Seoul");
        City shanghai = new City(GameBoardModels.COLOR.red, "Shanghai");
        City tokyo = new City(GameBoardModels.COLOR.red, "Tokyo");
        City osaka = new City(GameBoardModels.COLOR.red, "Osaka");
        City taipei = new City(GameBoardModels.COLOR.red, "Taipei");
        City hongKong = new City(GameBoardModels.COLOR.red, "Hong Kong");
        City bangkok = new City(GameBoardModels.COLOR.red, "Bangkok");
        City manila = new City(GameBoardModels.COLOR.red, "Manila");
        City hoChiMinhCity = new City(GameBoardModels.COLOR.red, "Ho Chi Minh City");
        City jakarta = new City(GameBoardModels.COLOR.red, "Jakarta");
        City sydney = new City(GameBoardModels.COLOR.red, "Sydney");

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
            catch(Exception e)
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

        public GameBoardModels.Card[] makePlayerDeck()
        {
            GameBoardModels.Card[] deck = new GameBoardModels.Card[58];
            Random rand = new Random();
            deck[rand.Next(0, 9)] = new GameBoardModels.Card("EPIDEMIC", GameBoardModels.CARDTYPE.Special);
            deck[rand.Next(10, 19)] = new GameBoardModels.Card("EPIDEMIC", GameBoardModels.CARDTYPE.Special);
            deck[rand.Next(20, 29)] = new GameBoardModels.Card("EPIDEMIC", GameBoardModels.CARDTYPE.Special);
            deck[rand.Next(30, 39)] = new GameBoardModels.Card("EPIDEMIC", GameBoardModels.CARDTYPE.Special);
            deck[rand.Next(40, 58)] = new GameBoardModels.Card("EPIDEMIC", GameBoardModels.CARDTYPE.Special);
            List<GameBoardModels.Card> cardList = makeCardList(new StringReader(SQADemicApp.Properties.Resources.CityList));
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
        public List<GameBoardModels.Card> makeCardList(StringReader stringReader)
        {
            List<GameBoardModels.Card> cardList = new List<GameBoardModels.Card>();
            string line;
            while ((line = stringReader.ReadLine()) != null)
            {
                string cardName = line.Substring(0, line.IndexOf(";"));
                string cardColor = line.Substring(line.IndexOf(";") + 2);
                GameBoardModels.COLOR color = getColor(cardColor);
                cardList.Add(new GameBoardModels.Card(cardName, GameBoardModels.CARDTYPE.City, color));
            }
            cardList.Add(new SQADemicApp.GameBoardModels.Card("Airlift", SQADemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQADemicApp.GameBoardModels.Card("One Quiet Night", SQADemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQADemicApp.GameBoardModels.Card("Resilient Population", SQADemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQADemicApp.GameBoardModels.Card("Government Grant", SQADemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQADemicApp.GameBoardModels.Card("Forecast", SQADemicApp.GameBoardModels.CARDTYPE.Special));
            return cardList;
        }
        public GameBoardModels.COLOR getColor(string color)
        {
            switch (color.ToLower())
            {
                case "red":
                    return GameBoardModels.COLOR.red;
                case "black":
                    return GameBoardModels.COLOR.black;
                case "yellow":
                    return GameBoardModels.COLOR.yellow;
                default:
                    return GameBoardModels.COLOR.blue;
            }

        }

    }

}