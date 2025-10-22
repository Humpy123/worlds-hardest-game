namespace worlds_hardest_game
{
    public static class LevelManager
    {
        public static void SetupLevel(Board board, int level)
        {
            switch (level)
            {
                case 1:
                    SetupLevel1(board);
                    break;
                case 2:
                    SetupLevel2(board);
                    break;
                default:
                    throw new ArgumentException("Invalid level number");
            }
        }

        private static void SetupLevel1(Board board)
        {
            var level = new LevelCreator(board);
            level.MakeRectangle<Empty>(4, 10, 15, 20);
            level.MakeRectangle<EndZone>(45, 10, 56, 20);
            level.MakeRectangle<Empty>(18, 11, 42, 19);
            level.MakeRectangle<Empty>(14, 20, 20, 20);
            level.MakeRectangle<Empty>(40, 10, 44, 10);

            board.CoinCount = 2;
            var coin = new GenericPickup<Coin>();
            var coin2 = new GenericPickup<Coin>();
            board.SetCell(coin, 30, 15);
            board.SetCell(coin2, 22, 11);

            for (int i = 11; i <= 19; i++)
            {
                if (i % 2 == 0)
                    board.AddEnemy(42, i);
                else
                    board.AddEnemy(18, i);
            }

            board.SetPlayerPos(11, 15);
        }

        private static void SetupLevel2(Board board)
        {
            var level = new LevelCreator(board);
            level.MakeRectangle<Empty>(14, 12, 46, 19);
            level.MakeRectangle<Empty>(6, 14, 13, 17);
            level.MakeRectangle<EndZone>(47, 14, 54, 17);

            for (int i = 5; i <= 15; i++)
            {
                if (i % 2 == 0)
                    board.AddEnemy(i*3, 12);
                else
                    board.AddEnemy(i*3, 19);
            }

            board.SetPlayerPos(11, 15);
        }
    }
}
