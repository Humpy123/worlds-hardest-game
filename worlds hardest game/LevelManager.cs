namespace worlds_hardest_game
{
    public static class LevelManager
    {


        public static Board SetupLevel(int level)
        {
            BoardFetcher boardFetcher = new BoardFetcher();

            switch (level)
            {
                case 1:
                    return SetupLevel1();
                case 2:
                    return SetupLevel2();
                case 3:
                    return SetupLevel3();
                case 4:
                    return SetupLevel4();
                case 5:
                    return SetupLevel5();
                default:
                    throw new ArgumentException("Invalid level number");
            }
        }


        private static Board SetupLevel1()
        {
            Board board = new Board
                            (60, 30, new List<IEnemyFactory>
                            {new BasicEnemyFactory(new SideToSideMovement()) });

            var level = new LevelCreator(board);
            board.SetPlayerPos(11, 15);


            level.MakeRectangle<Empty>(17, 16, 20, 19);
            level.MakeRectangle<EndZone>(38, 11, 41, 14);
            level.MakeRectangle<Empty>(22, 12, 36, 18);
            level.MakeRectangle<Empty>(21, 19, 22, 19);
            level.MakeRectangle<Empty>(36, 11, 37, 11);

            board.CoinCount = 0;

            board.SetCell(new GenericPickup<Coin>(), 29, 15);
    
            for (int i = 6; i <= 9; i++)
            {
                if (i % 2 == 0)
                    board.AddEnemy(24, i*2, '●', 0);
                else
                    board.AddEnemy(34, i*2, '●', 0);
            }

            board.SetPlayerPos(19, 17);

            return board;
        }

        private static Board SetupLevel2()
        {

            Board board = new Board
                (60, 30, new List<IEnemyFactory> { new BasicEnemyFactory(new UpAndDownMovement())});

            var level = new LevelCreator(board);
            board.SetPlayerPos(11, 15);

            level.MakeRectangle<Empty>(14, 10, 46, 21);
            level.MakeRectangle<Empty>(10, 14, 13, 17);
            level.MakeRectangle<EndZone>(47, 14, 50, 17);

            for (int i = 5; i <= 15; i++)
            {
                if (i % 2 == 0)
                    board.AddEnemy(i*3, 12, '●', 0);
                else
                    board.AddEnemy(i*3, 19, '●', 0);
            }

            board.SetPlayerPos(11, 15);
            board.SetCell(new GenericPickup<Coin>(), 19, 18);
            board.SetCell(new GenericPickup<Coin>(), 41, 13);
            board.SetCell(new GenericPickup<Freeze>(), 30, 16);

            return board;
        }

        private static Board SetupLevel3()
        {

            Board board = new Board
                (60, 30, new List<IEnemyFactory>
                { new BasicEnemyFactory(new DVDMovement()),
                  new BasicEnemyFactory(new UpAndDownMovement())});
            var level = new LevelCreator(board);

            level.MakeRectangle<Empty>(10, 9, 23, 20);
            level.MakeRectangle<Empty>(23, 14, 27, 20);
            level.MakeRectangle<Empty>(28, 9, 39, 20);
            level.MakeRectangle<Empty>(28, 9, 52, 14);
            level.MakeRectangle<Empty>(45, 15, 47, 20);
            level.MakeRectangle<Empty>(48, 18, 52, 20);
            level.MakeRectangle<Empty>(14, 6, 16, 8);
            level.MakeRectangle<Wall>(13, 12, 18, 17);
            level.MakeRectangle<EndZone>(48, 9, 52, 14);

            board.AddEnemy(25, 17, '●', 1);
            board.AddEnemy(42, 11, '●', 1);
            board.AddEnemy(14, 19, '●', 0);


            board.SetCell(new GenericPickup<Coin>(), 11, 10);
            board.SetCell(new GenericPickup<Coin>(), 11, 19);
            board.SetCell(new GenericPickup<Coin>(), 20, 19);
            board.SetCell(new GenericPickup<Coin>(), 51, 19);
            board.SetCell(new GenericPickup<Shield>(), 34, 16);

            board.CoinCount = 4;
            board.SetPlayerPos(15, 7);
            return board;


        }
        private static Board SetupLevel4()
        {

            BoardFetcher fetcher = new BoardFetcher();
            Board board = fetcher.ReadImage(@"..\..\..\assets\boards\level4.png");
            board.AddFactory(new BasicEnemyFactory(new SideToSideMovement()));
            board.AddFactory(new BasicEnemyFactory(new UpAndDownMovement()));
            board.AddFactory(new LargeEnemyFactory(new DVDMovement()));

            board.AddEnemy(11, 9, '●', 0);
            board.AddEnemy(11, 16, '●', 0);
            board.AddEnemy(21, 9, '●', 0);
            board.AddEnemy(21, 16, '●', 0);
            board.AddEnemy(28, 16, '●', 1);
            board.AddEnemy(31, 8, '●', 0);
            board.AddEnemy(33, 9, '●', 0);
            board.AddEnemy(31, 10, '●', 0);
            board.AddEnemy(44, 14, '●', 2);


            return board;

        }

        private static Board SetupLevel5()
        {

            BoardFetcher fetcher = new BoardFetcher();
            Board board = fetcher.ReadImage(@"..\..\..\assets\boards\level5.png");
            board.AddFactory(new BasicEnemyFactory(new SideToSideMovement()));
            board.AddFactory(new BasicEnemyFactory(new UpAndDownMovement()));
            board.AddFactory(new BasicEnemyFactory(new DVDMovement()));
            board.AddFactory(new RandomFactory());

            board.AddEnemy(5, 9, '●', 0);
            board.AddEnemy(9, 12, '●', 0);

            board.AddEnemy(14, 11, '●', 0);
            board.AddEnemy(18, 13, '●', 0);
            board.AddEnemy(20, 5, '●', 1);

            board.AddEnemy(30, 20, '●', 2);

            board.AddEnemy(49, 22, '●', 3);
            board.AddEnemy(49, 9, '●', 3);
            board.AddEnemy(55, 16, '●', 3);
            board.AddEnemy(43, 16, '●', 3);


            return board;
        }
    }
}
