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
        Player[] Players;

        public static void init(string[] roles)
        {
            List<Player> playerRoles = roles.Select(role => getRole(role)).ToList();
            GameBoardModels.Players = playerRoles.ToArray();
        }

        private PlayerFactory()
        {

        }

        private static Player getRole(string roleName)
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

                default:
                    player = null;
                    break;
            }
            return player;
        }

        public static object[] possibleRoles()
        {
            return new object[] {"Dispatcher", "Operations Expert", "Scientist", "Medic", "Researcher", "Gene Splicer"};
        }
    }
}
