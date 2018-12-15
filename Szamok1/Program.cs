using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szamok1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> Szamok = new List<int>();
            StreamReader file = new StreamReader("szamokfejlec.txt");
            string szam;
            szam = file.ReadLine();
            szam = file.ReadLine();

            while ((szam = file.ReadLine()) != null)
            {
                Szamok.Add(int.Parse(szam));
            }

            Console.WriteLine((from sz in Szamok.Select((item, index) => new { it = item, ind = index })
             .Take(Szamok.Count() - 1)
                               where Szamok[sz.ind] == Szamok[sz.ind + 1]
                               select sz.it)
             .ToList()
             .Count() > 0 ? "van" : "nincs");

            Console.WriteLine(Szamok.IndexOf(Szamok.Min()));


            Console.WriteLine((from sz in Szamok.Select((item, index) => new { it = item, ind = index })
                     .Take(Szamok.Count() - 1)
                               where sz.ind != 0 && Szamok[sz.ind] < Szamok[sz.ind - 1] &&
       Szamok[sz.ind] < Szamok[sz.ind + 1]
                               select sz.it)
                     .ToList().Count());

            Console.WriteLine();


            (from sz in Szamok.Select((item, index) => new { it = item, ind = index})
                     .Take(Szamok.Count() - 1)
             where Math.Abs(Szamok[sz.ind]) == Math.Abs(Szamok[sz.ind + 1])
             select sz.it + " " + Szamok[sz.ind +1])
                     .ToList()
                     .ForEach(x => Console.WriteLine(x));


            Console.ReadKey();
        }
    }
}
