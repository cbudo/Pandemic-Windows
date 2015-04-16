using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQADemicApp
{
    public class City
    {

        public string Name;
        public GameBoardModels.COLOR color;
        private int redCubes = 0;
        private int blackCubes = 0;
        private int blueCubes = 0;
        private int yellowCubes = 0;
        public bool researchStation = false;
        public List<City> adjacentCities;
        public City()
        {

        }
        public City(GameBoardModels.COLOR color)
        {
            this.color = color;
            adjacentCities = new List<City>();
        }
        public City(GameBoardModels.COLOR color, String name)
        {
            this.color = color;
            this.Name = name;
            adjacentCities = new List<City>();
        }

        public void setAdjacentCities(List<City> cities)
        {
            this.adjacentCities = cities;
        }

        public List<City> getAdjacentCities()
        {
            return adjacentCities;
        }

        public void infectCity(string color, int numToAdd)
        {

        }

        public void cureCity(string color, int numToRemove)
        {

        }

        public override bool Equals(object obj)
        {
            City temp = (City) obj;
            return (this.Name == temp.Name) && (this.color == temp.color);
        }
    }

}