namespace _15shkiNew
{
    internal class MainApp
    {
        private string hello = "Приветствую в игре \"Пятнашки\" v 1.2";
        private string starMenu = "1 - Старт игры\n2 - Рекорды\n3 - Создатель\n0 - Выход";
        private string control = "Упарвление: 8 - вверх, 5 - вниз, 4 - влево, 6 - вправо или W/A/S/D";
        private static bool exitGame = false;
        private static bool startGameSession = false;
        private Enum? selectMenu;
        private KeyReading keyReading;
        private GameStat gameStat;
        private GameManager manager;

        public MainApp()
        {
            Console.Title = "Пятнашки";
            keyReading = new();
            gameStat = new();
            manager = new();

        }

        private void GameSession()
        {

        }

        private void ShowStartMenu( bool boo )
        {

        }

        private void ReturnStartMenu()
        {
            Console.WriteLine( "Нажмите любую клавишу для выхода в главное меню" );
            Console.ReadKey( true );
            Console.Clear();
        }

        private void Score()
        {
            Console.Clear();
            Console.WriteLine( "Тут пока не чего нет\n" );
            ReturnStartMenu();
        }

        private static void Main( string[] args )
        {
            MainApp mainApp = new();
            while ( !exitGame )
            {
                if ( !startGameSession )
                {
                    Console.WriteLine( mainApp.hello );
                    Console.WriteLine( mainApp.gameStat.NickName );
                    Console.WriteLine( mainApp.starMenu );
                    mainApp.selectMenu = mainApp.keyReading.PressKeyInStartMenu();
                    Console.Clear();
                }
                else
                {
                    mainApp.selectMenu = StartMenu.START;
                }

                switch ( mainApp.selectMenu )
                {
                    case StartMenu.START: // Старт
                        startGameSession = true;
                        mainApp.manager.Show();
                        Console.WriteLine( mainApp.control );
                        Console.WriteLine( "Нажать \'Q\' для выхода" );
                        char readKey = mainApp.keyReading.ReadKey();
                        if ( readKey == 'q' || readKey == 'й' )
                        {
                            startGameSession = false;
                            Console.Clear();
                            break;
                        }
                        mainApp.manager.MoveItem( readKey );
                        if ( mainApp.manager.GameWin() )
                        {
                            Console.Clear();
                            Console.WriteLine( "Винер винер чикен динер" );
                            Console.WriteLine( "Press any key..." );
                            Console.ReadLine();
                            break;
                        }
                        Console.Clear();
                        break;

                    case StartMenu.SCORE: // Рекорды
                        mainApp.Score();
                        break;

                    case StartMenu.CREATER: // Создатель
                        Console.Clear();
                        Console.WriteLine( "Created by -=Diskein=-\n" );
                        mainApp.ReturnStartMenu();
                        break;

                    case StartMenu.EXIT: // Выход
                        exitGame = true;
                        break;

                    default: break;
                }
            }
            Console.WriteLine( "Haжмитe <Enter> для выхода . . . " );
            Console.ReadKey( true );
        }

    }
}
