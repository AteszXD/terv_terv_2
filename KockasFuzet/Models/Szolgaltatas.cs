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

        public int Id { get => id; set => id = value; }
        public string Nev { get => nev; set => nev = value; }
    }
}
