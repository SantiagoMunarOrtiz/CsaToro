namespace MVCCRUD.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public int VehiculoId { get; set; }
        public string CedulaVendedor { get; set; } = string.Empty;  // Inicialización predeterminada
        public DateTime FechaVenta { get; set; }

        public Vehiculo Vehiculo { get; set; } = new Vehiculo();  // Inicialización predeterminada
        public Vendedor Vendedor { get; set; } = new Vendedor();  // Inicialización predeterminada
    }
}
