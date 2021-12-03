using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.ValoresNormales
{
    public class ConsultaId
    {

        public class ValoresUnica : IRequest<TblCatValoresNormales>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<ValoresUnica, TblCatValoresNormales>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatValoresNormales> Handle(ValoresUnica request, CancellationToken cancellationToken)
            {
                var valores = await _context.TblCatValoresNormales.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return valores;
            }
        }

    }
}
