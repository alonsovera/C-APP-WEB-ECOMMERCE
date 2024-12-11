using EcoPets.model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoPets.repositorio.Contrato
{
    public interface IVentaRepositorio : IGenericoRepositorio<Venta>
    {
        Task<Venta> Registrar(Venta modelo);
    }
}
