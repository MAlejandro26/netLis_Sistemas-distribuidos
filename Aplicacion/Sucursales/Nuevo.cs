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
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
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
            public Manejador (netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var sucursal = new TblCatSucursales
                {
                    IdSucursal = Guid.NewGuid(),
                    IdHospital = request.IdHospital,
                    IdDepartamento = request.IdDepartamento,
                    IdPais = request.IdPais,
                    Descripcion = request.Descripcion,
                    Direccion = request.Direccion,
                    Telefono = request.Telefono,
                    UrlLogo = request.UrlLogo,
                };

                _context.TblCatSucursales.Add(sucursal);
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar la sucursal");
            }
        }

        
    }
}
