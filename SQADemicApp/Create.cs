using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace SQAdemicApp
{
    public class Create
    {
        public Create()
        {
            createDictionary();
        }
        //create the blues
        City sanFrancisco = new City(GameBoardModels.COLOR.blue);
        City chicago = new City(GameBoardModels.COLOR.blue);
        City montreal = new City(GameBoardModels.COLOR.blue);
        City newYork = new City(GameBoardModels.COLOR.blue);
        City washington = new City(GameBoardModels.COLOR.blue);
        City atlanta = new City(GameBoardModels.COLOR.blue);
        City london = new City(GameBoardModels.COLOR.blue);
        City madrid = new City(GameBoardModels.COLOR.blue);
        City paris = new City(GameBoardModels.COLOR.blue);
        City milan = new City(GameBoardModels.COLOR.blue);
        City stPetersburg = new City(GameBoardModels.COLOR.blue);
        City essen = new City(GameBoardModels.COLOR.blue);

        //create the yellows
        City losAngeles = new City(GameBoardModels.COLOR.yellow);
        City mexicoCity = new City(GameBoardModels.COLOR.yellow);
        City miami = new City(GameBoardModels.COLOR.yellow);
        City bogota = new City(GameBoardModels.COLOR.yellow);
        City lima = new City(GameBoardModels.COLOR.yellow);
        City saoPaulo = new City(GameBoardModels.COLOR.yellow);
        City buenosAires = new City(GameBoardModels.COLOR.yellow);
        City santiago = new City(GameBoardModels.COLOR.yellow);
        City lagos = new City(GameBoardModels.COLOR.yellow);
        City khartoum = new City(GameBoardModels.COLOR.yellow);
        City kinshasa = new City(GameBoardModels.COLOR.yellow);
        City johannesburg = new City(GameBoardModels.COLOR.yellow);

        //create the blacks
        City algiers = new City(GameBoardModels.COLOR.black);
        City cairo = new City(GameBoardModels.COLOR.black);
        City istanbul = new City(GameBoardModels.COLOR.black);
        City moscow = new City(GameBoardModels.COLOR.black);
        City baghdad = new City(GameBoardModels.COLOR.black);
        City riyadh = new City(GameBoardModels.COLOR.black);
        City tehran = new City(GameBoardModels.COLOR.black);
        City karachi = new City(GameBoardModels.COLOR.black);
        City delhi = new City(GameBoardModels.COLOR.black);
        City mumbai = new City(GameBoardModels.COLOR.black);
        City chennai = new City(GameBoardModels.COLOR.black);
        City kolkata = new City(GameBoardModels.COLOR.black);

        //create the reds
        City beijing = new City(GameBoardModels.COLOR.red);
        City seoul = new City(GameBoardModels.COLOR.red);
        City shanghai = new City(GameBoardModels.COLOR.red);
        City tokyo = new City(GameBoardModels.COLOR.red);
        City osaka = new City(GameBoardModels.COLOR.red);
        City taipei = new City(GameBoardModels.COLOR.red);
        City hongKong = new City(GameBoardModels.COLOR.red);
        City bangkok = new City(GameBoardModels.COLOR.red);
        City manila = new City(GameBoardModels.COLOR.red);
        City hoChiMinhCity = new City(GameBoardModels.COLOR.red);
        City jakarta = new City(GameBoardModels.COLOR.red);
        City sydney = new City(GameBoardModels.COLOR.red);

        static Dictionary<string, City> dictOfNeighbors = new Dictionary<string, City>();

        public void createDictionary()
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
                    switch (cityname)
                    {
                        case "San Francisco":
                            dictOfNeighbors[cityname].adjacentCities.Add(dictOfNeighbors[city]);
                            break;



                        default:
                            break;
                    }
                }
            }
            
        }

        public List<City> getAdjacentCities(string name)
        {
            City city = dictOfNeighbors[name];
            return city.getAdjacentCities();
        }

    }

}