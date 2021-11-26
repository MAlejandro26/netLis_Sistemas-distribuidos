using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.CategoriaExamenes
{
    public class ConsultaId
    {

        public class CatExaUnico : IRequest<TblCatCategoriaExamenes>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<CatExaUnico, TblCatCategoriaExamenes>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatCategoriaExamenes> Handle(CatExaUnico request, CancellationToken cancellationToken)
            {
                var dato = await _context.TblCatCategoriaExamenes.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return dato;
            }
        }

    }
}
