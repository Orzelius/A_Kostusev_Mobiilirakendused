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
        Button search;
        EditText textView;



        protected override void  OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.listviewViewWeather);
            Random rnd = new Random();
            search = (Button)FindViewById(Resource.Id.Search);
            textView = (EditText)FindViewById(Resource.Id.editText1);

            textView.Click += TextView_Click;
            search.Click += Search_Click;
        }

        private void Search_Click(object sender, EventArgs e) {
            setAdapter(textView.Text);
        }

        private void TextView_Click(object sender, EventArgs e) {
            textView.Text = "";
        }

        private void InfoListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e) {
            throw new NotImplementedException();
        }

        public async void setAdapter(string location) {
            var locations = await SecondProject.Core.DataService.GetLocation("https://www.metaweather.com/api/location/search/?query=" + location);
            var locationsArr = locations as SecondProject.Core.Location[];

            if(locationsArr.Length == 0) {
                Toast.MakeText(Application.Context, "Error, location not found", ToastLength.Long).Show();
                textView.SelectAll();
                return;
            }

            string query = "https://www.metaweather.com/api/location/" + locationsArr[0].Woeid;

            var result = await SecondProject.Core.DataService.GetDataService(query);
            var weather = result as SecondProject.Core.WeatherInfo;


            var ListAdapter = new BasicWeatherAdapter(this, weather);

            InfoListView = (ListView)FindViewById(Resource.Id.demolist);

            _listView = FindViewById<ListView>(Resource.Id.listView1);
            _listView.Adapter = ListAdapter;
        }
    }
}