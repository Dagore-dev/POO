using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace ConectarseEnRedLocal
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;
            
            Console.WriteLine("Elije rol:");
            Console.WriteLine(" Client: 1");
            Console.WriteLine(" Server: 2");

            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: 
                    Client(); 
                    break;
                case 2:
                    Server();
                    break;
                default: 
                    Console.WriteLine("¿Perdona?");
                    break;
            }

            Console.WriteLine("Fin del programa.");
        }
        private static void Server ()
        {
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
            server.Start();
            TcpClient client = server.AcceptTcpClient();
            StreamReader sr = new StreamReader(client.GetStream());

            Console.WriteLine(sr.ReadLine());

            sr.Close();
            client.Close();
            server.Stop();
        }
        private static void Client ()
        {
            TcpClient client = new TcpClient("127.0.0.1", 8080);
            StreamWriter sw = new StreamWriter(client.GetStream());

            sw.WriteLine("ALGO ESCRITO DESDE EL CLIENTE");

            sw.Close();
            client.Close();
        }
    }
}
