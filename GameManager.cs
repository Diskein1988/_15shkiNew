namespace _15shkiNew
{
    internal class GameManager
    {
        private GameField gameField;

        public GameManager()
        {
            gameField = new GameField();
        }
        public bool GameWin()
        {
                return gameField.GameWin();
        }

        public void MoveItem( char ch)
        {
                gameField.MoveItem( ch );
        }

        public void Show()
        {
               gameField.Show();
        }
    }
}