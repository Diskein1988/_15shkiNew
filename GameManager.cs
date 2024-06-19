namespace _15shkiNew
{
    internal class GameManager
    {
        private GameField gameField;
        private const int SIZE_X = 3;
        private const int SIZE_Y = 3;

        public GameManager()
        {
            gameField = new GameField( SIZE_X, SIZE_Y );
            Console.WriteLine( "Игровое поле создано" );
            Show();
            MixSlot();
            Console.WriteLine( "Игровое поле перемешанно" );
            Show();
        }

        public void Show()// метод для отображения поля
        {
            for( int i = 0; i < SIZE_X; i++ )
            {
                Console.Write( "|" );
                for( int j = 0; j < SIZE_Y; j++ )
                {
                    Console.Write( " {0,2} |", gameField.Items[i, j].ID );
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
            for( int i = 0; i < 30; i++ )
            {
                int x = rnd.Next( 0, SIZE_X * SIZE_Y );
                Thread.Sleep( 10 );
                int y = rnd.Next( 0, SIZE_X * SIZE_Y );
                temp = itemOneArray[x];
                itemOneArray[x] = itemOneArray[y];
                itemOneArray[y] = temp;
            }
            int index = 0;
            for( int i = 0; i < SIZE_X; i++ )
            {
                for( int j = 0; j < SIZE_Y; j++ )
                {
                    gameField.Items[i, j] = itemOneArray[index++];
                }
            }
        }

        private Item[] ToOneLvlArray() //перегонка из двухмерного в одномерный массив
        {
            Item[] temp = new Item[SIZE_X * SIZE_Y];
            int index = 0;
            for( int i = 0; i < SIZE_X; i++ )
            {
                for( int j = 0; j < SIZE_Y; j++ )
                {
                    temp[index++] = gameField.Items[i, j];
                }
            }
            return temp;
        }

        public bool GameWin() // метод для проверки на победу
        {
            int id = 1;
            for( int i = 0; i < SIZE_X; i++ )
            {
                for( int j = 0; j < SIZE_Y; j++ )
                {
                    if( ( gameField.Items[i, j].ID != id ) && ( gameField.Items[i, j].ID != -1 ) )
                    {
                        return false;
                    }
                    id++;
                }
            }
            return true;

        }

        public void MoveItem( int move ) //метод для перемещения пустой фишки
        {
            int[] ZZERO = Search();
            Item temp;
            try
            {
                switch( move )
                {
                    case 56 or 119 or 1094: //Вверх 8
                        temp = gameField.Items[ZZERO[0] - 1, ZZERO[1]];
                        gameField.Items[ZZERO[0] - 1, ZZERO[1]] = gameField.Items[ZZERO[0], ZZERO[1]];
                        gameField.Items[ZZERO[0], ZZERO[1]] = temp;
                        break;
                    case 53 or 115 or 1099: //Вниз 2
                        temp = gameField.Items[ZZERO[0] + 1, ZZERO[1]];
                        gameField.Items[ZZERO[0] + 1, ZZERO[1]] = gameField.Items[ZZERO[0], ZZERO[1]];
                        gameField.Items[ZZERO[0], ZZERO[1]] = temp;
                        break;
                    case 52 or 97 or 1092: //Влево 4
                        temp = gameField.Items[ZZERO[0], ZZERO[1] - 1];
                        gameField.Items[ZZERO[0], ZZERO[1] - 1] = gameField.Items[ZZERO[0], ZZERO[1]];
                        gameField.Items[ZZERO[0], ZZERO[1]] = temp;
                        break;
                    case 54 or 100 or 1074: //Впрао 6
                        temp = gameField.Items[ZZERO[0], ZZERO[1] + 1];
                        gameField.Items[ZZERO[0], ZZERO[1] + 1] = gameField.Items[ZZERO[0], ZZERO[1]];
                        gameField.Items[ZZERO[0], ZZERO[1]] = temp;
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
            for( int x = 0; x < SIZE_X; x++ )
            {
                for( int y = 0; y < SIZE_Y; y++ )
                {
                    if( gameField.Items[x, y].ID == -1 )
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