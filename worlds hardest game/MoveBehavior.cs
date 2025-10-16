using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    public interface IMoveBehavior
    {
        void Move(Player player,int dx, int dy);
    }

    class PlayerMovement : IMoveBehavior
    {
        public void Move(Player player, int dx, int dy)
        {
            player.OldX = player.X;
            player.OldY = player.Y;
            player.X = dx;
            player.Y = dy;
        }
    }

    class UpAndDownMovement : IMoveBehavior
    {
        public void Move(Player player, int dx, int dy)
        {

        }

    }
}
