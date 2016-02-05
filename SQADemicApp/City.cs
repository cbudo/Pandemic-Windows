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

        public int getCityCubes(Color color)
        {
            Dictionary<Color, int> allcubes = new Dictionary<Color, int>();
            allcubes.Add(Color.Red, RedCubes);
            allcubes.Add(Color.Black, BlackCubes);
            allcubes.Add(Color.Blue, BlueCubes);
            allcubes.Add(Color.Yellow, YellowCubes);
            return allcubes[color];
        }

        public void setCityCubeCount(Color color, int newCount)
        {
            switch (color)
            {
                case Color.Red:
                    RedCubes = newCount;
                    break;

                case Color.Blue:
                    BlueCubes = newCount;
                    break;

                case Color.Yellow:
                    YellowCubes = newCount;
                    break;

                case Color.Black:
                    BlackCubes = newCount;
                    break;

                default:
                    throw new ArgumentException("invalid color");
            }
        }

        public void incrementCityCubeCount(Color color)
        {
            switch (color)
            {
                case Color.Red:
                    RedCubes++;
                    break;

                case Color.Blue:
                    BlueCubes++;
                    break;

                case Color.Yellow:
                    YellowCubes++;
                    break;

                case Color.Black:
                    BlackCubes++;
                    break;

                default:
                    throw new ArgumentException("invalid color");
            }
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
            Cures.Curestate cures = GameBoardModels.Curestatus.GetColorCureState(color);
            int gameBoardCubeCounts = GameBoardModels.CubeCount.GetColorCubeCount(color);
            int cityCubeCounts = getCityCubes(color);

            numberaftercure = GameBoardModels.Curestatus.GetColorCureState(color) == Cures.Curestate.Cured ? 0 : numberaftercure;

            gameBoardCubeCounts += (numberBeforeCure - numberaftercure);
            GameBoardModels.CubeCount.setCubeCount(color, gameBoardCubeCounts);

            cityCubeCounts = numberaftercure;
            setCityCubeCount(color, cityCubeCounts);

            if (GameBoardModels.CubeCount.GetColorCubeCount(color) == Maxcubecount && GameBoardModels.Curestatus.GetColorCureState(color) == Cures.Curestate.Cured)
                GameBoardModels.Curestatus.setSunset(color);

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