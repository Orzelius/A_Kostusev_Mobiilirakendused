using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;

using Microsoft.CSharp.RuntimeBinder;

namespace Hey_MbyThisWillWork.Scripts {
    [Activity(Label = "viewList")]
    public class ViewListWeatherActivity : Activity {
        GridView parentView;
        Button search;
        EditText textView;
        SecondProject.Core.WeatherInfo weather;


        protected override void  OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.listviewViewWeather);
            Random rnd = new Random();
            search = (Button)FindViewById(Resource.Id.Search);
            textView = (EditText)FindViewById(Resource.Id.editText1);

            textView.EditorAction += (sender, e) => {
                if (e.ActionId == ImeAction.Send) {
                    search.PerformClick();
                }
                else {
                    e.Handled = false;
                }
            };

            textView.Click += TextView_Click;
            search.Click += Search_Click;
        }

        private void ParentView_ItemClick(object sender, AdapterView.ItemClickEventArgs e) {
            Toast.MakeText(Application.Context, e.Position.ToString() + " was clicked on", ToastLength.Long).Show();

            var weatherDetail = weather.consolidated_weather[e.Position];
        }

        private void Search_Click(object sender, EventArgs e) {
            setAdapter(textView.Text);
        }

        private void TextView_Click(object sender, EventArgs e) {
            textView.Text = "";
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
            weather = result as SecondProject.Core.WeatherInfo;


            var ListAdapter = new BasicWeatherAdapter(this, weather);

            parentView = FindViewById<GridView>(Resource.Id.parentView);
            parentView.Adapter = ListAdapter;

            parentView.ItemClick += ParentView_ItemClick;
        }
    }
}