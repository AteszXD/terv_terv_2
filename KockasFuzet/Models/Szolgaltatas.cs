namespace KockasFuzet.Models
{
    internal class Szolgaltatas
    {
        private int id;
        private string nev;

        public Szolgaltatas(int id, string nev)
        {
            this.Id = id;
            this.Nev = nev;
        }

        public Szolgaltatas()
        {

        }

        public int Id { get { return id; } set { id = value; } }
        public string Nev { get { return nev; } set { nev = value; } }

        public override string ToString()
        {
            return $"Id: {Id}, Név: {Nev}";
        }
    }
}
