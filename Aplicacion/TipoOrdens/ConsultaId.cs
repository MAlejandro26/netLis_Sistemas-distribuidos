using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoOrdens
{
    public class ConsultaId
    {
        public class TipoOrdenUnica : IRequest<TblCatTipoOrden>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<TipoOrdenUnica, TblCatTipoOrden>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatTipoOrden> Handle(TipoOrdenUnica request, CancellationToken cancellationToken)
            {
                var tipoorden = await _context.TblCatTipoOrdens.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return tipoorden;
            }
        }
    }
}
