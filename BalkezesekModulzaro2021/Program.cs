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
        private static int bevittEvszam;
        
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
            //rájöttem hogy contains-t is használhattam volna és akkor lehet egyszerűbb

            //4.feladat: kérjünk be évszámot 1990 és 1990 között, akkor írjunk mi minden adatot azokról a versenyzőkről akik ebben az évben léptek pályára!
            int bekertEvszam = EvszamBekeresJatekosokKiiras(true);
            foreach (Balkezes jatekos in balkezesekListaja)
            {
                if (bekertEvszam == jatekos.GetElsoEvszamEv())
                {
                    Console.WriteLine(jatekos.GetAdatSor());
                }
            }

            //5.feladat: a legkorábbi év amikor pályára léptek?
            int minEvszamIndex = 0;
            for (int i = 0; i < N; i++)
            {
                if (balkezesekListaja[i].GetElsoEvszamEv() < balkezesekListaja[minEvszamIndex].GetElsoEvszamEv())
                {
                    minEvszamIndex = i;
                }
            }
            Console.WriteLine($"Legkorábban ebben az évben léptek pályára: {balkezesekListaja[minEvszamIndex].GetElsoEvszamEv()}");

            //6.feladat: minden játékos 2000 előtt lépett utoljára pályára?
            int j = 0;
            bool maxKetezerbenLepettPalyaraMindenki = false;
            while (j < N && balkezesekListaja[j].GetUtolsoEvszamEv() < 2000)
            {
                j++;
            }
            if (j >= N)
            {
                maxKetezerbenLepettPalyaraMindenki = true;
            }
            string kiiras = maxKetezerbenLepettPalyaraMindenki ? "igen" : "nem";
            Console.WriteLine($"Minden játékos 2000 előtt lépett utoljára pályára? {kiiras}");

            //7.feladat: hány játékos van "john"-nal a nevében? Sorold fel!
            int johnokSzama = 0;
            for (int i = 0; i < N; i++)
            {
                if (balkezesekListaja[i].GetNev().Contains("John") || balkezesekListaja[i].GetNev().Contains("john"))
                {
                    johnokSzama++;
                    Console.WriteLine(balkezesekListaja[i].GetNev());
                }
            }
            //Console.WriteLine($"Ennyi John nevű játékos van: {johnokSzama}");

            //8.feladat: statisztika a leggyakoribb keresztnevekről! Joe, John, Jim, Jack statisztika kiírása kernevek.txt-be és képernyőre is ugyanúgy!
            Dictionary<string, int> keresztNevStatisztika = new Dictionary<string, int>();
            foreach (Balkezes jatekos in balkezesekListaja)
            {
                string kulcs = jatekos.GetKeresztNev();
                if (kulcs.Contains("Joe") || kulcs.Contains("John") || kulcs.Contains("Jim") || kulcs.Contains("Jack"))
                {
                    if (keresztNevStatisztika.ContainsKey(kulcs))
                    {
                        keresztNevStatisztika[kulcs]++;
                    }
                    else
                    {
                        keresztNevStatisztika.Add(kulcs, 1);
                    }
                }
            }
            foreach (KeyValuePair<string, int> item in keresztNevStatisztika)
            {
                Console.WriteLine($"Név: {item.Key}, ennyi játékos van: {item.Value}");
            }

            Console.ReadLine();
        }

        private static int EvszamBekeresJatekosokKiiras(bool elsoBevitel)
        {
            if (elsoBevitel)
            {
                Console.Write("Kérek egy 1990 és 1999 közötti évszámot!: ");
            }
            else
            {
                Console.Write("Hibás adat, újra!: ");
            }
            bevittEvszam = int.Parse(Console.ReadLine());
            bool helyesBevitel = bevittEvszam >= 1990 && bevittEvszam <= 1999;
            if (!helyesBevitel)
            {
                EvszamBekeresJatekosokKiiras(helyesBevitel);
            }
            return bevittEvszam;
        }

    }
}
