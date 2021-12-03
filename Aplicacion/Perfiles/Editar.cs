using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Perfiles
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid Id { get; set; }
            public string Descripcion { get; set; }
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
                var dato = await _context.TblCatPerfiles.FindAsync(request.Id);
                if(dato == null)
                {
                    throw new Exception("La categoría de perfil no existe");
                }

                dato.Descripcion = request.Descripcion ?? dato.Descripcion;
                dato.Estado = 2;

                var resultado = await _context.SaveChangesAsync();
                if(resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el perfil");
            }
        }

    }
}
