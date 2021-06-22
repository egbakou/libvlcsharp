#if IOS
using Foundation;
using LibVLCSharp.Forms.Platforms.iOS;
using LibVLCSharp.Forms.Shared;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(OrientationHandler))]
namespace LibVLCSharp.Forms.Platforms.iOS
{
    /// <summary>
    /// Force orientation of iOS device.
    /// In iOS client project, Developer should override the GetSupportedInterfaceOrientations method.
    /// Refer to the sample LibVLCSharp.Forms.Sample.MediaElement to see how to use it.
    /// </summary>
    public class OrientationHandler : IOrientationHandler
    {
        private const string LandscapeMode = "Landscape";
        private const string PortraitMode = "Portrait";
        private const string LandscapeAndPortraitMode = "All";
        private const string OrientationLabel = "orientation";
        private const int IOSLandscapeLeftMode = (int)UIInterfaceOrientation.LandscapeLeft;
        private const int IOSPortraitMode = (int)UIInterfaceOrientation.Portrait;

        /// <summary>
        /// Force Landscape mode.
        /// </summary>
        public void ForceLandscape()
        {
            MessagingCenter.Send(this, LandscapeMode);
            UIDevice.CurrentDevice.SetValueForKey(new NSNumber(IOSLandscapeLeftMode), new NSString(OrientationLabel));
        }

        /// <summary>
        /// Force Portrait mode.
        /// </summary>
        public void ForcePortrait()
        {
            MessagingCenter.Send(this, PortraitMode);
            UIDevice.CurrentDevice.SetValueForKey(new NSNumber(IOSPortraitMode), new NSString(OrientationLabel));
        }

        /// <summary>
        /// Restore Landscape and Portrait orientation mode.
        /// </summary>
        public void ResetOrientation() => MessagingCenter.Send(this, LandscapeAndPortraitMode);
    }
}
#endif
