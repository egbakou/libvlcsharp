using Android.Content;
using Android.Graphics;
using Android.Views;

namespace LibVLCSharp.Forms.Platforms.Android
{
    /// <summary>
    /// 
    /// </summary>
    public class NativeOverlayView : View
    {
        Bitmap? windowFrame;
        float overlayOpacity = 0.5f;

       
        private bool showOverlay = false;
        /// <summary>
        /// ShowOverlay property
        /// </summary>
        public bool ShowOverlay
        {
            get { return showOverlay; }
            set
            {
                var repaint = !showOverlay;
                showOverlay = value;
                if (repaint)
                {
                    Redraw();
                }
            }
        }

        /// <summary>
        /// The Opcacity value
        /// </summary>
        public float Opacity
        {
            get { return overlayOpacity; }
            set
            {
                overlayOpacity = value;
                Redraw();
            }
        }

        private Color overlayColor = Color.Gray;
        /// <summary>
        /// The background Color property
        /// </summary>
        public Color OverlayBackgroundColor
        {
            get { return overlayColor; }
            set
            {
                overlayColor = value;
                Redraw();
            }
        }

        /// <summary>
        /// Initialize the application's context.
        /// </summary>
        /// <param name="context">Application context</param>
        /// <param name="showOverlay">Show overlay or not.</param>
        public NativeOverlayView(Context context, bool showOverlay = false) : base(context)
        {
            ShowOverlay = showOverlay;
            SetWillNotDraw(false);
        }

        /// <summary>
        /// Draw the overlay view.
        /// </summary>
        /// <param name="canvas">dd</param>
        protected override void OnDraw(Canvas? canvas)
        {
            if (canvas != null)
                base.OnDraw(canvas);
            if (ShowOverlay)
            {
                if (windowFrame == null)
                {
                    CreateWindowFrame();
                }
                canvas?.DrawBitmap(windowFrame, 0, 0, null);
            }
        }

        /// <summary>
        /// Redraw the overlay view.
        /// </summary>
        void Redraw()
        {
            if (ShowOverlay)
            {
                windowFrame?.Recycle();
                windowFrame = null;
                Invalidate();
            }
        }

        /// <summary>
        /// Create the windows represented by the overlay view.
        /// </summary>
        void CreateWindowFrame()
        {
            float width = Width;
            float height = Height;

            windowFrame = Bitmap.CreateBitmap((int)width, (int)height, Bitmap.Config.Argb8888);
            var osCanvas = new Canvas(windowFrame);
            var paint = new Paint(PaintFlags.AntiAlias)
            {
                Color = OverlayBackgroundColor,
                Alpha = (int)(255 * Opacity)
            };

            var outerRectangle = new RectF(0, 0, width, height);
            osCanvas.DrawRect(outerRectangle, paint);
            paint.SetXfermode(new PorterDuffXfermode(PorterDuff.Mode.Clear));
        }

        /// <summary>
        /// Called from layout when this view should assign a size and position to each of its children.
        /// </summary>
        /// <param name="changed">The layout changed or not</param>
        /// <param name="left">Left position value</param>
        /// <param name="top">Top position value</param>
        /// <param name="rignht">Right position value</param>
        /// <param name="bottom">Bottom position value</param>
        protected override void OnLayout(bool changed, int left, int top, int rignht, int bottom)
        {
            base.OnLayout(changed, left, top, rignht, bottom);
            windowFrame?.Recycle();
            windowFrame = null;
        }
    }
}
