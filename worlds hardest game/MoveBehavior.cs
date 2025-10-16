using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    interface IMoveBehavior
    {
        void Move();
    }

    class PlayerMovement : IMoveBehavior
    {
        public (int x, int y) Move(Player player, int dx, int dy)
        {
            player.
        }
    }

    class UpAndDownMovement : IMoveBehavior
    {
        public void Move()
        {

        }

    }
}
