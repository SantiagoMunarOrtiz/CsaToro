namespace MVCCRUD.Models
{
    public class Marca
    {
        public int Id { get; set; }
        public string NombreMarca { get; set; } = string.Empty;  

        public ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();  
    }
}
