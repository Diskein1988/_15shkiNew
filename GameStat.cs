namespace _15shkiNew
{
    internal class GameStat
    {
        private Player player;

        public GameStat()
        {
            Console.Write( "Введи ваше имя: " );
            player = new Player( SetNickName() );

        }

        private string SetNickName()
        {
            string? nick = Console.ReadLine();
            if( string.IsNullOrEmpty(nick) )
            {
                return "Чиполин";
            }
            else if ( nick.Length > 15 )
            {
                Console.WriteLine( "Ник слишком длинный. Более 15 символов" );
                return SetNickName();
            }
            else
            {
                Console.Clear();
                return nick;
            }
        }

        public string ShowNickName()
        {
            return "Ваш ник: " + player.NickName + "\n";
        }

    }
}
