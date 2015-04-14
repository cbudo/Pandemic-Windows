using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp.BL
{
    class CityBL
    {

        Hashtable neighbors = new Hashtable();

        public Hashtable makeNeighborTable()
        {
            List<String> sfneighbors = new List<String>();
            sfneighbors.Add("Chicago");
            sfneighbors.Add("Los Angeles");
            sfneighbors.Add("Manila");
            sfneighbors.Add("Tokyo");
            neighbors["San Francisco"] = sfneighbors;

            List<String> chicagoneighbors = new List<String>();
            chicagoneighbors.Add("San Francisco");
            chicagoneighbors.Add("Montreal");
            chicagoneighbors.Add("Atlanta");
            chicagoneighbors.Add("Mexico City");
            chicagoneighbors.Add("Los Angeles");
            neighbors["Chicago"] = chicagoneighbors;

            List<String> montrealneighbors = new List<String>();
            montrealneighbors.Add("New York");
            montrealneighbors.Add("Washington");
            montrealneighbors.Add("Chicago");
            neighbors["Montreal"] = montrealneighbors;

            List<String> nyneighbors = new List<String>();
            nyneighbors.Add("Montreal");
            nyneighbors.Add("Washington");
            nyneighbors.Add("London");
            nyneighbors.Add("Madrid");
            neighbors["New York"] = nyneighbors;

            List<String> atlantaneighbors = new List<String>();
            atlantaneighbors.Add("Chicago");
            atlantaneighbors.Add("Washington");
            atlantaneighbors.Add("Miami");
            neighbors["Atlanta"] = atlantaneighbors;

            List<String> washneighbors = new List<String>();

            return neighbors;
        }


        /// <summary>
        /// Gets the Neighboring Cities
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns>List of Neigboring Cities names</returns>
        public List<String> getNeighborNames(String cityName)
        {
            //switch statment will be best
            return new List<String> { "city" };
        }

    }
}
