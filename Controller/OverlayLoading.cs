using DevExpress.Utils.Drawing;
using DevExpress.XtraSplashScreen;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Umoxi
{
    public static class OverlayLoading
    {
        internal static IOverlaySplashScreenHandle ShowProgressPanel(Control control)
        {
            OverlayWindowOptions options = new OverlayWindowOptions(
                  // startupDelay: 1000,
                  backColor: Color.Black,
                  opacity: 0.5,
                  fadeIn: false,
                  fadeOut: false,
                  imageSize: new Size(64, 64),
            animationType: WaitAnimationType.Image, image: Properties.Resources.icons8_iphone_spinner_96px
            );

            return SplashScreenManager.ShowOverlayForm(control, options);
            //return SplashScreenManager.ShowOverlayForm(control, customPainter: new CustomOverlayPainter());
        }
        public static void CloseProgressPanel(IOverlaySplashScreenHandle handle)
        {
            if (handle != null)
                SplashScreenManager.CloseOverlayForm(handle);
        }
        internal static IOverlaySplashScreenHandle handle = null;
    }

    class CustomOverlayPainter : OverlayWindowPainterBase
    {
        static readonly Font drawFont;
        static CustomOverlayPainter()
        {
            drawFont = new Font("Rubik", 18);
        }
        protected override void Draw(OverlayWindowCustomDrawContext context)
        {
            context.Handled = true;
            GraphicsCache cache = context.DrawArgs.Cache;
            cache.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            Rectangle bounds = context.DrawArgs.Bounds;
            context.DrawBackground();
            String drawString = "Aguarde porfavor...";
            Brush drawBrush = Brushes.Gray;
            SizeF textSize = cache.CalcTextSize(drawString, drawFont);
            PointF drawPoint = new PointF(
                bounds.Left + bounds.Width / 2 - textSize.Width / 2,
                bounds.Top + bounds.Height / 2 - textSize.Height / 2
                );
            //cache.Graphics.DrawImage();
            cache.Graphics.DrawString(drawString, drawFont, drawBrush, drawPoint);
        }
    }

}
