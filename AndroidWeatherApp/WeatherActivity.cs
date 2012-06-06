using System;
using Android.App;
using Android.Widget;
using Android.OS;
using WeatherCore;

namespace AndroidWeatherApp
{
    [Activity(Label = "AndroidWeatherApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class WeatherActivity : Activity
    {
        private WeatherService _weatherService;
        private TextView _temperature;
        private TextView _conditions;
        private TextView _zipCode;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            _zipCode = FindViewById<TextView>(Resource.Id.ZipCode);
            _temperature = FindViewById<TextView>(Resource.Id.Temperature);
            _conditions = FindViewById<TextView>(Resource.Id.Conditions);

            _weatherService = new WeatherService();

            FindViewById<Button>(Resource.Id.CheckWeather).Click += checkWeather;
        }

        private void checkWeather(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty (_zipCode.Text))
			{
				var builder = new AlertDialog.Builder (this);
				
				builder.SetTitle ("Error");
				builder.SetMessage ("Please enter a zip code");
				
				builder.Show ();
				
				return;
			}
			
            _weatherService.GetWeather(_zipCode.Text, weather => {
           		RunOnUiThread(() =>
				{
					_temperature.Text = weather.Temperature.ToString();
					_conditions.Text = weather.Description;
				});
           });
        }
    }
}

