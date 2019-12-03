using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace Hey_MbyThisWillWork.Activities {
    [Activity(Label = "WeatherDetailActibity")]
    public class WeatherDetailActivity : Activity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.WeatherDetailLayout);

            // Create your application here
            var maxTemp = FindViewById<TextView>(Resource.Id.maxTemp);
            var minTemp = FindViewById<TextView>(Resource.Id.minTemp);
            var windDir = FindViewById<TextView>(Resource.Id.windDirection);
            var windSpeed = FindViewById<TextView>(Resource.Id.windSpeed);
            var Title = FindViewById<TextView>(Resource.Id.Title);


            var WeatherDetails = JsonConvert.DeserializeObject<SecondProject.Core.ConsolidatedWeather>(Intent.GetStringExtra("weatherDetails"));
            DateTime oDate = Convert.ToDateTime(WeatherDetails.applicable_date);

            maxTemp.Text = WeatherDetails.max_temp.ToString();
            minTemp.Text = WeatherDetails.min_temp.ToString();
            windDir.Text = WeatherDetails.wind_direction_compass;
            Title.Text = oDate.ToString("MMM dd dddd");
        }
    }
}