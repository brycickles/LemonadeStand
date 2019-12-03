using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Store
    {
        // member variables (HAS A)
        private double pricePerLemon;
        private double pricePerSugarCube;
        private double pricePerIceCube;
        private double pricePerCup;

        // constructor (SPAWNER)
        public Store()
        {
            pricePerLemon = .05;
            pricePerSugarCube = .1;
            pricePerIceCube = .01;
            pricePerCup = .05;
        }

        // member methods (CAN DO)
        public void SellLemons(Player player)
        {
            int lemonsToPurchase = UserInterface.GetNumberOfItems("lemons");
            double transactionAmount = CalculateTransactionAmount(lemonsToPurchase, pricePerLemon);
            if(player.wallet.Money >= transactionAmount)
            {
                player.wallet.PayMoneyForItems(transactionAmount);
                player.inventory.AddLemonsToInventory(lemonsToPurchase);
            }
        }

        public void SellSugarCubes(Player player)
        {
            int sugarToPurchase = UserInterface.GetNumberOfItems("sugar cubes");
            double transactionAmount = CalculateTransactionAmount(sugarToPurchase, pricePerSugarCube);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddSugarCubesToInventory(sugarToPurchase);
            }
        }

        public void SellIceCubes(Player player)
        {
            int iceCubesToPurchase = UserInterface.GetNumberOfItems("ice cubes");
            double transactionAmount = CalculateTransactionAmount(iceCubesToPurchase, pricePerIceCube);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddIceCubesToInventory(iceCubesToPurchase);
            }
        }

        public void SellCups(Player player)
        {
            int cupsToPurchase = UserInterface.GetNumberOfItems("cups");
            double transactionAmount = CalculateTransactionAmount(cupsToPurchase, pricePerCup);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddCupsToInventory(cupsToPurchase);
            }
        }

        private double CalculateTransactionAmount(int itemCount, double itemPricePerUnit)
        {
            double transactionAmount = itemCount * itemPricePerUnit;
            return transactionAmount;
        }

        private void PerformTransaction(Wallet wallet, double transactionAmount)
        {
            wallet.PayMoneyForItems(transactionAmount);
        }

        public void DisplayStore(Wallet wallet, Player player)
        {
            string sinput = "";
            int input = -1; 
            Console.WriteLine("Come buy supplies at the Lemonade Supply Store\nDISCLAIMER: WE ARE NOT A FRONT FOR DRUGS");
            bool cont = true;

            while (cont == true){ 
                Console.WriteLine("Lemons: {0}   Sugar Cubes: {1}   Ice Cubes: {2}  Paper Cups: {3}     Bankroll: {4}", player.inventory.lemons.Count, player.inventory.sugarCubes.Count, player.inventory.iceCubes.Count, player.inventory.cups.Count, ("$" + wallet.Money));
                Console.WriteLine("Prices: \n1.)Lemon - {0} cents each\n2.)Sugar Cubes - {1} cents each\n3.)Ice Cubes - {2} cents each\n4.)Paper Cups - {3} cents each \n5.)Exit", (pricePerLemon * 100), (pricePerSugarCube * 100), (pricePerIceCube * 100), (pricePerCup * 100));
                Console.WriteLine("Please enter the number that corresponds with which item you would like to buy: "); 
                while (input <= 0 || input > 4){ 
                    input = Convert.ToInt32(Console.ReadLine()); 
                    if (input == 5){
                        break;
                        //return; //this would end the entire function
                    } else if(input > 5){
                        Console.WriteLine("Value exceeds choice. Enter choice value again!");
                    }
                    
                }

                if(input == 1){  //lemons
                    SellLemons(player);
                }else if (input == 2){ //sugar cubes
                    SellSugarCubes(player);
                }else if (input == 3){ //ice cubes
                    SellIceCubes(player);
                }else if (input == 4){ //paper cups
                    SellCups(player);        
                }

                input = -1; //reset to be able to purchase more if necessary
                Console.WriteLine("Remaining money: {0}", wallet.Money);

                while(sinput != "yes" && sinput != "no"){                    
                    Console.WriteLine("Purchase more items?\nEnter 'yes' or 'no'");
                    sinput = Console.ReadLine();
                    Console.Clear();
                }         

                if(sinput == "no"){ 
                    if(player.inventory.lemons.Count > 0 && player.inventory.sugarCubes.Count > 0 && player.inventory.iceCubes.Count > 0 && player.inventory.cups.Count > 0){
                        cont = false; 
                    } else { 
                        Console.Clear();
                        Console.WriteLine("You have not purchased at least one of every item. Please try again and ensure you have purchased enough items."); 
                        Console.WriteLine("Lemons: {0}\nSugar Cubes: {1}\nIce Cubes: {2}\nPaper Cups: {3}", player.inventory.lemons.Count, player.inventory.sugarCubes.Count, player.inventory.iceCubes.Count, player.inventory.cups.Count);
                    }
                }
                sinput = "";
            }           
        }


    }
}
