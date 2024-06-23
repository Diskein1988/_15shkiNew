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
                if ( instance == null )
                    instance = new GameManager();

                return instance;
            }
        }

        public bool GameWin()
        {
            return gameField.GameWin();
        }

        public void MoveItem( char ch )
        {
            gameField.MoveItem( ch );
        }

        public void Show()
        {
            gameField.Show();
        }

        public void ResetGame()
        {
            gameField = new();
        }
    }
}