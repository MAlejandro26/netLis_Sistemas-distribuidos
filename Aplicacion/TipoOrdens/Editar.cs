using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Aplicacion.TipoOrdens
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdTipoOrden { get; set; }
            public string Descripcion { get; set; }
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
                var dato = await _context.TblCatTipoOrdens.FindAsync(request.IdTipoOrden);
                if (dato == null)
                {
                    throw new Exception("El tipo de orden no existe");

                }

                dato.Descripcion = request.Descripcion ?? dato.Descripcion;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar Tipo de orden");
            }
        }

    }
}
