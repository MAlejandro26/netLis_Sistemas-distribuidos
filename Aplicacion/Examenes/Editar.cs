using Dominio;
using Dominio.Model;
using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Examenes
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdExamen { get; set; }
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

        //public class EjecutaValidacion : AbstractValidator<Ejecuta>
        //{
        //    public EjecutaValidacion()
        //    {
        //        RuleFor(x => x.Titulo).NotEmpty();
        //        RuleFor(x => x.Descripcion).NotEmpty();
        //        RuleFor(x => x.FechaPublicacion).NotEmpty();
        //    }
        //}

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly netLisContext _context;

            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var dato = await _context.TblExamenes.FindAsync(request.IdExamen);
                if (dato == null)
                {
                    throw new Exception("El examen no existe");
                }


                dato.IdAreaLabServicio = request.IdAreaLabServicio;
                dato.IdCategoriaExamenes= request.IdCategoriaExamenes;
                dato.IdTipoMuestra = request.IdTipoMuestra;
                dato.IdUnidadMedidas = request.IdUnidadMedidas;
                dato.IdTipoResultado = request.IdTipoResultado;
                dato.Descripcion = request.Descripcion ?? dato.Descripcion;
                dato.DescripcionCorta = request.DescripcionCorta ?? dato.DescripcionCorta;
                dato.Confidencial = request.Confidencial ?? dato.Confidencial;
                dato.Estado = request.Estado;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el examen");
            }
        }
    }
}
