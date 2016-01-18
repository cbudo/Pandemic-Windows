using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp
{
    class EpidemicCard:Cards
    {
        public String name { get; set; }
        public EpidemicCard(String name)
        {
            this.name = name;
        }

    }
}
