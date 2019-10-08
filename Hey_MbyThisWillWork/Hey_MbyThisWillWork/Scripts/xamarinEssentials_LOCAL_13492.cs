using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Graphics.Drawables;
using Android.Widget;
using Xamarin.Essentials;

namespace Hey_MbyThisWillWork.Scripts {


    [Activity(Label = "xamarinEssentials")]
    public class xamarinEssentials : Activity {

        LinearLayout rl;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.xamarin_essentials);

            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
            Accelerometer.Start(SensorSpeed.Game);

            rl = (LinearLayout)FindViewById(Resource.Id.backgorund);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
        }

        protected override void OnStop() {
            base.OnStop();

            Accelerometer.Stop();
        }

        private void Accelerometer_ShakeDetected(object sender, EventArgs e) {
            Random randonGen = new Random();
            rl.SetBackgroundColor(Android.Graphics.Color.Argb(randonGen.Next(255), randonGen.Next(255), randonGen.Next(255), randonGen.Next(255)));
            //ColorConverters.FromHsl(randonGen.Next(255), randonGen.Next(255), randonGen.Next(255));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}