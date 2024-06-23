namespace _15shkiNew
{
    public enum StartMenu
    {
        START,
        SCORE,
        CREATER,
        EXIT
    }

    public enum MoveItemInGames
    {
        MUVE_UP,
        MUVE_DOWN,
        MUVE_LEFT,
        MUVE_RIGHT,
        EXIT
    }
    internal class KeyReading
    {
        private static KeyReading? instance = null;

        private KeyReading() { }

        public static KeyReading GetInstance
        {
            get
            {
                if ( instance == null )
                    instance = new KeyReading();

                return instance;
            }
        }

        public char ReadKey()
        {
            ConsoleKeyInfo key;
            key = Console.ReadKey( true );
            return key.KeyChar;
        }

        public Enum? PressKeyInStartMenu()
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
                    Console.Clear();
                    return null;
            }
        }

        public Enum? MoveItemInGame()
        {
            switch ( ReadKey() )
            {
                case '8' or 'w':
                    return MoveItemInGames.MUVE_UP;
                case '5' or 's':
                    return MoveItemInGames.MUVE_DOWN;
                case '4' or 'a':
                    return MoveItemInGames.MUVE_LEFT;
                case '6' or 'd':
                    return MoveItemInGames.MUVE_RIGHT;
                default:
                    Console.Clear();
                    return null;
            }
        }
    }
}
