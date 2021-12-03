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

namespace Aplicacion.Departamentos
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public Guid IdPais { get; set; }
            public string Descripcion { get; set; }

        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.IdPais).NotEmpty();
                RuleFor(x => x.Descripcion).NotEmpty();
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
                var dpt = new TblCatDepartamento
                {
                    IdDepartamento = Guid.NewGuid(),
                    IdPais = request.IdPais,
                    Descripcion = request.Descripcion,
                    Estado = 1

                };

                _context.TblCatDepartamentos.Add(dpt);
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar el departamento");
            }
        }
    }
}

