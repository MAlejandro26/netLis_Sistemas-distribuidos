﻿using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Examenes
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public Guid IdAreaLabServicio { get; set; }
            public Guid IdCategoriaExamenes { get; set; }
            public Guid IdTipoMuestra { get; set; }
            public Guid IdUnidadMedidas { get; set; }
            public Guid IdTipoResultado { get; set; }
            public string Descripcion { get; set; }
            public string DescripcionCorta { get; set; }
            public string Confidencial { get; set; }
            public int Estado { get; set; }
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
                var examenes = new TblExamenes
                {
                    IdExamen = Guid.NewGuid(),
                    IdAreaLabServicio = request.IdAreaLabServicio,
                    IdCategoriaExamenes = request.IdCategoriaExamenes,
                    IdTipoMuestra = request.IdTipoMuestra,
                    IdUnidadMedidas = request.IdUnidadMedidas,
                    IdTipoResultado = request.IdTipoResultado,
                    Descripcion = request.Descripcion,
                    DescripcionCorta = request.DescripcionCorta,
                    Confidencial = request.Confidencial,
                    Estado = request.Estado

                };

                _context.TblExamenes.Add(examenes);
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar el examen");
            }
        }
    }
}
