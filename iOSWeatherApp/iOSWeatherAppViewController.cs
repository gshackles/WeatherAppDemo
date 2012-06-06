using MonoTouch.Foundation;
using MonoTouch.UIKit;
using WeatherCore;

namespace IOSWeatherApp
{
	public partial class IOSWeatherAppViewController : UIViewController
	{
		private WeatherService _weatherService;
		
		public IOSWeatherAppViewController() : base ("IOSWeatherAppViewController", null)
		{
			_weatherService = new WeatherService ();
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();
		}
		
		partial void CheckWeather(NSObject sender)
		{
			ZipCode.ResignFirstResponder ();
			
			if (string.IsNullOrEmpty (ZipCode.Text))
			{
				var alert = new UIAlertView("Error", "Please enter a zip code", null, "Ok", null);
				alert.Show ();
				
				return;
			}
			
			_weatherService.GetWeather(ZipCode.Text, weather => {
				InvokeOnMainThread(() => {
					Temperature.Text = weather.Temperature.ToString();
					Conditions.Text = weather.Description;
				});
			});
		}
	}
}

