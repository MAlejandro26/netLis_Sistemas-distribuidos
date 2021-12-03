using Aplicacion.ManejadorError;
using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Aplicacion.Medicos
{
    public class Eliminar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdMedico { get; set; }
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
                var dato = await _context.TblMedicos.FindAsync(request.IdMedico);
                if (dato == null)
                {
                    //throw new Exception("El curso no existe");
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El medico no existe" });
                }
                dato.FechaEliminacion = DateTime.Today;
                dato.Estado = 3;
                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al eliminar el medico");
            }
        }
    }
}
