using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Stream_Server
{
    class Program
    {
        static StreamWriter outp;
        static void Main(string[] args)
        {
            IPHostEntry addresses = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in addresses.AddressList)
            {
                Console.WriteLine(ip);
            }
            
            IPAddress ipm = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(ipm, 5000);
            listener.Start();

            TcpClient client = listener.AcceptTcpClient();
            StreamReader r = new StreamReader(client.GetStream(), Encoding.UTF8);

            outp = new StreamWriter(client.GetStream(), Encoding.UTF8);
            outp.WriteLine("Hello! I want to go home!");
            outp.Flush();
            bool end = false;
            while (end)
            {
                string cmd = r.ReadLine().ToUpper();
                string[] line = cmd.Split('|');
                switch (line[0])
                {
                    case "OSZTAS":
                        Osztas(line[1],line[2]);
                        break;
                    case "BYE": outp.WriteLine("BYE"); 
                        end = true; 
                        break;
                    default: outp.WriteLine("Error,Unknown command"); 
                        break;
                }
                outp.Flush();
            }
            Console.ReadKey();
        }

        static void Osztas(string p1, string p2)
        {
            if (int.Parse(p2) == 0)
            {
                outp.WriteLine("OK*");
                outp.WriteLine("Error, Divided by zero");
                outp.WriteLine("Error, I'm Batman!");
                outp.WriteLine("OK!");
                outp.Flush();
            }
            else
            {
                outp.WriteLine(int.Parse(p1) / int.Parse(p2));
            }
        }
    }
}
