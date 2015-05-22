using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp
{
    public class Card
    {
        public enum CARDTYPE { Infection, City, Special, EPIDEMIC }
        public Card(string CityName, CARDTYPE type, COLOR color)
        {
            this.CityName = CityName;
            this.CardType = type;
            this.CityColor = color;
        }
        public Card(string CityName, CARDTYPE type)
        {
            this.CityName = CityName;
            this.CardType = type;
        }
        public string CityName;
        public CARDTYPE CardType { get; set; }
        public COLOR CityColor { get; set; }

        public override bool Equals(Object obj)
        {
            Card objects = (Card)obj;
            return (this.CityName == objects.CityName) && (this.CardType == objects.CardType) && (this.CityColor == objects.CityColor);
        }
    }
}
