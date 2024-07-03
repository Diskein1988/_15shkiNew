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

        private class PlayerData
        {
            [Name( "NickName" )]
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

        public void CreatingPlayerData( string nick )
        {
            playerDatas = new List<PlayerData>();
            bool availableNickName = true;
            DataReader();

            if ( playerDatas.FirstOrDefault() == null )
            {
                playerDatas.AddRange(
                   new List<PlayerData>()
                   {
                       {
                           new PlayerData
                           {
                               NickName = nick,
                               GameTime = 0,
                               GameWin = 0
                           }
                       }
                   }
                   );
                DataWriter();
            }

            foreach ( var e in playerDatas )
            {
                if ( e.NickName == nick )
                {
                    availableNickName = false;
                    break;
                }
            }

            if ( availableNickName )
            {
                playerDatas.AddRange(
                   new List<PlayerData>()
                   {
                       {new PlayerData { NickName = nick, GameTime = 0, GameWin = 0 }
                   }
                   }
                   );
                DataWriter();
            }
        }

        private void DataReader()
        {
            var reader = new StreamReader( "data.csv" );
            var csvReader = new CsvReader( reader, CultureInfo.InvariantCulture );
            var data = csvReader.GetRecords<PlayerData>();
            playerDatas.AddRange( data );
            reader.Close();
        }

        private void DataWriter()
        {
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
