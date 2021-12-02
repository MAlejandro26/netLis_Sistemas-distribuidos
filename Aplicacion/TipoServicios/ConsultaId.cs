using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoServicios
{
    public class ConsultaId
    {

        public class TipoServicioUnico : IRequest<TblCatTipoServicio>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<TipoServicioUnico, TblCatTipoServicio>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatTipoServicio> Handle(TipoServicioUnico request, CancellationToken cancellationToken)
            {
                var dato = await _context.TblCatTipoServicios.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return dato;
            }
        }

    }
}
