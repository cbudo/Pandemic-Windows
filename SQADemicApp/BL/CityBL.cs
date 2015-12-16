using System;
using System.Collections.Generic;

namespace SQADemicApp.BL
{
    public class CityBl
    {
        //Not sure what this does for us
        /// <summary>
        /// Gets the Neighboring Cities
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns>List of Neigboring Cities names</returns>
        public static List<string> GetNeighborNames(string cityName)
        {
            List<string> ls = new List<string>();
            HashSet<City> cityls = Create.CityDictionary[cityName].GetAdjacentCities();
            foreach (var city in cityls)
            {
                ls.Add(city.Name);
            }
            return ls;
        }

        //I would prefer to use a static list that gets updated as opposed to continualy
        // finding the cities. This function has a heavy runtime and the amount of times it
        // will get called makes it burndensome
        public static List<City> GetCitiesWithResearchStations()
        {
            List<City> ls = new List<City>();
            foreach (var key in Create.CityDictionary.Keys)
            {
                if (Create.CityDictionary[key].ResearchStation == true)
                {
                    ls.Add(Create.CityDictionary[key]);
                }
            }
            return ls;
        }

        //Not sure what this does for us
        public static HashSet<City> GetAdjacentCities(string name)
        {
            City city = Create.CityDictionary[name];
            return city.GetAdjacentCities();
        }
    }
}