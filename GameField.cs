using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15shkiNew
{
    internal class GameField
    {
        private const int SIZE_X = 4;
        private const int SIZE_Y = 4;
        private Item[,] item = new Item[SIZE_X,SIZE_Y];
        public GameField()
        {
            int id = 1;
            for (int i = 0; i < SIZE_X; i++)
            {
                for (int j = 0; j < SIZE_Y; j++)
                {
                    item[i,j] = new Item(id <= 15 ? id : -1);
                    id++;
                }
            }
            Console.WriteLine("Создан");
            Show();
            MixSlot();
            Console.WriteLine("Перемешан");
            Show();
        }
        private void MixSlot() // перемешивание фишек
        {
            Item temp;
            Item[] itemOneArray = ToOneLvlArray();
            Random rnd = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < 30; i++)
            {
                int x = rnd.Next(0,16);
                Thread.Sleep(10);
                int y = rnd.Next(0,16);
                temp = itemOneArray[x];
                itemOneArray[x] = itemOneArray[y];
                itemOneArray[y] = temp;
            }
            int index = 0;
            for (int i = 0; i < SIZE_X; i++)
            {
                for (int j = 0; j < SIZE_Y; j++)
                {
                    item[i,j] = itemOneArray[index++];
                }
            }
        }

        public void Show()// метож для отображения поля
        {
            for (int i = 0; i < SIZE_X; i++)
            {
                Console.Write("|");
                for (int j = 0; j < SIZE_Y; j++)
                {
                    Console.Write(" {0,2} |",item[i,j].ID);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public bool GameOver() // метод для проверки на победу
        {
            int id = 1;
            for (int i = 0; i < SIZE_X; i++)
            {
                for (int j = 0; j < SIZE_Y; j++)
                {
                    if ((item[i,j].ID != id) && (item[i,j].ID != -1))
                    {
                        return false;
                    }
                    id++;
                }
            }
            return true;

        }

        public void MoveItem(int move) //метод для перемещения пустой фишки
        {
            int[] ZZERO = Search();
            Item temp;
            try
            {
                switch (move)
                {
                    case 56 or 119 or 1094: //Вверх 8
                    temp = item[ZZERO[0] - 1,ZZERO[1]];
                    item[ZZERO[0] - 1,ZZERO[1]] = item[ZZERO[0],ZZERO[1]];
                    item[ZZERO[0],ZZERO[1]] = temp;
                    break;
                    case 53 or 115 or 1099: //Вниз 2
                    temp = item[ZZERO[0] + 1,ZZERO[1]];
                    item[ZZERO[0] + 1,ZZERO[1]] = item[ZZERO[0],ZZERO[1]];
                    item[ZZERO[0],ZZERO[1]] = temp;
                    break;
                    case 52 or 97 or 1092: //Влево 4
                    temp = item[ZZERO[0],ZZERO[1] - 1];
                    item[ZZERO[0],ZZERO[1] - 1] = item[ZZERO[0],ZZERO[1]];
                    item[ZZERO[0],ZZERO[1]] = temp;
                    break;
                    case 54 or 100 or 1074: //Впрао 6
                    temp = item[ZZERO[0],ZZERO[1] + 1];
                    item[ZZERO[0],ZZERO[1] + 1] = item[ZZERO[0],ZZERO[1]];
                    item[ZZERO[0],ZZERO[1]] = temp;
                    break;
                    default: Console.WriteLine("Не премещенно"); break;
                }
            }
            catch
            {
                Console.WriteLine("В не поля");
            }
        }

        private int[] Search() // поиск пустого поля
        {
            int[] result = new int[2];
            for (int x = 0; x < SIZE_X; x++)
            {
                for (int y = 0; y < SIZE_Y; y++)
                {
                    if (item[x,y].ID == -1)
                    {
                        result[0] = x;
                        result[1] = y;
                        break;
                    }
                }
            }
            return result;
        }
        private Item[] ToOneLvlArray() //перегонка из двухмерного в одномерный массив
        {
            Item[] temp = new Item[SIZE_X * SIZE_Y];
            int index = 0;
            for (int i = 0; i < SIZE_X; i++)
            {
                for (int j = 0; j < SIZE_Y; j++)
                {
                    temp[index++] = item[i,j];
                }
            }
            return temp;
        }

    }

}
