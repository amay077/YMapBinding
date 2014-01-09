using System;
using YMapBinding;
using MonoTouch.CoreLocation;

namespace YMapApp
{
	public class MyAnnotation : YMKAnnotation
    {
		private string _title;
		private string _subTitle;

		public MyAnnotation(CLLocationCoordinate2D coord, string title, string subTitle)
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

