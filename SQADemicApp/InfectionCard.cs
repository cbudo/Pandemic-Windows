using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp
{
    class InfectionCard:Cards
    {
        public InfectionCard(string name, Color color)
        {
            this.name = name;
            this.CityColor = color;
        }

        public InfectionCard(string name)
        {
            this.name = name;
        }

        public String name { get; set; }
        public Color CityColor { get; set; }

        public override bool Equals(Object obj)
        {
            InfectionCard objects = (InfectionCard)obj;
            return (this.name == objects.name) && (this.CityColor == objects.CityColor);
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() + CityColor.GetHashCode();
        }
    }
}
