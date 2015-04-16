using SQADemicApp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SQADemicApp.BL
{
    public class CityBL
    {
        /// <summary>
        /// Gets the Neighboring Cities
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns>List of Neigboring Cities names</returns>
        public CityBL()
        {

        }
        public List<String> getNeighborNames(String cityName)
        {
            List<String> ls = new List<String>();
            List<City> cityls = Create.dictOfNeighbors[cityName].getAdjacentCities();
            foreach (var city in cityls)
            {
                ls.Add(city.Name);
            }
            return ls;
        }

        public List<City> getCitiesWithResearchStations()
        {
            List<City> ls = new List<City>();
            foreach (var key in Create.dictOfNeighbors.Keys)
            {
                if (Create.dictOfNeighbors[key].researchStation == true)
                {
                    ls.Add(Create.dictOfNeighbors[key]);
                }
            }
            return ls;
        }

        public List<City> getAdjacentCities(string name)
        {
            City city = Create.dictOfNeighbors[name];
            return city.getAdjacentCities();
        }

    }
}
