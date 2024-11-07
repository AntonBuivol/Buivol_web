namespace Buivol_web.Models
{
    public class Kasutajad
    {
        public int Id { get; set; }
        public string Kasutajanimi { get; set; }
        public string Parool { get; set; }
        public string Nimi { get; set; }
        public string Perenimi { get; set; }

        public Kasutajad(int id, string kasutajanimi, string parool, string nimi, string perenimi)
        {
            Id = id;
            Kasutajanimi = kasutajanimi;
            Parool = parool;
            Nimi = nimi;
            Perenimi = perenimi;
        }
    }
}
