using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp
{
    public class EpidemicCard:Cards
    {

        public EpidemicCard()
        {
        }

        public string CityName { get; set; }
        public Color CityColor { get; set; }

        public override bool Equals(Object obj)
        {
            return obj.GetType() == typeof(EpidemicCard);
        }

    }
}
