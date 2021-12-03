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
    public class ConsultaId
    {

        public class IdentificacionUnica : IRequest<TblCatIdentificacion>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<IdentificacionUnica, TblCatIdentificacion>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatIdentificacion> Handle(IdentificacionUnica request, CancellationToken cancellationToken)
            {
                var identificacion = await _context.TblCatIdentificacions.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return identificacion;
            }
        }

    }
}