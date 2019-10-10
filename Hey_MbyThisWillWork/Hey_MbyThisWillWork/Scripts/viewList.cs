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
    [Activity(Label = "viewList")]
    public class viewList : ListActivity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            //var items = new string[] { "üks", "kaks", "kolm", "neli" };
            var items = new List<WeatherInfo>() {
                new WeatherInfo() { Name = "Esmaspäev", Temperature="Hot", windspeed="Stronk"},
                new WeatherInfo() { Name = "Teisipäev", Temperature="Ugh", windspeed="Week"},
                new WeatherInfo() { Name = "Kolmapäev", Temperature="Uff", windspeed="Medium"},
                new WeatherInfo() { Name = "Neljapäev", Temperature="Hot", windspeed="Very Stronk"},
                new WeatherInfo() { Name = "Reede", Temperature="Noicc", windspeed="Stronk"},
                new WeatherInfo() { Name = "Laupäev", Temperature="Moist", windspeed="AAAAAAAAAAA"},
                new WeatherInfo() { Name = "Pühapäev", Temperature="Cold", windspeed="Oyyy"}
            };

            ListAdapter = new BasicAdapter(this, items);

            ListView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args) {
                Toast.MakeText(Application, ((TextView)args.View).Text, ToastLength.Short).Show();
            };

            ListView.ItemClick += ListView_ItemClick;

            // Create your application here
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e) {
            throw new NotImplementedException();
        }
    }
}