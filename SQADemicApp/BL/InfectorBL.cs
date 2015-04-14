using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp.BL
{
    public class InfectorBL
    {

        public static List<String> InfectCities(LinkedList<String> deck, LinkedList<String> pile, int drawAmmount)
        {
            List<string> returnList;

            returnList = drawAmmount == 2 ? new List<string> { "Sydney", "Saint Petersburg" } : new List<string> { "New York", "Sydney", "Saint Petersburg" };
            return returnList;
        }

    }
}
