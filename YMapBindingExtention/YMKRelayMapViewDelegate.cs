using System;

namespace YMapBinding
{
    public class YMKRelayMapViewDelegate : YMKMapViewDelegate
    {
        readonly Action<YMKMapView, bool> _regionDidChangeAnimatedHandler;
        readonly Func<YMKMapView, YMKOverlay, YMKOverlayView> _viewForOverlayHandler;

        public YMKRelayMapViewDelegate(
            Func<YMKMapView, YMKOverlay, YMKOverlayView> viewForOverlayHandler,
            Action<YMKMapView, bool> regionDidChangeAnimatedHandler)
        {
            _regionDidChangeAnimatedHandler = regionDidChangeAnimatedHandler;
            _viewForOverlayHandler = viewForOverlayHandler;
        }

        public YMKRelayMapViewDelegate(
            Func<YMKMapView, YMKOverlay, YMKOverlayView> viewForOverlayHandler) : this(viewForOverlayHandler, null)
        {
        }

        public override YMKOverlayView ViewForOverlay(YMKMapView sender, YMKOverlay overlay)
        {
            if (_viewForOverlayHandler != null)
            {
                return _viewForOverlayHandler(sender, overlay);
            }

            return null;
        }

        public override void RegionDidChangeAnimated(YMKMapView sender, bool animated)
        {
            if (_regionDidChangeAnimatedHandler != null)
            {
                _regionDidChangeAnimatedHandler(sender, animated);
            }
        }
    }
}

