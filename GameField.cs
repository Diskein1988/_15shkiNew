namespace _15shkiNew
{
    internal class GameField
    {
        private Item[,] item;
        public GameField( int SIZE_X, int SIZE_Y )
        {
            item = new Item[SIZE_X, SIZE_Y];
            int id = 1;
            for( int i = 0; i < SIZE_X; i++ )
            {
                for( int j = 0; j < SIZE_Y; j++ )
                {
                    item[i, j] = new Item( id <= ( ( SIZE_X * SIZE_Y ) - 1 ) ? id : -1 );
                    id++;
                }
            }

        }

        public Item[,] Items
        {
            get
            {
                return item;
            }
            set
            {
                item = value;
            }
        }


    }

}
