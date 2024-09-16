using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _15shkiNew
{
    internal class TCPConnect
    {
        private const string IP = "78.29.36.242";
        private const int PORT = 8888;
        private string messege = "";
        private static TCPConnect? instance = null;

        public static TCPConnect GetInstance
        {
            get
            {
                instance ??= new TCPConnect(); 
                return instance;
            }
        }

        public string GetMassege
        {
            get
            {
                return messege;
            }
        }

        private void Exchange( string outMessage )
        {
            try
            {
                // Инициализация
                TcpClient client = new TcpClient( IP, PORT );
                Byte[] data = Encoding.UTF8.GetBytes( outMessage );
                NetworkStream stream = client.GetStream();
                try
                {
                    // Отправка сообщения
                    stream.Write( data, 0, data.Length );
                    // Получение ответа
                    Byte[] readingData = new Byte[256];
                    String responseData = String.Empty;
                    StringBuilder completeMessage = new StringBuilder();
                    int numberOfBytesRead = 0;
                    do
                    {
                        numberOfBytesRead = stream.Read( readingData, 0, readingData.Length );
                        completeMessage.AppendFormat( "{0}", Encoding.UTF8.GetString( readingData, 0, numberOfBytesRead ) );
                    }
                    while ( stream.DataAvailable );
                    responseData = completeMessage.ToString();
                    messege = responseData;
                }
                finally
                {
                    stream.Close();
                    client.Close();
                }
            }
            catch ( Exception ex )
            {
                Console.WriteLine(ex);
                Console.WriteLine("Ошибка!!!");
            }
        }

        public void SendMsg ( string msg )
        {
            Exchange( msg );
        }
    }
}
