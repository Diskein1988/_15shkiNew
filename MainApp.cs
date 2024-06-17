using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15shkiNew
{
    internal class MainApp
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

        private static void Main(string[] args)
        {
            MainApp mainApp = new MainApp();
            KeyReading keyReading = new KeyReading();
            Console.Title = "Пятнашки";
            bool exitGame = false;
            while (!exitGame)
            {
                Console.WriteLine(mainApp.Hello);
                Console.WriteLine(mainApp.StarMenu);

                switch (mainApp.ReadKey())
                {
                    case 49: // Старт
                        GameManager manager = new GameManager();
                        Console.WriteLine("Упарвление: 8 - вверх, 5 - вниз, 4 - влево, 6 - вправо или W/A/S/D");

                    break;

                    case 50: // Рекорды
                        Console.Clear();
                        Console.WriteLine("Тут пока не чего нет\n");
                        mainApp.ReturnStartMenu();
                    break;

                    case 51: // Создатель
                        Console.Clear();
                        Console.WriteLine("Created by -=Diskein=-\n");
                        mainApp.ReturnStartMenu();
                    break;

                    case 48: // Выход
                        exitGame = true;
                    break;

                    default: break;
                }
            }
            Console.WriteLine("Haжмитe <Enter> для выхода . . . ");
            Console.Read();
        }

    }
}
