using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Protection.PlayReady;

namespace _15shkiNew
{
    internal class TCPConn
    {
        private static TCPConn? instance;
        private const string IPaddr = "78.29.36.242";
        private const int port = 8888;

        public static TCPConn Instance
        {
            get
            {
                instance ??= new TCPConn();
                return instance;
            }
        }

        private void RxTranssmit( string outMessage ) //отправка
        {
            TcpClient server = new TcpClient( IPaddr, port );
            Byte[] data = Encoding.UTF8.GetBytes( outMessage );
            NetworkStream stream = server.GetStream();
            try
            {
                stream.Write( data, 0, data.Length );
            }
            finally
            {
                stream.Close();
                server.Close();
            }
        }
    }
}
