// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;

namespace _15shkiNew
{
    internal class GameManager
    {
        private string Hello = "Приветствую в игре \"Пятнашки\" v 1.1";

        private string StarMenu = "1 - Старт игры\n2 - Рекорды\n3 - Создатель\n0 - Выход";

        private int ReadKey()
        {
            ConsoleKeyInfo key;
            key = Console.ReadKey(true);
            return (int)key.KeyChar;
        }

        private void ReturnStartMenu()
        {
            Console.WriteLine("Нажмите любую клавишу для выхода в главное меню");
            Console.ReadKey(true);
            Console.Clear();
        }

        private string SetNickName (string nickName)
        {
            return nickName;
        }

        static void Main(string[] args)
        {
            Console.Title = "Пятнашки";
            bool exitGame = false;
            GameManager gameManager = new GameManager();
            Console.WriteLine(gameManager.Hello);
            Console.WriteLine("Введите выше имя");
            GameStat gameStat = new GameStat(gameManager.SetNickName("Test"));
            while (!exitGame)
            {
                Console.WriteLine($"Приветствую,{gameStat.NickName}");
                Console.WriteLine(gameManager.StarMenu);
                switch (gameManager.ReadKey())
                {
                    case 49: // Старт
                        GameField gameField = new GameField(); // тут создаю экземпляр класса
                        Console.WriteLine("Упарвление: 8 - вверх, 5 - вниз, 4 - влево, 6 - вправо или W/A/S/D");
                        int readKey;
                        while (true) // создаю замкнутый цикл
                        {
                            readKey = gameManager.ReadKey();
                            if (readKey != 1081 && readKey != 113) // Q или Й для выхода
                            {
                                gameField.MoveItem(readKey);
                                Console.Clear();
                                gameField.Show();
                                Console.WriteLine("Нажать \"Q\" для выхода в главное меню");
                                if (gameField.GameOver() == true)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Винер винер чикен динер :D");
                                    Console.WriteLine("Press any key...");
                                    Console.ReadLine();
                                    break;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                break;
                            }
                        }
                        break;
                    case 50: // Рекорды
                        Console.Clear();
                        Console.WriteLine("Тут пока не чего нет\n");
                        gameManager.ReturnStartMenu();
                        break;
                    case 51: // Создатель
                        Console.Clear();
                        Console.WriteLine("Created by -=Diskein=-\n");
                        gameManager.ReturnStartMenu();
                        break;
                    case 48: // Выход
                        exitGame = true;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Haжмитe <Enter> для выхода . . . ");
            Console.Read();
        }
    }
}