using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xam_Imiev;
using Xam_Imiev.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryText), typeof(EntryTextAndroid))]
namespace Xam_Imiev.Droid
{
    class EntryTextAndroid : EntryRenderer
    {
        public EntryTextAndroid(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetCornerRadius(10);
                gradientDrawable.SetStroke(1, Android.Graphics.Color.Black);
                gradientDrawable.SetColor(Android.Graphics.Color.White);

                Control.SetBackground(gradientDrawable);
                //Paddinf interno del Entry
                //Control.SetPadding(6, Control.PaddingTop, 6, Control.PaddingBottom);
            }
        }
    }
}