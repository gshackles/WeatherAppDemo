// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace IOSWeatherApp
{
	[Register ("IOSWeatherAppViewController")]
	partial class IOSWeatherAppViewController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel Temperature { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel Conditions { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField ZipCode { get; set; }

		[Action ("CheckWeather:")]
		partial void CheckWeather (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (Temperature != null) {
				Temperature.Dispose ();
				Temperature = null;
			}

			if (Conditions != null) {
				Conditions.Dispose ();
				Conditions = null;
			}

			if (ZipCode != null) {
				ZipCode.Dispose ();
				ZipCode = null;
			}
		}
	}
}
