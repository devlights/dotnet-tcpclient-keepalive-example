using System;
using System.Net;
using System.Net.Sockets;

var port = 12345;
var addr = IPAddress.Parse("127.0.0.1");
var server = new TcpListener(addr, port);

server.Start();

for (; ; )
{
    using (var client = server.AcceptTcpClient())
    {
        var buf = new byte[10];
        using (var s = client.GetStream())
        {
            var n = s.Read(buf, 0, buf.Length);
            Console.WriteLine("[server] read {0}", n);
        }

        client.Close();
    }

    break;
}
