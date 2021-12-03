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

namespace Aplicacion.AreasServs
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Descripcion { get; set; }
            public string DescripcionCorta { get; set; }
        }
        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.DescripcionCorta).NotEmpty();
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
                var model = new TblCatAreasServ
                {
                    IdAreaServ = Guid.NewGuid(),
                    Descripcion = request.Descripcion,
                    DescripcionCorta = request.DescripcionCorta,
                    Estado = 1

                };

                _context.TblCatAreasServs.Add(model);
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar el Area Servs");
            }
        }
    }
}
