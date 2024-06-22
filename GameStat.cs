namespace _15shkiNew
{   
    internal class GameStat
    {
        public GameStat() 
        {
            Console.Write( "Введи ваше имя: " );
            string nick = Console.ReadLine();
            NickName = nick != null ? nick : nick = "Тупой";
        }
        public string NickName { get; }
    }
}
