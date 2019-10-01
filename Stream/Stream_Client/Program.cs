using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace Stream_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 5000);
            StreamReader reader = new StreamReader(client.GetStream(), Encoding.UTF8);
            StreamWriter writer = new StreamWriter(client.GetStream(), Encoding.UTF8);

            string msg = reader.ReadLine();
            Console.WriteLine(msg);
            bool end = false;
            while (!end)
            {
                string cmd = Console.ReadLine();
                writer.WriteLine(cmd);
                writer.Flush();
                string answer = reader.ReadLine();
                Console.WriteLine(answer);

                if (answer == "OK*")
                {
                    while (answer != "OK!")
                    {
                        answer = reader.ReadLine();
                        Console.WriteLine(answer);
                    }
                }
                if (answer == "BYE") end = true;
            }
                
        }
    }
}
