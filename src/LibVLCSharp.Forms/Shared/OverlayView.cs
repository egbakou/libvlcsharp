using Xamarin.Forms;

namespace LibVLCSharp.Forms.Shared
{
    /// <summary>
    /// Overlay custom view.
    /// </summary>
    public class OverlayView : ContentView
    {
        /// <summary>
        /// Bindable property that determines whether the Overlay should be displayed or not.
        /// </summary>
        public static readonly BindableProperty ShowOverlayProperty = BindableProperty.Create(
        propertyName: nameof(ShowOverlay),
        returnType: typeof(bool),
        declaringType: typeof(OverlayView),
        defaultValue: true,
        defaultBindingMode: BindingMode.TwoWay);

        /// <summary>
        /// Determines if the Overlay should be displayed or not.
        /// </summary>
        public bool ShowOverlay
        {
            get { return (bool)GetValue(ShowOverlayProperty); }
            set { SetValue(ShowOverlayProperty, value); }
        }

        /// <summary>
        /// Bindable property that speficies the overlay opacity.
        /// </summary>
        public static readonly BindableProperty OverlayOpacityProperty = BindableProperty.Create(
        propertyName: nameof(OverlayOpacity),
        returnType: typeof(float),
        declaringType: typeof(OverlayView),
        defaultValue: 1.0f,
        defaultBindingMode: BindingMode.TwoWay);

        /// <summary>
        /// Speficies the overlay opacity.
        /// </summary>
        public float OverlayOpacity
        {
            get { return (float)GetValue(OverlayOpacityProperty); }
            set { SetValue(OverlayOpacityProperty, value); }
        }

        /// <summary>
        /// Bindable property that speficies the overlay background color.
        /// </summary>
        public static readonly BindableProperty OverlayBackgroundColorProperty = BindableProperty.Create(
            propertyName: nameof(OverlayBackgroundColor),
            returnType: typeof(Color),
            declaringType: typeof(OverlayView),
            defaultValue: Color.Gray,
            defaultBindingMode: BindingMode.TwoWay);

        /// <summary>
        /// Speficies the overlay background color
        /// </summary>
        public Color OverlayBackgroundColor
        {
            get { return (Color)GetValue(OverlayBackgroundColorProperty); }
            set { SetValue(OverlayBackgroundColorProperty, value); }
        }
    }
}
