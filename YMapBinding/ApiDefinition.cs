using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;

namespace YMapBinding
{
    [BaseType (typeof (NSObject))]
    public partial interface YMKAnnotation {

        [Export ("coordinate")]
        CLLocationCoordinate2D Coordinate { get; set; }

        [Export ("title")]
        string Title { get; }

        [Export ("subtitle")]
        string Subtitle { get; }
    }

    [BaseType (typeof (YMKAnnotation))]
    public partial interface YMKOverlay : YMKAnnotation {

//        [Export ("coordinate")]
//        CLLocationCoordinate2D Coordinate { get; }

        [Export ("boundingMapRect")]
        YMKMapRect BoundingMapRect { get; }

        [Export ("intersectsMapRect:")]
        bool IntersectsMapRect (YMKMapRect mapRect);
    }

    [BaseType (typeof (YMKOverlay))]
    public partial interface YMKWeatherOverlay : YMKOverlay {

//        [Export ("coordinate")]
//        CLLocationCoordinate2D Coordinate { get; }
//
//        [Export ("boundingMapRect")]
//        YMKMapRect BoundingMapRect { get; }

//        [Export ("init")]
//        IntPtr Constructor ();

//        [Export ("intersectsMapRect:")]
//        bool IntersectsMapRect (YMKMapRect mapRect);
    }

    [BaseType (typeof (UIView),
        Delegates=new string [] {"WeakDelegate"}, 
        Events=new Type [] { typeof (YMKMapViewDelegate) })]
    public partial interface YMKMapView {
        [Export ("initWithFrame:appid:")]
        IntPtr Constructor (RectangleF frame, string appid);

        [Export ("centerCoordinate")]
        CLLocationCoordinate2D CenterCoordinate { get; set; }

        [Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
        NSObject WeakDelegate { get; set; }

        [Wrap ("WeakDelegate")][NullAllowed]
        YMKMapViewDelegate Delegate { get; set; }

        [Export ("addOverlay:")]
        void AddOverlay (YMKOverlay overlay);
    }

    public class RegionDidChangeAnimatedEventArgs
    {
        public RegionDidChangeAnimatedEventArgs (bool animated)
        {
            this.Animated = animated;
        }
        public bool Animated { get; set; }
    }

    [Model, BaseType (typeof (NSObject))]
    public partial interface YMKMapViewDelegate {
       
        [Export ("mapView:regionDidChangeAnimated:"), EventArgs ("RegionDidChangeAnimated"), ]
        void RegionDidChangeAnimated (YMKMapView sender, bool animated);

        [Export ("mapView:viewForOverlay:"), DelegateName ("ViewForOverlay"), DefaultValue(null)]
        YMKOverlayView ViewForOverlay (YMKMapView mapView, YMKOverlay overlay);

    }


    [BaseType (typeof (UIView))]
    public partial interface YMKOverlayView {

        [Export ("initWithOverlay:")]
        IntPtr Constructor (YMKOverlay overlay);

        [Export ("overlay")]
        YMKOverlay Overlay { get; }

        [Export ("pointForMapPoint:")]
        PointF PointForMapPoint (YMKMapPoint mapPoint);

        [Export ("mapPointForPoint:")]
        YMKMapPoint MapPointForPoint (PointF point);

        [Export ("rectForMapRect:")]
        RectangleF RectForMapRect (YMKMapRect mapRect);

        [Export ("mapRectForRect:")]
        YMKMapRect MapRectForRect (RectangleF rect);

//        [Export ("canDrawMapRect:zoomScale:")]
//        bool CanDrawMapRect (YMKMapRect mapRect, YMKZoomScale zoomScale);
//
//        [Export ("drawMapRect:zoomScale:inContext:")]
//        void DrawMapRect (YMKMapRect mapRect, YMKZoomScale zoomScale, CGContext context);
//
//        [Export ("needsDisplayInMapRect"), Verify ("ObjC method massaged into setter property", "/Users/hrnv/Downloads/201401/mapsdk_ios/YMap/YMapKit.framework/Headers/YMKOverlayView.h", Line = 33)]
//        YMKMapRect NeedsDisplayInMapRect { set; }
//
//        [Export ("setNeedsDisplayInMapRect:zoomScale:")]
//        void SetNeedsDisplayInMapRect (YMKMapRect mapRect, YMKZoomScale zoomScale);
    }

    [BaseType (typeof (YMKOverlayView))]
    public partial interface YMKTileOverlayView {

        [Export ("nowZLevel")]
        int NowZLevel { get; }

        [Export ("initWithFrame:")]
        IntPtr Constructor (RectangleF frame);

        [Export ("updateTileX:tileY:tileZ:tileRect:")]
        void UpdateTileX (int x, int y, int z, RectangleF rect);

        [Export ("changeZLevel:")]
        void ChangeZLevel (int z);
    }

    [BaseType (typeof (YMKTileOverlayView))]
    public partial interface YMKWeatherOverlayView {

        [Export ("nowDate", ArgumentSemantic.Assign)]
        NSDate NowDate { get; }

//        [Export ("delegate", ArgumentSemantic.Assign)]
//        YMKWeatherOverlayDelegate Delegate { get; set; }

        [Export ("initWithOverlay:")]
        IntPtr Constructor (YMKWeatherOverlay overlay);

//        [Export ("initWithWeatherOverlay:")]
//        IntPtr Constructor (YMKWeatherOverlay overlay);

        [Export ("updateWeatherWithMinutes:")]
        void UpdateWeatherWithMinutes (int minutes);

        [Export ("updateWeather")]
        void UpdateWeather ();

        [Export ("startAutoUpdate")]
        void StartAutoUpdate ();

        [Export ("startAutoUpdateWithInterval:")]
        void StartAutoUpdateWithInterval (int minutes);

        [Export ("stopAutoUpdate")]
        void StopAutoUpdate ();
    }



//    [BaseType (typeof (NSObject))]
//    [Model][Protocol]
//    interface UIAccelerometerDelegate {
//        [Export ("accelerometer:didAccelerate:")]
//        void DidAccelerate (UIAccelerometer accelerometer, UIAcceleration acceleration);
//    }

}

