using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoResultados
{
    public class ConsultaId
    {

        public class TipoResultadoUnico : IRequest<TblCatTipoResultado>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<TipoResultadoUnico, TblCatTipoResultado>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatTipoResultado> Handle(TipoResultadoUnico request, CancellationToken cancellationToken)
            {
                var tipo = await _context.TblCatTipoResultados.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return tipo;
            }
        }

    }
}
