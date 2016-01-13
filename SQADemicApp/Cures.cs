using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp
{
    public class Cures
    {
        public enum Curestate { NotCured, Cured, Sunset }

        public Curestate RedCure { get; set; }
        public Curestate BlueCure { get; set; }
        public Curestate BlackCure { get; set; }
        public Curestate YellowCure { get; set; }

        public Curestate GetCureStatus(Color color)
        {
            switch (color)
            {
                case Color.Red:
                    return RedCure;

                case Color.Blue:
                    return BlueCure;

                case Color.Yellow:
                    return YellowCure;

                case Color.Black:
                    return BlackCure;

                default:
                    throw new ArgumentException("Not a vaild color");
            }
        }

        public void SetCureStatus(Color color, Curestate curestate)
        {
            switch (color)
            {
                case Color.Red:
                    RedCure = curestate;
                    break;

                case Color.Blue:
                    BlueCure = curestate;
                    break;

                case Color.Yellow:
                    YellowCure = curestate;
                    break;

                case Color.Black:
                    BlackCure = curestate;
                    break;

                default:
                    throw new ArgumentException("Not a vaild color");
            }
        }
    }
}
