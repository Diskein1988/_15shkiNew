using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System.Globalization;

namespace _15shkiNew
{
    internal class GameDataSaver
    {
        private static GameDataSaver? instance;
        private List<PlayerData> playerDatas;

        class PlayerData
        {
            [Name("NickName")]
            public string? NickName { get; set; }

            [Name( "GameWin" )]
            public int? GameWin { get; set; }

            [Name( "GameTime" )]
            public int? GameTime { get; set; }

        }

        private GameDataSaver()
        {
            if( !File.Exists( "data.csv" ) )
            {
                File.Create( "data.csv" );
            }
        }

        public static GameDataSaver GetInstance
        {
            get
            {
                instance ??= new GameDataSaver();
                return instance;
            }
        }

        public void DataWriter()
        {
            playerDatas = new List<PlayerData>
            {
                new PlayerData
                {
                    NickName = "Test", GameTime = 100, GameWin = 50
                }
            };

            using var writer = new StreamWriter( "data.csv" );
            using var csv = new CsvWriter( writer, CultureInfo.InvariantCulture );
            csv.WriteHeader<PlayerData>();
            
        }

    }
}
