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

namespace Aplicacion.Pacientes
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblPaciente>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblPaciente>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<List<TblPaciente>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var list = await _context.TblPacientes.Where(x => x.Estado != 3).ToListAsync();
                return list;
            }
        }
    }
}
