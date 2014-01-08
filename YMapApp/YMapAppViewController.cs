using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using YMapBinding;
using MonoTouch.CoreLocation;

namespace YMapApp
{
    public partial class YMapAppViewController : UIViewController
    {
        public YMapAppViewController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();
            
            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            var v = new YMKMapView(new RectangleF(0f, 0f, 320f, 320f), 
                "dj0zaiZpPWR2b2IyRmRsRzdrMSZzPWNvbnN1bWVyc2VjcmV0Jng9MzU-");

            v.CenterCoordinate = new CLLocationCoordinate2D(35.180188, 136.906565); 
            v.RegionDidChangeAnimated += (sender, e) => this.InvokeOnMainThread(() => 
            {
                new UIAlertView("RegionDidChange", "", null, "Close", null).Show();
            });

            v.Delegate = new MyYMKMapViewDelegate();

            var weartherOvr = new YMKWeatherOverlay();
            v.AddOverlay(weartherOvr);

            this.View.AddSubview(v);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }
}

