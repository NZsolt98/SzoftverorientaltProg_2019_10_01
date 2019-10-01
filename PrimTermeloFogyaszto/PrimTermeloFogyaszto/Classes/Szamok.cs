using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrimTermeloFogyaszto
{
    class Szamok
    {
        public static List<int> list = new List<int>();
        public static int termoDB = 0;

        public static void Insert(int szam)
        {
            lock (list)
            {
                list.Add(szam);
            }
        }

        public static void TermeloCsokkent()
        {
            lock (typeof(Szamok))
            {
                termoDB--;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Egy termelő leállt!");
                Console.ResetColor();

                if (termoDB == 0)
                {
                    lock (list)
                    {
                        Monitor.PulseAll(list);
                    }
                }
            }
        }
    }
}
