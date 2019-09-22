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
using Android.Widget;
using Xamarin.Essentials;

namespace Hey_MbyThisWillWork.Scripts {


    [Activity(Label = "xamarinEssentials")]
    public class xamarinEssentials : Activity {

        LinearLayout rl;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.xamarin_essentials);

            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected; ;
            Accelerometer.Start(SensorSpeed.Default);

            rl = (LinearLayout)FindViewById(Resource.Id.backgorund);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
        }

        private void Accelerometer_ShakeDetected(object sender, EventArgs e) {
            Random randonGen = new Random();
            rl.BackgroundTintList = Color.FromArgb(randonGen.Next(255), randonGen.Next(255),
            randonGen.Next(255));
        }

        static Random rand = new Random();
        public static Color GetRandomColor() {
            int hue = rand.Next(255);
            Color color = Color.HSVToColor(
                new[] {
            hue,
            1.0f,
            1.0f,
                }
            );
            return color;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}