using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Religion
{
    public class ConsultaId
    {

        public class ReligionUnica : IRequest<TblCatReligion>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<ReligionUnica, TblCatReligion>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatReligion> Handle(ReligionUnica request, CancellationToken cancellationToken)
            {
                var dato = await _context.TblCatReligion.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return dato;
            }
        }

    }
}