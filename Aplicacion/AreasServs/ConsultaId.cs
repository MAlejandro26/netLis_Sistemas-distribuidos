using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.AreasServs
{
    public class ConsultaId
    {

        public class AreaServsUnico : IRequest<TblCatAreasServ>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<AreaServsUnico, TblCatAreasServ>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatAreasServ> Handle(AreaServsUnico request, CancellationToken cancellationToken)
            {
                var dato = await _context.TblCatAreasServs.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return dato;
            }
        }

    }
}
