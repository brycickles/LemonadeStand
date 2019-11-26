using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Pitcher
    {
        public int cupsLeftInPitcher; 
        public double pricePerCup;
        public int lemonsInPitcher; 
        public int sugarPerPitcher;
        public int icePerPitcher; 

        public Pitcher()
        {
            cupsLeftInPitcher = 16; //2 quarts to standard pitcher, 4 cups per quart
            pricePerCup = 0.25; // 25c per cup
            lemonsInPitcher = 4; //4 lemons per pitcher
            sugarPerPitcher = 4; //4 sugar cubes per pitcher
            icePerPitcher = 4; //4 cubes per cup 


        }

        public void MakePitcher(Inventory inventory)
        {
            string sinput = "";
            string ssinput = "";
            string sssinput = "";
            bool cont = true;
            Console.Clear();
            Console.WriteLine("Its time to make your lemonade recipe. The base recipe consists of: \n${0} per cup\n{1} lemons per pitcher\n{2} sugar cubes per pitcher\n{3} Ice Cubes per cup",pricePerCup, lemonsInPitcher, sugarPerPitcher, icePerPitcher);
            
            while(sinput != "yes" && sinput != "no"){ 
                Console.WriteLine("You have {0} lemons, {1} sugar cubes, {2} ice cubes, and {3} cups\nWould you like to adjust the recipe at all?", inventory.lemons.Count, inventory.sugarCubes.Count, inventory.iceCubes.Count, inventory.cups.Count);
                Console.WriteLine("Enter 'yes' or 'no;");
                sinput = Console.ReadLine();
            }
            
            while(cont == true){               
                if (sinput == "yes"){ 
                    while(ssinput != "lemons" && ssinput != "sugar" && ssinput != "ice" && ssinput != "cups"){                    
                    Console.WriteLine("enter 'lemons', 'sugar', 'ice', or 'cups' (cup price) to change a value"); 
                        ssinput = Console.ReadLine();
                    }

                    if(ssinput == "lemons"){ 
                        Console.WriteLine("You currently have {0} lemons in your recipe and a total of {1} lemons",lemonsInPitcher, inventory.lemons.Count);
                        lemonsInPitcher = changeValue(lemonsInPitcher, inventory.lemons.Count);
                        Console.WriteLine("You now are using {0} lemons per pitcher", lemonsInPitcher); 
                    } else if (ssinput == "sugar"){
                        Console.WriteLine("You currently have {0} sugar cubes in your recipe and a total of {1} sugar cubes",sugarPerPitcher, inventory.sugarCubes.Count);
                        sugarPerPitcher = changeValue(sugarPerPitcher, inventory.sugarCubes.Count);
                        Console.WriteLine("You now are using {0} sugar cubes per pitcher", sugarPerPitcher); 
                    } else if (ssinput == "ice"){ 
                        Console.WriteLine("You currently have {0} ice cubes in your recipe and a total of {1} ice cubes",icePerPitcher, inventory.iceCubes.Count);
                        icePerPitcher = changeValue(icePerPitcher, inventory.iceCubes.Count);
                        Console.WriteLine("You now are using {0} ice cubes per pitcher", icePerPitcher); 
                    } else if (ssinput == "cups"){ 
                        Console.WriteLine("You currently have {0} as a price per cup in your recipe and a total of {1} cups",pricePerCup, inventory.cups.Count);
                        pricePerCup = changeCupsPrice(pricePerCup, inventory.cups.Count);
                        Console.WriteLine("You now are using {0} as a price for each cup", pricePerCup); 
                    }
                
                    while (sssinput != "yes" && sssinput != "no"){ 
                        Console.WriteLine("Change any other values? Enter 'yes' to change another value, 'no' to continue on.");
                        sssinput = Console.ReadLine;
                    }
                    if (sssinput == "no"){ 
                        cont = false;
                    }
                }

            }


        
        }

        public int changeValue(int item, int totalNumber){
            item = -1; 
            while(item < 0 || item > totalNumber){
                Console.WriteLine("Please enter new amount to be used in recipe."); 
                item = Convert.ToInt32(Console.ReadLine());
                if(item > totalNumber){ 
                    Console.WriteLine("Not enough items of that type in inventory to support making a pitcher. Choose a smaller value.");
                }
            }
            return item;
        }

        public double changeCupsPrice(double item, int totalNumber){
            item = -1; 
            while(item < 0 || item > totalNumber){
                Console.WriteLine("Please enter new amount (in #.## format) to be used as a price."); 
                item = Convert.ToDouble(Console.ReadLine());
                if(item > totalNumber){ 
                    Console.WriteLine("Not enough items of that type in inventory to support making a pitcher. Choose a smaller value.");
                }
            }
            return item;
        }
    }
}
