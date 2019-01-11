using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;
using Xam_Imiev;
using Xam_Imiev.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EntryText), typeof(EntryTextiOS))]
namespace Xam_Imiev.iOS
{
    public class EntryTextiOS: EntryRenderer
    {
        protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged (e);

            if (Control != null)
            {
                Control.Layer.CornerRadius = 20;
                Control.Layer.BorderWidth = 3f;
                Control.Layer.BorderColor = Color.DeepPink.ToCGColor();
                Control.Layer.BackgroundColor = Color.LightGray.ToCGColor();

                Control.LeftView = new UIKit.UIView(new CGRect (0, 0, 10, 0));
                //Control.Layer.LeftViewMode = UIKit.UITextFieldViewMode.Always;
            }
        }
    }
}