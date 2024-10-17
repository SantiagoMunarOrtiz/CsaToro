namespace MVCCRUD.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public int MarcaId { get; set; }
        public string? Modelo { get; set; }  // Permitir nulos
        public decimal Precio { get; set; }

        public Marca? Marca { get; set; }  // Permitir nulos
    }
}
