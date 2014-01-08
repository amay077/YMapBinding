using System;
using YMapBinding;

namespace YMapApp
{
    public class MyYMKMapViewDelegate : YMKMapViewDelegate
    {
        public override YMKOverlayView ViewForOverlay(YMKMapView mapView, YMKOverlay overlay)
        {
//            //YMKWeatherOverlayView作成
//            YMKWeatherOverlayView *weatherOverlayView = [[YMKWeatherOverlayView alloc]initWithWeatherOverlay:overlay];
//            //YMKWeatherOverlayDelegateの設定
//            weatherOverlayView.delegate = self;
//            //アルファ値を設定
//            weatherOverlayView.alpha = 0.6;
//            return weatherOverlayView;
//
            var view = new YMKWeatherOverlayView(overlay as YMKWeatherOverlay);
            view.Alpha = 0.6f;

//            var i = 0;
            return view;
        }
    }
}

