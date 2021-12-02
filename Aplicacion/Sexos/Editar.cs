using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Sexos
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdSexo { get; set; }
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
                var dato = await _context.TblCatSexos.FindAsync(request.IdSexo);
                if (dato == null)
                {
                    throw new Exception("El sexo no existe D:");

                }

                dato.Descripcion = request.Descripcion ?? dato.Descripcion;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el sexo");
            }
        }
    }
}
