using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Game
    {
        // member variables
        List<Day> days;
        List<Customer> customerList;
        Player player;
        Store store;
        

        // constructor
        public Game()
        {
            //objects now come preinitialized
            store = new Store();
            player = new Player();
            days = new List<Day>();
            customerList = new List<Customer>();
            //note - because of initialization in constructor, each day object comes preinstantiated with its own weather, etc
            Day d1 = new Day();
            days.Add(d1);
            Day d2 = new Day();
            days.Add(d2);
            Day d3 = new Day();
            days.Add(d3);
            Day d4 = new Day();
            days.Add(d4);
            Day d5 = new Day();
            days.Add(d5);
            Day d6 = new Day();
            days.Add(d6);
            Day d7 = new Day();
            days.Add(d7);
        }

        // member methods
        public void RunGame()
        {
            int counter = 1; 
            //turn it to int currentday
            foreach(Day currentDay in days)
            {
                //welcome message to display at start of each day.                 
                currentDay.Welcome(player.wallet, player.inventory, counter);
                counter++;
                bool endDay = true;

                currentDay.weather.GenerateRandomWeather();
                //get the weather 
                Console.WriteLine("The projected weather today is somewhere around 75 degrees and {0}", currentDay.weather.condition);
                currentDay.weather.GenerateTemp(); 
                currentDay.weather.GenerateWeather();
                int actualTemp = currentDay.weather.actualTemperature;
                string actualConditions = currentDay.weather.condition;
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
                Console.Clear();
                
                //handles all buying requirements before learning about the weather. 
                store.DisplayStore(player.wallet, player);
               
                //make lemonade
                player.inventory.pitcher.MakePitcher(player.inventory);
                DisplayRecipe(player);
               

                //set customer amounts based off weatherconditions
                //rainy 75, cloudy 100, sunny 150
                if(actualConditions == "rainy"){ 
                    for (int i = 0; i < 75; i++){
                        customerList.Add(new Customer());
                    }                    
                }else if (actualConditions =="cloudy"){ 
                    for (int i = 0; i < 100; i++){
                        customerList.Add(new Customer());
                    }
                }else if (actualConditions == "sunny"){
                    for (int i = 0; i < 150; i++){
                        customerList.Add(new Customer());
                    }
                }

                Console.Clear();
                Console.WriteLine("Customers begin to line up near your stand. It is {0} degrees and the weather is {1}", actualTemp, actualConditions);
                Console.WriteLine("Press Enter to begin your day.");
                Console.ReadLine();

                foreach(Customer customers in customerList){ 
                    
                    customers.generatePropensityToBuy(customers ,currentDay.weather.actualTemperature);
                    if(customers.willBuy == true){ 
                        customers.PayMoneyForItems(player.inventory.pitcher.pricePerCup);
                        player.inventory.pitcher.cupsLeftInPitcher -= 1;
                        if(player.inventory.pitcher.cupsLeftInPitcher == 0){ 
                           endDay = checkToRefillPitcher(player);
                           if (endDay == false){ 
                                return;
                           }
                        }
                    }
                }

                //iterate through the loop and manipulate objects 
                //foreach 
                //     check if bool willBuy is true 
                //      purchase a cup 

                //run game
            }

        }

        public bool checkToRefillPitcher(Player player){
            bool cont = true;
            int lemonsInInventory = player.inventory.lemons.Count;
            int sugarInInventory = player.inventory.sugarCubes.Count;
            int iceInInventory = player.inventory.iceCubes.Count; 

            int lemonsNeededForRecipe = player.pitcher.lemonsInPitcher;
            int iceNeededForRecipe = player.pitcher.icePerPitcher; 
            int sugarNeededForRecipe = player.pitcher.sugarPerPitcher;
          
            int cupsInInventory = player.inventory.cups.Count; 
            
            if (player.inventory.pitcher.cupsLeftInPitcher == 0){
                if((lemonsNeededForRecipe <= lemonsInInventory) && (iceNeededForRecipe <= iceInInventory) && (sugarNeededForRecipe <= sugarInInventory) && (cupsInInventory > 16)){
                    //if we have enough to actually make the recipe
                    player.inventory.pitcher.cupsLeftInPitcher = 16;
                    lemonsInInventory -= lemonsNeededForRecipe; 
                    cupsInInventory -= 16;
                    sugarInInventory -= sugarNeededForRecipe; 
                    iceInInventory -= iceNeededForRecipe;
                    return cont;
                } else{ 
                    Console.WriteLine("Not enough ingredients left, day is over!"); 
                    cont = false; 
                    return cont;
                }            
            }
            return cont;
            

        }

        public void DisplayRecipe(Player player){       
            Console.Clear();
            Console.WriteLine("Your recipe has been created!");
            Console.WriteLine("Recipe List: One Pitcher Requires");
            Console.WriteLine("{0} Lemons", player.inventory.pitcher.lemonsInPitcher);
            Console.WriteLine("{0} Ice Cubes", player.inventory.pitcher.icePerPitcher);
            Console.WriteLine("{0} Sugar Cubes", player.inventory.pitcher.sugarPerPitcher);
            Console.WriteLine("{0} Paper Cups", 16);
        }
    }
}
