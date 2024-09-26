using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Text.Encodings;
using System.IO;

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
            Byte[] bytes = new byte[256];
            string data = null;

            TcpListener webServer = new TcpListener(Client.IPV4AddrBytes, Client.TCPPort);

            // Starting TCPListener for IPV4 Address (127.0.0.1) on port 33333
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
                        using TcpClient client = webServer.AcceptTcpClient();
                        Console.WriteLine("Connected!");

                        data = null;
                        NetworkStream netStream = client.GetStream();
                        
                        int i;

                        // Loop to receive all the data sent by the client.
                        // Shamelessly stolen from Microsoft
                        while ((i = netStream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            // Translate data bytes to a ASCII string.
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                            Console.WriteLine("Received: {0}", data);

                            // Process the data sent by the client.
                            data = data.ToUpper();

                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                            // Send back a response.
                            netStream.Write(msg, 0, msg.Length);
                            Console.WriteLine("Sent: {0}", data);
                        }
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