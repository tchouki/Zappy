using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

namespace Server
{    public class Server
    {
        private Socket _socket;

        public string ReceiveMsg()
        {
            Byte[] bytes = new byte[256];
            return Encoding.ASCII.GetString(bytes, 0, _socket.Receive(bytes, bytes.Length, 0));
        }

        public void SendMsg(string request)
        {
            Byte[] bytes = Encoding.ASCII.GetBytes(request);
            _socket.Send(bytes, bytes.Length, 0);
        }

        public Server(string ip, string port)
        {
            var serverIp = IPAddress.Parse(ip);
            var endpoint = new IPEndPoint(serverIp, int.Parse(port));
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Connect(endpoint);
        }
    }
}
