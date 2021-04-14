using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkezesekModulzaro2021
{
    class Balkezes
    {
        private string eredetiSor;
        private string nev;
        private string keresztNev;
        private string vezetekNev;
        private int elsoEvszamEv;
        private int elsoEvszamHo;
        private int elsoEvszamNap;
        private int utolsoEvszamEv;
        private int utolsoEvszamHo;
        private int utolsoEvszamNap;
        private int suly;
        private int magassag;

        public Balkezes(string sor)
        {
            string[] s = sor.Split(';');
            eredetiSor = sor;
            this.nev = s[0];
            string[] osszesNev = s[0].Split(' ');
            this.keresztNev = osszesNev[0];
            this.vezetekNev = osszesNev[1];
            string[] sElso = s[1].Split('-');
            this.elsoEvszamEv = int.Parse(sElso[0]);
            this.elsoEvszamHo = int.Parse(sElso[1]);
            this.elsoEvszamNap = int.Parse(sElso[2]);
            string[] sUtolso = s[2].Split('-');
            this.utolsoEvszamEv = int.Parse(sUtolso[0]);
            this.utolsoEvszamHo = int.Parse(sUtolso[1]);
            this.utolsoEvszamNap = int.Parse(sUtolso[2]);
            this.suly = int.Parse(s[3]);
            this.magassag = int.Parse(s[4]);
        }

        //getterek
        public string GetAdatSor() { return eredetiSor; }
        public string GetNev() { return nev; }
        public string GetKeresztNev() { return keresztNev; }
        public string GetVezetekNev() { return vezetekNev; }
        public int GetElsoEvszamEv() { return elsoEvszamEv; }
        public int GetElsoEvszamHo() { return elsoEvszamHo; }
        public int GetElsoEvszamNap() { return elsoEvszamNap; }
        public int GetUtolsoEvszamEv() { return utolsoEvszamEv; }
        public int GetUtolsoEvszamHo() { return utolsoEvszamHo; }
        public int GetUtolsoEvszamNap() { return utolsoEvszamNap; }
        public int GetSuly() { return suly; }
        public int GetMagassag() { return magassag; }

    }
}
