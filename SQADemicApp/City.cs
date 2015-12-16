using System;
using System.Collections.Generic;

namespace SQADemicApp
{
    public class City
    {
        public string Name;
        public COLOR color;
        public int redCubes { get; set; }
        public int blackCubes { get; set; }
        public int blueCubes { get; set; }
        public int yellowCubes { get; set; }
        public bool researchStation = false;
        public HashSet<City> adjacentCities;
        //public List<City> adjacentCities;

        public City(COLOR color, String name)
        {
            this.color = color;
            this.Name = name;
            redCubes = 0;
            blackCubes = 0;
            blueCubes = 0;
            yellowCubes = 0;
            adjacentCities = new HashSet<City>();
        }

        public int allCubeCount()
        {
            return redCubes + blackCubes + blueCubes + yellowCubes;
        }

        public void setAdjacentCities(HashSet<City> cities)
        {
            this.adjacentCities = cities;
        }

        public HashSet<City> getAdjacentCities()
        {
            return adjacentCities;
        }

        public override bool Equals(object obj)
        {
            City temp = (City)obj;
            return (this.Name == temp.Name) && (this.color == temp.color);
        }
    }
}