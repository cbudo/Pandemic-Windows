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
            List<string> returnList = new List<string>();

            for (int i = 0; i < drawAmmount; i++)
            {
                returnList.Add(deck.First.Value);
                pile.AddFirst(deck.First.Value);
                deck.RemoveFirst();
				
            }
                return returnList;
        }

    }
}
