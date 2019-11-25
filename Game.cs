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
        Player player;
        Store store;


        // constructor
        public Game()
        {
            //objects now come preinitialized
            store = new Store();
            player = new Player();
            days = new List<Day>();
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
            //turn it to int currentday
            foreach(var currentDay in days)
            {
                int counter = 1; 
                currentDay.Welcome(player.wallet, player.inventory, counter);
                counter++;
                store.DisplayStore();
            }

        }
    }
}
