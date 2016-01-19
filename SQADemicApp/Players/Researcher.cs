using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp.Players
{
    public class Researcher:Player
    {
        public Researcher() : base("Researcher")
        {
        }
        public override bool ShareKnowledgeOption(Player reciver, string cityname)
        {
            if (!Equals(CurrentCity, reciver.CurrentCity))
                return false;
            int index = Hand.FindIndex(x => x.CityName.Equals(cityname));
            if (index == -1)
                return false;
            reciver.Hand.Add(Hand[index]);
            Hand.RemoveAt(index);
            return true;
        }
    }
}
