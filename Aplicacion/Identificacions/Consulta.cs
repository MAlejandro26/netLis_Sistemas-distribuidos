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

namespace Aplicacion.Identificacions
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatIdentificacion>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatIdentificacion>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<List<TblCatIdentificacion>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var identificacion = await _context.TblCatIdentificacions.Where(x => x.Estado != 3).ToListAsync();
                return identificacion;
            }
        }
    }
}

