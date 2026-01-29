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

        public string RovidNev { get => rovidNev; set => rovidNev = value; }
        public string Nev { get => nev; set => nev = value; }
        public string Ugyfelszolgalat { get => ugyfelszolgalat; set => ugyfelszolgalat = value; }
    }
}
