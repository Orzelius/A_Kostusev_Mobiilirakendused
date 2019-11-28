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

namespace Hey_MbyThisWillWork.Activities {
    [Activity(Label = "WeatherDetailActivity")]
    public class WeatherDetailActivity : Activity {

        public SecondProject.Core.WeatherInfo weather { get; set; }
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.WeatherDetailLayout);
            // Create your application here
        }
    }
}