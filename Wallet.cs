﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Wallet
    {
        private double money;

        public double Money
        {
            get
            {
                return money;
            }
        }

        public Wallet()
        {
            money = 50.00;
        }

        public void PayMoneyForItems(double transactionAmount)
        {
            money -= transactionAmount;
        }

        public void GetMoney(double transactionAmount){
            money += transactionAmount;
        }
    }
}
