using System.Text;
using System.Net.Sockets;
using System.Net;


namespace ServerSocket
{
    class Program
    {
        public static void Main()
        {
            // Generates new Class that sets Initial Values (Port, IPV4 Address (String) & IPAddress)
            ServerData Initialiser = new ServerData();
            Initialiser.IPV4Address = "127.0.0.1";
            Initialiser.TCPPort = 33333;

            SocketServer InitialiserSocketServer = new SocketServer();
            InitialiserSocketServer.CreateServer(Initialiser.TCPPort, Initialiser.IPV4AddrBytes, Initialiser.IPV4Address);

            SocketServerConnector InitialiserConnector = new SocketServerConnector();
            InitialiserConnector.CreateServerConnector(Initialiser.TCPPort, Initialiser.IPV4AddrBytes, Initialiser.IPV4Address);

        }
    }
}