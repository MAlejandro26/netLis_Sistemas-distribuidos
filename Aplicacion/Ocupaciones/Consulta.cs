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

namespace Aplicacion.Ocupaciones
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatOcupaciones>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatOcupaciones>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<List<TblCatOcupaciones>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var ocupacion = await _context.TblCatOcupaciones.ToListAsync();
                return ocupacion;
            }
        }
    }
}
