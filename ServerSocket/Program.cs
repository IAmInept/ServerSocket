using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Text.Encodings;

    namespace ServerSocket
{
    class Program
    {
        public static void Main()
        {
            TCPSocket Client = new TCPSocket();
            Client.TCPPort = 33333;
            Client.IPV4Address = "127.0.0.1";

            TcpListener webServer = new TcpListener(Client.IPV4AddrBytes, Client.TCPPort);
            TcpClient s = new TcpClient(Client.IPV4Address, Client.TCPPort);

            webServer.Start();
            s.Connect(Client.IPV4Address, Client.TCPPort);
            

            //Socket ServerSock = new Socket()
            //NetworkStream TCPStream = new NetworkStream();

        }
    }
}