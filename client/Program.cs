using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

var port = 12345;
var addr = IPAddress.Parse("127.0.0.1");

using (var client = new TcpClient())
{
    client.Connect(addr, port);

/*
    // For Windows
    {
        const uint on = 1;
        const uint time = 2000;
        const uint interval = 2000;

        byte[] inOptionValues = new byte[Marshal.SizeOf(on) * 3];

        BitConverter.GetBytes(on).CopyTo(inOptionValues, 0);
        BitConverter.GetBytes(time).CopyTo(inOptionValues, Marshal.SizeOf(on));
        BitConverter.GetBytes(interval).CopyTo(inOptionValues, Marshal.SizeOf(on) * 2);

        client.Client.IOControl(IOControlCode.KeepAliveValues, inOptionValues, null);
    }
*/

    // For Linux
    {
        const bool on = true;
        const int time = 2;
        const int interval = 2;

        var sock = client.Client;
        sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, on);
        sock.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.TcpKeepAliveTime, time);
        sock.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.TcpKeepAliveInterval, interval);
    }

    using (var s = client.GetStream())
    {
        s.ReadTimeout = (int)TimeSpan.FromSeconds(10).TotalMilliseconds;

        try
        {
            var buf = new byte[10];
            var n = s.Read(buf, 0, buf.Length);
        }
        catch (IOException)
        {
        }
    }

    client.Close();
}
