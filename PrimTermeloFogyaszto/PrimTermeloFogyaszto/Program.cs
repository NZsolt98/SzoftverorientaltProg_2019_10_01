using PrimTermeloFogyaszto.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrimTermeloFogyaszto
{
    class Program
    {
        static void Main(string[] args)
        {
            Termelo T1 = new Termelo(0,100);
            Termelo T2 = new Termelo(100, 200);
            
            Fogyaszto F1 = new Fogyaszto();
            Fogyaszto F2 = new Fogyaszto();

            Thread t1 = new Thread(T1.Termel);
            Thread t2 = new Thread(T2.Termel);
            Thread t3 = new Thread(F1.Fogyaszt);
            Thread t4 = new Thread(F2.Fogyaszt);

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();

            t3.Join();
            t4.Join();
            
            Console.WriteLine(Szamok.list.Count);
            Console.ReadKey();
        }
    }
}
