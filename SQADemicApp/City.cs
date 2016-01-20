using System;
using System.Collections.Generic;
using System.Linq;
using SQADemicApp.BL;

namespace SQADemicApp
{
    public class City
    {
        private const int Maxcubecount = 24;
        public string Name;
        public Color Color;
        public int RedCubes { get; set; }
        public int BlackCubes { get; set; }
        public int BlueCubes { get; set; }
        public int YellowCubes { get; set; }
        public bool ResearchStation = false;
        public HashSet<City> AdjacentCities;
        //public List<City> adjacentCities;

        public City(Color color, string name)
        {
            this.Color = color;
            this.Name = name;
            RedCubes = 0;
            BlackCubes = 0;
            BlueCubes = 0;
            YellowCubes = 0;
            AdjacentCities = new HashSet<City>();
        }

        public int AllCubeCount()
        {
            return RedCubes + BlackCubes + BlueCubes + YellowCubes;
        }

        public void SetAdjacentCities(HashSet<City> cities)
        {
            this.AdjacentCities = cities;
        }

        public HashSet<City> GetAdjacentCities()
        {
            return AdjacentCities;
        }

        public override bool Equals(object obj)
        {
            City temp = (City)obj;
            return (this.Name == temp.Name) && (this.Color == temp.Color);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Color.GetHashCode() + RedCubes.GetHashCode() + BlackCubes.GetHashCode() + BlueCubes.GetHashCode() + YellowCubes.GetHashCode() +
                   AdjacentCities.GetHashCode();
        }

        /// <summary>
        /// Helper method for Treat Disease Option
        /// </summary>
        /// <param name="city"></param>
        /// <param name="color"></param>
        /// <returns>number of disease cubes in the city</returns>
        public int GetDiseaseCubes(Color color)
        {
            switch (color)
            {
                case Color.Red:
                    return RedCubes;

                case Color.Blue:
                    return BlueCubes;

                case Color.Yellow:
                    return YellowCubes;

                case Color.Black:
                    return BlackCubes;

                default:
                    throw new ArgumentException("invalid color");
            }
        }
        /// <summary>
        /// Helper method for Treat Disease Option
        /// </summary>
        /// <param name="city"></param>
        /// <param name="color"></param>
        /// <param name="number"></param>
        public bool SetDiseaseCubes(Color color, int numberaftercure, int numberBeforeCure)
        {
            switch (color)
            {
                case Color.Red:
                    numberaftercure = GameBoardModels.Curestatus.RedCure == Cures.Curestate.Cured ? 0 : numberaftercure;
                    GameBoardModels.CubeCount.RedCubes += (numberBeforeCure - numberaftercure);
                    RedCubes = numberaftercure;
                    if (GameBoardModels.CubeCount.RedCubes == Maxcubecount && GameBoardModels.Curestatus.RedCure == Cures.Curestate.Cured)
                        GameBoardModels.Curestatus.RedCure = Cures.Curestate.Sunset;
                    break;

                case Color.Blue:
                    numberaftercure = GameBoardModels.Curestatus.BlueCure == Cures.Curestate.Cured ? 0 : numberaftercure;
                    GameBoardModels.CubeCount.BlueCubes += (numberBeforeCure - numberaftercure);
                    BlueCubes = numberaftercure;
                    if (GameBoardModels.CubeCount.BlueCubes == Maxcubecount && GameBoardModels.Curestatus.BlueCure == Cures.Curestate.Cured)
                        GameBoardModels.Curestatus.BlueCure = Cures.Curestate.Sunset;
                    break;

                case Color.Yellow:
                    numberaftercure = GameBoardModels.Curestatus.YellowCure == Cures.Curestate.Cured ? 0 : numberaftercure;
                    GameBoardModels.CubeCount.YellowCubes += (numberBeforeCure - numberaftercure);
                    YellowCubes = numberaftercure;
                    if (GameBoardModels.CubeCount.YellowCubes == Maxcubecount && GameBoardModels.Curestatus.YellowCure == Cures.Curestate.Cured)
                        GameBoardModels.Curestatus.YellowCure = Cures.Curestate.Sunset;
                    break;

                case Color.Black:
                    numberaftercure = GameBoardModels.Curestatus.BlackCure == Cures.Curestate.Cured ? 0 : numberaftercure;
                    GameBoardModels.CubeCount.BlackCubes += (numberBeforeCure - numberaftercure);
                    BlackCubes = numberaftercure;
                    if (GameBoardModels.CubeCount.BlackCubes == Maxcubecount && GameBoardModels.Curestatus.BlackCure == Cures.Curestate.Cured)
                        GameBoardModels.Curestatus.BlackCure = Cures.Curestate.Sunset;
                    break;

                default:
                    throw new ArgumentException("invalid color");
            }
            return true;
        }

        /// <summary>
        /// Determines if the player can use a Shuttle Flight and returns list of possibilities
        /// </summary>
        /// <param name="currentCity"></param>
        /// <returns></returns>
        public List<string> ShuttleFlightOption()
        {
            if (!ResearchStation)
            {
                return new List<string>();
            }
            List<City> stations = CityBl.GetCitiesWithResearchStations();

            return (from city in stations where city.Name != Name select city.Name).ToList();
        }

    }
}