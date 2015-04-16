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
            //switch statment will be best
            return new List<String> { "city" };
        }

        public List<City> getCitiesWithResearchStations()
        {
            return new List<City>();
        }

        public List<City> getAdjacentCities(string name)
        {
            City city = Create.dictOfNeighbors[name];
            return city.getAdjacentCities();
        }

    }
}
