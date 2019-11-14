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

namespace Hey_MbyThisWillWork.Scripts {
    class Car {
        public string Model { get; set; }
        public int ReleaseYear { get; set; }
        public float FuelUsage { get; set; }
        public string Color { get; set; }
    }
}