using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerSocket
{
    class SocketServerConnector
        {
            public void CreateServerConnector(int TCPPort, IPAddress IPV4Address, string IPV4)
            {
                while (true)
                {
                    try
                    {
                        // Initalise a Client to Send & Recieve Data.
                        using TcpClient client = new TcpClient(IPV4, TCPPort);
                        Console.WriteLine("Connected on {0}, Port: {1}", IPV4, TCPPort);

                        // Takes User Input:
                        string? Message = Console.ReadLine();

                        Byte[] MessageSender = System.Text.Encoding.ASCII.GetBytes(Message);
                        NetworkStream stream = client.GetStream();

                        stream.Write(MessageSender, 0, MessageSender.Length);

                        Console.WriteLine("Sent: {0}", MessageSender);

                        MessageSender = new Byte[256];
                        string ResponseData = string.Empty;

                        Int32 bytes = stream.Read(MessageSender, 0, MessageSender.Length);
                        ResponseData = System.Text.Encoding.ASCII.GetString(MessageSender, 0, bytes);
                        Console.WriteLine("Received: {0}", ResponseData);

                    }
                    catch (ArgumentNullException e)
                    {
                        Console.WriteLine("Error! {0}, Client Message was empty, Null returned", e);
                    }
                    catch (SocketException e)
                    {
                        Console.WriteLine("Error! {0}, Socket Error, Is the server active?", e);
                    }
                }
            }
    }
}