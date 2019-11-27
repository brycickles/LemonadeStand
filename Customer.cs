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
        
        public Customer()
        {
            random = new Random();
            money = 100.00; //i swear if you figure out a way to exceed 100 in individual sales...           

        }

        public void PayMoneyForItems(double transactionAmount)
        {
            money -= transactionAmount;
        }

        public void generatePropensityToBuy(Customer customer, int temperature){
            int buyIndex = 0;
            buyIndex = random.Next(0, 100); 
            if(temperature > 75){ 
                if(buyIndex >= 20){ 
                    customer.willBuy = true;
                } 
                else { 
                    customer.willBuy = false;
                }
            } else if (temperature > 65){ 
                if(buyIndex >= 40){
                    customer.willBuy = true; 
                } 
                else { 
                    customer.willBuy = false;
                }
            }            
        }

    }
}
