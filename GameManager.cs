namespace _15shkiNew
{
    internal class GameManager
    {
        private GameField gameField;

        public GameManager()
        {
            gameField = new GameField();
        }
        public bool GameWin
        {
            get
            {
                return gameField.GameWin();
            }
        }
        public char MoveItem
        {
            set
            {
                gameField.MoveItem( value );
            }
        }

        public Action Show
        {
            get
            {
                return gameField.Show;
            }
        }

    }
}