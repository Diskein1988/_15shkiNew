namespace _15shkiNew
{
    internal class GameField
    {
        private const int SIZE_X = 3;
        private const int SIZE_Y = 3;

        private Item[,] item;
        public GameField()
        {
            item = new Item[SIZE_X, SIZE_Y];
            int id = 1;
            for ( int i = 0; i < SIZE_X; i++ )
            {
                for ( int j = 0; j < SIZE_Y; j++ )
                {
                    item[i, j] = new Item( id <= ( ( SIZE_X * SIZE_Y ) - 1 ) ? id : -1 );
                    id++;
                }
            }
            MixSlot();
        }

        public void Show()// метод для отображения поля
        {
            for ( int i = 0; i < SIZE_X; i++ )
            {
                Console.Write( "|" );
                for ( int j = 0; j < SIZE_Y; j++ )
                {
                    Console.Write( " {0,2} |", item[i, j].ID );
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void MixSlot() // перемешивание фишек
        {
            Item temp;
            Item[] itemOneArray = ToOneLvlArray();
            Random rnd = new Random( (int)DateTime.Now.Ticks );
            for ( int i = 0; i < 30; i++ )
            {
                int x = rnd.Next( 0, SIZE_X * SIZE_Y );
                Thread.Sleep( 10 );
                int y = rnd.Next( 0, SIZE_X * SIZE_Y );
                temp = itemOneArray[x];
                itemOneArray[x] = itemOneArray[y];
                itemOneArray[y] = temp;
            }
            int index = 0;
            for ( int i = 0; i < SIZE_X; i++ )
            {
                for ( int j = 0; j < SIZE_Y; j++ )
                {
                    item[i, j] = itemOneArray[index++];
                }
            }
        }

        private Item[] ToOneLvlArray() //перегонка из двухмерного в одномерный массив
        {
            Item[] temp = new Item[SIZE_X * SIZE_Y];
            int index = 0;
            for ( int i = 0; i < SIZE_X; i++ )
            {
                for ( int j = 0; j < SIZE_Y; j++ )
                {
                    temp[index++] = item[i, j];
                }
            }
            return temp;
        }

        public bool GameWin() // метод для проверки на победу
        {
            int id = 1;
            for ( int i = 0; i < SIZE_X; i++ )
            {
                for ( int j = 0; j < SIZE_Y; j++ )
                {
                    if ( ( item[i, j].ID != id ) && ( item[i, j].ID != -1 ) )
                    {
                        return false;
                    }
                    id++;
                }
            }
            return true;

        }

        public void MoveItem( char ch ) //метод для перемещения пустой фишки
        {
            int[] ZZERO = Search();
            Item temp;
            try
            {
                switch ( ch )
                {
                    case '8' or 'w' or 'ц': //Вверх 8 or W
                        temp = item[ZZERO[0] - 1, ZZERO[1]];
                        item[ZZERO[0] - 1, ZZERO[1]] = item[ZZERO[0], ZZERO[1]];
                        item[ZZERO[0], ZZERO[1]] = temp;
                        break;
                    case '5' or 's' or 'ы': //Вниз 2 or S
                        temp = item[ZZERO[0] + 1, ZZERO[1]];
                        item[ZZERO[0] + 1, ZZERO[1]] = item[ZZERO[0], ZZERO[1]];
                        item[ZZERO[0], ZZERO[1]] = temp;
                        break;
                    case '4' or 'a' or 'ф': //Влево 4 or A
                        temp = item[ZZERO[0], ZZERO[1] - 1];
                        item[ZZERO[0], ZZERO[1] - 1] = item[ZZERO[0], ZZERO[1]];
                        item[ZZERO[0], ZZERO[1]] = temp;
                        break;
                    case '6' or 'd' or 'в': //Впрао 6 or D
                        temp = item[ZZERO[0], ZZERO[1] + 1];
                        item[ZZERO[0], ZZERO[1] + 1] = item[ZZERO[0], ZZERO[1]];
                        item[ZZERO[0], ZZERO[1]] = temp;
                        break;
                    default: Console.WriteLine( "Не премещенно" ); break;
                }
            }
            catch
            {
                Console.WriteLine( "В не поля" );
            }
        }

        private int[] Search() // поиск пустого поля
        {
            int[] result = new int[2];
            for ( int x = 0; x < SIZE_X; x++ )
            {
                for ( int y = 0; y < SIZE_Y; y++ )
                {
                    if ( item[x, y].ID == -1 )
                    {
                        result[0] = x;
                        result[1] = y;
                        break;
                    }
                }
            }
            return result;
        }



    }

}
