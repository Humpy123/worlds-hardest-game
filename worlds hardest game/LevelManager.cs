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

            for (int i = 11; i <= 19; i++)
            {
                if (i % 2 == 0)
                    board.AddEnemy(42, i);
                else
                    board.AddEnemy(18, i);
            }
        }

        private static void SetupLevel2(Board board)
        {
            var level = new LevelCreator(board);
            level.MakeRectangle<Empty>(4, 10, 15, 20);
            level.MakeRectangle<EndZone>(45, 10, 56, 20);
            level.MakeRectangle<Empty>(18, 11, 42, 19);
            level.MakeRectangle<Empty>(14, 20, 20, 20);
            level.MakeRectangle<Empty>(13, 10, 44, 10);

            for (int i = 11; i <= 13; i++)
            {
                if (i % 2 == 0)
                    board.AddEnemy(42, i);
                else
                    board.AddEnemy(18, i);
            }
        }
    }
}
