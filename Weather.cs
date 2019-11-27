using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Weather
    {
        // member variables
        public string condition;
        public int actualTemperature;
        private Random random; //used throughout


        // constructor
        public Weather()
        {
            random = new Random();
            GenerateTemp();
            GenerateWeather();
        }

        // member methods
        public void GenerateTemp()
        {
            int temperature = 75;
            actualTemperature = random.Next(temperature - 10, temperature + 11); //generates a value between 65 and 85 for weather  
        }
        public void GenerateWeather()
        {
            int el = 0;
            List<string> weatherConditions = new List<string>();
            weatherConditions.Add("rainy");
            weatherConditions.Add("cloudy");
            weatherConditions.Add("sunny");

            el = random.Next(0, 3); //test to make sure this is correct.I want range from 0 to 2 not between 0 and 2. Will return cloudy only when i run this if im wrong
            condition = weatherConditions[el];
        }


    }
}
