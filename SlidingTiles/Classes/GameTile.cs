using System;

using UIKit;
using CoreGraphics;

using SlidingTiles.Interfaces;

namespace SlidingTiles.Classes
{
    /// <summary>
    /// A tile image.
    /// </summary>
    public class GameTile: UIImageView, IGameTile
    {
        public GameTile()
        {
        }

        public GameTile(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; private set; }

        public int Col { get; private set; }

        /// <summary>
        /// Draw a text onto a specified tile image
        /// </summary>
        /// <param name="uiImage">The tile image to use</param>
        /// <param name="sText">Text to place in the image</param>
        /// <param name="textColor">Color of the text</param>
        /// <param name="iFontSize">Font size of the text</param>
        /// <returns>A tile image with a text</returns>
        public UIImage DrawTileText(
            UIImage uiImage, string sText, UIColor textColor, int iFontSize)
        {
            nfloat fWidth = uiImage.Size.Width;
            nfloat fHeight = uiImage.Size.Height;

            // Device dependent RGB color space
            CGColorSpace colorSpace = CGColorSpace.CreateDeviceRGB();

            using (
                // Creates an in-memory bitmap
                CGBitmapContext ctx = new CGBitmapContext(
                    IntPtr.Zero,
                    (nint)fWidth,
                    (nint)fHeight,
                    8,
                    4* (nint)fWidth,
                    colorSpace,
                    CGImageAlphaInfo.PremultipliedFirst))
            {
                ctx.DrawImage(
                    new CGRect(0, 0, (double)fWidth, (double)fHeight),
                    uiImage.CGImage);

                ctx.SelectFont(
                    "HelveticaNeue-Bold", iFontSize, CGTextEncoding.MacRoman);

                // Measure the text's width - This involves drawing an invisible
                // string to calculate the X position difference.
                float start, end, textWidth;

                // Get the texts current position
                start = (float)ctx.TextPosition.X;

                // Set the drawing mode to invisible
                ctx.SetTextDrawingMode(CGTextDrawingMode.Invisible);

                // Draw the text at the current position
                ctx.ShowText(sText);

                // Get the end position
                end = (float)ctx.TextPosition.X;

                // Substact start from end  to get the text's width
                textWidth = end - start;


                // Set the fill color to black. This is the text color
                textColor.GetRGBA(
                    out nfloat fRed,
                    out nfloat fGreen,
                    out nfloat fBlue,
                    out nfloat fAlpha);

                ctx.SetFillColor(fRed, fGreen, fBlue, fAlpha);

                // Set the drawing mode to something that will actually draw
                // e.g. Fill
                ctx.SetTextDrawingMode(CGTextDrawingMode.Fill);

                // Draw the text at given coords
                ctx.ShowTextAtPoint(50, 50, sText);

                return UIImage.FromImage(ctx.ToImage());
            }
        }
    }
}
