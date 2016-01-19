using System;
using System.Collections.Generic;

namespace SQADemicApp.BL
{
    public class CityBl
    {
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