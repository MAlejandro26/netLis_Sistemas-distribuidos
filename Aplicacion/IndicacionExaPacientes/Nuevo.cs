using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.IndicacionExaPacientes
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public Guid IdExamen { get; set; }
            public string Indicacion { get; set; }
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
                var indicacion = new TblCatIndicacionExaPaciente
                {
                    IdIndicacionExaPaciente = Guid.NewGuid(),
                    IdExamen = request.IdExamen,
                    Indicacion = request.Indicacion

                };

                _context.TblCatIndicacionExaPacientes.Add(indicacion);
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar la indicacion");
            }
        }
    }
}