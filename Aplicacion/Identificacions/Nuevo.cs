using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Identificacions
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public Guid IdNacionalidad { get; set; }
            public string Descripcion { get; set; }
            public int Estado { get; set; }
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
                var identificacion = new TblCatIdentificacion
                {
                    IdIdentificacion = Guid.NewGuid(),
                    IdNacionalidad = request.IdNacionalidad,
                    Descripcion = request.Descripcion,
                    Estado = request.Estado

                };

                _context.TblCatIdentificacions.Add(identificacion);
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar la identificacion");
            }
        }
    }
}
