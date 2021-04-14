using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkezesekModulzaro2021
{
    class Program
    {
        
        static void Main(string[] args)
        {

            //file beolvasás:
            string[] beolvasas = File.ReadAllLines("balkezesek.csv");
            List<Balkezes> balkezesekListaja = new List<Balkezes>();
            foreach (string adatsor in beolvasas.Skip(1))
            {
                Balkezes jatekos = new Balkezes(adatsor);
                balkezesekListaja.Add(jatekos);
            }

            //1. feladat: hány versenyzőről van adatunk?
            int N = balkezesekListaja.Count();
            Console.WriteLine($"Ennyi versenyzőről van adatunk: {N}");


            Console.ReadLine();
        }
    }
}
