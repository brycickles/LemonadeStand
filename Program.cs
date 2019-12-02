using LemonadeStand_3DayStarter.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void ShowWeather(WeatherAPI weatherapi)
        {

        }



        static void Main(string[] args)
        {
            Game game = new Game();
            game.RunGame();

           
           
            

        }
    }
}
