using System;
using MonoTouch.CoreLocation;

namespace YMapBinding
{
    public enum YMKMapType : uint {
        Standard = 0,
        Satellite,
        Chika,
        HD,
        Style,
        OSM,
        Hybrid,
        Indoor,
        Weather
    }

    public enum YMKErrorCode : uint {
        Unknown = 1,
        ServerFailure,
        LoadingThrottled,
        PlacemarkNotFound
    }


    public struct YMKCoordinateSpan
    {
        public YMKCoordinateSpan(double lat, double lon)
        {
            this.latitudeDelta = lat;
            this.longitudeDelta = lon;
        }

        public double latitudeDelta;
        public double longitudeDelta;
    }

    public struct YMKCoordinateRegion
    {
        public YMKCoordinateRegion(CLLocationCoordinate2D center, YMKCoordinateSpan span)
        {
            this.center = center;
            this.span = span;
        }

        public CLLocationCoordinate2D center;
        public YMKCoordinateSpan span;
    }

    public struct YMKMapPoint
    {        
        public double x;           
        public double y;           
    }          

    public struct YMKMapSize
    {
        public double width;
        public double height;
    }

    public struct YMKMapRect
    {
        public YMKMapPoint origin;
        public YMKMapSize size;
    };
}

