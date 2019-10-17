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
using Java.Lang;

namespace Hey_MbyThisWillWork.Scripts {

    class BasicAdapter : BaseAdapter<Car> {

        List<Car> _items;
        Activity _context;
        int _listItem = Resource.Id.infoBar;

        public BasicAdapter(Activity context, List<Car> items) : base() {
            this._context = context;
            this._items = items;
        }


        public override Car this[int position] {
            get { return _items[position]; }
        }

        public override int Count {
            get { return _items.Count; }
        }

        public override long GetItemId(int position) {
            throw new NotImplementedException();
        }

        //public override int Count => throw new NotImplementedException();



        //public override long GetItemId(int position) {
        //    throw new NotImplementedException();
        //}

        public override View GetView(int position, View convertView, ViewGroup parent) {
            View view = convertView;
            if(view == null) {
                view = _context.LayoutInflater.Inflate(Resource.Layout.listRow, null);
            }
            view.FindViewById<TextView>(Resource.Id.textView1).Text = _items[position].Model;
            view.FindViewById<TextView>(Resource.Id.textView2).Text = _items[position].ReleaseYear.ToString();
            view.FindViewById<TextView>(Resource.Id.textView3).Text = _items[position].Color;
            view.FindViewById<TextView>(Resource.Id.textView4).Text = _items[position].FuelUsage.ToString();
            return view;
        }
    }
}