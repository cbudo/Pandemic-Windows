using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp.Players
{
    public class Medic : Player
    {
        public Medic() : base("Medic")
        {
        }
        /// <summary>
        /// Treates the Diesease if possible
        /// </summary>
        /// <param name="player"></param>
        /// <param name="color"></param>
        /// <returns>Success Flag</returns>
        public override bool TreatDiseaseOption(Color color)
        {
            int number = CurrentCity.GetDiseaseCubes(color);
            if (number < 1)
                return false;
            return CurrentCity.SetDiseaseCubes(color, 0, number);
        }
    }
}
