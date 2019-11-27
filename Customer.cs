using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Customer
    {
        //member variables
        public double money; 
        public bool willBuy = true;
        public int propensityToBuy; 
        private Random random; //used throughout
        
        public Customer(Random rng)
        {
            random = rng;
            money = 100.00; //i swear if you figure out a way to exceed 100 in individual sales...           

        }

        public void PayMoneyForItems(double transactionAmount)
        {
            money -= transactionAmount;
        }

        public bool generatePropensityToBuy(int temperature){
            int buyIndex = 0;
            buyIndex = random.Next(0, 100); 
            if(temperature > 75){ 
                if(buyIndex >= 35){ 
                    willBuy = true;
                } 
                else { 
                    willBuy = false;
                }
            } else if (temperature > 65){ 
                if(buyIndex >= 50){
                    willBuy = true; 
                } 
                else { 
                    willBuy = false;
                }
            }
            return willBuy;
        }

    }
}
