using System;

namespace SQADemicApp
{
    public class Card
    {
        public enum Cardtype { Infection, City, Special, Epidemic }

        public Card(string cityName, Cardtype type, Color color)
        {
            this.CityName = cityName;
            this.CardType = type;
            this.CityColor = color;
        }

        public Card(string cityName, Cardtype type)
        {
            this.CityName = cityName;
            this.CardType = type;
        }

        public string CityName;
        public Cardtype CardType { get; set; }
        public Color CityColor { get; set; }

        public override bool Equals(Object obj)
        {
            Card objects = (Card)obj;
            return (this.CityName == objects.CityName) && (this.CardType == objects.CardType) && (this.CityColor == objects.CityColor);
        }

        public override int GetHashCode()
        {
            return  CityName.GetHashCode() + CardType.GetHashCode() + CityColor.GetHashCode();
        }
    }
}