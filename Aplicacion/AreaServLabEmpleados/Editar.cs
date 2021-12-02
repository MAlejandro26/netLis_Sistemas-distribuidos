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
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdAreaServLabEmpleados { get; set; }
            public Guid IdAreaLabServicio { get; set; }
            public Guid IdEmpleado { get; set; }
            public Guid IdSucursal { get; set; }
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
                var dato = await _context.TblAreaServLabEmpleados.FindAsync(request.IdAreaServLabEmpleados);
                if (dato == null)
                {
                    throw new Exception("El tipo de orden no existe");

                }

                dato.IdAreaLabServicio = request.IdAreaLabServicio;
                dato.IdEmpleado = request.IdEmpleado;
                dato.IdSucursal = request.IdSucursal;



                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar Area de servicio empleado");
            }
        }
    }
}
