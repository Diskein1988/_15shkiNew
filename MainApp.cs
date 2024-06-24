namespace _15shkiNew
{
    internal class MainApp
    {
        private string hello = "Приветствую в игре \"Пятнашки\" v 1.2";
        private string starMenu = "Стартовое меню:\n1 - Старт игры\n2 - Рекорды\n3 - Создатель\n0 - Выход";
        private KeyReading keyReading;
        private GameStat gameStat;
        private GameManager manager;
        private GameUpdate gameUpdate;

        public MainApp()
        {
            Console.Title = "Пятнашки";
            keyReading = KeyReading.GetInstance;
            gameUpdate = GameUpdate.GetInstance;
            manager = GameManager.GetInstance;
            gameStat = new();
        }


        private static void Main( string[] args )
        {
            MainApp mainApp = new();
            while ( !mainApp.gameUpdate.ExitGame )
            {
                if ( !mainApp.gameUpdate.StartGameSession )
                {
                    Console.WriteLine( mainApp.hello );
                    Console.WriteLine( mainApp.gameStat.ShowNickName() );
                    Console.WriteLine( mainApp.starMenu );
                    mainApp.gameUpdate.Update( mainApp.keyReading.PressKeyInStartMenu() );
                    Console.Clear();
                }
                else
                {
                    mainApp.gameUpdate.Update( StartMenu.START );
                }
            }
            Console.WriteLine( "Haжмитe <Enter> для выхода . . . " );
            Console.ReadKey( true );
        }

    }
}
