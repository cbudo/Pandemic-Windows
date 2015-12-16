using System;
using System.Collections.Generic;

namespace SQADemicApp
{
    public class City
    {
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
    }
}