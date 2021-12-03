using Dominio;
using Dominio.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.AreaServLabEmpleados
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public Guid IdAreaLabServicio { get; set; }
            public Guid IdEmpleado { get; set; }
            public Guid IdSucursal { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.IdAreaLabServicio).NotEmpty();
                RuleFor(x => x.IdEmpleado).NotEmpty();
                RuleFor(x => x.IdSucursal).NotEmpty();
            }
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
                var areaservemmpleado = new TblAreaServLabEmpleado
                {
                    IdAreaServLabEmpleados = Guid.NewGuid(),
                    IdAreaLabServicio = request.IdAreaLabServicio,
                    IdSucursal = request.IdSucursal,

                };

                _context.TblAreaServLabEmpleados.Add(areaservemmpleado);
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar el registro");
            }
        }
    }

   
}
