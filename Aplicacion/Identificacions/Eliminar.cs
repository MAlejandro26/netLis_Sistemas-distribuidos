using Dominio.Model;
using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Identificacions
{
    public class Eliminar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdIdentificacion { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var dato = await _context.TblCatIdentificacions.FindAsync(request.IdIdentificacion);
                //if (curso == null)
                //{
                //    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { curso = "No se encontró el curso" });
                //}
                _context.Remove(dato);

                var resultado = await _context.SaveChangesAsync();

                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo eliminar la identificacion");
            }
        }
    }
}