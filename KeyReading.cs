namespace _15shkiNew
{
    public enum StartMenu
    {
        START,
        SCORE,
        CREATER,
        EXIT,
        NONE
    }

    public enum MoveItemInGames
    {
        MOVE_UP,
        MOVE_DOWN,
        MOVE_LEFT,
        MOVE_RIGHT,
        EXIT,
        NONE
    }

    public enum StaticMenu
    {
        LOCAL,
        GLOBAL,
        EXIT,
        NONE
    }
    internal class KeyReading
    {
        private static KeyReading? instance = null;

        private KeyReading() { }

        public static KeyReading GetInstance
        {
            get
            {
                instance ??= new KeyReading();

                return instance;
            }
        }

        private char ReadKey()
        {
            ConsoleKeyInfo key;
            key = Console.ReadKey( true );
            return key.KeyChar;
        }

        public StartMenu PressKeyInStartMenu()
        {
            switch ( ReadKey() )
            {
                case '1':
                    return StartMenu.START;
                case '2':
                    return StartMenu.SCORE;
                case '3':
                    return StartMenu.CREATER;
                case '0':
                    return StartMenu.EXIT;
                default:
                    return StartMenu.NONE;
            }
        }

        public MoveItemInGames MoveItemInGame()
        {
            switch ( ReadKey() )
            {
                case '8' or 'w' or 'ц':
                    return MoveItemInGames.MOVE_UP;
                case '5' or 's' or 'ы':
                    return MoveItemInGames.MOVE_DOWN;
                case '4' or 'a' or 'ф':
                    return MoveItemInGames.MOVE_LEFT;
                case '6' or 'd' or 'в':
                    return MoveItemInGames.MOVE_RIGHT;
                case 'q' or 'й':
                    return MoveItemInGames.EXIT;
                default:
                    return MoveItemInGames.NONE;
            }
        }

        public StaticMenu GetStaticMenu()
        {
            switch ( ReadKey() )
            {
                case '1':
                    return StaticMenu.LOCAL;
                case '2':
                    return StaticMenu.GLOBAL;
                case '3':
                    return StaticMenu.EXIT;
                default:
                    return StaticMenu.NONE;
            }
        }
    }
}
