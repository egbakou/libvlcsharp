#if IOS
using UIKit;
using Xamarin.Forms;

namespace LibVLCSharp.Forms.Platforms.iOS
{
    /// <summary>
    /// Suscribes AppDelegate.cs to orientation change event.
    /// </summary>
    public static class OrientationChangeListener
    {
        private static UIInterfaceOrientationMask OrientationMode;

        /// <summary>
        /// Susbscriber.
        /// </summary>
        /// <param name="appDelegate">AppDelegate.</param>
        /// <returns>The desired orientation to lock</returns>
        public static UIInterfaceOrientationMask Subscribe(object appDelegate)
        {
            MessagingCenter.Subscribe<OrientationHandler>(appDelegate, "Landscape", o =>
            {
                OrientationMode = UIInterfaceOrientationMask.Landscape;
            });
            MessagingCenter.Subscribe<OrientationHandler>(appDelegate, "Portrait", o =>
            {
                OrientationMode = UIInterfaceOrientationMask.Portrait;
            });
            MessagingCenter.Subscribe<OrientationHandler>(appDelegate, "All", o =>
            {
                OrientationMode = UIInterfaceOrientationMask.All;
            });

            return OrientationMode;
        }
    }
}
#endif
