using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.AreaServLabEmpleados
{
    public class ConsultaId
    {
        public class AreaServLabEmpleadoUnico : IRequest<TblAreaServLabEmpleado>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<AreaServLabEmpleadoUnico, TblAreaServLabEmpleado>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblAreaServLabEmpleado> Handle(AreaServLabEmpleadoUnico request, CancellationToken cancellationToken)
            {
                var areaServLabEmpleado = await _context.TblAreaServLabEmpleados.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return areaServLabEmpleado;
            }
        }
    }
}
