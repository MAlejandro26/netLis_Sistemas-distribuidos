﻿using Dominio;
using Dominio.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Metodologia
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Descripcion { get; set; }
            public int Estado { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Descripcion).NotEmpty();
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
                var metodologia = new TblCatMetodologia
                {
                    IdMetodologia = Guid.NewGuid(),
                    Descripcion = request.Descripcion,
                    Estado = request.Estado

                };

                _context.TblCatMetodologia.Add(metodologia);
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar la metodologia");
            }
        }
    }
}
