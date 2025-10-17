using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    internal class LevelCreator
    {
        private Board board { get; set; }

        public LevelCreator(Board board)
        {
            this.board = board;
        }

        public void MakeRectangle<T>(int x1, int y1, int x2, int y2) where T : ICell, new()
        {
            for (int i = x1; i <= x2; i++)
            {
                for (int j = y1; j <= y2; j++)
                {
                    board.ChangeCell<T>(i, j);
                }
            }
        }



    }
}
