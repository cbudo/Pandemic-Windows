using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp
{
    public class SpecialCard:Cards
    {

        public SpecialCard(string cityName)
        {
            this.CityName = cityName;
        }

        public string CityName { get; set; }
        public Color CityColor { get; set; }

        public override bool Equals(Object obj)
        {
            SpecialCard objects = (SpecialCard)obj;
            return (this.CityName == objects.CityName);
        }
    }
}
