namespace _15shkiNew
{
    public enum StartMenu
    {
        START,
        SCORE,
        CREATER,
        EXIT
    }
    internal class KeyReading
    {
        private char ReadKey()
        {
            ConsoleKeyInfo key;
            key = Console.ReadKey(true);
            return key.KeyChar;
        }

        public Enum? PressKey()
        {

            switch (ReadKey())
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
        public int readKey
        {
            get
            {
               return ReadKey();
            }
        }

    }
}
