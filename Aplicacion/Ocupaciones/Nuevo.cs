using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Ocupaciones
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public Guid IdEmpleado { get; set; }
            public Guid IdProfesiones { get; set; }
            public string Descripcion { get; set; }
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
                var ocupacion = new TblCatOcupaciones
                {
                    IdOcupaciones = Guid.NewGuid(),
                    IdProfesiones = request.IdProfesiones,
                    Descripcion = request.Descripcion

                };

                _context.TblCatOcupaciones.Add(ocupacion);
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar la ocupacion");
            }
        }
    }
}
