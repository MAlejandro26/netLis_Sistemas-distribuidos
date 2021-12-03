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

namespace Aplicacion.Ocupaciones
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdOcupaciones { get; set; }
            public Guid IdEmpleado { get; set; }
            public Guid IdProfesiones { get; set; }
            public string Descripcion { get; set; }
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
                var dato = await _context.TblCatOcupaciones.FindAsync(request.IdOcupaciones);
                if (dato == null)
                {
                    throw new Exception("La ocupacion no existe");
                }

                dato.IdEmpleado = request.IdEmpleado;
                dato.IdProfesiones = request.IdProfesiones;
                dato.Descripcion = request.Descripcion ?? dato.Descripcion;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar la ocupacion");
            }
        }
    }
}
