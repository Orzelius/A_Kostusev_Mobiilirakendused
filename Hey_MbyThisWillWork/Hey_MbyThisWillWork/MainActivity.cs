using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Hey_MbyThisWillWork
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        Button calculatorButton;
        Button[] colorButtons;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            calculatorButton = (Button)FindViewById(Resource.Id.calculator);

            
            colorButtons[0] = (Button)FindViewById(Resource.Id.activities_button0);
            colorButtons[1] = (Button)FindViewById(Resource.Id.activities_button1);
            colorButtons[2] = (Button)FindViewById(Resource.Id.activities_button2);
            colorButtons[3] = (Button)FindViewById(Resource.Id.activities_button3);


            colorButtons[0].Click += ColorButtonClick0;
            colorButtons[1].Click += ColorButtonClick1;
            colorButtons[2].Click += ColorButtonClick2;
            colorButtons[3].Click += ColorButtonClick3;
            calculatorButton.Click += CalculatorButton_Click;
        }

        private void ColorButtonClick3(object sender, EventArgs e)
        {
            //StartActivity(typeof());
        }

        private void ColorButtonClick2(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ColorButtonClick1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ColorButtonClick0(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CalculatorButton_Click(object sender, EventArgs e)
        {            
            //throw new NotImplementedException();
            Intent intent = new Intent(this, typeof(SecondActivity));
            //intent.PutExtra("DATA_PASS", txtdatapass.Text); //DATA_PASS is Identify the Value Pass variable  
            this.StartActivity(intent);

            //View view = (View) sender;
            //Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
            //    .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

