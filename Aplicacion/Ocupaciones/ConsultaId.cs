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
    public class ConsultaId
    {

        public class OcupacionUnica : IRequest<TblCatOcupaciones>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<OcupacionUnica, TblCatOcupaciones>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatOcupaciones> Handle(OcupacionUnica request, CancellationToken cancellationToken)
            {
                var ocupacion = await _context.TblCatOcupaciones.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return ocupacion;
            }
        }

    }
}
