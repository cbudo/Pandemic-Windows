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
