using UIKit;

namespace SlidingTiles.Interfaces
{
    public interface IGameTile
    {
        /// <summary>
        /// Draw a text onto a specified image
        /// </summary>
        /// <param name="uiImage">The image to use</param>
        /// <param name="sText">Text to place in the image</param>
        /// <param name="textColor">Color of the text</param>
        /// <param name="FontSize">Font size of the text</param>
        /// <returns>An image with a text</returns>
        UIImage DrawTileText(
            UIImage uiImage, string sText, UIColor textColor, int FontSize);
    }
}