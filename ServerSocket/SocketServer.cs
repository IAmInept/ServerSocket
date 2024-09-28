using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerSocket
{
    class SocketServer
    {
        public void CreateServer(int TCPPort, IPAddress IPV4Addr, string IPV4)
        {

            Byte[] NSBuffer = new byte[256];
            string? data;

            TcpListener webServer = new TcpListener(IPV4Addr, TCPPort);

            try
            {
                // Begins TcpListener
                webServer.Start();
                Console.WriteLine("Listening on Address: {0} Port: {1}", IPV4, TCPPort);
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

                        int _;

                        // Loop to receive all the data sent by the client.
                        // Code taken from Microsoft
                        while ((_ = netStream.Read(NSBuffer, 0, NSBuffer.Length)) != 0)
                        {
                            // Translate data bytes to a ASCII string.
                            data = Encoding.ASCII.GetString(NSBuffer, 0, _);
                            Console.WriteLine("Received: {0}", data);

                            // Process the data sent by the client.
                            data = data.ToUpper();

                            byte[] msg = Encoding.ASCII.GetBytes(data);

                            // Send back a response.
                            netStream.Write(msg, 0, msg.Length);
                            Console.WriteLine("Sent: {0}", data);
                        }
                    }
                }
            }
            catch (SocketException e)
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
       
                 
