using System.ComponentModel;
using Android.Content;
using LibVLCSharp.Forms.Platforms.Android;
using LibVLCSharp.Forms.Shared;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(OverlayView), typeof(OverlayViewRenderer))]
namespace LibVLCSharp.Forms.Platforms.Android
{
    
    /// <summary>
    /// Defines the <see cref="OverlayViewRenderer" />.
    /// </summary>
    public class OverlayViewRenderer : ViewRenderer<OverlayView, NativeOverlayView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OverlayViewRenderer"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="Context"/>.</param>
        public OverlayViewRenderer(Context context) : base(context)
        {
        }

        /// <summary>
        /// OnElementChanged event
        /// </summary>
        /// <param name="e">Event's argument</param>
        protected override void OnElementChanged(ElementChangedEventArgs<OverlayView> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                if (Context != null)
                {
                    SetNativeControl(new NativeOverlayView(Context));
                }

                if (e.NewElement != null)
                {
                    Control.Opacity = (float)Element.OverlayOpacity;
                    Control.ShowOverlay = Element.ShowOverlay;
                    Control.OverlayBackgroundColor = Element.OverlayBackgroundColor.ToAndroid();
                }
            }
        }

        /// <summary>
        /// OnElementPropertyChanged event
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">Event's argument</param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == OverlayView.OverlayOpacityProperty.PropertyName)
            {
                Control.Opacity = (float)Element.OverlayOpacity;
            }
            else if (e.PropertyName == OverlayView.OverlayBackgroundColorProperty.PropertyName)
            {
                Control.OverlayBackgroundColor = Element.OverlayBackgroundColor.ToAndroid();
            }
            else if (e.PropertyName == OverlayView.ShowOverlayProperty.PropertyName)
            {
                Control.ShowOverlay = Element.ShowOverlay;
            }
        }
    }
}
