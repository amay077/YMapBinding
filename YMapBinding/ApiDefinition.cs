using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;

namespace YMapBinding
{

    #region delegates


    [Model, BaseType (typeof (NSObject))]
    public partial interface YMKMapViewDelegate {

        [Export ("mapView:regionDidChangeAnimated:"), EventArgs ("RegionDidChangeAnimated"), ]
        void RegionDidChangeAnimated (YMKMapView sender, bool animated);

        [Export ("mapView:viewForOverlay:"), DelegateName ("ViewForOverlay"), DefaultValue(null)]
        YMKOverlayView ViewForOverlay (YMKMapView mapView, YMKOverlay overlay);

        //-(YMKAnnotationView *)mapView:(YMKMapView *)mapView viewForAnnotation:(id <YMKAnnotation>)annotation
        [Export ("mapView:viewForAnnotation:"), DelegateName ("ViewForAnnotation"), DefaultValue(null)]
        YMKAnnotationView ViewForAnnotation (YMKMapView mapView, YMKAnnotation annotation);
    }

    [Model, BaseType (typeof (NSObject))]
    public partial interface YMKRouteOverlayDelegate {

        [Export ("finishRouteSearch:")]
        void FinishRouteSearch (YMKRouteOverlay routeOverlay);

        [Export ("errorRouteSearch:withError:")]
        void WithError (YMKRouteOverlay routeOverlay, int error);
    }

    [Model, BaseType (typeof (NSObject))]
    public partial interface YMKNaviControllerDelegate {

        [Export ("naviController:didUpdateUserLocation:")]
        void DidUpdateUserLocation (YMKNaviController naviController, YMKUserLocation userLocation);

        [Export ("naviController:didFailToLocateUserWithError:")]
        void DidFailToLocateUserWithError (YMKNaviController naviController, NSError error);

//        [Export ("naviControllerAccuracyBad:didUpdateUserLocation:")]
//        void DidUpdateUserLocation (YMKNaviController naviController, YMKUserLocation userLocation);
//
//        [Export ("naviControllerRouteOut:didUpdateUserLocation:")]
//        void DidUpdateUserLocation (YMKNaviController naviController, YMKUserLocation userLocation);
//
//        [Export ("naviControllerOnGoal:didUpdateUserLocation:")]
//        void DidUpdateUserLocation (YMKNaviController naviController, YMKUserLocation userLocation);
    }

    #endregion

    #region events

    public class RegionDidChangeAnimatedEventArgs
    {
        public RegionDidChangeAnimatedEventArgs (bool animated)
        {
            this.Animated = animated;
        }
        public bool Animated { get; set; }
    }

    #endregion

	[BaseType (typeof (NSObject))]
	[Model, Protocol]
    public partial interface YMKAnnotation {
        [Export ("coordinate")]
        CLLocationCoordinate2D Coordinate { get; set; }

        [Export ("title")]
        string Title { get; }

        [Export ("subtitle")]
        string Subtitle { get; }
    }

	[BaseType (typeof (YMKAnnotation))]
	public partial interface YMKUserLocation : YMKAnnotation {

//		[Export ("initWithInternal:")]
//		IntPtr Constructor (UserLocationAnnotation usrLocAnnotation);

		[Export ("updating")]
		bool Updating { [Bind ("isUpdating")] get; }

		[Export ("location")]
		CLLocation Location { get; }

//		[Export ("title", ArgumentSemantic.Retain)]
//		string Title { get; set; }
//
//		[Export ("subtitle", ArgumentSemantic.Retain)]
//		string Subtitle { get; set; }
	}


	[BaseType (typeof (YMKAnnotation))]
	[Model, Protocol]
    public partial interface YMKOverlay : YMKAnnotation {

//        [Export ("coordinate")]
//        CLLocationCoordinate2D Coordinate { get; }

        [Export ("boundingMapRect")]
        YMKMapRect BoundingMapRect { get; }

        [Export ("intersectsMapRect:")]
        bool IntersectsMapRect (YMKMapRect mapRect);
    }

    [BaseType (typeof (YMKOverlay))]
	[Model]
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

