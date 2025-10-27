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
                case 3:
                    SetupLevel3(board);
                    break;
                case 4:
                    SetupLevel4(board);
                    break;
                case 5:
                    break;
                case 6:
                    break;
                default:
                    throw new ArgumentException("Invalid level number");
            }
        }

        private static void SetupLevel1(Board board)
        {
            var level = new LevelCreator(board);
            board.SetPlayerPos(11, 15);


            level.MakeRectangle<Empty>(4, 10, 15, 20);
            level.MakeRectangle<EndZone>(45, 10, 56, 20);
            level.MakeRectangle<Empty>(18, 11, 42, 19);
            level.MakeRectangle<Empty>(14, 20, 20, 20);
            level.MakeRectangle<Empty>(40, 10, 44, 10);

            board.CoinCount = 0;

            board.SetCell(new GenericPickup<Coin>(), 30, 15);


            /*
            for (int i = 12; i <= 18; i++)
            {
                if (i % 2 == 0)
                    board.AddEnemy(42, i);
                else
                    board.AddEnemy(18, i);
            }*/
            board.AddEnemy(30, 15);

            board.SetPlayerPos(11, 15);
        }

        private static void SetupLevel2(Board board)
        {
            var level = new LevelCreator(board);
            board.SetPlayerPos(11, 15);

            level.MakeRectangle<Empty>(14, 11, 46, 20);
            level.MakeRectangle<Empty>(10, 14, 13, 17);
            level.MakeRectangle<EndZone>(47, 14, 50, 17);

            for (int i = 5; i <= 15; i++)
            {
                if (i % 2 == 0)
                    board.AddEnemy(i*3, 12);
                else
                    board.AddEnemy(i*3, 19);
            }

            board.SetPlayerPos(11, 15);
            board.SetCell(new GenericPickup<Coin>(), 19, 18);
            board.SetCell(new GenericPickup<Coin>(), 41, 13);
            board.SetCell(new GenericPickup<Freeze>(), 42, 12);
        }

        private static void SetupLevel3(Board board)
        {
            var level = new LevelCreator(board);
            board.SetPlayerPos(11, 15);

            level.MakeRectangle<Empty>(10, 9, 23, 20);
            level.MakeRectangle<Empty>(24, 14, 27, 20);
            level.MakeRectangle<Empty>(28, 9, 39, 20);
            level.MakeRectangle<Empty>(28, 9, 52, 14);
            level.MakeRectangle<Empty>(45, 15, 47, 20);
            level.MakeRectangle<Empty>(48, 18, 52, 20);
            level.MakeRectangle<Empty>(14, 6, 16, 8);
            level.MakeRectangle<Empty>(4, 12, 6, 20);
            level.MakeRectangle<Empty>(4, 12, 9, 14);
            level.MakeRectangle<EndZone>(48, 9, 52, 14);

            board.AddEnemy(25, 17);
            board.AddEnemy(42, 11);
            board.AddEnemy(29, 13);

            board.CoinCount = 2;
            var coin1 = new GenericPickup<Coin>();
            var coin2 = new GenericPickup<Coin>();
            board.SetCell(coin1, 15, 7);
            board.SetCell(coin2, 51, 19);


        }
        private static void SetupLevel4(Board board)
        {
            var level = new LevelCreator(board);
            board.SetPlayerPos(11, 15);

            level.MakeRectangle<Empty>(10, 13, 44, 20);
            level.MakeRectangle<Empty>(6, 14, 10, 17);
            level.MakeRectangle<EndZone>(45, 14, 48, 17);

            board.AddEnemy(20, 14);
            board.AddEnemy(10, 19);


        }

       
    }
}
