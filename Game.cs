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
            int customerCount = 0;
            //turn it to int currentday
            foreach(Day currentDay in days)
            {
                //welcome message to display at start of each day.                 
                currentDay.Welcome(player.wallet, player.inventory, counter);
                counter++;
                bool endDay = true;
                
                //get the weather 
                Console.WriteLine("The projected weather today is somewhere around 75 +/-10 degrees and {0}", currentDay.weather.condition);
                currentDay.weather.GenerateTemp(); 
                currentDay.weather.GenerateWeather();
                int actualTemp = currentDay.weather.actualTemperature;
                string actualConditions = currentDay.weather.condition;
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
                Console.Clear();

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
                
                //handles all buying requirements before learning about the weather. 
                store.DisplayStore(player.wallet, player);
               
                //make lemonade and subtract your pitcher ingredients from your inventory
                player.inventory.pitcher.MakePitcher(player.inventory);                
                player.inventory.pitcher.SubtractIngredientsFromInventory(player.inventory);
                DisplayRecipe(player);               
                
                Console.WriteLine("Customers begin to line up at your stand. The day will begin shortly.\nPress Enter to continue.");
                Console.ReadLine();
                Console.Clear();


                Console.WriteLine("Weather Conditions: {0} degrees and {1}", actualTemp, actualConditions);               
                
                
                for(int i = 0; i < customerList.Count; i++){
                    Customer c = new Customer(); 
                    c.generatePropensityToBuy(c, actualTemp);
                    if(c.willBuy == true){ 
                        customerCount++; //someone bought a cuppa. Joy. 
                        c.PayMoneyForItems(player.inventory.pitcher.pricePerCup);
                        player.wallet.GetMoney(player.inventory.pitcher.pricePerCup);
                        player.inventory.pitcher.cupsLeftInPitcher -= 1; //really the only thing we need to track is how many cups remain

                        if(player.inventory.pitcher.cupsLeftInPitcher == 0){ 
                            if(player.inventory.lemons.Count < player.inventory.pitcher.lemonsInPitcher){ 
                                Console.WriteLine("Not enough lemons left in inventory to support your lifestyle choices");
                                break;
                            } else if(player.inventory.sugarCubes.Count < player.inventory.pitcher.sugarPerPitcher){ 
                                Console.WriteLine("Not enough sugar cubes left in inventory to support your lifestyle choices");
                                break;
                            } else if(player.inventory.iceCubes.Count < player.inventory.pitcher.icePerPitcher) { 
                                Console.WriteLine("Not enough lce cubes left in inventory to support your lifestyle choices");
                                break;
                            } else if(player.inventory.cups.Count < 16) { 
                                Console.WriteLine("Not enough cups left in inventory to support your lifestyle choices");
                                break;
                            }else { 
                                //do the refill logic here
                                player.inventory.pitcher.cupsLeftInPitcher = 16;
                                player.inventory.cups.RemoveRange(0, 16);
                                player.inventory.lemons.RemoveRange(0, player.inventory.pitcher.lemonsInPitcher);
                                player.inventory.sugarCubes.RemoveRange(0, player.inventory.pitcher.sugarPerPitcher);
                                player.inventory.iceCubes.RemoveRange(0, player.inventory.pitcher.icePerPitcher);
                            
                            }
                        }

                       

                    }
                }

                Console.WriteLine("{0} customers bought lemonade today!", customerCount); 
                customerCount = 0;
                Console.WriteLine("Ready for the next day? \nPress enter to continue");
                Console.ReadLine();
               
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
                    player.inventory.lemons.RemoveRange(0, lemonsNeededForRecipe); 
                    player.inventory.cups.RemoveRange(0, 16);
                    player.inventory.sugarCubes.RemoveRange(0, sugarInInventory);
                    player.inventory.iceCubes.RemoveRange(0, iceInInventory);
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
            Console.WriteLine("\nYour new current totals before start of day: \n {0} lemons, {1} ice cubes, {2} sugar cubes, {3} cups", player.inventory.lemons.Count, player.inventory.iceCubes.Count, player.inventory.sugarCubes.Count, player.inventory.cups.Count);

        }
    }
}
