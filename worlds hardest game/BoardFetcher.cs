using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices.Marshalling;
/*
namespace worlds_hardest_game
{
    /// <summary>
    /// Använder externt NuGet package System.Drawing
    /// Denna del har jag kodat för en rolig utmaning.
    /// Det är inte tänkt som en del av spelet.
    /// </summary>
    public class BoardFetcher
    {
        Bitmap image;
        public Board ReadImage(string link)
        {
            Board createdBoard = new Board(60, 30, new UpAndDownFactory());
            for (int y = 0; y < 30; y++)
            {
                image = new Bitmap(link);
                for (int x = 0; x < 60; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    string hex = $"#{pixelColor.R:X2}{pixelColor.G:X2}{pixelColor.B:X2}";
                    var pixel = FindCellTypeFromHex(hex);



                    switch (pixel)
                    {
                        case ICell:
                            createdBoard.SetCell((ICell)pixel, x, y);
                            break;
                        case 1:
                            createdBoard.AddEnemy(x, y);
                            createdBoard.SetCell(new Empty(), x, y);
                            break;
                        case 2:
                            createdBoard.SetPlayerPos(x, y);
                            createdBoard.SetCell(new Empty(), x, y);
                            break;
                    }                                             
                }
            }
            return createdBoard;
        }

        private object FindCellTypeFromHex(string hex)
        {
            switch (hex.ToUpper())
            {
                case "#0000FF": return new Wall();       // Blue
                case "#FFFFFF": return new Empty();      // White
                case "#00FF00": return new EndZone();    // Green
                case "#FFFF00": return new Coin();
                case "#FF0000": return 1;                // Red (enemy)
                case "#000000": return 2;                // Black (player)

                default:
                    throw new Exception($"Invalid color in image: {hex}");
            }
        }

    }
}
*/