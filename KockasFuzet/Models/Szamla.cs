using System;

namespace KockasFuzet.Models
{
    internal class Szamla
    {
        private int id;
        private string szolgaltatasAzon;
        private string szolgaltatasRovid;
        private DateTime tol;
        private DateTime ig;
        private int osszeg;
        private DateTime hatarido;
        private DateTime befizetve;
        private string megjegyzes;

        public Szamla(int id, string szolgaltatasAzon, string szolgaltatasRovid, DateTime tol, DateTime ig, int osszeg, DateTime hatarido, DateTime befizetve, string megjegyzes)
        {
            this.Id = id;
            this.SzolgaltatasAzon = szolgaltatasAzon;
            this.SzolgaltatasRovid = szolgaltatasRovid;
            this.Tol = tol;
            this.Ig = ig;
            this.Osszeg = osszeg;
            this.Hatarido = hatarido;
            this.Befizetve = befizetve;
            this.Megjegyzes = megjegyzes;
        }

        public Szamla() 
        { 
            
        }

        public int Id { get { return id; } set { id = value; } }
        public string SzolgaltatasAzon { get { return szolgaltatasAzon; } set { szolgaltatasAzon = value; } }
        public string SzolgaltatasRovid { get { return szolgaltatasRovid; } set { szolgaltatasRovid = value; } }
        public DateTime Tol { get { return tol; } set { tol = value; } }
        public DateTime Ig { get { return ig; } set { ig = value; } }
        public int Osszeg { get { return osszeg; } set { osszeg = value; } }
        public DateTime Hatarido { get { return hatarido; } set { hatarido = value; } }
        public DateTime Befizetve { get { return befizetve; } set { befizetve = value; } }
        public string Megjegyzes { get { return megjegyzes; } set { megjegyzes = value; } }

        public override string ToString()
        {
            return $"Id: {Id}, Azonosító {SzolgaltatasAzon}, Rövid név: {SzolgaltatasRovid}, Tól: {Tol}, Ig: {Ig}, Összeg: {Osszeg}, Határidő: {Hatarido}, Befizetve: {Befizetve}, Megjegyzés: {Megjegyzes}";
        }
    }
}
