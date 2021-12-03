﻿using Dominio;
using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoServicios
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatTipoServicio>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatTipoServicio>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<List<TblCatTipoServicio>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var list = await _context.TblCatTipoServicios.ToListAsync();
                return list;
            }
        }
    }
}
