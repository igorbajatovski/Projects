using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MkdFTPGuiClient
{
    public static class ImageExtensionMethods
    {
        public static void Progress(this Image image, int progress)
        {
            if (progress >= 0 || progress <= 100)
            {
                Graphics g = Graphics.FromImage((Image)image);
                g.FillRectangle(Brushes.White, g.VisibleClipBounds.X + 1, g.VisibleClipBounds.Y + 1, g.VisibleClipBounds.Width - 2, g.VisibleClipBounds.Height - 2);
                g.FillRectangle(Brushes.Blue, g.VisibleClipBounds.X + 1, g.VisibleClipBounds.Y + 1, progress, g.VisibleClipBounds.Height - 2);
                g.DrawString(progress.ToString() + " %",
                             new Font(FontFamily.GenericSerif, 10, FontStyle.Regular),
                                      Brushes.Black,
                                      new PointF((g.VisibleClipBounds.X + g.VisibleClipBounds.Width) / 2.0F, g.VisibleClipBounds.Y));
                g.Flush(System.Drawing.Drawing2D.FlushIntention.Sync);
            }
        }
    }
}
