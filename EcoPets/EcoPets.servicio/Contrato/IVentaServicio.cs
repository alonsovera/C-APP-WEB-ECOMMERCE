using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcoPets.DTO;


namespace EcoPets.servicio.Contrato
{
    public interface IVentaServicio
    {
        Task<VentaDTO> Registrar(VentaDTO modelo);

    }
}
