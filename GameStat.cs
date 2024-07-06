using System.Timers;

namespace _15shkiNew
{
    internal class GameStat
    {
        private Player player;
        private System.Timers.Timer GSTimer;
        private static GameStat? instance = null;
        private GameDataSaver? gameDataSaver;

        private GameStat()
        {
            Console.Write( "Введи ваше имя: " );
            gameDataSaver = GameDataSaver.GetInstance;
            player = new Player( SetNickName() );
            gameDataSaver.CreatingPlayerData(player.NickName);
            GSTimer = new System.Timers.Timer();
            GSTimer.Elapsed += UpdateGameTime;
            GSTimer.Interval = 1000;
            GSTimer.AutoReset = true;

        }

        public static GameStat GetInstance
        {
            get
            {
                instance ??= new GameStat();
                return instance;
            }
        }

        private string SetNickName()
        {
            string? nick = Console.ReadLine();
            if ( string.IsNullOrEmpty( nick ) )
            {
                return "Чиполин";
            }
            else if ( nick.Length > 20 )
            {
                Console.WriteLine( "Ник слишком длинный. Более 20 символов" );
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

        public void GSTimer_Start()
        {
            GSTimer.Start();
        }

        public void GSTimer_Stop()
        {
            GSTimer.Stop();
        }

        private void UpdateGameTime( Object source, ElapsedEventArgs e )
        {
            player.TimeGameSession += 1;
        }

        public void ShowGameTime()
        {
            Console.WriteLine( $"Игровое время игрока состовляет: {player.TimeGameSession} секунд\n" );
        }

        public void ShowGameWin()
        {
            Console.WriteLine($"Количество побед: {player.GameWin}");
        }

        public void ShowTotalStat()
        {
            var temp = gameDataSaver.GetTotalStatPlayer( player.NickName );
            Console.WriteLine( $"Общая игровая статистика игрока \"{temp[0]}\"\n" +
                $"Число побед: {temp[1]}\n" +
                $"Игровое время: {temp[2]}\n" );
        }

        public void SaveTotalStat()
        {
            gameDataSaver.SetTotalStatPlayer( player.NickName, player.TimeGameSession, player.GameWin );
        }

        public bool GSTimer_Enable => GSTimer.Enabled;

    }
}
