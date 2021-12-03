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

namespace Aplicacion.ValoresNormales
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public Guid IdExamen { get; set; }
            public Guid IdSexo { get; set; }
            public double RangoAlto { get; set; }
            public double RangoBajo { get; set; }
            public int Estado { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.IdExamen).NotEmpty();
                RuleFor(x => x.IdSexo).NotEmpty();
                RuleFor(x => x.RangoAlto).NotEmpty();
                RuleFor(x => x.RangoBajo).NotEmpty();
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
                var valores = new TblCatValoresNormales
                {
                    IdValoresNormales = Guid.NewGuid(),
                    IdExamen = request.IdExamen,
                    IdSexo = request.IdSexo,
                    RangoAlto = request.RangoAlto,
                    RangoBajo = request.RangoBajo,
                    Estado = request.Estado

                };

                _context.TblCatValoresNormales.Add(valores);
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar el rango de valor");
            }
        }
    }
}
