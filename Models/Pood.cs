namespace Buivol_web.Models
{
    public class Pood
    {
        public int Id { get; set; }
        public int ToodeId { get; set; }
        public Toode Toode { get; set; }

        public int KasutajaId { get; set; }
        public Kasutajad Kasutajad { get; set; }
    }
}
