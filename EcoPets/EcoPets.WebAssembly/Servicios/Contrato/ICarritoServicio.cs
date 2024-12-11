using EcoPets.DTO;

namespace EcoPets.WebAssembly.Servicios.Contrato
{
    public interface ICarritoServicio
    {
        event Action MostrarItems;

        int CantidadProductos();
        Task AgregarCarrito(CarritoDTO modelo);
        Task EliminarCarrito(Guid idProducto);
        Task<List<CarritoDTO>> DevolverCarrito();
        Task LimpiarCarrito();
    }
}
