using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Day
    {
        //public Customer customer = new Customer();
        Random random = new Random(); //used throughout
        public Weather weather;




        //Constructor
        public Day()
        {
            weather = new Weather();
        }

        
        //TODO make a run day function 


        //weather section of day


        public static int GetNumberOfItems(string itemsToGet)
        {
            bool userInputIsAnInteger = false;

            int quantityOfItem = -1;

            while (!userInputIsAnInteger || quantityOfItem < 0)
            {
                Console.WriteLine("How many " + itemsToGet + " would you like to buy?");
                Console.WriteLine("Please enter a positive integer (or 0 to cancel):");

                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out quantityOfItem);
            }

            return quantityOfItem;
        }

        public void Welcome(Wallet wallet, Inventory inventory, int currentDay)
        {
            Console.WriteLine("Welcome to day {5}- you have ${0} and your inventory consists of\n{1} Lemons\n{2} Cups\n{3} Cups of Sugar\n{4} Ice Cubes", wallet.Money, inventory.lemons.Count(), inventory.cups.Count(), inventory.sugarCubes.Count(), inventory.iceCubes.Count(), currentDay);
            Console.ReadLine();
        }
    
    }
}
