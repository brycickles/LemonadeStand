
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Program
    {

        public static async void LoadTempInfo()
        {

            var tempInfo = await TempProcessor.LoadWeatherInformation();
            Console.WriteLine("Temperature is {0}", tempInfo.temp);
        }
        static void Main(string[] args)
        {
            //LoadTempInfo();
            Game game = new Game();
            game.RunGame();    
        }
    }
}

