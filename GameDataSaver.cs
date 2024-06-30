using CsvHelper;
using CsvHelper.Configuration;
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
            CreatData();
        }

        public static GameDataSaver GetInstance
        {
            get
            {
                instance ??= new GameDataSaver();
                return instance;
            }
        }

        private void CreatData()
        {
            if ( !File.Exists( "data.csv" ) )
            {
                File.Create( "data.csv" ).Close();
            }
        }

        public void DataWriter( string nick)
        {
            using var reader = new StreamReader( "data.csv" );
            using var csvReader = new CsvReader( reader, CultureInfo.InvariantCulture );
            var data = csvReader.GetRecords<PlayerData>();
            foreach ( var item in data )
            {
                if ( item.NickName != nick )
                {
                    
                }
            }
            reader.Close();
            playerDatas = new List<PlayerData>
            {
                new PlayerData
                {
                    NickName = nick, GameTime = 100, GameWin = 50
                }
            };

            using var writer = new StreamWriter( "data.csv" );
            using var csvWriter = new CsvWriter( writer, CultureInfo.InvariantCulture );
            csvWriter.WriteHeader<PlayerData>();
            csvWriter.NextRecord();
            foreach ( var playerData in playerDatas )
            {
                csvWriter.WriteRecord( playerData );
                csvWriter.NextRecord();
            }
            
        }

    }
}
