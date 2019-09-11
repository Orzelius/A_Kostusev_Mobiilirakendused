using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Hey_MbyThisWillWork {
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity {

        DataTable dt;
        EditText editText;
        TextView textView;
        TextView errorTextView;
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            dt = new DataTable();
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SecondLayout);
            textView = (TextView)FindViewById(Resource.Id.textView1);
            editText = (EditText)FindViewById(Resource.Id.editText1);
            errorTextView = (TextView)FindViewById(Resource.Id.errorText);
            errorTextView.Text = "";

            editText.TextChanged += EditText_TextChanged;
        }

        private void EditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            try
            {
                string solution = dt.Compute(editText.Text.ToString(), "").ToString();
                textView.Text = "=" + solution;
                errorTextView.Text = "";
                textView.SetTextColor(Android.Graphics.Color.Black);
            }
            catch (Exception ex)
            {
                textView.SetTextColor(Android.Graphics.Color.Gray);
                errorTextView.Text = "Invalid syntax: " + ex.Message;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            dt.Dispose();
        }
    }
}