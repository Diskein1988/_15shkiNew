namespace _15shkiNew
{
    internal class Player
    {

        public Player( string name )
        {
            NickName = name;
            TimeGameSession = 0;
        }

        public string NickName { get; }

        public int TimeGameSession { get; set; }

    }
}
