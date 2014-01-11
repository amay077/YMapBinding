using System;

namespace YMapBinding
{
	public class YMKRelayNaviControllerDelegate : YMKNaviControllerDelegate
    {
		readonly Action<YMKNaviController, YMKUserLocation> _didUpdateUserLocationHandler;

		public YMKRelayNaviControllerDelegate(Action<YMKNaviController, YMKUserLocation> didUpdateUserLocationHandler)
        {
			_didUpdateUserLocationHandler = didUpdateUserLocationHandler;
        }

		public override void DidUpdateUserLocation(YMKNaviController naviController, YMKUserLocation userLocation)
		{
			if (_didUpdateUserLocationHandler != null)
			{
				_didUpdateUserLocationHandler(naviController, userLocation);
			}
		}

    }
}

