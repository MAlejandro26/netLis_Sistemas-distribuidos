using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.UnidadMedidas
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string UnidadMedida { get; set; }
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
                var model = new TblCatUnidadMedida
                {
                    IdUnidadMedidas = Guid.NewGuid(),
                    UnidadMedida = request.UnidadMedida,
                    Estado = 1

                };

                _context.TblCatUnidadMedidas.Add(model);
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar la unidad medidad");
            }
        }
    }
}
