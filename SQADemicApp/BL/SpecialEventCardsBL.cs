using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp.BL
{
    public class SpecialEventCardsBL
    {
        public static bool GovernmentGrant(string cityName)
        {
            if (Create.cityDictionary[cityName] != currentCity)
            {
                return false;
            }
            if (Create.cityDictionary[cityName].researchStation == true)
            {
                return false;
            }
            Create.cityDictionary[cityName].researchStation = true;
            return true;
        }
    }
}
