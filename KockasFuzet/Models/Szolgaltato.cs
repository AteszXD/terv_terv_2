namespace KockasFuzet.Models
{
    internal class Szolgaltato
    {
        private string rovidNev;
        private string nev;
        private string ugyfelszolgalat;

        public Szolgaltato(string rovidNev, string nev, string ugyfelszolgalat)
        {
            this.RovidNev = rovidNev;
            this.Nev = nev;
            this.Ugyfelszolgalat = ugyfelszolgalat;
        }
        public Szolgaltato()
        {

        }

        public string RovidNev { get { return rovidNev; } set { rovidNev = value; } }
        public string Nev { get { return nev; } set { nev = value; } }
        public string Ugyfelszolgalat { get { return ugyfelszolgalat; } set { ugyfelszolgalat = value; } }

        public override string ToString()
        {
            return $"Rövid név: {RovidNev}, Név: {Nev}, Ügyfélszolgálat: {Ugyfelszolgalat}";
        }
    }
}
