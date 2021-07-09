#if IOS
using System;
using CoreAnimation;
using CoreGraphics;
using UIKit;

namespace LibVLCSharp.Forms.Platforms.Apple
{
    /// <summary>
    /// Defines the <see cref="NativeOverlayView" />.
    /// </summary>
    public class NativeOverlayView : UIView
    {
        /// <summary>
        /// Defines the showOverlay.
        /// </summary>
        private bool showOverlay = true;

        /// <summary>
        /// Gets or sets a value indicating whether ShowOverlay.
        /// </summary>
        public bool ShowOverlay
        {
            get { return showOverlay; }
            set
            {
                showOverlay = value;

                if (showOverlay)
                    AddOverlayLayer();
                else
                    RemoveOverlayLayer();
            }
        }

        /// <summary>
        /// Defines the overlayLayer.
        /// </summary>
        internal CAShapeLayer? overlayLayer = null;

        /// <summary>
        /// Gets or sets the Opacity.
        /// </summary>
        public float Opacity { get; set; } = 0.5f;

        /// <summary>
        /// Gets or sets the OverlayBackgroundColor.
        /// </summary>
        public UIColor OverlayBackgroundColor { get; set; } = UIColor.Clear;

        internal UIBezierPath GetHeartOverlayPath(CGRect originalRect, float scale)
        {
            var scaledWidth = (originalRect.Size.Width * scale);
            var scaledXValue = ((originalRect.Size.Width) - scaledWidth) / 2;
            var scaledHeight = (originalRect.Size.Height * scale);
            var scaledYValue = ((originalRect.Size.Height) - scaledHeight) / 2;

            var scaledRect = new CGRect(x: scaledXValue, y: scaledYValue, width: scaledWidth, height: scaledHeight);
            var path = new UIBezierPath();

            path.MoveTo(new CGPoint(x: originalRect.Size.Width / 2, y: scaledRect.Y + scaledRect.Size.Height));

            path.AddCurveToPoint(new CGPoint(x: scaledRect.X, y: scaledRect.Y + (scaledRect.Size.Height / 4)),
                controlPoint1: new CGPoint(x: scaledRect.X + (scaledRect.Size.Width / 2), y: scaledRect.Y + (scaledRect.Size.Height * 3 / 4)),
                controlPoint2: new CGPoint(x: scaledRect.X, y: scaledRect.Y + (scaledRect.Size.Height / 2)));

            path.AddArc(new CGPoint(scaledRect.X + (scaledRect.Size.Width / 4), scaledRect.Y + (scaledRect.Size.Height / 4)),
                (scaledRect.Size.Width / 4),
                (nfloat)Math.PI,
                 0,
                 true);

            path.AddArc(new CGPoint(scaledRect.X + (scaledRect.Size.Width * 3 / 4), scaledRect.Y + (scaledRect.Size.Height / 4)),
                  (scaledRect.Size.Width / 4),
                 (nfloat)Math.PI,
                 0,
                  true);

            path.AddCurveToPoint(new CGPoint(x: originalRect.Size.Width / 2, y: scaledRect.Y + scaledRect.Size.Height),
            controlPoint1: new CGPoint(x: scaledRect.X + scaledRect.Size.Width, y: scaledRect.Y + (scaledRect.Size.Height / 2)),
            controlPoint2: new CGPoint(x: scaledRect.X + (scaledRect.Size.Width / 2), y: scaledRect.Y + (scaledRect.Size.Height * 3 / 4)));

            path.ClosePath();

            return path;
        }

        internal UIBezierPath GetCircularOverlayPath()
        {
            var radius = (int)(Bounds.Width / 2) - 20;

            var circlePath = UIBezierPath.FromRoundedRect(new CGRect(Bounds.GetMidX() - radius, Bounds.GetMidY() - radius, 2.0 * radius, 2.0 * radius), radius);
            circlePath.ClosePath();
            return circlePath;
        }

        /// <summary>
        /// Add the Overlay layer
        /// </summary>
        public void AddOverlayLayer()
        {
            var path = UIBezierPath.FromRoundedRect(new CGRect(Frame.X, Frame.Y, Frame.Width, Frame.Height), 0);
            path.UsesEvenOddFillRule = true;

            var fillLayer = new CAShapeLayer
            {
                Path = path.CGPath,
                FillRule = CAShapeLayer.FillRuleEvenOdd,
                FillColor = OverlayBackgroundColor.CGColor,
                Opacity = Opacity
            };
            overlayLayer = fillLayer;
            Layer.AddSublayer(fillLayer);
        }

        /// <summary>
        /// Update Path
        /// </summary>
        public void UpdatePath()
        {
            var path = UIBezierPath.FromRoundedRect(new CGRect(Frame.X, Frame.Y, Frame.Width, Frame.Height), 0);
            if (overlayLayer != null)
                overlayLayer.Path = path.CGPath;
        }

        /// <summary>
        /// Update the Opacity
        /// </summary>
        public void UpdateOpacity()
        {
            if (overlayLayer != null)
                overlayLayer.Opacity = Opacity;
        }

        /// <summary>
        /// Update the Fillcolor
        /// </summary>
        public void UpdateFillColor()
        {
            if (overlayLayer != null)
                overlayLayer.FillColor = OverlayBackgroundColor.CGColor;
        }

        /// <summary>
        /// Remove the Overlay layer
        /// </summary>
        public void RemoveOverlayLayer()
        {
            overlayLayer?.RemoveFromSuperLayer();
        }
    }
}
#endif
