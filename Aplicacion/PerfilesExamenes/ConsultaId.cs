using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.PerfilExamen
{
    public class ConsultaId
    {

        public class PerfilExamenUnica : IRequest<TblCatPerfilesExamenes>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<PerfilExamenUnica, TblCatPerfilesExamenes>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatPerfilesExamenes> Handle(PerfilExamenUnica request, CancellationToken cancellationToken)
            {
                var ocupacion = await _context.TblCatPerfilesExamenes.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return ocupacion;
            }
        }

    }
}
