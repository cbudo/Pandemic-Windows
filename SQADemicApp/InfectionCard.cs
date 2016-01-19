using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp
{
    public class InfectionCard:Cards
    {
        public enum Cardtype { Infection, City, Special, Epidemic }

        public InfectionCard(string cityName, Cardtype type, Color color)
        {
            this.CityName = cityName;
            this.CardType = type;
            this.CityColor = color;
        }

        public InfectionCard(string cityName, Cardtype type)
        {
            this.CityName = cityName;
            this.CardType = type;
        }

        public string CityName { get; set; }
        public Cardtype CardType { get; set; }
        public Color CityColor { get; set; }

        public override bool Equals(Object obj)
        {
            InfectionCard objects = (InfectionCard)obj;
            return (this.CityName == objects.CityName) && (this.CardType == objects.CardType) && (this.CityColor == objects.CityColor);
        }

        public override int GetHashCode()
        {
            return CityName.GetHashCode() + CardType.GetHashCode() + CityColor.GetHashCode();
        }
    }
}
