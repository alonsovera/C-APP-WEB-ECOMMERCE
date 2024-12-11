using EcoPets.DTO;

namespace EcoPets.WebAssembly.Servicios.Contrato
{
    public interface IVentaServicio
    {
        Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo);

    }
}
