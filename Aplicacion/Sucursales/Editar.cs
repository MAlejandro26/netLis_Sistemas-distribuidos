using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Aplicacion.Sucursales
{
    public class Editar
    {
        public class Ejecuta : IRequest{
            public Guid IdSucursal { get; set; }
            public Guid IdHospital { get; set; }
            public Guid IdDepartamento { get; set; }
            public Guid IdPais { get; set; }
            public String Descripcion { get; set; }
            public String Direccion { get; set; }
            public String Telefono { get; set; }
            public String UrlLogo { get; set; }
        }
       
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly netLisContext _context;

            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var dato = await _context.TblCatSucursales.FindAsync(request.IdSucursal);
                if (dato == null)
                {
                    throw new Exception("La sucursal no existe");
                }

                dato.IdHospital = request.IdHospital;
                dato.IdDepartamento = request.IdDepartamento;
                dato.IdPais = request.IdPais;
                dato.Descripcion = request.Descripcion ?? dato.Descripcion;
                dato.Direccion = request.Direccion ?? dato.Direccion;
                dato.Telefono = request.Telefono ?? dato.Telefono;
                dato.UrlLogo = request.UrlLogo ?? dato.UrlLogo;
                dato.Estado = 2;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar sucursal");
            }
        }
    }
}
