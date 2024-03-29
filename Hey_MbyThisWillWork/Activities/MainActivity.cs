﻿using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Hey_MbyThisWillWork.Scripts;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace Hey_MbyThisWillWork
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {


        Button calculatorButton;
        Button xamarimEssentialsButton;
        Button WeatherBtn;
        Button[] colorButtons = new Button[4];
        Button[] relativeColorButtons = new Button[4];

        protected override void OnCreate(Bundle savedInstanceState)
        {
            AppCenter.Start("1b20a55e-39c6-4f45-843f-39a646500207",
                       typeof(Analytics), typeof(Crashes));

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            calculatorButton = (Button)FindViewById(Resource.Id.calculator);
            xamarimEssentialsButton = (Button)FindViewById(Resource.Id.xamarinEssentialsBtn);
            WeatherBtn = (Button)FindViewById(Resource.Id.WeatherBtn);


            colorButtons[0] = (Button)FindViewById(Resource.Id.activities_button0);
            colorButtons[1] = (Button)FindViewById(Resource.Id.activities_button1);
            colorButtons[2] = (Button)FindViewById(Resource.Id.activities_button2);
            colorButtons[3] = (Button)FindViewById(Resource.Id.activities_button3);

            relativeColorButtons[0] = (Button)FindViewById(Resource.Id.relative_activities_button0);
            relativeColorButtons[1] = (Button)FindViewById(Resource.Id.relative_activities_button1);
            relativeColorButtons[2] = (Button)FindViewById(Resource.Id.relative_activities_button2);

            relativeColorButtons[0].Click += Relative_Click0;
            relativeColorButtons[1].Click += Relative_Click1;
            relativeColorButtons[2].Click += Relative_Click2;

            colorButtons[0].Click += ColorButtonClick0;
            colorButtons[1].Click += ColorButtonClick1;
            colorButtons[2].Click += ColorButtonClick2;
            colorButtons[3].Click += ColorButtonClick3;

            calculatorButton.Click += CalculatorButton_Click;
            xamarimEssentialsButton.Click += XamarimEssentialsButton_Click;
            WeatherBtn.Click += WeatherBtn_Click;
        }

        private void WeatherBtn_Click(object sender, EventArgs e) {
            StartActivity(typeof(ViewListWeatherActivity));
        }

        private void XamarimEssentialsButton_Click(object sender, EventArgs e) {
            StartActivity(typeof(XamarinEssentialsActivity));
        }

        private void Relative_Click2(object sender, EventArgs e) {
            StartActivity(typeof(Rel2));
        }

        private void Relative_Click1(object sender, EventArgs e) {
            StartActivity(typeof(Rel1));
        }

        private void Relative_Click0(object sender, EventArgs e) {
            StartActivity(typeof(Rel0));
        }

        private void ColorButtonClick3(object sender, EventArgs e)
        {
            StartActivity(typeof(Color3));
        }

        private void ColorButtonClick2(object sender, EventArgs e)
        {
            StartActivity(typeof(Color2));
        }

        private void ColorButtonClick1(object sender, EventArgs e)
        {
            StartActivity(typeof(Color1));
        }

        private void ColorButtonClick0(object sender, EventArgs e)
        {
            StartActivity(typeof(Color0));
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

