using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp.Players
{
    public class Scientist:Player
    {
        public Scientist() : base("Scientist")
        {
        }
        public override bool Cure(List<string> cardsToSpend, Color color)
        {
            if (!CurrentCity.ResearchStation || GameBoardModels.Curestatus.GetCureStatus(color) != Cures.Curestate.NotCured)
                return false;
            var cards = Hand.Where(x => x.CityColor == color && cardsToSpend.Contains(x.CityName));
            
            if (cards.Count() != 4)
                return false;

            Hand.RemoveAll(x => cards.Contains(x));
            GameBoardModels.Curestatus.SetCureStatus(color, Cures.Curestate.Cured);
            if (GameBoardModels.Curestatus.BlackCure != Cures.Curestate.NotCured &&
                   GameBoardModels.Curestatus.BlueCure != Cures.Curestate.NotCured &&
                   GameBoardModels.Curestatus.RedCure != Cures.Curestate.NotCured &&
                   GameBoardModels.Curestatus.YellowCure != Cures.Curestate.NotCured)
            {
                throw new InvalidOperationException("Game Over You Win");
            }

            return true;
        }
    }
}
