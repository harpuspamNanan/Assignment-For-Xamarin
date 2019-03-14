using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace AssignmentForXamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView TvPrice, TvQuantity, TvTotal, TvFinal;
        SeekBar SbPrice, SbQuantity;
        RadioButton rbBtn5, rdBtn10, rdBtn15;

        double total, finalPrice;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            TvPrice = (TextView)FindViewById(Resource.Id.priceInputTV);
            TvQuantity = (TextView)FindViewById(Resource.Id.quantityInputTV);
            TvTotal = (TextView)FindViewById(Resource.Id.totalInputTV);
            TvFinal = (TextView)FindViewById(Resource.Id.finalInputTV);
            SbPrice = (SeekBar)FindViewById(Resource.Id.priceSeekBar);
            SbQuantity = (SeekBar)FindViewById(Resource.Id.quantitySeekBar);
            rbBtn5 = (RadioButton)FindViewById(Resource.Id.fivePerRdBtn);
            rdBtn10 = (RadioButton)FindViewById(Resource.Id.tenPerRdBtn);
            rdBtn15 = (RadioButton)FindViewById(Resource.Id.fifteenPerRdBtn);

            SbPrice.ProgressChanged += delegate {
                TvPrice.Text = SbPrice.Progress.ToString();
            };

            SbQuantity.ProgressChanged += delegate {
                TvQuantity.Text = SbQuantity.Progress.ToString();
            };


            TvTotal.Click += delegate
            {
                if (rbBtn5.Checked)
                    total = (SbPrice.Progress * SbQuantity.Progress) - ((SbPrice.Progress * SbQuantity.Progress) * 0.05);                    

                else if (rdBtn10.Checked)
                    total = (SbPrice.Progress * SbQuantity.Progress) - ((SbPrice.Progress * SbQuantity.Progress) * 0.10);                

                else if (rdBtn15.Checked)
                    total = (SbPrice.Progress * SbQuantity.Progress) - ((SbPrice.Progress * SbQuantity.Progress) * 0.15);


                TvTotal.Text = total.ToString();
                finalPrice = total + (0.13 * total);
                TvFinal.Text = TvFinal.ToString();
            };

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

