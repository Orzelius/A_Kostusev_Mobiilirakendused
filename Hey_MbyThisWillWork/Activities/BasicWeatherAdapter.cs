using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using SecondProject.Core;

namespace Hey_MbyThisWillWork.Scripts {

    class BasicWeatherAdapter : BaseAdapter<SecondProject.Core.WeatherInfo> {

        SecondProject.Core.WeatherInfo _item;
        Activity _context;

        public BasicWeatherAdapter(Activity context, WeatherInfo item) : base() {
            this._context = context;
            this._item = item;
        }


        public override SecondProject.Core.WeatherInfo this[int position] {
            get { throw new NotImplementedException(); }
        }

        public override int Count {
            get { return _item.consolidated_weather.Count; }
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
            view.FindViewById<TextView>(Resource.Id.textView1).Text = _item.consolidated_weather[position].weather_state_name;
            view.FindViewById<TextView>(Resource.Id.textView2).Text = _item.consolidated_weather[position].wind_direction_compass;
            view.FindViewById<TextView>(Resource.Id.textView3).Text = _item.consolidated_weather[position].max_temp.ToString();
            view.FindViewById<TextView>(Resource.Id.textView4).Text = _item.consolidated_weather[position].min_temp.ToString();
            var drawable = (int)typeof(Resource.Drawable).GetField(
                "file:///android_asset/BMPs/" + _item.consolidated_weather[position].weather_state_abbr + ".btp").GetValue(null);
            view.FindViewById<ImageView>(Resource.Id.svg).SetImageResource(drawable);
            //"file:///android_asset/BMPs/" + _item.consolidated_weather[position].weather_state_abbr + ".btp"
            return view;
        }
    }
}