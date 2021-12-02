using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoMuestras
{
    public class Eliminar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdTipoMuestra { get; set; }

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
                var dato = await _context.TblCatTipoMuestras.FindAsync(request.IdTipoMuestra);
                if (dato == null)
                {
                    throw new Exception("El tipo de eliminar no existe");

                }

                dato.Estado = 0;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al eliminar Tipo de muestra");
            }
        }
    }
}
