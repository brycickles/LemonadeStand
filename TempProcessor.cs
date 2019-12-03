using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    public class TempProcessor
    {
        public async Task<TempModel> LoadWeatherInformation()
        {
            string url = "https://samples.openweathermap.org/data/2.5/weather?zip=53074,us&appid=b6907d289e10d714a6e88b30761fae22";
            ApiHelper.InitializeClient();
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    TempResultsModel result = await response.Content.ReadAsAsync<TempResultsModel>();

                    return result.Results;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