		[Export ("addAnnotation:")]
		void AddAnnotation (YMKAnnotation annotation);
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

	[BaseType (typeof (NSObject))]
	public partial interface YMKAnnotationView {
        [Export ("initWithAnnotation:reuseIdentifier:")]
        IntPtr Constructor (YMKAnnotation wkannotation, string _reuseIdentifier);

        [Export ("resetAnnotaion")]
        void ResetAnnotaion ();

        [Export ("rotateTransform:")]
        void RotateTransform (double radian);

        [Export ("reuseIdentifier")]
        string ReuseIdentifier { get; }

        [Export ("prepareForReuse")]
        void PrepareForReuse ();

        [Export ("annotation", ArgumentSemantic.Retain)]
        YMKAnnotation Annotation { get; set; }

        [Export ("image", ArgumentSemantic.Retain)]
        UIImage Image { get; set; }

        [Export ("centerOffset")]
        PointF CenterOffset { get; set; }

        [Export ("calloutOffset")]
        PointF CalloutOffset { get; set; }

        [Export ("enabled")]
        bool Enabled { [Bind ("isEnabled")] get; set; }

        [Export ("highlighted")]
        bool Highlighted { [Bind ("isHighlighted")] get; set; }

        [Export ("selected")]
        bool Selected { [Bind ("isSelected")] get; set; }

        [Export ("setSelected:animated:")]
        void SetSelected (bool selected, bool animated);

        [Export ("canShowCallout")]
        bool CanShowCallout { get; set; }

        [Export ("leftCalloutAccessoryView", ArgumentSemantic.Retain)]
        UIView LeftCalloutAccessoryView { get; set; }

        [Export ("rightCalloutAccessoryView", ArgumentSemantic.Retain)]
        UIView RightCalloutAccessoryView { get; set; }

        [Export ("setImageShadow:withCenterOffset:")]
        void SetImageShadow (UIImage imageShadow, PointF offset);

        [Export ("popBackVisible")]
        bool PopBackVisible { get; set; }

        [Export ("mapPoint")]
        YMKMapPoint MapPoint { get; set; }
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

    [BaseType (typeof (YMKOverlay))]
    public partial interface YMKRouteOverlay : YMKOverlay {

        [Export ("distance")]
        float Distance { get; set; }

        [Export ("time")]
        float Time { get; set; }

        [Export ("pointCount")]
        uint PointCount { get; }

        [Export ("nodeInfoCount")]
        uint NodeInfoCount { get; }

//        [Export ("coordinate")]
//        CLLocationCoordinate2D Coordinate { get; }
//
//        [Export ("boundingMapRect")]
//        YMKMapRect BoundingMapRect { get; }

        [Export ("delegate", ArgumentSemantic.Assign)]
        YMKRouteOverlayDelegate Delegate { get; set; }

        [Static, Export ("routeWithYdfXmlString:")]
        YMKRouteOverlay RouteWithYdfXmlString (string ydf);

        [Static, Export ("routeWithYdfJsonString:")]
        YMKRouteOverlay RouteWithYdfJsonString (string ydf);

        [Static, Export ("routeWithYdfJsonString:StartPos:withGoalPos:")]
        YMKRouteOverlay RouteWithYdfJsonString (string ydf, CLLocationCoordinate2D sp, CLLocationCoordinate2D gp);

        [Export ("initWithData:")]
        IntPtr Constructor (NSObject data);

        [Export ("initWithAppid:")]
        IntPtr Constructor (string appid);

        [Export ("setRouteStartPos:withGoalPos:withTraffic:")]
        void SetRouteStartPos (CLLocationCoordinate2D sp, CLLocationCoordinate2D gp, int traffic);

        [Export ("search")]
        bool Search ();

//        [Export ("getRouteNodeInfoWithIndex:")]
//        YMKRouteNodeInfo GetRouteNodeInfoWithIndex (int index);
//
//        [Export ("intersectsMapRect:")]
//        bool IntersectsMapRect (YMKMapRect mapRect);

        [Export ("getData")]
        NSObject GetData { get; }

