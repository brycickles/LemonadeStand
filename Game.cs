using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
            customerList = new List<Customer>();
            //note - because of initialization in constructor, each day object comes preinstantiated with its own weather, etc
                
        }

        // member methods
        public void RunGame()
        {   int counter = 1; 
            int customerCount = 0;

            string dayString = "-1";
            int dayCount = 0;
            while(Convert.ToInt32(dayString) < 0)
            {
                Console.WriteLine("How many days would you like to run your stand for?");
                dayString = Console.ReadLine();
            }
            dayCount = Convert.ToInt32(dayString);

            days = new List<Day>();

            for (int i =0; i < dayCount; i++)
            {
                Day d = new Day();
                days.Add(d);
            }            
            
            

            foreach (Day currentDay in days)
            {
                //welcome message to display at start of each day.                 
                currentDay.Welcome(player.wallet, player.inventory, counter);
                counter++;
                
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
                //rainy 75, cloudy 100, sunny 15

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
                
                //determine customer base size
                int customerBase = 0;
                if(actualConditions == "rainy"){ 
                    customerBase = 75;                                      
                }else if (actualConditions =="cloudy"){ 
                    customerBase = 100;              
                }else if (actualConditions == "sunny"){
                    customerBase = 150;
                }
                Random random = new Random();
                for(int i = 0; i < customerBase; i++){
                    Customer c = new Customer(random); 
                    c.generatePropensityToBuy(actualTemp);                   
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

                //melt the ice cubes and rot 20% of the lemons - this adds greater impact to scalability instead of initial days
                double lemonGoneBad = player.inventory.lemons.Count * 0.2; //this is the double representation of number of lemons we will be removin
                player.inventory.lemons.RemoveRange(0, Convert.ToInt32(lemonGoneBad));                
                int iceCount = player.inventory.iceCubes.Count;
                player.inventory.iceCubes.RemoveRange(0, iceCount);
                Console.WriteLine("Some of your lemons have spoiled! You now have {0} lemons remaining.\nAll of your ice has melted too! You have 0 ice remaining.", player.inventory.lemons.Count);
               
            }
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
