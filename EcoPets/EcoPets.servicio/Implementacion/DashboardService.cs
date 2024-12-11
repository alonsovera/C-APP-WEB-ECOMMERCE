using EcoPets.servicio.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EcoPets.model.Models;
using EcoPets.DTO;
using EcoPets.repositorio.Contrato;
using EcoPets.servicio.Contrato;
using AutoMapper;


namespace EcoPets.servicio.Implementacion
{
    public class DashboardService : IDashboardService
    {
        private readonly IVentaRepositorio _ventaRepositorio;
        private readonly IGenericoRepositorio<Usuario> _usuarioRepositorio;
        private readonly IGenericoRepositorio<Producto> _productoRepositorio;

        public DashboardService(
            IVentaRepositorio ventaRepositorio,
            IGenericoRepositorio<Usuario> usuarioRepositorio,
            IGenericoRepositorio<Producto> productoRepositorio)
        {
            _ventaRepositorio = ventaRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _productoRepositorio = productoRepositorio;
        }

        private string Ingresos()
        {
            var consulta = _ventaRepositorio.Consultar();
            decimal?ingresos = consulta.Sum(x => x.Total);
            return Convert.ToString(ingresos);
        }

        private int Ventas()
        {
            var consulta = _ventaRepositorio.Consultar();
            int total = consulta.Count();
            return total;
        }

        private int Clientes()
        {
            var consulta = _usuarioRepositorio.Consultar(U=>U.Rol.ToLower()=="cliente");
            int total = consulta.Count();
            return total;
        }

        private int Productos()
        {
            var consulta = _productoRepositorio.Consultar();
            int total = consulta.Count();
            return total;
        }
        public DashboardDTO Resumen()
        {
            try
            {
                DashboardDTO dto = new DashboardDTO()
                {
                    TotalIngresos = Ingresos(),
                    TotalVentas = Ventas(),
                    TotalCliente = Clientes(),
                    TotalProductos = Productos(),
                };
                return dto;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}
