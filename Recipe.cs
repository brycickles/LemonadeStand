using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Recipe
    {
        private int amountOfLemons;
        private int amountOfSugarCubes;
        private int amountOfIceCubes;
        private double pricePerCup; 

        public Recipe()
        {
            amountOfLemons = 0;
            amountOfSugarCubes = 0;
            amountOfIceCubes = 0;
            pricePerCup = 0.25;
        }
    }
}
