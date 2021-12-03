using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Metodologia
{
    public class ConsultaId
    {

        public class MetodologiaUnica : IRequest<TblCatMetodologia>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<MetodologiaUnica, TblCatMetodologia>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatMetodologia> Handle(MetodologiaUnica request, CancellationToken cancellationToken)
            {
                var metodologia = await _context.TblCatMetodologia.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return metodologia;
            }
        }

    }
}

