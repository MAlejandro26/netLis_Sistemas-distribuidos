using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.EstadoCivils
{
    public class ConsultaId
    {

        public class EstadoCivilUnico : IRequest<TblCatEstadoCivil>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<EstadoCivilUnico, TblCatEstadoCivil>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatEstadoCivil> Handle(EstadoCivilUnico request, CancellationToken cancellationToken)
            {
                var dato = await _context.TblCatEstadoCivils.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return dato;
            }
        }

    }
}
