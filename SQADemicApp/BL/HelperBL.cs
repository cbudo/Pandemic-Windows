using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace SQADemicApp.BL
{
    public static class HelperBl
    {
        //The following shuffiling code refrences comon array shuffling techniques and was gotten from: http://stackoverflow.com/questions/108819/best-way-to-randomize-a-string-array-with-net
        //This code is not my own, and combinied with the randomness, is not generated with TDD

        /// <summary>
        /// Suffles a string[]
        /// </summary>
        /// <param name="unshuffledArry"></param>
        /// <returns>a shuffled Arry</returns>
        public static string[] ShuffleArray(string[] unshuffledArry)
        {
            RNGCryptoServiceProvider rnd = new RNGCryptoServiceProvider();
            string[] shuffledarray = unshuffledArry.OrderBy(x => GetNextInt32(rnd)).ToArray();
            return shuffledarray;
        }

        public static List<SQADemicApp.Cards> ShuffleArray(List<SQADemicApp.Cards> unshuffledArry)
        {
            RNGCryptoServiceProvider rnd = new RNGCryptoServiceProvider();
            List<SQADemicApp.Cards> shuffledarray = unshuffledArry.OrderBy(x => GetNextInt32(rnd)).ToList<Cards>();
            return shuffledarray;
        }

        private static int GetNextInt32(RNGCryptoServiceProvider rnd)
        {
            byte[] randomInt = new byte[4];
            rnd.GetBytes(randomInt);
            return Convert.ToInt32(randomInt[0]);
        }

        private static Dictionary<string, Color> colors = new Dictionary<string, Color>
        {
            {"red", Color.Red},
            {"black", Color.Black},
            {"yellow", Color.Yellow},
            {"blue", Color.Blue}
        };
        public static Color GetColor(string color)
        {
            color = color.ToLower();
            return colors[color];
        }
    }
}