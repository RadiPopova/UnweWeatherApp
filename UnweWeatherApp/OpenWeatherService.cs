﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnweWeatherApp;

namespace UnweWeatherApp
{
    public class OpenWeatherService
    {
        HttpClient _httpClient;
       
        public OpenWeatherService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<WeatherData> GetWeatherData(string query)
        {
            WeatherData weatherData = null;
            try
            {
                var response = await _httpClient.GetAsync(query);
                if (response.IsSuccessStatusCode) 
                { 
                    var content = await response.Content.ReadAsStringAsync();
                    weatherData = JsonConvert.DeserializeObject<WeatherData>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
            return weatherData;
        }

        public async Task<List<List>> GetForecastData(string query)
        {
            ForecastData forecastData = null;
            try
            {
                var response = await _httpClient.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    forecastData = JsonConvert.DeserializeObject<ForecastData>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
            return forecastData.list;
        }
    }
}
