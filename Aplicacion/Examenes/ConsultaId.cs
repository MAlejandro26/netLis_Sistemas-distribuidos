using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Examenes
{
    public class ConsultaId
    {

        public class ExamenUnica : IRequest<TblExamenes>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<ExamenUnica, TblExamenes>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblExamenes> Handle(ExamenUnica request, CancellationToken cancellationToken)
            {
                var examenes = await _context.TblExamenes.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return examenes;
            }
        }

    }
}
