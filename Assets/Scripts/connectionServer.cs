using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace zappy_test.include
{
    public class Connection
    {
        int port = -1;
        public string team;
        string machine;

        IPEndPoint endpoint;
        IPAddress serverIp;
        Socket socket;

        public string receiveMsg()
        {
            Byte[] bytes = new byte[256];
            int rec = 0;
            string message;

            rec = socket.Receive(bytes, bytes.Length, 0);
            message = Encoding.ASCII.GetString(bytes, 0, rec);
            return message;
        }

        public void sendMsg(string request)
        {
            Byte[] bytes = Encoding.ASCII.GetBytes(request);

            socket.Send(bytes, bytes.Length, 0);
        }

        public bool connect()
        {
            serverIp = IPAddress.Parse("127.0.0.1");
            endpoint = new IPEndPoint(serverIp, port);
            try {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(endpoint);
            } catch {
                return false;
            }
            Console.Write(receiveMsg());
            return true;
        }

        public Connection(string[] args)
        {
            int res;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-p" && args[i + 1] != null && int.TryParse(args[i + 1], out res))
                    port = int.Parse(args[i + 1]);
                if (args[i] == "-n" && args[i + 1] != null)
                    team = args[i + 1];
                if (args[i] == "-h" && args[i + 1] != null)
                    machine = args[i + 1];
            }
            if (port == -1 || team == null || machine == null)
                throw new Exception("Error in command line arguments.");
            if (!connect())
                throw new Exception("Cannot connect to distant server.");
        }
    }
}
