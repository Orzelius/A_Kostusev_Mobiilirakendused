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

using Microsoft.CSharp.RuntimeBinder;

namespace Hey_MbyThisWillWork.Scripts {
    [Activity(Label = "viewList")]
    public class viewListWeather : Activity {
        ListView _listView;
        private ListView InfoListView;
        protected override async void  OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.listviewViewWeather);
            Random rnd = new Random();


            //var items = new string[] { "üks", "kaks", "kolm", "neli" };
            string query = "https://www.metaweather.com/api/location/44418/";

            var result = await SecondProject.Core.DataService.GetDataService(query);
            var weather = result as SecondProject.Core.WeatherInfo;


            var ListAdapter = new BasicWeatherAdapter(this, weather);

            InfoListView = (ListView)FindViewById(Resource.Id.demolist);

            _listView = FindViewById<ListView>(Resource.Id.listView1);
            _listView.Adapter = ListAdapter;
        }

        private void InfoListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e) {
            throw new NotImplementedException();
        }
    }
}