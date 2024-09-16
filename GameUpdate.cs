using System.Net;

namespace _15shkiNew
{
    internal class GameUpdate
    {

        private string control = "Упарвление: 8 - вверх, 5 - вниз, 4 - влево, 6 - вправо или W/A/S/D";
        private string infoStat = "Управление: 1 - локальная статистика, 2 - глобальная стата, 3 - выход";
        private object num = 1;
        private MoveItemInGames inGames = MoveItemInGames.NONE;
        private GameManager manager;
        private KeyReading keyReading;
        private GameStat gameStat;
        private TCPConnect tCPConnect;
        private static GameUpdate? instance = null;
        private bool exitGame = false;
        private static bool startGameSession = false;

        private GameUpdate()
        {
            manager = GameManager.GetInstance;
            keyReading = KeyReading.GetInstance;
            gameStat = GameStat.GetInstance;
            tCPConnect = TCPConnect.GetInstance;
        }

        public static GameUpdate GetInstance
        {
            get
            {
                instance ??= new GameUpdate();
                return instance;
            }
        }

        private static void ReturnStartMenu()
        {
            Console.WriteLine( "Нажмите любую клавишу для выхода в главное меню" );
            Console.ReadKey( true );
            Console.Clear();
        }

        public void Update( StartMenu start )
        {

            switch ( start )
            {
                case StartMenu.START: // Старт
                    startGameSession = true;
                    if ( !gameStat.GSTimer_Enable )
                    {
                        gameStat.ResetCurrentGameTime();
                        gameStat.GSTimer_Start();
                    }
                    manager.Show();
                    Console.WriteLine( control );
                    Console.WriteLine( "Нажать \'Q\' для выхода" );
                    inGames = keyReading.MoveItemInGame();
                    if ( inGames == MoveItemInGames.EXIT )
                    {
                        startGameSession = false;
                        gameStat.GSTimer_Stop();
                        gameStat.SaveTotalStat();
                        manager.ResetGame();
                        Console.Clear();
                        break;
                    }
                    manager.MoveItem( inGames );
                    if ( manager.GameWin() )
                    {
                        Console.Clear();
                        Console.WriteLine( "Винер винер чикен динер" );
                        startGameSession = false;
                        gameStat.GSTimer_Stop();
                        gameStat.SaveTotalStat();
                        manager.ResetGame();
                        ReturnStartMenu();
                        break;
                    }
                    Console.Clear();
                    break; //Старт

                case StartMenu.SCORE: // Рекорды
                    Console.Clear();
                    do
                    {
                        Console.WriteLine( infoStat );
                        switch ( keyReading.GetStaticMenu() )
                        {
                            case StaticMenu.LOCAL:
                                gameStat.ShowGameWin();
                                gameStat.ShowGameTime();
                                break;
                            case StaticMenu.GLOBAL:
                                Console.Write( "Тестовое соединение с сервером, введите произвольный текст: " );
                                tCPConnect.SendMsg( Console.ReadLine() );
                                Console.WriteLine(tCPConnect.GetMassege);
                                break;
                            case StaticMenu.EXIT:
                                return;
                            default:
                                break;
                        }
                    }
                    while ( true );

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
        public bool ExitGame => exitGame;
        public bool StartGameSession => startGameSession;
    }
}
