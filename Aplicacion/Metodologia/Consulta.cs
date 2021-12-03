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

namespace Aplicacion.Metodologia
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatMetodologia>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatMetodologia>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<List<TblCatMetodologia>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var metodologia = await _context.TblCatMetodologia.ToListAsync();
                return metodologia;
            }
        }
    }
}