namespace _15shkiNew
{
    internal class GameManager
    {
        private GameField gameField;
        private static GameManager? instance = null;

        private GameManager()
        {
            gameField = new();
        }

        public static GameManager GetInstance
        {
            get
            {
                instance ??= new GameManager();
                return instance;
            }
        }

        public bool GameWin()
        {
            return gameField.GameWin();
        }

        public void MoveItem( Enum @enum )
        {
            gameField.MoveItem( @enum );
        }

        public void Show()
        {
            gameField.Show();
        }

        public void ResetGame()
        {
            if ( instance != null )
            {
                gameField = new();
            }
        }

    }
}