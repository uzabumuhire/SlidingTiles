using UIKit;

namespace SlidingTiles.Interfaces
{
    public interface IGameTile
    {
        /// <summary>
        /// Draw a text onto a specified tile image
        /// </summary>
        /// <param name="uiImage">The tile image to use</param>
        /// <param name="sText">Text to place in the image</param>
        /// <param name="textColor">Color of the text</param>
        /// <param name="iFontSize">Font size of the text</param>
        /// <returns>A tile image with a text</returns>
        UIImage DrawTileText(
            UIImage uiImage, string sText, UIColor textColor, int iFontSize);
    }
}