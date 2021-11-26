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
    public class ConsultaId
    {

        public class UnidadMedidadUnico : IRequest<TblCatUnidadMedida>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<UnidadMedidadUnico, TblCatUnidadMedida>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatUnidadMedida> Handle(UnidadMedidadUnico request, CancellationToken cancellationToken)
            {
                var dato = await _context.TblCatUnidadMedidas.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return dato;
            }
        }

    }
}
