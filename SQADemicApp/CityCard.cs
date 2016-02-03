using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp
{
    public class CityCard:Cards
    {

        public CityCard(string cityName, Color color)
        {
            this.CityName = cityName;
            this.CityColor = color;
        }

        public string CityName { get; set; }
        public Color CityColor { get; set; }

        public override bool Equals(Object obj)
        {
            Cards objects = (Cards)obj;
            return (this.CityName == objects.CityName) && (this.CityColor == objects.CityColor);
        }
    }
}
