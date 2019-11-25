using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Player
    {
        private string name;
        // member variables (HAS A)
        public Inventory inventory;
        public Wallet wallet;
        public Recipe recipe;
        public Pitcher pitcher; 

        // constructor (SPAWNER)
        public Player()
        {
            pitcher = new Pitcher();
            inventory = new Inventory();
            wallet = new Wallet();
            recipe = new Recipe();
        }

        // member methods (CAN DO)
    }
}
