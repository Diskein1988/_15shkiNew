using System.Net;

namespace _15shkiNew
{
    internal class GameUpdate
    {

        private string control = "Упарвление: 8 - вверх, 5 - вниз, 4 - влево, 6 - вправо или W/A/S/D";
        private GameManager manager;
        private KeyReading keyReading;
        private static GameUpdate? instance = null;
        private static bool exitGame = false;
        private static bool startGameSession = false;

        private GameUpdate()
        {
            manager = GameManager.GetInstance;
            keyReading = KeyReading.GetInstance;
        }

        public static GameUpdate GetInstance
        {
            get
            {
                if ( instance == null )
                {
                    instance = new GameUpdate();
                }
                return instance;
            }
        }

        private void ReturnStartMenu()
        {
            Console.WriteLine( "Нажмите любую клавишу для выхода в главное меню" );
            Console.ReadKey( true );
            Console.Clear();
        }

        public void Update( Enum? selectMenu )
        {

            switch ( selectMenu )
            {
                case StartMenu.START: // Старт
                    startGameSession = true;
                    manager.Show();
                    Console.WriteLine( control );
                    Console.WriteLine( "Нажать \'Q\' для выхода" );
                    char readKey = keyReading.ReadKey();
                    if ( readKey == 'q' || readKey == 'й' )
                    {
                        startGameSession = false;
                        manager.ResetGame();
                        Console.Clear();
                        break;
                    }
                    manager.MoveItem( readKey );
                    if ( manager.GameWin() )
                    {
                        Console.Clear();
                        Console.WriteLine( "Винер винер чикен динер" );
                        Console.WriteLine( "Press any key..." );
                        Console.ReadLine();
                        startGameSession = false;
                        manager.ResetGame();
                        break;
                    }
                    Console.Clear();
                    break;

                case StartMenu.SCORE: // Рекорды
                    Console.Clear();
                    Console.WriteLine( "Тут пока не чего нет\n" );
                    ReturnStartMenu();
                    break;

                case StartMenu.CREATER: // Создатель
                    Console.Clear();
                    Console.WriteLine( "Created by -=Diskein=-\n" );
                    ReturnStartMenu();
                    break;

                case StartMenu.EXIT: // Выход
                    exitGame = true;
                    break;

                default: break;
            }
        }
        public bool ExitGame
        {
            get
            {
                return exitGame;
            }
        }
        public bool StartGameSession
        {
            get
            {
                return startGameSession;
            }
        }
    }
}
