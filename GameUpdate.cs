﻿using System.Net;

namespace _15shkiNew
{
    internal class GameUpdate
    {

        private string control = "Упарвление: 8 - вверх, 5 - вниз, 4 - влево, 6 - вправо или W/A/S/D";
        private object num = 1;
        MoveItemInGames inGames = MoveItemInGames.NONE;
        private GameManager manager;
        private KeyReading keyReading;
        private GameStat gameStat;
        private static GameUpdate? instance = null;
        private static bool exitGame = false;
        private static bool startGameSession = false;

        private GameUpdate()
        {
            manager = GameManager.GetInstance;
            keyReading = KeyReading.GetInstance;
            gameStat = GameStat.GetInstance;
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
                    break;

                case StartMenu.SCORE: // Рекорды
                    Console.Clear();
                    Console.WriteLine("Текущая игровая сессия:");
                    gameStat.ShowGameWin();
                    gameStat.ShowGameTime();
                    gameStat.ShowTotalStat();
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
