// See https://aka.ms/new-console-template for more information
namespace _15shkiNew
{
    internal class GameManager
    {
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
        private string Hello = "Приветствую в игре \"Пятнашки\" v 1.0";
        private string StarMenu = "1 - Старт игры\n2 - Рекорды\n3 - Создатель\n0 - Выход";

        static void Main(string[] args)
        {
            Console.Title = "Пятнашки";
            bool endGame = false;
            GameManager gameManager = new GameManager();
            while (endGame == false)
            {
                Console.WriteLine(gameManager.Hello);
                Console.WriteLine(gameManager.StarMenu);
                switch (gameManager.ReadKey())
                {
                    case 49: // Старт
                    GameField gameField = new GameField(); // тут создаю экземпляр класса
                    Console.WriteLine("Упарвление: 8 - вверх, 5 - вниз, 4 - влево, 6 - вправо или W/A/S/D");
                    while (gameField.GameOver() == false) // создаю замкнутый цикл
                    {
                        gameField.MoveItem(gameManager.ReadKey());
                        Console.Clear();
                        gameField.Show();
                    }
                    Console.WriteLine("Винер винер чикен динер, ёгиль нюхат чиполинку!!!");
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
                    endGame = true;
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