namespace MVCCRUD.Models
{
    public class Vendedor
    {
        public string Cedula { get; set; } = string.Empty; 
        public string Nombre { get; set; } = string.Empty;  
        public string Telefono { get; set; } = string.Empty; 

        public ICollection<Venta> Ventas { get; set; } = new List<Venta>();  
    }
}
