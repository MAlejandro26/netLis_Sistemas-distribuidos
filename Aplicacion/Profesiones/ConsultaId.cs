using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Profesiones
{
    public class ConsultaId
    {

        public class ProfesionUnica : IRequest<TblCatProfesiones>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<ProfesionUnica, TblCatProfesiones>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatProfesiones> Handle(ProfesionUnica request, CancellationToken cancellationToken)
            {
                var profesion = await _context.TblCatProfesiones.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return profesion;
            }
        }

    }
}
