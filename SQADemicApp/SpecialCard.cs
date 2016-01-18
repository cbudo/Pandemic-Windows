using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp
{
    class SpecialCard:Cards
    {

        public SpecialCard(string name)
        {
            this.name = name;
        }

        public String name { get; set; }

        public override bool Equals(Object obj)
        {
            SpecialCard objects = (SpecialCard)obj;
            return (this.name == objects.name);
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
    }
}
