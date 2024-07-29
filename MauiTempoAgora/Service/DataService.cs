using MauiTempoAgora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace MauiTempoAgora.Service
{
    public class DataService
    {
        public static async Task<Tempo> GetPrevisaoDoTempo(string cidade)
        {
            // https://openweathermap.org/current#current_JSON
            // https://home.openweathermap.org/api_keys
            string appId = "6135072afe7f8cec1537d5cb08a5a1a2";

            string url = $"https://api.openweather.org/data/2.5/weather?1=" +
                         $"{cidade}&unit=metric&appid{appId}";

            Tempo tempo = null;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    var rascunho =  JSObject.Parse(json);

                    DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    DateTime sunrise = time.AddSeconds(double)rascunho["sys"]["sunrise"].ToLocalTime();
                    DateTime sunset = time.AddSeconds(double)rascunho["sys"]["sunrise"].ToLocalTime();
                }
            }

           
        }
        
            
    }
}
