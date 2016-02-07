using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp.Players
{
    class FirstResponder:Player
    {
        public FirstResponder() : base("First Responder")
        {
        }
        public override bool Move(City destination)
        {
            if (DriveOptions().Any(c => c.Name.Equals(destination.Name)))
            {
                //Do Nothing
            }
            else if (destination.ResearchStation)
            {
                //Do Nothing
            }
            else if (CurrentCity.ShuttleFlightOption().Contains(destination.Name))
            {
                //Do Nothing
            }
            else if (DirectFlightOption().Contains(destination.Name))
            {
                Hand.RemoveAll(x => x.CityName.Equals(destination.Name));
            }
            else if (CharterFlightOption())
            {
                Hand.RemoveAll(x => x.CityName.Equals(CurrentCity.Name));
            }
            else
            {
                return false;
            }
            CurrentCity = destination;
            return true;
        }
    }
}
