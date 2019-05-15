using SIS.WebServer.Routing.Contracts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SIS.WebServer
{
    public class Server
    {
        private const string LocalhostIpAddress = "127.0.0.1";

        private readonly int port;

        private readonly TcpListener tcpListener;

        private readonly IServerRoutingTable serverRoutingTable;

        private bool isRunning;

        public Server(int port, IServerRoutingTable serverRoutingTable)
        {
            this.port = port;
            this.tcpListener = new TcpListener(IPAddress.Parse(LocalhostIpAddress), port);
            this.serverRoutingTable = serverRoutingTable;
        }

        public void Run()
        {
            this.tcpListener.Start();
            this.isRunning = true;

            Console.WriteLine($"Server started at http://{LocalhostIpAddress}:{this.port}");

            while (isRunning)
            {
                Console.WriteLine("Waiting for a client...");

                Socket client = tcpListener.AcceptSocket();

                this.Listen(client);
            }
        }

        public void Listen(Socket client)
        {
            var connectionHandler = new ConnectionHandler(client, this.serverRoutingTable);
            connectionHandler.ProcessRequest();
        }
    }
}
