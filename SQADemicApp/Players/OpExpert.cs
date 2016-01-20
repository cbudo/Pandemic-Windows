using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQADemicApp.BL;

namespace SQADemicApp.Players
{
    public class OpExpert:Player
    {
        public OpExpert() : base("OpExpert")
        {
        }

        public override bool BuildAResearchStationOption()
        {
            if (CityBl.GetCitiesWithResearchStations().Contains(CurrentCity))
                return false;
            CurrentCity.ResearchStation = true;
            return true;
        }
    }
}
