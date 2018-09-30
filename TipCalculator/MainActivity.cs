using System;
using System.Globalization;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using String = Java.Lang.String;

namespace TipCalculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText _amountInput;
        private Button _calculateBtn;
        private TextView _tipText;
        private TextView _totalText;

        protected override void OnCreate(Bundle savedInstanceState) 
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.tip_calc_activity);

            _amountInput = FindViewById<EditText>(Resource.Id.amountInput);
            _calculateBtn = FindViewById<Button>(Resource.Id.calculateButton);
            _tipText = FindViewById<TextView>(Resource.Id.tipValueText);
            _totalText = FindViewById<TextView>(Resource.Id.totalValueText);

            _calculateBtn.Click += OnCalculateBtnClick;
        }

        private void OnCalculateBtnClick(object sender, EventArgs e)
        {
            if (!decimal.TryParse(_amountInput.Text, NumberStyles.AllowDecimalPoint, new NumberFormatInfo(), out var amount))
                return;

            var tip = amount * 0.15m;
            var total = amount + tip;

            _tipText.Text = $"{tip:C}";
            _totalText.Text = $"{total:C}";
        }
    }
}

