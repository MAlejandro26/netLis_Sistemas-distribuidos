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

namespace Aplicacion.Identificacions
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdIdentificacion { get; set; }
            public Guid IdNacionalidad { get; set; }
            public string Descripcion { get; set; }
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
                var dato = await _context.TblCatIdentificacions.FindAsync(request.IdIdentificacion);
                if (dato == null)
                {
                    throw new Exception("La identificacion no existe");
                }

                dato.IdNacionalidad = request.IdNacionalidad;
                dato.Descripcion = request.Descripcion ?? dato.Descripcion;
                dato.Estado = request.Estado;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar la identificacion");
            }
        }
    }
}
