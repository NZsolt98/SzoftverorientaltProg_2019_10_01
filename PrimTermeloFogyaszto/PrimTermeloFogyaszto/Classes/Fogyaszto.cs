using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PrimTermeloFogyaszto.Classes
{
    class Fogyaszto
    {
        public void Fogyaszt()
        {
            lock (Szamok.list)
            {
                while (Szamok.termoDB != 0 || Szamok.list.Count != 0)
                {
                    if (Szamok.list.Count == 0)
                    {
                        Console.WriteLine("Várok egy számra vagy termelőre.");
                        Monitor.Wait(Szamok.list);
                        Console.WriteLine("Már nem várok se számra se termelőre.");
                    }
                    else if(Szamok.list.Count!=0)
                    {
                        Szamok.list.RemoveAt(0);
                        Monitor.PulseAll(Szamok.list);
                        Console.WriteLine("Kivettem!");
                    }
                }
            }
        }
    }
}
