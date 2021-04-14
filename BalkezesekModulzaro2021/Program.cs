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

            //2. feladat: kik azok a versenyzők, akik 1980-ban léptek először pályára?
            List<string> jatekosok1980Eloszor = new List<string>();
            foreach (Balkezes jatekos in balkezesekListaja)
            {
                if (jatekos.GetElsoEvszamEv() == 1980)
                {
                    jatekosok1980Eloszor.Add(jatekos.GetNev());
                }
            }

            //3. feladat: kérjünk be egy nevet, ha a 2.feladat listájában van, akkor írjuk ki a magasságát cm-ben (1 tizedesjegyre), egyébként "hibás adat"-ot írjunk ki!
            Console.Write($"Kérlek írj be egy nevet: ");
            string bekertNev = Console.ReadLine();
            bool benneVan = false;
            foreach (string nev in jatekosok1980Eloszor)
            {
                if (nev == bekertNev)
                {
                    benneVan = true;
                }
            }
            int jatekosIndex = 0;
            for (int i = 0; i < N; i++)
            {
                if (balkezesekListaja[i].GetNev() == bekertNev)
                {
                    jatekosIndex = i;
                }
            }
            if (benneVan)
            {
                Console.WriteLine($"A játékos magassága: {balkezesekListaja[jatekosIndex].GetMagassag()*2.54:N1} cm");
            }
            else
            {
                Console.WriteLine("Hibás adat!");
            }
            
            //4.feladat: 


            Console.ReadLine();
        }
    }
}
