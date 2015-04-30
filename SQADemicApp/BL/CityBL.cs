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
        public List<String> getNeighborNames(String cityName)
        {
            List<String> ls = new List<String>();
            HashSet<City> cityls = Create.cityDictionary[cityName].getAdjacentCities();
            foreach (var city in cityls)
            {
                ls.Add(city.Name);
            }
            return ls;
        }

        public List<City> getCitiesWithResearchStations()
        {
            List<City> ls = new List<City>();
            foreach (var key in Create.cityDictionary.Keys)
            {
                if (Create.cityDictionary[key].researchStation == true)
                {
                    ls.Add(Create.cityDictionary[key]);
                }
            }
            return ls;
        }

        public HashSet<City> getAdjacentCities(string name)
        {
            City city = Create.cityDictionary[name];
            return city.getAdjacentCities();
        }

    }
}
