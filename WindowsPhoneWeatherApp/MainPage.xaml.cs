using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.Phone.Controls;
using WeatherCore;

namespace WindowsPhoneWeatherApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        private WeatherService _weatherService;

        public MainPage()
        {
            InitializeComponent();

            _weatherService = new WeatherService();
        }

        private void CheckWeather_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ZipCode.Text))
            {
                MessageBox.Show("Please enter a zip code");

                return;
            }

            _weatherService.GetWeather(ZipCode.Text, weather =>
            {
                Dispatcher.BeginInvoke(() => 
                {
                    Temperature.Text =
                        weather.Temperature.ToString();
                    Conditions.Text = weather.Description;
                });
            });
        }
    }
}