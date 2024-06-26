﻿using System.ComponentModel;
using System.Diagnostics;
using static UnweWeatherApp.WeatherData;

namespace UnweWeatherApp
{
    public partial class MainPage : ContentPage
    {
        OpenWeatherService _openWeatherService;
        
        private List<List> forecastData {  get; set; }

        

        public MainPage()
        {
            InitializeComponent();
            _openWeatherService = new OpenWeatherService();
            forecastData = new List<List>();
            InitalRender();
        }

        private async Task InitalRender()
        {
            await GetWeatherWithGeoLocation();
            await GetForecastData();
            
        }
        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={_cityEntry.Text}";
            requestUri += "&units=metric";
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }

        string GenerateRequestUriGeo(string endpoint, double lati, double longt)
        {
            string requestUri = endpoint;
            requestUri += $"?lat={lati}";
            requestUri += $"&lon={longt}";
            requestUri += "&units=metric";
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }


        public async void OnGetWeatherButtonClicked(object sender, EventArgs e)
        {
            var location = await Geolocation.GetLocationAsync();

            if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
            {

                WeatherData weatherData = await _openWeatherService.GetWeatherData(GenerateRequestUri(Constants.OpenWeatherMapEndpoint));

                weatherData.weather[0].icon = ("http://openweathermap.org/img/wn/" + weatherData.weather[0].icon + ".png");

                BindingContext = weatherData;
            }

            else if (string.IsNullOrWhiteSpace(_cityEntry.Text))
            {
                GetWeatherWithGeoLocation();

            }
        }
        public async Task GetWeatherWithGeoLocation()
        {
            var location = await Geolocation.GetLocationAsync();
            if (location != null)
            {
                var lat = location.Latitude;
                var lon = location.Longitude;
                WeatherData weatherData = await _openWeatherService.GetWeatherData(GenerateRequestUriGeo(Constants.OpenWeatherMapEndpoint, lat, lon));
                weatherData.weather[0].icon = "http://openweathermap.org/img/wn/" + weatherData.weather[0].icon + ".png";
                BindingContext = weatherData;
            }
       
        }
        public async Task GetForecastData()
        {
            var location = await Geolocation.GetLocationAsync();

            if (location != null)
            {
                var lat = location.Latitude;
                var lon = location.Longitude;
                forecastData = await _openWeatherService.GetForecastData(GenerateRequestUriGeo(Constants.OpenWeatherMapGeo, lat, lon));

                foreach (var row in forecastData)
                {
                    string formattedDate = row.dt_txt.ToLocalTime().ToString("dd.MM");
                    row.FormattedDate = formattedDate;
                    string formattedTime = row.dt_txt.ToLocalTime().ToString("HH:mm");
                    row.FormattedTime = formattedTime;
                }
                forecastDataList.ItemsSource = forecastData;
            }
        }
    }

}
