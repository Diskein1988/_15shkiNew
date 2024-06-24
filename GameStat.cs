namespace _15shkiNew
{
    internal class GameStat
    {
        private Player player;
        private string? nick = "";

        public GameStat()
        {
            Console.Write( "Введи ваше имя: " );
            player = new Player( SetNickName() );

        }

        private string SetNickName()
        {
            nick = Console.ReadLine();
            if( nick == "" )
            {
                return "Чиполин";
            }
            else
            {
                return nick;
            }
        }

        public string ShowNickName()
        {
            return player.NickName;
        }

    }
}
