using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp
{
    class CityCard:Cards
    {

        public CityCard(string cityName, Color color)
        {
            this.CityName = cityName;
            this.CityColor = color;
        }

        public CityCard(string cityName)
        {
            this.CityName = cityName;
        }

        public string CityName;
        public Color CityColor { get; set; }

        public override bool Equals(Object obj)
        {
            Card objects = (Card)obj;
            return (this.CityName == objects.CityName) && (this.CityColor == objects.CityColor);
        }

        public override int GetHashCode()
        {
            return CityName.GetHashCode() + CityColor.GetHashCode();
        }
    }
}
