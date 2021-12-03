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

namespace Aplicacion.PerfilExamen
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public Guid IdExamen { get; set; }
            public Guid IdPerfiles { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.IdExamen).NotEmpty();
                RuleFor(x => x.IdPerfiles).NotEmpty();
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
                var perfilesExamenes = new TblCatPerfilesExamenes
                {
                    IdPerfilesExamenes = Guid.NewGuid(),
                    IdExamen = request.IdExamen,
                    IdPerfiles = request.IdPerfiles

                };

                _context.TblCatPerfilesExamenes.Add(perfilesExamenes);
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar el perfil del examen");
            }
        }
    }
}
