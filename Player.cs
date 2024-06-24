namespace _15shkiNew
{
    internal class Player
    {
        private static Player? instance;

        public Player( string name )
        {
            NickName = name;
        }

        public string NickName { get; }

    }
}
