using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Customer
    {
         
        List<string> names;
        private string name;

        private double money; 

        

        public void PayMoneyForItems(double transactionAmount)
        {
            money -= transactionAmount;
        }

        public Customer()
        {
            names = new List<string>();

            money = 100.00; //i swear if you figure out a way to exceed 100 in individual sales...           
            names.Add("Wallace");
            names.Add("Bill");
            names.Add("Doreen");
            names.Add("Kathy");
            names.Add("Slagathor");
            names.Add("Gadnuk, Breaker of Worlds");
            names.Add("Ash Ketchup");
            names.Add("Steven");
            names.Add("Aerro");
            names.Add("Billiam");
            names.Add("William");
            names.Add("Sweetthang");
            names.Add("Bryce");
            names.Add("Tyler");
            names.Add("Abigale");
            names.Add("LeShandra");
            names.Add("Curtis");
            names.Add("Monique");
            names.Add("Preston");
            names.Add("Emily");
            names.Add("Anna");
            names.Add("Jordyn");
            names.Add("Jordin");
            names.Add("Jordan");


        }

    }
}
