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
        // Game Board
        float gameViewWidth;
        float gameViewHeight;
        
        // Game tile
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

        /// <summary>
        /// Creates the game board and placing each tile the GameBoard View.
        /// </summary>
        public void CreateGameBoard()
        {
            // Specifiy the width and the height for each tile
            tileWidth = this.gameViewWidth / this.gridCellSize;
            tileHeight = this.gameViewHeight / this.gridCellSize;

            // Specify the tile width and the tile center values
            float tileCenterX = tileWidth / 2;
            float tileCenterY = tileHeight / 2;

            // Initialize the tile counter value
            int counter = 65; // 65 <=> letter A

            // Build the game board with images from the array.
            for (int row = 0; row < this.gridCellSize; row++)
            {
                for (int column = 0; column < this.gridCellSize; column++)
                {
                    GameTile tile = new GameTile(row, column);

                    tile.Frame = new CGRect(0, 0, tileWidth, tileHeight);

                    tile.Image = tile.DrawTileText(
                        UIImage.FromFile("game_tile.png"),
                        Convert.ToChar(counter).ToString(),
                        UIColor.White,
                        65);

                    tile.Center = new CGPoint(tileCenterX, tileCenterY);

                    // Allow user to tap on the tile in the game board
                    tile.UserInteractionEnabled = true;

                    // Store the coordinates
                    gameTileCoords.Add(new CGPoint(tileCenterX, tileCenterY));

                    // Add the image to our tile images
                    gameTileImagesArray.Add(tile);

                    gameBoardView.AddSubview(tile);

                    // Increment to the next tile position
                    tileCenterX += tileWidth;

                    counter++;
                }

                tileCenterX = tileWidth / 2;
                tileCenterY += tileHeight;
            }

            // Remove the last tile from the gameBoard and our gameTileImagesArray.
            var emptyTile = gameTileImagesArray[gameTileImagesArray.Count - 1];
            emptyTile.RemoveFromSuperview();
            gameTileImagesArray.RemoveAt(gameTileImagesArray.Count - 1);
        }

        private void StartNewGame()
        {
            throw new NotImplementedException();
        }
    }
}
