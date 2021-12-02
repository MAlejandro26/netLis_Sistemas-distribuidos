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

namespace Aplicacion.AreaServLabEmpleados
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblAreaServLabEmpleado>> { }
        public class Manejador : IRequestHandler<Ejecuta, List<TblAreaServLabEmpleado>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<List<TblAreaServLabEmpleado>> Handle(Ejecuta request, CancellationToken cancellationtoken)
            {
                var areaServLabEmpleados = await _context.TblAreaServLabEmpleados.ToListAsync();
                return areaServLabEmpleados;
            }
        }
    }
}
