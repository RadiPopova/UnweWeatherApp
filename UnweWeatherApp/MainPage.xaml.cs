namespace UnweWeatherApp
{
    public partial class MainPage : ContentPage
    {
        OpenWeatherService _openWeatherService;


        public MainPage()
        {
            InitializeComponent();
            _openWeatherService = new OpenWeatherService();
            GetWeatherWithGeoLocation();

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
            if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
            {
                WeatherData weatherData = await _openWeatherService.GetWeatherData(GenerateRequestUri(Constants.OpenWeatherMapEndpoint));
                //Image image = new Image
                //{
                //    Source = ImageSource.FromUri(new Uri(("https://openweathermap.org/img/wn/" + weatherData.weather[0].icon + ".png")))
                //};
                weatherData.weather[0].icon = ("http://openweathermap.org/img/wn/" + weatherData.weather[0].icon + ".png");
                BindingContext = weatherData;
            }
        }
        public async void GetWeatherWithGeoLocation()
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




    }
}