        [Export ("startTitle")]
        string StartTitle { set; }

        [Export ("goalTitle")]
        string GoalTitle { set; }

        [Export ("getStartTitle")]
        string GetStartTitle { get; }

        [Export ("getGoalTitle")]
        string GetGoalTitle { get; }
    }

    [BaseType (typeof (YMKOverlayView))]
    public partial interface YMKRouteOverlayView {

        [Export ("routeOverlay")]
        YMKRouteOverlay RouteOverlay { get; }

        [Export ("startPinVisible")]
        bool StartPinVisible { get; set; }

        [Export ("goalPinVisible")]
        bool GoalPinVisible { get; set; }

        [Export ("routePinVisible")]
        bool RoutePinVisible { get; set; }

        [Export ("initWithRouteOverlay:")]
        IntPtr Constructor (YMKRouteOverlay overlay);
    }

    [BaseType (typeof (CLLocationManagerDelegate))]
	public partial interface YMKNaviController /*: CLLocationManagerDelegate*/ {

        [Export ("delegate", ArgumentSemantic.Assign)]
        YMKNaviControllerDelegate Delegate { get; set; }

        [Export ("initWithRouteOverlay:")]
        IntPtr Constructor (YMKRouteOverlay routeOverlay);

        [Export ("start")]
		bool Start ();

        [Export ("stop")]
		bool Stop ();

        [Export ("getDistanceOfRemainder")]
		double GetDistanceOfRemainder ();

        [Export ("getTotalDistance")]
		double GetTotalDistance ();

        [Export ("getRemainderDistance")]
		double GetRemainderDistance ();

        [Export ("getTimeOfRemainder")]
		double GetTimeOfRemainder();

        [Export ("getTotalTime")]
		double GetTotalTime ();

        [Export ("getNowPointByCoordinate")]
		CLLocationCoordinate2D GetNowPointByCoordinate();

        [Export ("checkSpeed")]
        void CheckSpeed ();

		[Export ("aRKViewController")]
        YARKViewController ARKViewController { set; }

        [Export ("mapView")]
        YMKMapView MapView { set; }

//        [Export ("getNextNodeInfo"), Verify ("ObjC method massaged into getter property", "/Users/hrnv/Downloads/201401/mapsdk_ios/YMap/YMapKit.framework/Headers/YMKNaviController.h", Line = 57)]
//        YMKRouteNodeInfo GetNextNodeInfo { get; }
//
//        [Export ("getCurrentNodeInfo"), Verify ("ObjC method massaged into getter property", "/Users/hrnv/Downloads/201401/mapsdk_ios/YMap/YMapKit.framework/Headers/YMKNaviController.h", Line = 58)]
//        YMKRouteNodeInfo GetCurrentNodeInfo { get; }
    }

	//@protocol DeviceStateDelegate
	[Model, BaseType (typeof (NSObject))]
	public partial interface DeviceStateDelegate {
		//- (void) StateChanged;
		[Export ("StateChanged:")]
		void StateChanged();
	}

	//@protocol NavigationMgrDelegate
	[Model, BaseType (typeof (NSObject))]
	public partial interface NavigationMgrDelegate {
		//- (void) NavigationMgrUpdated;
		[Export ("NavigationMgrUpdated:")]
		void NavigationMgrUpdated();
	}

	//@protocol POIViewDelegate <NSObject>
	[Model, BaseType (typeof (NSObject))]
	public partial interface POIViewDelegate {
		//- (void) poiView:(POIView*)poiView onPick:(int)index;
	}

//	//@interface NavigationMgr : NSObject <DeviceStateDelegate> {
//	[BaseType (typeof (NSObject))]
//	public partial interface NavigationMgr : DeviceStateDelegate {
//
//	}

	[BaseType (typeof (UIViewController))]
	public interface YARKViewController { // : YMKMapViewDelegate, NavigationMgrDelegate, POIViewDelegate {
//		//(void) setCurrentPos:(CLLocation*)loc
//		[Export("currentPos")]
//		CLLocation CurrentPos { set; }
	}

}

