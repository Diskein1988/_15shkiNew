namespace _15shkiNew
{
    internal class GameField
    {
        private const int SIZE_X = 3;
        private const int SIZE_Y = 3;
        private Item[,] item = new Item[SIZE_X,SIZE_Y];
        public GameField()
        {
            int id = 1;
            for (int i = 0; i < SIZE_X; i++)
            {
                for (int j = 0; j < SIZE_Y; j++)
                {
                    item[i,j] = new Item(id <= ((SIZE_X * SIZE_Y) - 1) ? id : -1);
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

        public int size_x
        {
            get
            {
                return SIZE_X;
            }
        }

        public int size_y
        {
            get
            {
                return SIZE_Y;
            }
        }

    }

}
