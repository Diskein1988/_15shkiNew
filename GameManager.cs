// See https://aka.ms/new-console-template for more information
namespace _15shkiNew
{
    internal class GameManager
    {
        private int Move()
        {
            ConsoleKeyInfo key;
            key = Console.ReadKey(true);
            return (int)key.KeyChar;
        }

        static void Main(string[] args)
        {
            Console.Title = "Пятнашки";
            GameManager gameManager = new GameManager();
            GameField gameField = new GameField(); // тут создаю экземпляр класса
            Console.WriteLine("Упарвление: 8 - вверх, 5 - вниз, 4 - влево, 6 - вправо или W/A/S/D");
            while (gameField.GameOver() == false) // создаю замкнутый цикл
            {
                gameField.MoveItem(gameManager.Move());
                Console.Clear();
                gameField.Show();
            }
            Console.WriteLine("Винер винер чикен динер, ёгиль нюхат чиполинку!!!");
            Console.WriteLine("Haжмитe <Enter> для выхода . . . ");
            Console.Read();
        }
    }
}