using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQADemicApp.Players;

namespace SQADemicApp
{
    class PlayerFactory
    {
        private static bool responder = false;
        public static void init(string[] roles)
        {
            List<Player> playerRoles = roles.Select(role => GetRole(role)).ToList();
            GameBoardModels.Players = playerRoles.ToArray();
        }

        private PlayerFactory()
        {

        }

        private static Player GetRole(string roleName)
        {
            Player player;
            switch (roleName.ToUpper())
            {
                case "DISPATCHER":
                    player = new Dispatcher();
                    break;

                case "OPERATIONS EXPERT":
                    player = new OpExpert();
                    break;

                case "SCIENTIST":
                    player = new Scientist();
                    break;

                case "MEDIC":
                    player = new Medic();
                    break;

                case "RESEARCHER":
                    player = new Researcher();
                    break;

                case "GENE SPLICER":
                    player = new GeneSplicer();
                    break;

                case "PHARMACIST":
                    player = new Pharmacist();
                    break;

                case "FIRST RESPONDER":
                    player = new FirstResponder();
                    SetResponder(true);
                    break;

                default:
                    player = null;
                    break;
            }
            return player;
        }

        public static bool HasResponder()
        {
            return responder;
        }

        public static void SetResponder(bool respondr)
        {
            PlayerFactory.responder = respondr;
        }
        public static object[] PossibleRoles()
        {
            return new object[] { "First Responder", "Dispatcher", "Operations Expert", "Scientist", "Medic", "Researcher", "Gene Splicer" };
        }
    }
}
