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
            // Rename Class to Something Less Shit
            TCPSocket Client = new TCPSocket();
         
            // Setting Variables
            Client.TCPPort = 33333;
            Client.IPV4Address = "127.0.0.1";

            // Need to Move these to Methods in Class
            TcpListener webServer = new TcpListener(Client.IPV4AddrBytes, Client.TCPPort);

            // Starting TCPListener for IPV4 Address (127.0.0.1) on port 33333
            // Try 
            try
            {
                // Begins TcpListener
                webServer.Start();
                Console.WriteLine("Listening on Address: {0} Port: {1}", Client.IPV4Address, Client.TCPPort);
                Console.WriteLine("Awaiting Connection...");

                while (true)
                {
                    // Checks if theres a Pending TCP Request
                        // Returns True/False)
                    if (webServer.Pending())
                    {
                        webServer.AcceptTcpClient();
                        Console.WriteLine("Connected!");
                        break;
                    }
                }
            }
            catch(SocketException e)
            {
                Console.WriteLine("Socket Exception: {0}", e);
            }
            finally
            {
                webServer.Stop();
                Console.WriteLine("Connection Closing...");
            }
            
        }
    }
}