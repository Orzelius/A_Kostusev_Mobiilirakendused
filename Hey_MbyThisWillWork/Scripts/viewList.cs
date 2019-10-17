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
    public class viewList : Activity {
        ListView _listView;
        private ListView InfoListView;
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.listviewView);
            Random rnd = new Random();


            //var items = new string[] { "üks", "kaks", "kolm", "neli" };
            var items = new List<Car>();

            for (int x = 0; x < rnd.Next(20, 40); x++) {
                items.Add(
                    new Car() { Model= Faker.Name.Last(), 
                        FuelUsage = rnd.Next(2,10), Color = Faker.Name.First(), ReleaseYear = rnd.Next(1940,2040)});
            }

            var ListAdapter = new BasicAdapter(this, items);

            InfoListView = (ListView)FindViewById(Resource.Id.demolist);

            _listView = FindViewById<ListView>(Resource.Id.listView1);
            //listView.Adapter = ListAdapter;
            _listView.Adapter = ListAdapter;
        }

        private void InfoListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e) {
            throw new NotImplementedException();
        }
    }
}