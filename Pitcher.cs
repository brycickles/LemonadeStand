using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Pitcher
    {
        private int cupsLeftInPitcher; 
        private double pricePerCup;
        private int lemonsInPitcher; 
        private int sugarPerPitcher;
        private int icePerCup; 

        public Pitcher()
        {
            cupsLeftInPitcher = 16; //2 quarts to standard pitcher, 4 cups per quart
            pricePerCup = 0.25; // 25c per cup
            lemonsInPitcher = 4; //4 lemons per pitcher
            sugarPerPitcher = 4; //4 sugar cubes per pitcher
            icePerCup = 4; //4 cubes per cup 


        }

        public void MakePitcher(Inventory inventory)
        {
            Console.WriteLine("Its time to make your lemonade recipe. The base recipe consists of: \n{0} per cup\n{1} lemons per pitcher\n{2} sugar cubes per pitcher\n{3} Ice Cubes per cup",pricePerCup, lemonsInPitcher, sugarPerPitcher, icePerCup);
            Console.WriteLine("You have {0} lemons, {1} sugar cubes, {2} ice cubes, and {3} cups,");
        
        }
    }
}
