using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.IndicacionExaPacientes
{
    public class ConsultaId
    {

        public class IndicacionUnica : IRequest<TblCatIndicacionExaPaciente>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<IndicacionUnica, TblCatIndicacionExaPaciente>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatIndicacionExaPaciente> Handle(IndicacionUnica request, CancellationToken cancellationToken)
            {
                var identificacion = await _context.TblCatIndicacionExaPacientes.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return identificacion;
            }
        }

    }
}
