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

			var arV = new YARKViewController();
            
			var v = new YMKMapView(new RectangleF(new PointF(0f, 0f), this.View.Frame.Size), 
				        "dj0zaiZpPWR2b2IyRmRsRzdrMSZzPWNvbnN1bWVyc2VjcmV0Jng9MzU-");

//            v.CenterCoordinate = new CLLocationCoordinate2D(35.180188, 136.906565); 
			v.CenterCoordinate = new CLLocationCoordinate2D(35.6657214, 139.7310058); 
//            v.RegionDidChangeAnimated += (sender, e) => this.InvokeOnMainThread(() => 
//            {
//                new UIAlertView("RegionDidChange", "", null, "Close", null).Show();
//            });

//            v.Delegate = new MyYMKMapViewDelegate();
			v.Delegate = new YMKRelayMapViewDelegate((_, ovr) => new YMKRouteOverlayView(ovr as YMKRouteOverlay));

//            var weartherOvr = new YMKWeatherOverlay();
//            v.AddOverlay(weartherOvr);

			this.View.AddSubview(v);

//			var annotation = new MyAnnotation(new CLLocationCoordinate2D(35.180188, 136.906565), "たいとる", "サブタイトル");
//			v.AddAnnotation(annotation);
////			v.AddAnnotation(null);

			var routeOvr = new YMKRouteOverlay("dj0zaiZpPWR2b2IyRmRsRzdrMSZzPWNvbnN1bWVyc2VjcmV0Jng9MzU-");
//            routeOvr.Delegate = new MyRouteOverlayDelegate(v);
			routeOvr.Delegate = new YMKRelayRouteOverlayDelegate(ovr =>
			{
				v.AddOverlay(ovr);
				var naviCon = new YMKNaviController(ovr);
				naviCon.MapView = v;
//					naviCon.Delegate = new YMKRelayNaviControllerDelegate(

				naviCon.Start();

				var arViewCon = new YARKViewController();
				naviCon.ARKViewController = arViewCon;

			});
			routeOvr.StartTitle = "東京ミッドタウン";
			routeOvr.GoalTitle = "東京タワー";
			routeOvr.SetRouteStartPos(new CLLocationCoordinate2D(35.6657214, 139.7310058), new CLLocationCoordinate2D(35.6586308, 139.7454106), TrafficType.TRAFFIC_CAR);
			routeOvr.Search();


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

