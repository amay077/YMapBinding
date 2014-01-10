using System;

namespace YMapBinding
{
    public class YMKRelayRouteOverlayDelegate : YMKRouteOverlayDelegate
    {
        readonly Action<YMKRouteOverlay> _finishRouteSearchHandler;
        readonly Action<YMKRouteOverlay, int> _withErrorHandler;

        public YMKRelayRouteOverlayDelegate(
            Action<YMKRouteOverlay> finishRouteSearchHandler, 
            Action<YMKRouteOverlay, int> withErrorHandler)
        {
            _finishRouteSearchHandler = finishRouteSearchHandler;
            _withErrorHandler = withErrorHandler;
        }

        public YMKRelayRouteOverlayDelegate(
            Action<YMKRouteOverlay> finishRouteSearchHandler) : this(finishRouteSearchHandler, null)
        {
        }

        public override void FinishRouteSearch (YMKRouteOverlay routeOverlay)
        {
            if (_finishRouteSearchHandler != null)
            {
                _finishRouteSearchHandler(routeOverlay);
            }
        }

        public override void WithError (YMKRouteOverlay routeOverlay, int error)
        {
            if (_withErrorHandler != null)
            {
                _withErrorHandler(routeOverlay, error);
            }
        }
    }
}

