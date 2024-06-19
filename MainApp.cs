namespace _15shkiNew
{
    internal class MainApp
    {
        private string hello = "Приветствую в игре \"Пятнашки\" v 1.2";
        private string starMenu = "1 - Старт игры\n2 - Рекорды\n3 - Создатель\n0 - Выход";
        private string control = "Упарвление: 8 - вверх, 5 - вниз, 4 - влево, 6 - вправо или W/A/S/D";

        private void ReturnStartMenu()
        {
            Console.WriteLine( "Нажмите любую клавишу для выхода в главное меню" );
            Console.ReadKey( true );
            Console.Clear();
        }

        private static void Main( string[] args )
        {
            MainApp mainApp = new MainApp();
            KeyReading keyReading = new KeyReading();
            Console.Title = "Пятнашки";
            bool exitGame = false;
            while ( !exitGame )
            {
                Console.WriteLine( mainApp.hello );
                Console.WriteLine( mainApp.starMenu );

                switch ( keyReading.PressKeyInStartMenu() )
                {
                    case StartMenu.START: // Старт
                        GameManager manager = new GameManager();
                        Console.WriteLine( mainApp.control );
                        char readKey;
                        while ( true )
                        {
                            readKey = keyReading.ReadKey();
                            if ( readKey == 'q' || readKey == 'й'  )
                            {
                                Console.Clear();
                                break;
                            }
                            manager.MoveItem = readKey;
                            if ( manager.GameWin )
                            {
                                Console.Clear();
                                Console.WriteLine( "Винер винер чикен динер" );
                                Console.WriteLine( "Press any key..." );
                                Console.ReadLine();
                                break;
                            }
                            Console.Clear();
                            manager.Show();
                            Console.WriteLine( "Нажать \'Q\' для выхода" );
                        }
                        break;

                    case StartMenu.SCORE: // Рекорды
                        Console.Clear();
                        Console.WriteLine( "Тут пока не чего нет\n" );
                        mainApp.ReturnStartMenu();
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
            Console.ReadKey(true);
        }

    }
}
