using System;
using System.Net;
using System.Net.Sockets;

namespace NtpClient
{
    /// <summary>
    /// Represents a connection that provides information from a ntp-server.
    /// </summary>
    public class NtpConnection : INtpConnection
    {
        private readonly string server;

        /// <summary>
        /// Initializes a new instance of the <see cref="NtpConnection"/> class.
        /// </summary>
        /// <param name="server">The server to connect to.</param>
        public NtpConnection(string server)
        {
            if (string.IsNullOrEmpty(server)) throw new ArgumentException("Must be non-empty", nameof(server));

            this.server = server;
        }

        DateTime INtpConnection.GetUtc()
        {
            var ntpData = new byte[48];
            ntpData[0] = 0x1B;

            var addresses = Dns.GetHostEntry(server).AddressList;
            var ipEndPoint = new IPEndPoint(addresses[0], 123);
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.ReceiveTimeout = 3000;

            socket.Connect(ipEndPoint);
            socket.Send(ntpData);
            socket.Receive(ntpData);
            socket.Close();

            ulong intPart = (ulong)ntpData[40] << 24 | (ulong)ntpData[41] << 16 | (ulong)ntpData[42] << 8 | (ulong)ntpData[43];
            ulong fractPart = (ulong)ntpData[44] << 24 | (ulong)ntpData[45] << 16 | (ulong)ntpData[46] << 8 | (ulong)ntpData[47];

            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
            var networkDateTime = (new DateTime(1900, 1, 1)).AddMilliseconds((long)milliseconds);

            return networkDateTime;
        }
    }
}
