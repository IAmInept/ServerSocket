using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Text.Encodings;


namespace ServerSocket
{
    public class TCPSocket()
    {
        public int TCPPort { get; set; }
        public string IPV4Address { get; set; }

        public IPAddress IPV4AddrBytes { get
            {
                return IPAddress.Parse(IPV4Address);
            }
        }

    }
}
