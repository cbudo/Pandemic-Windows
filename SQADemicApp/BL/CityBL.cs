using System;
using System.Collections.Generic;

namespace SQADemicApp.BL
{
    public class CityBL
    {
        //Not sure what this does for us
        /// <summary>
        /// Gets the Neighboring Cities
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns>List of Neigboring Cities names</returns>
        public static List<String> getNeighborNames(String cityName)
        {
            List<String> ls = new List<String>();
            HashSet<City> cityls = Create.cityDictionary[cityName].getAdjacentCities();
            foreach (var city in cityls)
            {
                ls.Add(city.Name);
            }
            return ls;
        }

        //I would prefer to use a static list that gets updated as opposed to continualy
        // finding the cities. This function has a heavy runtime and the amount of times it
        // will get called makes it burndensome
        public static List<City> getCitiesWithResearchStations()
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

        //Not sure what this does for us
        public static HashSet<City> getAdjacentCities(string name)
        {
            City city = Create.cityDictionary[name];
            return city.getAdjacentCities();
        }
    }
}