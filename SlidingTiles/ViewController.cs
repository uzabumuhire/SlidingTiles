using System;
using System.Collections.Generic;

using UIKit;
using CoreGraphics;
using Foundation;

using SlidingTiles.Classes;

namespace SlidingTiles
{
    /// <summary>
    /// Main game logic.
    /// </summary>
    public partial class ViewController : UIViewController
    {
        float gameViewWidth;
        float gameViewHeight;

        float tileWidth;
        float tileHeight;
        int gridCellSize = 5;
        GameTile[,] tiles = new GameTile[5, 5]; // 5x5 (Rows, Columns)

        // Game tile images
        List<UIImageView> gameTileImagesArray = new List<UIImageView>();

        // Index positions of each tile that is placed on the game board.
        List<CGPoint> gameTileCoords = new List<CGPoint>();

        // Empty tile position
        CGPoint emptyTilePos;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            // Layout  our game board
            gameViewWidth = (float)gameBoardView.Frame.Size.Width;
            gameViewHeight = (float)gameBoardView.Frame.Size.Width;

            // Start a new game
            StartNewGame();
        }


        private void StartNewGame()
        {
            throw new NotImplementedException();
        }
    }
}
