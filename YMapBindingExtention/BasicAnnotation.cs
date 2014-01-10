using System;
using MonoTouch.CoreLocation;

namespace YMapBinding
{
    public class BasicAnnotation : YMKAnnotation
    {
        private readonly string _title;
        private readonly string _subTitle;

        public BasicAnnotation(CLLocationCoordinate2D coord, string title, string subTitle)
        {
            this.Coordinate = coord;
            _title = title;
            _subTitle = subTitle;
        }

        public override CLLocationCoordinate2D Coordinate { get; set; }

        public override string Title { get { return _title; } }

        public override string Subtitle { get { return _subTitle; } }
    }
}

