using Dominio;
using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.IndicacionExaPacientes
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatIndicacionExaPaciente>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatIndicacionExaPaciente>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<List<TblCatIndicacionExaPaciente>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var indicacion = await _context.TblCatIndicacionExaPacientes.ToListAsync();
                return indicacion;
            }
        }
    }
}