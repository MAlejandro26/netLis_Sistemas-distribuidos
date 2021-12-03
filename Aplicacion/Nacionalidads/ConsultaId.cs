using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Nacionalidad
{
    public class ConsultaId
    {

        public class NacionalidadUnica : IRequest<TblCatNacionalidad>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<NacionalidadUnica, TblCatNacionalidad>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatNacionalidad> Handle(NacionalidadUnica request, CancellationToken cancellationToken)
            {
                var nacionalidad = await _context.TblCatNacionalidads.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return nacionalidad;
            }
        }

    }
}

