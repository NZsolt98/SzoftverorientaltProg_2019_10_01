using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrimTermeloFogyaszto.Classes
{
    class Termelo
    {
        public int also, felso;

        public void Termel()
        {
            lock (typeof(Szamok))
            {
                Szamok.termoDB++;
                Console.WriteLine("Elindult a termelés!");
            }

            for (int i = also; i < felso; i++)
            {
                if (PrimE(i))
                {
                    lock (Szamok.list)
                    {
                        while (Szamok.list.Count >= 50)
                        {
                            Monitor.Wait(Szamok.list);
                        }
                        Szamok.Insert(i);
                        Console.WriteLine("Beraktam!");
                        Monitor.PulseAll(Szamok.list);
                    }
                }
            }
            Szamok.TermeloCsokkent();
        }

        private bool PrimE(int szam)
        {
            for (int i = 2; i < Math.Sqrt(szam); i++)
            {
                if (szam % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public Termelo(int also,int felso)
        {
            this.also = also;
            this.felso = felso;
        }
    }
}
