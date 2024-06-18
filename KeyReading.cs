namespace _15shkiNew
{
    internal class KeyReading
    {
        private char ReadKey()
        {
            ConsoleKeyInfo key;
            key = Console.ReadKey(true);
            return key.KeyChar;
        }

        public Enum PressKey()
        {
            switch (ReadKey())
            {
                case '1':
                    return StartMenu.start;
                case '2':
                    return StartMenu.score;
                case '3':
                    return StartMenu.credits;
                case '0':
                    return StartMenu.exit;
                default:
                    return StartMenu.exit;

            }
        }
        public int readKey
        {
            get
            {
               return ReadKey();
            }
        }

        public enum StartMenu
        {
            start,
            score,
            credits,
            exit
        }
    }
}
