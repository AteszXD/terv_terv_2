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

        public int Id { get => id; set => id = value; }
        public string SzolgaltatasAzon { get => szolgaltatasAzon; set => szolgaltatasAzon = value; }
        public string SzolgaltatasRovid { get => szolgaltatasRovid; set => szolgaltatasRovid = value; }
        public DateTime Tol { get => tol; set => tol = value; }
        public DateTime Ig { get => ig; set => ig = value; }
        public int Osszeg { get => osszeg; set => osszeg = value; }
        public DateTime Hatarido { get => hatarido; set => hatarido = value; }
        public DateTime Befizetve { get => befizetve; set => befizetve = value; }
        public string Megjegyzes { get => megjegyzes; set => megjegyzes = value; }
    }
}
