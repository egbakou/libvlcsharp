#if IOS
using System.ComponentModel;
using LibVLCSharp.Forms.Platforms.Apple;
using LibVLCSharp.Forms.Shared;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(OverlayView), typeof(OverlayViewRenderer))]
namespace LibVLCSharp.Forms.Platforms.Apple
{
    /// <summary>
    /// Defines the <see cref="OverlayViewRenderer" />.
    /// </summary>
    public class OverlayViewRenderer : ViewRenderer<OverlayView, NativeOverlayView>
    {
        /// <summary>
        /// OnElementChanged event.
        /// </summary>
        /// <param name="e">Event's arguments</param>
        protected override void OnElementChanged(ElementChangedEventArgs<OverlayView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                SetNativeControl(new NativeOverlayView()
                {
                    ContentMode = UIViewContentMode.ScaleToFill
                });
            }
            else
            {
                if (e.NewElement != null)
                {
                    Control.Opacity = (float)Element.OverlayOpacity;
                    Control.ShowOverlay = Element.ShowOverlay;
                    Control.OverlayBackgroundColor = Element.OverlayBackgroundColor.ToUIColor();
                }
            }
        }

        /// <summary>
        /// OnElementPropertyChanged event.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event argument</param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == OverlayView.OverlayOpacityProperty.PropertyName)
            {
                Control.Opacity = (float)Element.OverlayOpacity;
                Control.UpdateOpacity();
            }
            else if (e.PropertyName == OverlayView.OverlayBackgroundColorProperty.PropertyName)
            {
                Control.OverlayBackgroundColor = Element.OverlayBackgroundColor.ToUIColor();
                Control.UpdateFillColor();
            }
            else if (e.PropertyName == OverlayView.ShowOverlayProperty.PropertyName)
            {
                Control.ShowOverlay = Element.ShowOverlay;
            }
        }
        
        private bool rendered = false;
        /// <summary>
        /// Lays out subviews.
        /// </summary>
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            if (!rendered && Control.ShowOverlay)
            {
                Control.AddOverlayLayer();
                rendered = true;
            }
        }
    }
}
#endif
