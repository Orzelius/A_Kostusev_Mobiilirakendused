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
using System.Data;

namespace A_Kostusev_App {
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity {

        DataTable dt;
        EditText editText;
        TextView textView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            dt = new DataTable();
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.second_layout);
            // Create your application here
            textView = FindViewById<TextView>(Resource.Id.textView1);
            editText = FindViewById<EditText>(Resource.Id.editText1);

            editText.TextChanged += EditText_TextChanged;
        }

        private void EditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e) {
            try {
                int solution = Convert.ToInt32(dt.Compute(editText.Text.ToString(), "").ToString());
                editText.Text = "=" + solution;
            }
            catch(Exception ex) {
                editText.Text = "Invalid syntax";
            }
        }

        protected override void Dispose(bool disposing) 
        {
            base.Dispose(disposing);

            dt.Dispose();
        }
    }
}